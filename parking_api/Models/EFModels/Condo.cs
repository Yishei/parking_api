namespace parking_api.Models.EFModels;

public class Condo
{
    public int Id { get; set; }
    public string? CondoAdminId { get; set; }
    public User? CondoAdmin { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Zip { get; set; } = null!;
    public string? TowingDriverId { get; set; }
    public int? DefaultMaxCarAllowed { get; set; }
    public ICollection<Lot>? Lots { get; set; }
    public ICollection<Unit>? Units { get; set; }
    public ICollection<CamLog>? CamLogs { get; set; }
    public ICollection<Polling>? Pollings { get; set; }
}
