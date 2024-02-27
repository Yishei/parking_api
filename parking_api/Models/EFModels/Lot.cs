namespace parking_api.Models.EFModels;

public class Lot
{
    public int Id { get; set; }
    public int? CondoId { get; set; }
    public Condo? Condo { get; set; }
    public string? LotNo { get; set; }
    public string? Address { get; set; }
    public string? Name { get; set; }
    public bool IsLocked { get; set; } = false;
    public ICollection<Camera>? Cameras { get; set; }
    public ICollection<CamLog>? CamLogs { get; set; }
}
