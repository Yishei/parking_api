
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using parking_api.Data;
using parking_api.Models;
using parking_api.Models.EFModels;
using parking_api.Models.ViewModels;
using parking_api.Services;
using System.Threading.Tasks;

namespace parking_api.Controllers;

[Route("api/auth")]
[ApiController]
[AllowAnonymous]
[Route("[controller]")]

public class AccountsController : ControllerBase
{
    const string UserAgentClientHeader = "Sec-CH-UA";
    const string PlatformClientHeader = "Sec-CH-UA-Platform";
    const string MobileClientHeader = "Sec-CH-UA-Mobile";
    const string ModelClientHeader = "Sec-CH-UA-Model";

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _identityContext;
    private readonly IEmailService _emailService;

    public AccountsController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        AppDbContext identityContext,
        IEmailService emailService
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _identityContext = identityContext;
        _emailService = emailService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        User user = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            PhoneSecondary = model.PhoneSecondary,
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            UserName = model.Email

        };
        
        var result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, model.UserRole);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = Url.Action("ResetPassword", "Accounts", new { email = user.Email, token }, Request.Scheme);

            // Send the email with the password reset link (passwordResetLink) here...
            string emailSubject = "Password Reset";
            string emailMessage = $"Please reset your password by <a href='{passwordResetLink}'>clicking here</a>.";
            await _emailService.SendEmail(model.Email, model.FirstName, emailSubject, emailMessage);

            return Ok(new { message = "Registration successful, please check your email to set up your password." });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        User? user = new();
        
        user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            user = await _signInManager.UserManager.FindByNameAsync(model.Email);
        }

        if (user == null)
            return Ok(new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage = "User name or password is invalid." });

        bool isAuthSucceeded = false;
        string errorMessage = "";

        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

        if (result.Succeeded)
        {
            if (!user.IsActive)
            {
                return Ok(new AuthResponseDto() { IsAuthSuccessful = false, ErrorMessage = "User account inactive!" });

            }

            if (!user.EmailConfirmed)
            {
                return Ok(new AuthResponseDto() { IsAuthSuccessful = false, ErrorMessage = "Pending invite acceptance" });
            }

            UserLoginHistory loginInfo = new()
            {
                UserId = user.Id,
                LoginDate = DateTime.Now,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                UserAgent = Request.Headers.TryGetValue(UserAgentClientHeader, out var agent) ? agent.FirstOrDefault() : null,
                UserPlatform = Request.Headers.TryGetValue(PlatformClientHeader, out var platform) ? platform.FirstOrDefault().TrimStart('"').TrimEnd('"') : null,
                IsMobile = Request.Headers.TryGetValue(MobileClientHeader, out var isMobile) ? (isMobile.FirstOrDefault() == "?1" ? true : false) : null,
                DeviceModel = Request.Headers.TryGetValue(ModelClientHeader, out var vm) ? vm.FirstOrDefault() : null,
                ClientVersion = model.ClientVersion,
            };

            await _identityContext.LogUserLoginAsync(loginInfo);
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        // Invalidate the user's token here...
        return Ok();
    }

    private string GenerateToken(User user)
    {
        // Implement your token generation logic here...
        return "token";
    }

}
