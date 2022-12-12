using Microsoft.AspNetCore.Mvc;

namespace DescripcionCargos.Controllers
{
	public class CatalogoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
