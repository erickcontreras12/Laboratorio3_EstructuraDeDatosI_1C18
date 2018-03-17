using Lab3EDI_1C18.DBContext;
using Lab3EDI_1C18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDA.Clases;

namespace Lab3EDI_1C18.Controllers
{
    public class PartidoController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;
        // GET: Partido
        public ActionResult Index()
        {
            return View(db.listaPartido.ToList());
        }

        public ActionResult IndexPorFecha()
        {
            return View(db.listaFechaPartido.ToList());
        }

        public ActionResult IndexPorNumero()
        {
            return View(db.listaNoPartido.ToList());
        }

        // GET: Partido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partido/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "noPartido,FechaPartido,Grupo,Pais1,Pais2,Estadio")] Partido partido)
        {
            try
            {
                // TODO: Add insert logic here
                db.arbolFechaPartido.FuncionObtenerLlave = ObtenerFecha;
                db.arbolFechaPartido.FuncionCompararLlave = CompararFecha;
                db.arbolNoPartido.FuncionObtenerLlave = ObtenerNumero;
                db.arbolNoPartido.FuncionCompararLlave = CompararNumero;

                db.listaFechaPartido.Clear();
                db.listaNoPartido.Clear();

                db.arbolFechaPartido.Insertar(partido);
                db.arbolNoPartido.Insertar(partido);
                db.listaPartido.Add(partido);

                db.arbolFechaPartido.EnOrden(RecorrerPartidoInFecha);
                db.arbolNoPartido.EnOrden(RecorrerPartidoInNumero);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        

        // GET: Partido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Partido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Partido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void RecorrerPartidoInFecha(Nodo<Partido> actual)
        {
            db.listaFechaPartido.Add(actual.valor);
        }

        public void RecorrerPartidoInNumero(Nodo<Partido> actual)
        {
            db.listaNoPartido.Add(actual.valor);
        }

        public static int ObtenerNumero(Partido dato)
        {
            return dato.noPartido;
        }

        public static DateTime ObtenerFecha(Partido dato)
        {
            return dato.FechaPartido;
        }

        public static int CompararNumero(int actual, int nuevo)
        {
            return actual.CompareTo(nuevo);
        }

        public static int CompararFecha(DateTime actual, DateTime nuevo)
        {
            return actual.CompareTo(nuevo);
        }
    }
}
