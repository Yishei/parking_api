namespace parking_api.Models.EFModels;

public class CamLog
{
    public int Id { get; set; }
    public string DataSourceId { get; set; } = null!;
    public int? CameraId { get; set; }
    public Camera? Camera { get; set; }
    public int? LotId { get; set; }
    public Lot? Lot { get; set; }
    public int? CondoId { get; set; }
    public Condo? Condo { get; set; }
    public string PlateNo { get; set; } = null!;
    public DateTime CapturedOn { get; set; } = DateTime.Now;
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Color { get; set; }
    public string? Year { get; set; }
    public string? Type { get; set; }
    public string Direction { get; set; } = null!;
    public string? PlateImgPath { get; set; }
    public string? CarImgPath { get; set; }
    public bool Archived { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public bool ResolvedStatus { get; set; } = false;
    public string? ResolvedDescription { get; set; }
    public DateTime? ResolvedTime { get; set; }
    public string? ResolvedById { get; set; }
    public User? ResolvedBy { get; set; }

}
