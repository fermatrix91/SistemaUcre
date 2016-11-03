using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaUcre.Models.DAL;
using WebMatrix.WebData;

namespace SistemaUcre.Controllers
{
    public class EstudianteController : Controller
    {
        //
        // GET: /Estudiante/
        private readonly UcreEntities modeloUcre = new UcreEntities();

        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Estudiante"))
            {
                Estudiante estudianteActual = modeloUcre.Estudiante.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                ViewBag.NombreUsuario = estudianteActual.Nombre;
                return View(estudianteActual);
            }
            return RedirectToAction("CerrarSesion");
        }

        public ActionResult CerrarSesion()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}