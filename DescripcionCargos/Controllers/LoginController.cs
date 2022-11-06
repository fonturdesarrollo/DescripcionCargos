using DescripcionCargos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DescripcionCargos.Core.Interfaces;

namespace DescripcionCargos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IEmpleado _empleado;
        public LoginController(IEmpleado empleado)
        {
            this._empleado = empleado;
        }
        public IActionResult Login()
        {
            HttpContext.Session.Remove("PersonalId");
            HttpContext.Session.Remove("Cedula");
            HttpContext.Session.Remove("PrimerNombreEmpleado");
            HttpContext.Session.Remove("SegundoNombreEmpleado");
            HttpContext.Session.Remove("PrimerApellidoEmpleado");
            HttpContext.Session.Remove("SegundoApellidoEmpleado");
            HttpContext.Session.Remove("NombreCargo");
            HttpContext.Session.Remove("NombreGerencia");
            HttpContext.Session.Remove("NombreDivision");
            HttpContext.Session.Remove("NombreEstado");
            HttpContext.Session.Remove("NombreNivelEducativo");

            return View();
        }

        [HttpPost]
        public IActionResult Login(FichaDescriptivaCargoModel model)
        {
            try
            {
                var validUser = _empleado.ObtenerPorCedula(model.Cedula);

                if (validUser != null && validUser.PersonalId != 0)
                {

                    HttpContext.Session.SetInt32("PersonalId", validUser.PersonalId);
                    HttpContext.Session.SetInt32("Cedula", (int)validUser.Cedula);
                    HttpContext.Session.SetString("PrimerNombreEmpleado", validUser.PrimerNombreEmpleado);
                    HttpContext.Session.SetString("SegundoNombreEmpleado", validUser.SegundoNombreEmpleado);
                    HttpContext.Session.SetString("PrimerApellidoEmpleado", validUser.PrimerApellidoEmpleado);
                    HttpContext.Session.SetString("SegundoApellidoEmpleado", validUser.SegundoApellidoEmpleado);
                    HttpContext.Session.SetString("NombreCargo", validUser.NombreCargo);
                    HttpContext.Session.SetInt32("CargoId", validUser.CargoId);
                    HttpContext.Session.SetInt32("CodigoAdministrativoID", validUser.CodigoAdministrativoId);
                    HttpContext.Session.SetString("NombreGerencia", validUser.NombreGerencia);
                    HttpContext.Session.SetString("NombreDivision", validUser.NombreDivision);
                    HttpContext.Session.SetInt32("EstadoId", validUser.EstadoId);
                    HttpContext.Session.SetString("NombreEstado", validUser.NombreEstado);
                    HttpContext.Session.SetInt32("NivelEducativoId", validUser.NivelEducativoId);
                    HttpContext.Session.SetString("NombreNivelEducativo", validUser.NombreNivelEducativo);

                    return RedirectToAction("Agregar", "FichaDescripcionCargos");
                }

                ViewBag.InvalidUser = "true";

                return View("Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message.ToString() });
            }
        }
    }
}
