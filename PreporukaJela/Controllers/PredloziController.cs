using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PreporukaJela.Models;

namespace PreporukaJela.Controllers
{
    [Authorize]
    public class PredloziController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Random rndJelo;
        public int result;
        public string nazivJela;
        public string nazivRestorana;
        public decimal cijenaJela;
        public string adresaRestorana;
        public string telefonRestorana;
        public ActionResult Index()
        {
            RandomJela();
            return View();
        }
        public void RandomJela()
        {
            rndJelo = new Random();
            result = rndJelo.Next(1, db.Jela.Count() + 1);
            foreach (var item in db.Jela.Include(j => j.Restoran))
            {
                if(item.Id == result)
                {
                    nazivJela = item.Naziv;
                    nazivRestorana = item.Restoran.Naziv;
                    cijenaJela = item.Cijena;
                    adresaRestorana = item.Restoran.Adresa;
                    telefonRestorana = item.Restoran.Telefon;
                }
            }
            ViewData["vorslag"] = "Jelo: " + nazivJela + "</br>" + "Cijena: " + cijenaJela + " BAM" + "</br>" + 
                "Restoran: " + nazivRestorana + "</br>" + "Adresa restorana: " + adresaRestorana + "</br>" + "Telefon restorana: "
                + telefonRestorana;
        }
    }
}
