namespace Library_Management.Models
{
    public class EditAuthorViewModel
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}


