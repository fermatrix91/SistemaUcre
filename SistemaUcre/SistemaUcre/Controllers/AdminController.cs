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
                Administrador adminActual = modeloUcre.Administrador.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                ViewBag.NombreUsuario = adminActual.Nombre;
                return View(adminActual);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        #region Cursos

        [Authorize]
        public ActionResult Cursos()
        {
            if (User.IsInRole("Admin"))
            {
                Administrador adminActual = modeloUcre.Administrador.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                List<Curso> listaCursos = new List<Curso>();
                listaCursos = modeloUcre.Curso.ToList();

                ViewBag.NombreUsuario = adminActual.Nombre;
                return View(listaCursos);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult DetalleCurso(int idCursoActual)
        {
            if (User.IsInRole("Admin"))
            {
                Curso cursoActual = new Curso();
                cursoActual = modeloUcre.Curso.Find(idCursoActual);

                return Json(new { IdCurso = cursoActual.IdCurso, Nombre = cursoActual.Nombre }, JsonRequestBehavior.AllowGet);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult HabilitarCurso(int idCursoActual, bool estado)
        {
            if (User.IsInRole("Admin"))
            {
                Curso cursoActual = new Curso();
                cursoActual = modeloUcre.Curso.Find(idCursoActual);
                cursoActual.Estado = estado;

                modeloUcre.Curso.Attach(cursoActual);
                modeloUcre.Entry(cursoActual).State = System.Data.EntityState.Modified;
                modeloUcre.SaveChanges();

                return RedirectToAction("Cursos", "Admin");
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult GuardarCurso(string nombreCurso, int idDeCursoActual, bool esEdicion)
        {
            if (User.IsInRole("Admin"))
            {
                Curso cursoActual = new Curso();
                if (esEdicion) cursoActual = modeloUcre.Curso.Find(idDeCursoActual);

                cursoActual.Nombre = nombreCurso;

                if (esEdicion)
                {
                    modeloUcre.Curso.Attach(cursoActual);
                    modeloUcre.Entry(cursoActual).State = System.Data.EntityState.Modified;
                }
                else
                {
                    cursoActual.Estado = true;
                    modeloUcre.Curso.Add(cursoActual);
                    modeloUcre.Entry(cursoActual).State = System.Data.EntityState.Added;
                }

                modeloUcre.SaveChanges();

                return RedirectToAction("Cursos", "Admin");
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Profesores
        [Authorize]
        public ActionResult Profesores()
        {
            if (User.IsInRole("Admin"))
            {
                Administrador adminActual = modeloUcre.Administrador.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                List<Profesor> listaProfesores = new List<Profesor>();
                listaProfesores = modeloUcre.Profesor.ToList();

                ViewBag.NombreUsuario = adminActual.Nombre;
                return View(listaProfesores);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult DetalleProfesor(int idProfesorActual)
        {
            if (User.IsInRole("Admin"))
            {
                Profesor profesorActual = new Profesor();
                profesorActual = modeloUcre.Profesor.Find(idProfesorActual);

                return Json(new { IdProfesor = profesorActual.IdProfesor, Correo = profesorActual.Correo, Nombre = profesorActual.Nombre }, JsonRequestBehavior.AllowGet);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult HabilitarProfesor(int idProfesorActual, bool estado)
        {
            if (User.IsInRole("Admin"))
            {
                Profesor profesorActual = new Profesor();
                profesorActual = modeloUcre.Profesor.Find(idProfesorActual);
                profesorActual.Estado = estado;

                modeloUcre.Profesor.Attach(profesorActual);
                modeloUcre.Entry(profesorActual).State = System.Data.EntityState.Modified;
                modeloUcre.SaveChanges();

                return RedirectToAction("Profesores", "Admin");
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult GuardarProfesor(string nombreProfesor, string correoProfesor, int idDeProfesorActual, bool esEdicion)
        {
            if (User.IsInRole("Admin"))
            {
                Profesor profesorActual = new Profesor();
                if (esEdicion) profesorActual = modeloUcre.Profesor.Find(idDeProfesorActual);

                profesorActual.Nombre = nombreProfesor;
                profesorActual.Correo = correoProfesor;

                if (esEdicion)
                {
                    modeloUcre.Profesor.Attach(profesorActual);
                    modeloUcre.Entry(profesorActual).State = System.Data.EntityState.Modified;
                }
                else
                {
                    profesorActual.Estado = true;
                    modeloUcre.Profesor.Add(profesorActual);
                    modeloUcre.Entry(profesorActual).State = System.Data.EntityState.Added;
                }

                modeloUcre.SaveChanges();

                return RedirectToAction("Profesores", "Admin");
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Asignaturas
        [Authorize]
        public ActionResult Asignaturas(int idCursoActual)
        {
            if (User.IsInRole("Admin"))
            {
                Administrador adminActual = modeloUcre.Administrador.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                List<Asignatura> listaAsignaturas = new List<Asignatura>();
                listaAsignaturas = modeloUcre.Asignatura.Where(x => x.IdCurso == idCursoActual).ToList();

                Curso cursoActual = new Curso();
                cursoActual = modeloUcre.Curso.Find(idCursoActual);
                ViewBag.NombreCurso = cursoActual.Nombre;
                ViewBag.IdDeCurso = idCursoActual;

                Dictionary<int, string> dicProfesores = new Dictionary<int, string>();
                List<Profesor> listaProfes = new List<Profesor>();
                listaProfes = modeloUcre.Profesor.Where(x => x.Estado == true).ToList();

                foreach (var item in listaProfes)
                {
                    dicProfesores.Add(item.IdProfesor, item.Nombre);
                }

                ViewBag.ListaProfesores = dicProfesores;

                ViewBag.NombreUsuario = adminActual.Nombre;
                return View(listaAsignaturas);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult DetalleAsignatura(int idAsignaturaActual, int idCursoActual)
        {
            if (User.IsInRole("Admin"))
            {
                Asignatura asignaturaActual = new Asignatura();
                asignaturaActual = modeloUcre.Asignatura.Find(idAsignaturaActual);

                return Json(new { IdAsignatura = asignaturaActual.IdAsignatura, IdProfesor = asignaturaActual.IdProfesor, Nombre = asignaturaActual.Nombre }, JsonRequestBehavior.AllowGet);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult HabilitarAsignatura(int idAsignaturaActual, int idCursoGo, bool estado)
        {
            if (User.IsInRole("Admin"))
            {
                Asignatura asignaturaActual = new Asignatura();
                asignaturaActual = modeloUcre.Asignatura.Find(idAsignaturaActual);
                asignaturaActual.Estado = estado;

                modeloUcre.Asignatura.Attach(asignaturaActual);
                modeloUcre.Entry(asignaturaActual).State = System.Data.EntityState.Modified;
                modeloUcre.SaveChanges();

                return RedirectToAction("Asignaturas", "Admin", new { idCursoActual = idCursoGo });
            }
            WebSecurity.Logout();
            return RedirectToAction("Asignaturas", "Home");
        }

        [Authorize]
        public ActionResult GuardarAsignatura(string nombreAsignatura, int idDeAsignaturaActual, int idDeProfesorActual, int idDeCursoActual, bool esEdicion)
        {
            if (User.IsInRole("Admin"))
            {
                Asignatura asignaturaActual = new Asignatura();
                if (esEdicion) asignaturaActual = modeloUcre.Asignatura.Find(idDeAsignaturaActual);

                asignaturaActual.Nombre = nombreAsignatura;
                asignaturaActual.IdProfesor = idDeProfesorActual;
                asignaturaActual.IdCurso = idDeCursoActual;

                if (esEdicion)
                {
                    modeloUcre.Asignatura.Attach(asignaturaActual);
                    modeloUcre.Entry(asignaturaActual).State = System.Data.EntityState.Modified;
                }
                else
                {
                    asignaturaActual.Estado = true;
                    modeloUcre.Asignatura.Add(asignaturaActual);
                    modeloUcre.Entry(asignaturaActual).State = System.Data.EntityState.Added;
                }

                modeloUcre.SaveChanges();

                return RedirectToAction("Asignaturas", "Admin", new { idCursoActual = idDeCursoActual });
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Modulos
        [Authorize]
        public ActionResult Modulos(int idAsignaturaActual)
        {
            if (User.IsInRole("Admin"))
            {
                Administrador adminActual = modeloUcre.Administrador.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                List<Modulo> listaModulos = new List<Modulo>();
                listaModulos = modeloUcre.Modulo.Where(x => x.IdAsignatura == idAsignaturaActual).ToList();

                Asignatura asignaturaActual = new Asignatura();
                asignaturaActual = modeloUcre.Asignatura.Find(idAsignaturaActual);
                ViewBag.NombreAsignatura = asignaturaActual.Nombre;
                ViewBag.IdDeAsignatura = idAsignaturaActual;
                ViewBag.IdCursoAsignatura = asignaturaActual.IdCurso;

                ViewBag.NombreUsuario = adminActual.Nombre;
                return View(listaModulos);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult DetalleModulo(int idAsignaturaActual, int idModuloActual)
        {
            if (User.IsInRole("Admin"))
            {
                Modulo moduloActual = new Modulo();
                moduloActual = modeloUcre.Modulo.Find(idModuloActual);

                return Json(new { IdModulo = moduloActual.IdModulo, Nombre = moduloActual.Nombre }, JsonRequestBehavior.AllowGet);
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult HabilitarModulo(int idModuloActual, int idAsignaturaGo, bool estado)
        {
            if (User.IsInRole("Admin"))
            {
                Modulo moduloActual = new Modulo();
                moduloActual = modeloUcre.Modulo.Find(idModuloActual);
                moduloActual.Estado = estado;

                modeloUcre.Modulo.Attach(moduloActual);
                modeloUcre.Entry(moduloActual).State = System.Data.EntityState.Modified;
                modeloUcre.SaveChanges();

                return RedirectToAction("Modulos", "Admin", new { idAsignaturaActual = idAsignaturaGo });
            }
            WebSecurity.Logout();
            return RedirectToAction("Asignaturas", "Home");
        }

        [Authorize]
        public ActionResult GuardarModulo(string nombreModulo, int idDeAsignaturaActual, int idDeModuloActual, bool esEdicion)
        {
            if (User.IsInRole("Admin"))
            {
                Modulo moduloActual = new Modulo();
                if (esEdicion) moduloActual = modeloUcre.Modulo.Find(idDeModuloActual);

                moduloActual.Nombre = nombreModulo;
                moduloActual.IdAsignatura = idDeAsignaturaActual;

                if (esEdicion)
                {
                    modeloUcre.Modulo.Attach(moduloActual);
                    modeloUcre.Entry(moduloActual).State = System.Data.EntityState.Modified;
                }
                else
                {
                    moduloActual.Estado = true;
                    modeloUcre.Modulo.Add(moduloActual);
                    modeloUcre.Entry(moduloActual).State = System.Data.EntityState.Added;
                }

                modeloUcre.SaveChanges();

                return RedirectToAction("Modulos", "Admin", new { idAsignaturaActual = idDeAsignaturaActual });
            }
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }


        #endregion

        public ActionResult CerrarSesion()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
