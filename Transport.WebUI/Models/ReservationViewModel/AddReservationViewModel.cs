namespace Transport.WebUI.Models.ReservationViewModel
{
    public class AddReservationViewModel
    {
        public string ReservationType { get; set; }
        public string ReservationDetails { get; set; }
        public DateTime ReservationDate { get; set; }

        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}
