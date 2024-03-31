using Microsoft.AspNetCore.Identity;

namespace parking_api.Models.EFModels;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneSecondary { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = false;
    public int? CreatedByUserId { get; set; }
    public string? Otp { get; set; }
    public DateTime? OtpExpireAt { get; set; }
    public ICollection<Car>? Cars { get; set; }
    public ICollection<Unit>? Units { get; set; }
    public ICollection<Condo>? Condos { get; set; }
    public ICollection<CamLog>? ResolvedLogs { get; set; }

}
