using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Predmet
    {
        Predmet(string naziv, Profesor profesor = null)
        {
            Naziv = naziv;
            if (profesor != null) Predmetni_profesor = profesor;

        }
        string Naziv { get; set; }
        Profesor Predmetni_profesor { get; set; }
    }
}
