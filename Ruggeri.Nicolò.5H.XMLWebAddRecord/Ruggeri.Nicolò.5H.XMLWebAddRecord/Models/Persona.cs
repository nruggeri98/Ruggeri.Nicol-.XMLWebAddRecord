using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Ruggeri.Nicolò._5H.XMLWebAddRecord.Models
{
    public class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Stato { get; set; }

        public Persona()
        { }
        public Persona(XElement riga)
        {
            Nome = riga.Attribute("Nome").Value;
            Cognome = riga.Attribute("Cognome").Value;
            Stato = riga.Attribute("Stato").Value;
        }
    }
}