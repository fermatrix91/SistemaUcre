using SistemaUcre.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SistemaUcre.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private readonly UcreEntities modeloUcre = new UcreEntities();

        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                Administrador adminActual = modeloUcre.Administrador.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                ViewBag.NombreUsuario = adminActual.Nombre;
                return View(adminActual);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CerrarSesion()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
