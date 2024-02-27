namespace parking_api.Models.EFModels;

public class Unit
{
    public int Id { get; set; }
    public int CondoId { get; set; }
    public Condo? Condo { get; set; }
    public string? UnitNo { get; set; }
    public string? Address { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public int? MaxCarsAllowed { get; set; }

    public ICollection<Car>? Cars { get; set; }
    public ICollection<PollResults>? PollResults { get; set; }
}
