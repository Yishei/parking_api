namespace parking_api.Models.EFModels;

public class Camera
{
    public int Id { get; set; }
    public int? LotId { get; set; }
    public Lot? Lot { get; set; }
    public string? Name { get; set; }
    public string DataSourceId { get; set; } = null!;

    public ICollection<CamLog>? CamLogs { get; set; }
}
