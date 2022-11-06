using DescripcionCargos.Core;
using DescripcionCargos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;
using static DescripcionCargos.Core.Interfaces;

namespace DescripcionCargos.Controllers
{
	public class FichaDescripcionCargosController : Controller
	{
        private readonly IFichaDescriptivaCargo _fichaDescriptivaCargo;
        public FichaDescripcionCargosController(IFichaDescriptivaCargo fichaDescriptivaCargo)
        {
            this._fichaDescriptivaCargo = fichaDescriptivaCargo;
        }
		public IActionResult Agregar()
		{
            try
            {
                if (HttpContext.Session.GetString("PersonalId") != null)
                {
                    var model = _fichaDescriptivaCargo.ObtenerPorIdEmpleado((int)HttpContext.Session.GetInt32("PersonalId"));

                    ViewBag.Cedula = (int)HttpContext.Session.GetInt32("Cedula");
                    ViewBag.PrimerNombreEmpleado = (string)HttpContext.Session.GetString("PrimerNombreEmpleado");
                    ViewBag.SegundoNombreEmpleado = (string)HttpContext.Session.GetString("SegundoNombreEmpleado");
                    ViewBag.PrimerApellidoEmpleado = (string)HttpContext.Session.GetString("PrimerApellidoEmpleado");
                    ViewBag.SegundoApellidoEmpleado = (string)HttpContext.Session.GetString("SegundoApellidoEmpleado");
                    ViewBag.NombreCargo = (string)HttpContext.Session.GetString("NombreCargo");
                    ViewBag.NombreGerencia = (string)HttpContext.Session.GetString("NombreGerencia");
                    ViewBag.NombreDivision = (string)HttpContext.Session.GetString("NombreDivision");
                    ViewBag.NombreEstado = (string)HttpContext.Session.GetString("NombreEstado");
                    ViewBag.NombreNivelEducativo = (string)HttpContext.Session.GetString("NombreNivelEducativo");

                    return View(model);
                }

                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message.ToString() });
            }
        }

        [HttpPost]
        public IActionResult Agregar(FichaDescriptivaCargoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.PersonalId = (int)HttpContext.Session.GetInt32("PersonalId");
                    var fichaAgregadaId = _fichaDescriptivaCargo.AgregarEditar(model);

                    return RedirectToAction("Editar", "FichaDescripcionCargos", new { fichaDescriptivaCargoId = fichaAgregadaId != 0 ? fichaAgregadaId : model.FichaDescriptivaCargoId });
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Modelo no valido" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message.ToString() });
            }
        }

        public IActionResult Editar(int fichaDescriptivaCargoId)
        {
            if (HttpContext.Session.GetString("PersonalId") != null)
            {
                ViewBag.Cedula = (int)HttpContext.Session.GetInt32("Cedula"); ;
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
                ViewBag.Message = string.Format("Registro actualizado correctamente");

                var model = _fichaDescriptivaCargo.ObtenerPorId(fichaDescriptivaCargoId);

                return View(model);
            }
            return RedirectToAction("Login", "Login");            
        }

        [HttpPost]
        public IActionResult Editar(FichaDescriptivaCargoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fichaDescriptivaCargo.AgregarEditar(model);

                    return RedirectToAction("Editar", "FichaDescripcionCargos", new { fichaDescriptivaCargoId = model.FichaDescriptivaCargoId });
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Modelo no valido" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message.ToString() });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Result(string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            return View();
        }
    }
}