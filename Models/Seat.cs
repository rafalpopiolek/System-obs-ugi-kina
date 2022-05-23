namespace WebApplication1.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public bool isOccupied { get; set; } = false;
    }
}
