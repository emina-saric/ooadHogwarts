using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Profesor : Osoba
    {
        Profesor(string ime, string prezime, DateTime datum_rodjenja, string username, string password, Predmet _predmet, bool predstavnik_kuce) : base(ime, prezime, datum_rodjenja, username, password) {
            predmet = _predmet;
            Predstavnik_kuce = predstavnik_kuce;
        }
        Predmet predmet { get; set; }
        bool Predstavnik_kuce { get; set; }

        public void PromjeniPredmet(Predmet predmet1)
        {
            predmet = predmet1;
        }
        public void PostaviZaPredstavnika() 
        {
            Predstavnik_kuce = true;
        }
    }
}
