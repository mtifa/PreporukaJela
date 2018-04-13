using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PreporukaJela.Models;

namespace PreporukaJela.Controllers
{
    [Authorize]
    public class JeloesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            var jela = db.Jela.Include(j => j.Restoran);
            return View(await jela.ToListAsync());
        }

        public ActionResult Create()
        {
            ViewBag.RestoranId = new SelectList(db.Restorani, "Id", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Naziv,Cijena,RestoranId")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                db.Jela.Add(jelo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RestoranId = new SelectList(db.Restorani, "Id", "Naziv", jelo.RestoranId);
            return View(jelo);
        }

    }
}
