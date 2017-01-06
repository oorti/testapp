using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class DatosPersonalesController : Controller
    {
        private TestAppContext db = new TestAppContext();

        // GET: DatosPersonales
        public ActionResult Index()
        {
            var datosPersonales = db.DatosPersonales.Include(d => d.Estado);
            return View(datosPersonales.ToList());
        }

        // GET: DatosPersonales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Nombre");
            return View();
        }

        // POST: DatosPersonales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Direccion,EstadoId,Activo")] DatosPersonales datosPersonales)
        {
            if (ModelState.IsValid)
            {
                db.DatosPersonales.Add(datosPersonales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Nombre", datosPersonales.EstadoId);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Nombre", datosPersonales.EstadoId);
            return View(datosPersonales);
        }

        // POST: DatosPersonales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Direccion,EstadoId,Activo")] DatosPersonales datosPersonales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosPersonales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Nombre", datosPersonales.EstadoId);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            return View(datosPersonales);
        }

        // POST: DatosPersonales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            db.DatosPersonales.Remove(datosPersonales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
