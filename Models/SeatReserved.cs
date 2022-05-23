namespace WebApplication1.Models
{
    public class SeatReserved
    {
        public int Id { get; set; }
        public Seat? Seat { get; set; }
        public Reservation? Reservation { get; set; }
        public Show? Show { get; set; }
    }
}
