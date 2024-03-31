namespace parking_api.Models.EFModels;

public class UserLoginHistory
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public string IPAddress { get; set; }

    public DateTime LoginDate { get; set; }

    public string UserPlatform { get; set; }

    public bool? IsMobile { get; set; }

    public string UserAgent { get; set; }

    public string DeviceModel { get; set; }

    public string ClientVersion { get; set; }
}
