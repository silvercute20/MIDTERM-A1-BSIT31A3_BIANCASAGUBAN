using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Models
{
    public class AddBookCopyViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
