using System;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            var authors = AuthorService.Instance.GetAuthors();
            return View(authors);
        }

        public IActionResult AddModal()
        {
            var model = new EditAuthorViewModel();
            return PartialView("_AddEditAuthorPartial", model);
        }

        [HttpPost]
        public IActionResult Add(EditAuthorViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var addVm = new AddAuthorViewModel
            {
                Name = vm.Name,
                Biography = vm.Biography,
                BirthDate = vm.BirthDate,
                ProfileImageUrl = vm.ProfileImageUrl
            };

            AuthorService.Instance.AddAuthor(addVm);
            return Ok();
        }

        public IActionResult EditModal(Guid id)
        {
            var editAuthor = AuthorService.Instance.GetAuthorById(id);
            if (editAuthor == null) return NotFound();

            var vm = new EditAuthorViewModel
            {
                AuthorId = editAuthor.AuthorId,
                Name = editAuthor.Name,
                Biography = editAuthor.Biography,
                BirthDate = editAuthor.BirthDate,
                ProfileImageUrl = editAuthor.ProfileImageUrl
            };

            return PartialView("_AddEditAuthorPartial", vm);
        }

        [HttpPost]
        public IActionResult Edit(EditAuthorViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            AuthorService.Instance.UpdateAuthor(vm);
            return Ok();
        }

        [HttpPost]
        public IActionResult ToggleArchive(Guid id)
        {
            AuthorService.Instance.ToggleArchive(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            AuthorService.Instance.DeleteAuthor(id);
            return Ok();
        }
    }
}
