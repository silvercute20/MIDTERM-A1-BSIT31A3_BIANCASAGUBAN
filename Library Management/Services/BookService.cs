using Library_Management.Models;
using Library_Management_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public class BookService
{
    private readonly ICollection<Book> _books = new List<Book>();
    private readonly ICollection<Author> _authors = new List<Author>();
    private readonly ICollection<BookCopy> _bookCopies = new List<BookCopy>();

    private BookService()
    {
        SeedData();
    }

    private void SeedData()
    {
        var author1 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "George Orwell",
            Biography = "English novelist, essayist, journalist and critic.",
            BirthDate = new DateTime(1903, 6, 25),
            ProfileImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/OrwellBurmaPassport.jpg/250px-OrwellBurmaPassport.jpg",
            Books = new List<Book>()
        };

        var book1 = new Book
        {
            Id = Guid.NewGuid(),
            Title = "1984",
            ISBN = "9780451524935",
            Description = "A dystopian social science fiction novel and cautionary tale.",
            Genre = "Fiction",
            PublishedDate = new DateTime(1949, 6, 2),
            IsArchived = false
        };

        var bookItem1 = new BookCopy
        {
            Id = Guid.NewGuid(),
            CoverImageUrl = "https://bookcoverarchive.com/wp-content/uploads/amazon/1984.jpg",
            Condition = "Good",
            Source = "Donation",
            AddedDate = DateTime.Now.AddMonths(-2),
            Book = book1
        };

        author1.Books.Add(book1);

        var author2 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "J.K. Rowling",
            Biography = "British author, best known for the Harry Potter series.",
            BirthDate = new DateTime(1965, 7, 31),
            ProfileImageUrl = "https://example.com/rowling.jpg",
            Books = new List<Book>()
        };

        var book2 = new Book
        {
            Id = Guid.NewGuid(),
            Title = "Harry Potter and the Philosopher's Stone",
            ISBN = "9780747532699",
            Description = "The first novel in the Harry Potter series.",
            Genre = "Fantasy",
            PublishedDate = new DateTime(1997, 6, 26),
            IsArchived = false
        };

        var bookItem2 = new BookCopy
        {
            Id = Guid.NewGuid(),
            CoverImageUrl = "https://contentful.harrypotter.com/usf1vwtuqyxm/2DCs73x6P8seNobQ9zBSbO/1a5dfd6ed5fc0ed9545370470fc3d74c/English_Harry_Potter_1_Epub_9781781100219.jpg",
            Condition = "Excellent",
            Source = "Purchase",
            AddedDate = DateTime.Now.AddMonths(-6),
            Book = book2
        };

        author2.Books.Add(book2);

        var extraBooks = new[]
        {
            new { Author = new Author { Id = Guid.NewGuid(), Name = "Harper Lee", Biography = "American novelist best known for To Kill a Mockingbird.", BirthDate = new DateTime(1926,4,28), ProfileImageUrl = "https://example.com/harper.jpg", Books = new List<Book>() }, Book = new Book { Id = Guid.NewGuid(), Title = "To Kill a Mockingbird", ISBN = "9780061120084", Description = "A novel about racial injustice in the Deep South.", Genre = "Classic", PublishedDate = new DateTime(1960,7,11), IsArchived = false }, Cover = "https://cdn.britannica.com/21/182021-050-666DB6B1/book-cover-To-Kill-a-Mockingbird-many-1961.jpg" },
            new { Author = new Author { Id = Guid.NewGuid(), Name = "J.R.R. Tolkien", Biography = "English writer, poet, philologist, and academic.", BirthDate = new DateTime(1892,1,3), ProfileImageUrl = "https://example.com/tolkien.jpg", Books = new List<Book>() }, Book = new Book { Id = Guid.NewGuid(), Title = "The Hobbit", ISBN = "9780547928227", Description = "A fantasy novel about Bilbo Baggins' adventure.", Genre = "Fantasy", PublishedDate = new DateTime(1937,9,21), IsArchived = false }, Cover = "https://m.media-amazon.com/images/I/81t2CVWEsUL.jpg" },
            new { Author = new Author { Id = Guid.NewGuid(), Name = "Mary Shelley", Biography = "English novelist best known for Frankenstein.", BirthDate = new DateTime(1797,8,30), ProfileImageUrl = "https://example.com/shelley.jpg", Books = new List<Book>() }, Book = new Book { Id = Guid.NewGuid(), Title = "Frankenstein", ISBN = "9780486282114", Description = "A gothic novel about Victor Frankenstein and his creation.", Genre = "Horror", PublishedDate = new DateTime(1818,1,1), IsArchived = false }, Cover = "https://www.magicmurals.com/media/catalog/product/cache/af1e2a1566fa2dbb552605e8822354b7/a/d/adg-0000001045_1.jpg" },
            new { Author = new Author { Id = Guid.NewGuid(), Name = "Brothers Grimm", Biography = "Famous German storytellers.", BirthDate = new DateTime(1785,1,4), ProfileImageUrl = "https://example.com/grimm.jpg", Books = new List<Book>() }, Book = new Book { Id = Guid.NewGuid(), Title = "Snow White", ISBN = "9781234567890", Description = "A classic fairy tale about Snow White and the Seven Dwarfs.", Genre = "Fairy Tale", PublishedDate = new DateTime(1812,1,1), IsArchived = false }, Cover = "https://assets2.titleleaf.com/abdopub/product/cover/xl_9781532145681_fc.jpg" },
            new { Author = new Author { Id = Guid.NewGuid(), Name = "F. Scott Fitzgerald", Biography = "American novelist and short story writer.", BirthDate = new DateTime(1896,9,24), ProfileImageUrl = "https://example.com/fitzgerald.jpg", Books = new List<Book>() }, Book = new Book { Id = Guid.NewGuid(), Title = "The Great Gatsby", ISBN = "9780743273565", Description = "A novel about the American dream.", Genre = "Classic", PublishedDate = new DateTime(1925,4,10), IsArchived = false }, Cover = "https://m.media-amazon.com/images/I/81af+MCATTL.jpg" },
            new { Author = new Author { Id = Guid.NewGuid(), Name = "Leo Tolstoy", Biography = "Russian writer, known for War and Peace and Anna Karenina.", BirthDate = new DateTime(1828,9,9), ProfileImageUrl = "https://example.com/tolstoy.jpg", Books = new Book[] { new Book() }.ToList() }, Book = new Book { Id = Guid.NewGuid(), Title = "War and Peace", ISBN = "9780199232765", Description = "Epic novel about Russian society.", Genre = "Historical Fiction", PublishedDate = new DateTime(1869,1,1), IsArchived = false }, Cover = "https://www.gutenberg.org/files/2600/2600-h/images/cover.jpg" },
            new { Author = new Author { Id = Guid.NewGuid(), Name = "Charlotte Brontë", Biography = "English novelist and poet.", BirthDate = new DateTime(1816,4,21), ProfileImageUrl = "https://example.com/bronte.jpg", Books = new List<Book>() }, Book = new Book { Id = Guid.NewGuid(), Title = "Jane Eyre", ISBN = "9780141441146", Description = "A novel about an orphaned girl and her growth.", Genre = "Classic", PublishedDate = new DateTime(1847,10,16), IsArchived = false }, Cover = "https://cdn.penguin.co.uk/dam-assets/books/9780241570029/9780241570029-jacket-large.jpg" },
            new { Author = new Author { Id = Guid.NewGuid(), Name = "Stephenie Meyer", Biography = "American novelist, best known for the Twilight series.", BirthDate = new DateTime(1973, 12, 24), ProfileImageUrl = "https://example.com/meyer.jpg", Books = new List<Book>() }, Book = new Book { Id = Guid.NewGuid(), Title = "Twilight", ISBN = "9780316015844", Description = "A vampire romance novel about Bella Swan and Edward Cullen.", Genre = "Romance/Fantasy", PublishedDate = new DateTime(2005, 10, 5), IsArchived = false }, Cover = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtEpdhxYfsxquuushfQTUgGeLV6Swwmp6S5g&s" }

        };

        _authors.Add(author1);
        _authors.Add(author2);
        _books.Add(book1);
        _books.Add(book2);
        _bookCopies.Add(bookItem1);
        _bookCopies.Add(bookItem2);

        foreach (var entry in extraBooks)
        {
            entry.Author.Books.Add(entry.Book);
            _authors.Add(entry.Author);
            _books.Add(entry.Book);
            _bookCopies.Add(new BookCopy
            {
                Id = Guid.NewGuid(),
                CoverImageUrl = entry.Cover,
                Condition = "New",
                Source = "Purchase",
                AddedDate = DateTime.Now,
                Book = entry.Book
            });
        }
    }

    public void AddBook(AddBookViewModel book)
    {
        ArgumentNullException.ThrowIfNull(book, nameof(book));
        var newBook = new Book
        {
            Id = Guid.NewGuid(),
            Title = book.Title,
            ISBN = book.ISBN,
            Description = book.Description,
            Genre = book.Genre,
            PublishedDate = book.PublishedDate ?? DateTime.Now,
            IsArchived = false
        };
        _books.Add(newBook);
        var newAuthor = new Author
        {
            Id = Guid.NewGuid(),
            Name = book.AuthorName,
            ProfileImageUrl = book.AuthorProfileImageUrl,
            Books = new List<Book> { newBook }
        };
        _authors.Add(newAuthor);
        var newBookItem = new BookCopy
        {
            Id = Guid.NewGuid(),
            CoverImageUrl = book.CoverImageUrl,
            Condition = book.Condition,
            Source = book.Source,
            AddedDate = DateTime.Now,
            Book = newBook
        };
        _bookCopies.Add(newBookItem);
    }

    public IEnumerable<BookListViewModel> GetBooks(bool includeArchived = false)
    {
        return _books
            .Where(b => includeArchived || !b.IsArchived)
            .Select(b => new BookListViewModel
            {
                BookId = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Description = b.Description,
                Genre = b.Genre,
                PublishedDate = b.PublishedDate,
                AuthorName = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.Name ?? "Unknown",
                AuthorProfileImageUrl = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.ProfileImageUrl ?? "",
                CoverImageUrl = _bookCopies.FirstOrDefault(bc => bc.Book.Id == b.Id)?.CoverImageUrl ?? "",
                TotalCopies = _bookCopies.Count(bc => bc.Book.Id == b.Id),
                AvailableCopies = _bookCopies.Count(bc => bc.Book.Id == b.Id && bc.PulloutDate == null),
                IsArchived = b.IsArchived
            });
    }

    public EditBookViewModel GetBookById(Guid id)
    {
        var bookViewModel = GetBooks(true).FirstOrDefault(b => b.BookId == id) ?? throw new KeyNotFoundException("Book not found");
        return new EditBookViewModel
        {
            BookId = bookViewModel.BookId,
            Title = bookViewModel.Title,
            ISBN = bookViewModel.ISBN,
            Description = bookViewModel.Description,
            Genre = bookViewModel.Genre,
            PublishedDate = bookViewModel.PublishedDate,
            AuthorId = _authors.FirstOrDefault(a => a.Name == bookViewModel.AuthorName)?.Id,
            Author = bookViewModel.AuthorName,
            AuthorProfileImageUrl = bookViewModel.AuthorProfileImageUrl,
            CoverImageUrl = bookViewModel.CoverImageUrl,
            Copies = _bookCopies
                .Where(bc => bc.Book.Id == bookViewModel.BookId)
                .Select(bc => new BookCopyViewModel
                {
                    BookId = bc.Book.Id,
                    Id = bc.Id,
                    CoverImageUrl = bc.CoverImageUrl,
                    Condition = bc.Condition,
                    Source = bc.Source,
                    AddedDate = DateTime.Now,
                    PulloutDate = bc.PulloutDate,
                    PulloutReason = bc.PulloutReason
                }).ToList()
        };
    }

    public void UpdateBook(EditBookViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm, nameof(vm));
        var book = _books.FirstOrDefault(b => b.Id == vm.BookId) ?? throw new KeyNotFoundException("Book not found");
        book.Title = vm.Title;
        book.ISBN = vm.ISBN;
        book.Description = vm.Description;
        book.Genre = vm.Genre;
        book.PublishedDate = vm.PublishedDate ?? DateTime.Now;
        var author = _authors.FirstOrDefault(a => a.Id == vm.AuthorId);
        if (author == null)
        {
            author = new Author
            {
                Id = Guid.NewGuid(),
                Name = vm.Author,
                ProfileImageUrl = vm.AuthorProfileImageUrl,
                Books = new List<Book> { book }
            };
            _authors.Add(author);
        }
        else
        {
            author.Name = vm.Author;
            author.ProfileImageUrl = vm.AuthorProfileImageUrl;
            if (!author.Books.Contains(book))
                author.Books.Add(book);
        }
        var bookCopy = _bookCopies.FirstOrDefault(bi => bi.Book.Id == vm.BookId);
        if (bookCopy != null)
        {
            bookCopy.CoverImageUrl = vm.CoverImageUrl;
        }
        else
        {
            _bookCopies.Add(new BookCopy
            {
                Id = Guid.NewGuid(),
                CoverImageUrl = vm.CoverImageUrl,
                AddedDate = DateTime.Now,
                Book = book
            });
        }
    }

    public void DeleteBook(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id) ?? throw new KeyNotFoundException("Book not found");
        _books.Remove(book);
        var author = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == id));
        if (author != null)
        {
            author.Books.Remove(book);
            if (!author.Books.Any())
                _authors.Remove(author);
        }
        var bookCopies = _bookCopies.Where(bc => bc.Book.Id == id).ToList();
        foreach (var bc in bookCopies)
            _bookCopies.Remove(bc);
    }

    public void AddBookCopy(Guid bookId, BookCopyViewModel vm)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId) ?? throw new KeyNotFoundException("Book not found");
        if (_bookCopies.Any(bc => bc.Book.Id == bookId &&
                                  bc.CoverImageUrl == vm.CoverImageUrl &&
                                  bc.Condition == vm.Condition &&
                                  bc.Source == vm.Source))
        {
            throw new InvalidOperationException("This copy already exists.");
        }
        _bookCopies.Add(new BookCopy
        {
            Id = Guid.NewGuid(),
            CoverImageUrl = vm.CoverImageUrl,
            Condition = vm.Condition,
            Source = vm.Source,
            AddedDate = DateTime.Now,
            PulloutDate = vm.PulloutDate,
            PulloutReason = vm.PulloutReason,
            Book = book
        });
    }

    public void ArchiveBook(Guid bookId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId) ?? throw new KeyNotFoundException("Book not found");
        book.IsArchived = true;
    }

    public void RestoreBook(Guid bookId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId) ?? throw new KeyNotFoundException("Book not found");
        book.IsArchived = false;
    }

    private static BookService? _instance;
    public static BookService Instance
    {
        get
        {
            if (_instance == null)
                _instance = new BookService();
            return _instance;
        }
    }
}
