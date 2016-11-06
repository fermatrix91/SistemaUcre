using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using SistemaUcre.Models.DAL;
using System.Web.Security;
using SistemaUcre.Filters;

namespace SistemaUcre.Controllers
{
    public class HomeController : Controller
    {
        private readonly UcreEntities modeloUcre = new UcreEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (modeloUcre.Administrador.Count() == 0)
                AdminDefault();
            if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "Admin");
            if (User.IsInRole("Estudiante"))
                return RedirectToAction("Index", "Estudiante");

            WebSecurity.Logout();
            return RedirectToAction("Login", "Account", new { returnUrl = "/Home/Index"});
        }

        public void AdminDefault()
        {
            try
            {
                WebSecurity.CreateUserAndAccount("josue@montes.cc", "Fernando$11");
                WebSecurity.Login("josue@montes.cc", "Fernando$11");
                Roles.CreateRole("Admin");
                Roles.CreateRole("Estudiante");
                Roles.AddUserToRole("josue@montes.cc", "Admin");

                Administrador administradorNuevo = new Administrador();
                administradorNuevo.Nombre = "Admin Default";
                administradorNuevo.Correo = "josue@montes.cc";
                administradorNuevo.Username = "josue@montes.cc";
                administradorNuevo.Estado = true;

                modeloUcre.Administrador.Add(administradorNuevo);
                modeloUcre.Entry(administradorNuevo).State = System.Data.EntityState.Added;
                modeloUcre.SaveChanges();
            }
            catch (Exception mensaje) { }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}