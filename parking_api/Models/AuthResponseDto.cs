using parking_api.Models.EFModels;

namespace parking_api.Models;

public class AuthResponseDto
{
    public bool IsAuthSuccessful { get; set; }
    public User User { get; set; }
    public string ErrorMessage { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
    public string SessionId { get; set; }
    public bool PasswordChangeRequired { get; set; }
    public MetaData MetaData { get; set; }
}

public class MetaData
{
    public bool VersionUpdateRequired { get; set; }
}
