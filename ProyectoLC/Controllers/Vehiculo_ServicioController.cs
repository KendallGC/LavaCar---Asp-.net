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
    public class Vehiculo_ServicioController : Controller
    {
        // GET: Vehiculo_Servicio
        public ActionResult Index()
        {
            var vehiculo_servicio = Vehiculo_ServicioCN.ListarVehiculo_Servicio();
            return View(vehiculo_servicio);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Vehiculo_Servicio vehiculo_serv)
        {
            try
            {
                if (vehiculo_serv.ID_Servicio == 0)
                {
                    ModelState.AddModelError("", "Debe ingresar una descripción del servicio para un vehiculo");
                    return View(vehiculo_serv);
                }

                Vehiculo_ServicioCN.Agregar(vehiculo_serv);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al agregar un servicio para un vehiculo");
                return View(vehiculo_serv);
            }
        }

        public ActionResult GetVehiculo_Servicio(int id)
        {
            var vehiculo_serv = Vehiculo_ServicioCN.GetVehiculo_Servicio(id);
            return View(vehiculo_serv);
        }

        public JsonResult GetVehiculos_Servicio()
        {
            var lista = Vehiculo_ServicioCN.ListarVehiculo_Servicio();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id)
        {
            var vehiculo_serv = Vehiculo_ServicioCN.GetVehiculo_Servicio(id);
            return View(vehiculo_serv);
        }

        [HttpPost]
        public ActionResult Editar(Vehiculo_Servicio vehiculo_serv)
        {
            try
            {
                if (vehiculo_serv.ID_Servicio == 0)
                {
                    ModelState.AddModelError("", "Debe ingresar la descripción del servicio");
                    return View(vehiculo_serv);
                }

                Vehiculo_ServicioCN.Editar(vehiculo_serv);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al editar un servicio");
                return View(vehiculo_serv);
            }
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vehiculo_serv = Vehiculo_ServicioCN.GetVehiculo_Servicio(id.Value);
            return View(vehiculo_serv);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                Vehiculo_ServicioCN.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al eliminar un servicio");
                return View();

            }
        }
    }
}