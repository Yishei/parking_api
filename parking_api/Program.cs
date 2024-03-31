using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using parking_api.Data;
using parking_api.Models.EFModels;
using parking_api.Models.SettingModels;
using parking_api.Services;
using MailKit.Net.Smtp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        string[] roles = ["SuperAdmin", "Admin", "Guest", "Driver", "resident"]; // Add your roles here
        foreach (var roleName in roles)
        {
            // If the role doesn't exist, create it
            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                IdentityRole role = new(roleName);
                var roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // database connection
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    // email settings
    services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
    services.AddTransient(sp =>
    {
        var emailSettings = sp.GetRequiredService<IOptions<EmailSettings>>().Value;
        var client = new SmtpClient();
        client.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
        client.Authenticate(emailSettings.Username, emailSettings.Password);
        return client;
    });

    // services
    services.AddScoped<IWebHookService, WebHookService>();
    services.AddScoped<IEmailService, EmailService>();

    services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();


    // Authentication
    services.AddAuthorizationBuilder()
        .AddPolicy("SuperAdmin", policy => policy.RequireRole("superadmin"))
        .AddPolicy("Admin", policy => policy.RequireRole("admin"))
        .AddPolicy("Resident", policy => policy.RequireRole("resident"))
        .AddPolicy("Driver", policy => policy.RequireRole("driver"))
        .AddPolicy("Guest", policy => policy.RequireRole("guest"));
    services.AddControllers();
}
