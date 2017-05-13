using Ruggeri.Nicolò._5H.XMLWebAddRecord.Models;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Ruggeri.Nicolò._5H.XMLWebAddRecord.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            string nomeFile = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Dati.xml");
            XElement data = XElement.Load(nomeFile);
            var Persone = from p in data.Element("persone").Elements("persona")
                          select new Persona(p);
            return View(Persone);
        }
        public ActionResult Aggiungi()
        {
            return View();
        }
        public ActionResult Salva()
        {
            string nome = Request.Form["Nome"];
            string cognome = Request.Form["Cognome"];
            string stato = Request.Form["Stato"];
            XDocument doc = XDocument.Load(HostingEnvironment.MapPath(@"~/App_Data/Dati.xml"));
            XElement persona = new XElement("persona", "");
            XAttribute Xnome = new XAttribute("Nome", nome);
            XAttribute Xcognome = new XAttribute("Cognome", cognome);
            XAttribute Xstato = new XAttribute("Stato", stato);
            persona.Add(Xnome, Xcognome, Xstato);
            doc.Element("root").Element("persone").Add(persona);
            doc.Save(HostingEnvironment.MapPath(@"~/App_Data/Dati.xml"));
            return RedirectToAction("Index", "Default");
        }
    }
}