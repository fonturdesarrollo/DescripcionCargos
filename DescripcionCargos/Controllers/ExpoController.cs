using Microsoft.AspNetCore.Mvc;

namespace DescripcionCargos.Controllers
{
	public class ExpoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
