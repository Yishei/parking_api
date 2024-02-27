namespace parking_api.Models.EFModels
{
    public class PollInputSelection
    {
        public int Id { get; set; }
        public int InputId { get; set; } 
        public string Name { get; set; }
        public string Value { get; set; }
        public PollInput? PollInput { get; set; }
    }
}
