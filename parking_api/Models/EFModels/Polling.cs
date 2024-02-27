namespace parking_api.Models.EFModels
{
    public class Polling
    {
        public int Id { get; set; }
        public int CondoId { get; set; }
        public required string Title { get; set; }
        public string? Subject { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PollStart { get; set; }
        public DateTime PollEnd { get; set; }
        public Condo? Condo { get; set; }
        public ICollection<PollInput>? PollInputs { get; set; }
    }
}
