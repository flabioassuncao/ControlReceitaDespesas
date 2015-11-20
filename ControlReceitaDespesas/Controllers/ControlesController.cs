using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlReceitaDespesas.DAL;
using ControlReceitaDespesas.Models;

namespace ControlReceitaDespesas.Controllers
{
    public class ControlesController : Controller
    {
        private RecDesContext db = new RecDesContext();

        // GET: Controles
        public ActionResult Index(string categoria, string datade, string dataate)
        {
            if(String.IsNullOrEmpty(categoria))
                return View(db.tbReceitasDespesas.ToList());
            else {
                DateTime dataDe = DateTime.Parse(datade.ToString());
                DateTime dataAte = DateTime.Parse(dataate);

                if (categoria == "Receitas")
                    return View(db.tbReceitasDespesas.Where(a => a.Data >= dataDe && a.Data <= dataAte
                && a.Categoria == "Receita").ToList());
                if (categoria == "Despesas")
                    return View(db.tbReceitasDespesas.Where(a => a.Data >= dataDe && a.Data <= dataAte
                && a.Categoria == "Despesa").ToList());
                else
                    return View(db.tbReceitasDespesas.Where(a => a.Data >= dataDe && a.Data <= dataAte).ToList());
            }
        }

        public ActionResult Relatorio(string categoria, string datade, string dataate)
        {
            if (String.IsNullOrEmpty(categoria))
               return View("Index");
            else
            {
                ViewBag.Tipo = categoria;
                ViewBag.DataDe = datade;
                ViewBag.DataAte = dataate;
                DateTime dataDe = DateTime.Parse(datade.ToString());
                DateTime dataAte = DateTime.Parse(dataate);
                return View(db.tbReceitasDespesas.Where(a => a.Data >= dataDe && a.Data <= dataAte).ToList());
            }
                          
        }
        
        // GET: Controles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecDes recDes = db.tbReceitasDespesas.Find(id);
            if (recDes == null)
            {
                return HttpNotFound();
            }
            return View(recDes);
        }

        // GET: Controles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecDesID,Valor,Categoria,Data,Observacao")] RecDes recDes)
        {
            if (ModelState.IsValid)
            {
                db.tbReceitasDespesas.Add(recDes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recDes);
        }

        // GET: Controles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecDes recDes = db.tbReceitasDespesas.Find(id);
            if (recDes == null)
            {
                return HttpNotFound();
            }
            return View(recDes);
        }

        // POST: Controles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecDesID,Valor,Categoria,Data,Observacao")] RecDes recDes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recDes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recDes);
        }

        // GET: Controles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecDes recDes = db.tbReceitasDespesas.Find(id);
            if (recDes == null)
            {
                return HttpNotFound();
            }
            return View(recDes);
        }

        // POST: Controles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecDes recDes = db.tbReceitasDespesas.Find(id);
            db.tbReceitasDespesas.Remove(recDes);
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

        public ActionResult GerarPdf(string categoria, string datade, string dataate)
        {
            ViewBag.Tipo = categoria;
            ViewBag.DataDe = datade;
            ViewBag.DataAte = dataate;
            DateTime dataDe = DateTime.Parse(datade.ToString());
            DateTime dataAte = DateTime.Parse(dataate.ToString());
            
            return new Rotativa.ViewAsPdf("Relatorio", db.tbReceitasDespesas.Where(a => a.Data >= dataDe && a.Data <= dataAte).ToList());
        }
    }
}
