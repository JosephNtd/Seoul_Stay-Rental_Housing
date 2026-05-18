namespace Web_UI.Models.ViewModels
{
    public class HomeStayCardVM
    {
        public long ItemId { get; set; }

        public string Title { get; set; } = "";

        public string ApproximateAddress { get; set; } = "";

        public string AreaName { get; set; } = "";

        public decimal PricePerNight { get; set; }

        public int Capacity { get; set; }

        public string ThumbnailUrl { get; set; } = "";

        public double Rating { get; set; }
    }
}
