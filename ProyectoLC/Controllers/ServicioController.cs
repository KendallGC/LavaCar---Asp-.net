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
    public class ServicioController : Controller
    {
        // GET: Servicio
        public ActionResult Index()
        {
            var servicios = ServiciosCN.ListarServicios();
            return View(servicios);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Servicios servic)
        {
            try
            {
                if (servic.Descripción == null)
                {
                    ModelState.AddModelError("", "Debe ingresar una descripción del servicio");
                    return View(servic);
                }

                ServiciosCN.Agregar(servic);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al agregar un servicio");
                return View(servic);
            }
        }

        public ActionResult GetServicio(int id)
        {
            var servic = ServiciosCN.GetServicios(id);
            return View(servic);
        }

        public JsonResult GetServicios()
        {
            var lista = ServiciosCN.ListarServicios();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id)
        {
            var vehic = ServiciosCN.GetServicios(id);
            return View(vehic);
        }

        [HttpPost]
        public ActionResult Editar(Servicios servic)
        {
            try
            {
                if (servic.Descripción == null)
                {
                    ModelState.AddModelError("", "Debe ingresar la descripción del servicio");
                    return View(servic);
                }

                ServiciosCN.Editar(servic);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al editar un servicio");
                return View(servic);
            }
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var servic = ServiciosCN.GetServicios(id.Value);
            return View(servic);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                ServiciosCN.Eliminar(id);
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