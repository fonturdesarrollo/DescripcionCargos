using DescripcionCargos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using static DescripcionCargos.Core.Interfaces;

namespace DescripcionCargos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("PersonalId") != null)
                {
                    var model = new FichaDescriptivaCargoModel();

                    ViewBag.Cedula = (int)HttpContext.Session.GetInt32("Cedula");
                    ViewBag.PrimerNombreEmpleado = (string)HttpContext.Session.GetString("PrimerNombreEmpleado");
                    ViewBag.SegundoNombreEmpleado = (string)HttpContext.Session.GetString("SegundoNombreEmpleado");
                    ViewBag.PrimerApellidoEmpleado = (string)HttpContext.Session.GetString("PrimerApellidoEmpleado");
                    ViewBag.SegundoApellidoEmpleado = (string)HttpContext.Session.GetString("SegundoApellidoEmpleado");
                    ViewBag.NombreCargo = (string)HttpContext.Session.GetString("NombreCargo");
                    ViewBag.NombreGerencia = (string)HttpContext.Session.GetString("NombreGerencia");
                    ViewBag.NombreDivision = (string)HttpContext.Session.GetString("NombreDivision");
                    ViewBag.NombreDivision = (string)HttpContext.Session.GetString("NombreDivision");
                    ViewBag.NombreEstado = (string)HttpContext.Session.GetString("NombreEstado");
                    ViewBag.NombreNivelEducativo = (string)HttpContext.Session.GetString("NombreNivelEducativo");

                    return View(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

    }
}