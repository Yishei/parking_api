using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using parking_api.Models.EFModels;

namespace parking_api.Data;

public class AppDbContext : IdentityDbContext<User, Role, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Condo> Condos { get; set; } = null!;
    public DbSet<Lot> Lots { get; set; } = null!;
    public DbSet<Camera> Cameras { get; set; } = null!;
    public DbSet<Unit> Units { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<CamLog> CamLogs { get; set; } = null!;

    // for polling

    public DbSet<Polling> Pollings { get; set; }
    public DbSet<PollInput> PollInputs { get; set; }
    public DbSet<PollInputSelection> PollInputSelections { get; set; }
    public DbSet<PollResults> PollResults { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Condo>(entity =>
        {
            entity
            .HasMany(c => c.Lots)
            .WithOne(l => l.Condo)
            .HasForeignKey(l => l.CondoId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasMany(c => c.Units)
            .WithOne(u => u.Condo)
            .HasForeignKey(u => u.CondoId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasOne(c => c.CondoAdmin)
            .WithMany(u => u!.Condos)
            .HasForeignKey(c => c.CondoAdminId)
            .OnDelete(DeleteBehavior.SetNull);

            entity
            .HasMany(c => c.CamLogs)
            .WithOne(cl => cl.Condo)
            .HasForeignKey(cl => cl.CondoId)
            .OnDelete(DeleteBehavior.NoAction);

            entity
            .HasMany(c => c.Pollings)
            .WithOne(p => p.Condo)
            .HasForeignKey(p => p.CondoId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity
            .HasOne(u => u.User)
            .WithMany(u => u!.Units)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.SetNull);

            entity
            .HasMany(u => u.Cars)
            .WithOne(c => c.Unit)
            .HasForeignKey(c => c.UnitId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasMany(u => u.PollResults)
            .WithOne(pr => pr.Unit)
            .HasForeignKey(pr => pr.UnitId)
            .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Lot>(entity =>
        {
            entity
            .HasMany(l => l.Cameras)
            .WithOne(c => c.Lot)
            .HasForeignKey(c => c.LotId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasMany(l => l.CamLogs)
            .WithOne(cl => cl.Lot)
            .HasForeignKey(cl => cl.LotId)
            .OnDelete(DeleteBehavior.NoAction);

        });

        modelBuilder.Entity<Camera>(entity =>
        {
            entity
            .HasMany(c => c.CamLogs)
            .WithOne(cl => cl.Camera)
            .HasForeignKey(cl => cl.CameraId)
            .OnDelete(DeleteBehavior.NoAction);

        });



        modelBuilder.Entity<CamLog>(entity =>
        {
            entity
                .HasOne(rl => rl.ResolvedBy)
                .WithMany(u => u.ResolvedLogs)
                .HasForeignKey(rl => rl.ResolvedById)
                .IsRequired(false) // Make the foreign key optional
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Polling>(entity =>
        {
            entity
                .HasMany(p => p.PollInputs)
                .WithOne(pi => pi.Polling)
                .HasForeignKey(pi => pi.PollId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PollInput>(entity =>
        {
            entity
                .HasMany(pi => pi.PollInputSelections)
                .WithOne(pis => pis.PollInput)
                .HasForeignKey(pis => pis.InputId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(pi => pi.PollResults)
                .WithOne(pr => pr.PollInput)
                .HasForeignKey(pr => pr.InputId)
                .OnDelete(DeleteBehavior.Cascade);
        });

    }
}