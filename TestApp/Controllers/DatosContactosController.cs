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
    public class DatosContactosController : Controller
    {
        private TestAppContext db = new TestAppContext();

        // GET: DatosContactos
        public ActionResult Index()
        {
            var datosContactoes = db.DatosContactoes.Include(d => d.DatosPersonales);
            return View(datosContactoes.ToList());
        }

        // GET: DatosContactos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosContacto datosContacto = db.DatosContactoes.Find(id);
            if (datosContacto == null)
            {
                return HttpNotFound();
            }
            return View(datosContacto);
        }

        // GET: DatosContactos/Create
        //public ActionResult Create()
        //{
        //    ViewBag.DatosPersonalesId = new SelectList(db.DatosPersonales, "Id", "Nombre");
        //    return View();
        //}

        // GET: Credits/Create
        public ActionResult Create(int? id)
        {
            var Id = Convert.ToInt32(id);

            

            

            DatosContacto model = new DatosContacto();
            model.DatosPersonalesId = Id;

            return View(model);
        }
        // POST: DatosContactos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Telefono,Correo,DatosPersonalesId")] DatosContacto datosContacto)
        {
            if (ModelState.IsValid)
            {
                db.DatosContactoes.Add(datosContacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DatosPersonalesId = new SelectList(db.DatosPersonales, "Id", "Nombre", datosContacto.DatosPersonalesId);
            return View(datosContacto);
        }

        // GET: DatosContactos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosContacto datosContacto = db.DatosContactoes.Find(id);
            if (datosContacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.DatosPersonalesId = new SelectList(db.DatosPersonales, "Id", "Nombre", datosContacto.DatosPersonalesId);
            return View(datosContacto);
        }

        // POST: DatosContactos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Telefono,Correo,DatosPersonalesId")] DatosContacto datosContacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosContacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DatosPersonalesId = new SelectList(db.DatosPersonales, "Id", "Nombre", datosContacto.DatosPersonalesId);
            return View(datosContacto);
        }

        // GET: DatosContactos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosContacto datosContacto = db.DatosContactoes.Find(id);
            if (datosContacto == null)
            {
                return HttpNotFound();
            }
            return View(datosContacto);
        }

        // POST: DatosContactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosContacto datosContacto = db.DatosContactoes.Find(id);
            db.DatosContactoes.Remove(datosContacto);
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
