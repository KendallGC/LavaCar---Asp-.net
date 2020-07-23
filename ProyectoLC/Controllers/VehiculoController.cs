using NEGOCIO;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ProyectoLC.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculos = VehiculoCN.ListarVehiculo();
            return View(vehiculos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Vehiculo vehic)
        {
            try
            {
                if (vehic.Dueño == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un dueño del vehiculo.");
                    return View(vehic);
                }

                VehiculoCN.Agregar(vehic);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al agregar un  vehiculo");
                return View(vehic);
            }
        }

        public ActionResult GetVehiculo(int id)
        {
            var vehic = VehiculoCN.GetVehiculo(id);
            return View(vehic);
        }

        public JsonResult GetVehiculos()
        {
            var lista = VehiculoCN.ListarVehiculo();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id)
        {
            var vehic = VehiculoCN.GetVehiculo(id);
            return View(vehic);
        }

        [HttpPost]
        public ActionResult Editar(Vehiculo vehic)
        {
            try
            {
                if (vehic.Dueño == null)
                {
                    ModelState.AddModelError("", "Debe ingresar el nombre del dueño del vehiculo.");
                    return View(vehic);
                }

                VehiculoCN.Editar(vehic);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al editar un vehiculo");
                return View(vehic);
            }
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vehic = VehiculoCN.GetVehiculo(id.Value);
            return View(vehic);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                VehiculoCN.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al eliminar un vehiculo");
                return View();
               
            }
        }
    }
}