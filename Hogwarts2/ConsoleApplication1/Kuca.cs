using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Kuca
    {
        public Kuca(string ime, int bodovi)
        {
            Ime_kuce = ime;
            Bodovi = bodovi;
        }
        public string Ime_kuce { get; set; }
        int Bodovi { get; set; }
        List<Ucenik> _ucenici_kuce = new List<Ucenik>();
        List<Ucenik> _prefekti = new List<Ucenik>();
        Profesor Predstavnik_profesor;

        public void DodajUcenika(Ucenik ucenik) {
            if (!_ucenici_kuce.Contains(ucenik)) _ucenici_kuce.Add(ucenik);
        }
        public void DodajPrefekta(Ucenik ucenik)
        {
                if (!_prefekti.Contains(ucenik)) _prefekti.Add(ucenik);
        }
        public void PostaviPredstavnika(Profesor profesor) 
        {
            
                Predstavnik_profesor = profesor;
        }
        public void OduzmiBodove(int i) 
        {
            if (i > 0)
            {
                if (Bodovi < i) Bodovi = 0;
                else Bodovi -= i;
            }
        }
        public void DodajBodove(int i)
        {
            if (i > 0) Bodovi += i;

        }
    }

}
