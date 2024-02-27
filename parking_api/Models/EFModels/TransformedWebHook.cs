namespace parking_api.Models.EFModels;

public class TransformedWebHook
{
    public string? DataSourceId { get; set; }
    public DateTime? CapturedOn { get; set; }
    public string? PlateNo { get; set; }
    public string? Color { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public string? Year { get; set; }
    public byte[]? VehiclePic { get; set; }
    public byte[]? PlatePic { get; set; }
    public string? PlateImgPath { get; set; }
    public string? CarImgPath { get; set; }
    public string? Direction { get; set; }
    public bool? Archived { get; set; }
}
