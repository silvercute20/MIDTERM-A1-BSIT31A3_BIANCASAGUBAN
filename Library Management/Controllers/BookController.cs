using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = BookService.Instance.GetBooks(true);
            return View(books);
        }

        public IActionResult AddModal()
        {
            return PartialView("_AddBookPartial");
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BookService.Instance.AddBook(vm);
            return Ok();
        }

        public IActionResult EditModal(Guid id)
        {
            var editBookViewModel = BookService.Instance.GetBookById(id);
            if (editBookViewModel == null) return NotFound();

            return PartialView("_EditBookPartial", editBookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BookService.Instance.UpdateBook(vm);
            return Ok();
        }

        public IActionResult ManageCopiesModal(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null) return NotFound();

            return PartialView("_ManageCopies", book);
        }

        [HttpPost]
        public IActionResult AddCopy(BookCopyViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (vm.BookId == Guid.Empty)
                return BadRequest("BookId is required");

            vm.AddedDate = DateTime.Now;

            BookService.Instance.AddBookCopy(vm.BookId, vm);
            var book = BookService.Instance.GetBookById(vm.BookId);
            var addedCopy = book.Copies.Last();

            return Json(new
            {
                success = true,
                message = "Book Copy added successfully to the book copies section",
                coverImageUrl = addedCopy.CoverImageUrl,
                source = addedCopy.Source,
                condition = addedCopy.Condition,
                addedDate = addedCopy.AddedDate.ToString("yyyy-MM-dd"),
                title = book.Title
            });
        }

        public IActionResult DeleteModal(Guid id)
        {
            return PartialView("_DeletePartial");
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            BookService.Instance.DeleteBook(id);
            return Ok();
        }

        public IActionResult Details(Guid id)
        {
            var book = BookService.Instance.GetBooks(true).FirstOrDefault(b => b.BookId == id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Archive(Guid id)
        {
            BookService.Instance.ArchiveBook(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Restore(Guid id)
        {
            BookService.Instance.RestoreBook(id);
            return Ok();
        }
    }
}
