using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRouts.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session11.UrlAndRouts.Controllers
{
    public class ContentController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(ContentController),
                Action = nameof(Index)
            });
        }
    }
}
