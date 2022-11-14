using Microsoft.AspNetCore.Mvc;

namespace DescripcionCargos.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
