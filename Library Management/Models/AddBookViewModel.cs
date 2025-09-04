namespace Library_Management.Models
{
    public class AddBookViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime? PublishedDate { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorProfileImageUrl { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string Condition { get; set; } = "New";
        public string Source { get; set; } = "Purchase";
    }
}