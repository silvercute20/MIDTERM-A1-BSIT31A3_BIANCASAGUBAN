namespace Library_Management.Models
{
    public class BookCopyViewModel
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; }
        public DateTime? PulloutDate { get; set; }
        public string PulloutReason { get; set; } = string.Empty;
    }
}