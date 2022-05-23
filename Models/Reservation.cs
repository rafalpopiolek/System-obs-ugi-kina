namespace WebApplication1.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Show? Show { get; set; }
        public int ShowId { get; set; }
        public Seat? Seat { get; set; }
        public int SeatId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public bool? Paid { get; set; } = false;
        public bool? active { get; set; } = true;
    }
}
