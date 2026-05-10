using System;

namespace DTO
{
    public class DTO_RecentStay
    {
        public long BookingID { get; set; }

        public string Title { get; set; }

        public string ThumbnailPath { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public bool IsAddCard { get; set; }

        // HTML TEMPLATE

        public string StayDate =>
            $"{CheckInDate:MMM dd} - {CheckOutDate:dd, yyyy}";

        public string NormalCardDisplay =>
            IsAddCard ? "none" : "block";

        public string AddCardDisplay =>
            IsAddCard ? "block" : "flex";

        public string ThumbnailSafe =>
            string.IsNullOrEmpty(ThumbnailPath)
            ? "https://placehold.co/600x400"
            : ThumbnailPath;

        public string ShortTitle =>
            string.IsNullOrEmpty(Title)
            ? ""
            : (Title.Length > 28
                ? Title.Substring(0, 28) + "..."
                : Title);
    }
}