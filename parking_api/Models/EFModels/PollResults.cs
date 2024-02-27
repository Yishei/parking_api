namespace parking_api.Models.EFModels
{
    public class PollResults
    {
        public int Id { get; set; }
        public int InputId { get; set; }
        public int UnitId { get; set; }
        public string Result { get; set; }
        public DateTime SubmitTime { get; set; }
        public PollInput PollInput { get; set; }
        public Unit Unit { get; set; }
    }
}
