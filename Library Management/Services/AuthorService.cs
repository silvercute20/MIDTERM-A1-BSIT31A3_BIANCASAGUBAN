using Library_Management.Models;
using Library_Management_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public class AuthorService
{
    private readonly ICollection<Author> _authors = new List<Author>();

    private AuthorService()
    {
        SeedData();
    }

    private void SeedData()
    {
        var sample = new Author
        {
            Id = Guid.NewGuid(),
            Name = "George Orwell",
            Biography = "English novelist...",
            BirthDate = new DateTime(1903, 6, 25),
            ProfileImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/OrwellBurmaPassport.jpg/250px-OrwellBurmaPassport.jpg",
            Books = new List<Book>()
        };
        _authors.Add(sample);

        var author2 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "Harper Lee",
            Biography = "American novelist best known for To Kill a Mockingbird.",
            BirthDate = new DateTime(1926, 4, 28),
            ProfileImageUrl = "https://cdn.britannica.com/04/193204-050-4B1C2FE7/Harper-Lee-American.jpg",
            Books = new List<Book>()
        };
        _authors.Add(author2);

        var author3 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "Stephenie Meyer",
            Biography = "American novelist, best known for the Twilight series.",
            BirthDate = new DateTime(1973, 12, 24),
            ProfileImageUrl = "https://m.media-amazon.com/images/M/MV5BMTM3NTQ0NjA2Ml5BMl5BanBnXkFtZTcwMjA4MTUwNw@@._V1_.jpg",
            Books = new List<Book>()
        };
        _authors.Add(author3);
    }

    public IEnumerable<AuthorListViewModel> GetAuthors()
    {
        return _authors.Select(a => new AuthorListViewModel
        {
            AuthorId = a.Id,
            Name = a.Name,
            ProfileImageUrl = a.ProfileImageUrl,
            TotalBooks = a.Books?.Count ?? 0,
            Biography = a.Biography,
            BirthDate = a.BirthDate,
            IsArchived = a.IsArchived
        });
    }

    public AddAuthorViewModel? GetAuthorById(Guid id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return null;

        return new AddAuthorViewModel
        {
            Name = author.Name,
            Biography = author.Biography,
            BirthDate = author.BirthDate,
            ProfileImageUrl = author.ProfileImageUrl
        };
    }

    public void AddAuthor(AddAuthorViewModel vm)
    {
        var newAuthor = new Author
        {
            Id = Guid.NewGuid(),
            Name = vm.Name,
            Biography = vm.Biography,
            BirthDate = vm.BirthDate ?? DateTime.MinValue,
            ProfileImageUrl = vm.ProfileImageUrl,
            Books = new List<Book>()
        };
        _authors.Add(newAuthor);
    }

    public void UpdateAuthor(EditAuthorViewModel vm)
    {
        var author = _authors.FirstOrDefault(a => a.Id == vm.AuthorId);
        if (author == null) return;

        author.Name = vm.Name;
        author.Biography = vm.Biography;
        author.ProfileImageUrl = vm.ProfileImageUrl;
    }

    public void ToggleArchive(Guid id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return;

        author.IsArchived = !author.IsArchived;
    }

    public void DeleteAuthor(Guid id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return;

        _authors.Remove(author);
    }

    private static AuthorService? _instance;
    public static AuthorService Instance => _instance ??= new AuthorService();
}
