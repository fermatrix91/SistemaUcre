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
            if (User.IsInRole("Estudiante"))
            {
                Estudiante estudianteActual = modeloUcre.Estudiante.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                return View(estudianteActual);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
