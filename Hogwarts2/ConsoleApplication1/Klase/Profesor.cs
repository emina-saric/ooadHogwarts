using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DAL {
        public class Profesor : Osoba
        {
            public Profesor(int id_profesor,string ime, string prezime, DateTime datum_rodjenja, string username, string password, int id_predmet, bool predstavnik_kuce)
                : base(ime, prezime, datum_rodjenja, username, password)
            {
                Id_profesor = id_profesor;
                Id_predmet = id_predmet;
                Predstavnik_kuce = predstavnik_kuce;
            }

            public bool Predstavnik_kuce { get; set; }
            public int Id_profesor { get; set; }
            public int Id_predmet { get; set; }


            public void PostaviZaPredstavnika()
            {
                Predstavnik_kuce = true;
            }
        }
    }
}
