using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Predmet
    {
        Predmet(string naziv, int casovi, Profesor profesor = null)
        {
            Naziv = naziv;
            Broj_casova = casovi;
            if (profesor != null) Predmetni_profesor = profesor;

        }
        string Naziv { get; set; }
        Profesor Predmetni_profesor { get; set; }
        int Broj_casova { get; set; }
        public void PromjeniProfesora(Profesor profesor)
        {
            Predmetni_profesor = profesor;
        }
    }
}
