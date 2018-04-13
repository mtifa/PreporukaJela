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
    public class RestoraniController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Restorani.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Naziv,Adresa,Telefon")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                db.Restorani.Add(restoran);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(restoran);
        }
    }
}
