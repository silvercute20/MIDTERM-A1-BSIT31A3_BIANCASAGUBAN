namespace Library_Management.Models
{
    public class AuthorListViewModel
    {
        public Guid AuthorId { get; set; }
        public string? Name { get; set; } = default!;
        public string? ProfileImageUrl { get; set; } = default!;
        public int TotalBooks { get; set; } = 0;

        public string? Biography { get; set; } = default!;
        public DateTime? BirthDate { get; set; } = default!;
        public bool IsArchived { get; set; } = false;
    }
}

