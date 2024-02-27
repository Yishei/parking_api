namespace parking_api.Models.EFModels
{
    public class PollInput
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string Type { get; set; } 
        public bool Required { get; set; }
        public ICollection<PollInputSelection>? PollInputSelections { get; set; }
        public Polling? Polling { get; set; }
        public ICollection<PollResults>? PollResults { get; set; }
    }
}
