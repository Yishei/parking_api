namespace parking_api.Models.EFModels;

public class Car
{
    public int Id { get; set; }
    public string PlateNo { get; set; } = null!;
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Color { get; set; }
    public string? Year { get; set; }
    public string? ImgPath { get; set; }
    public int UnitId { get; set; }
    public Unit? Unit { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
}
