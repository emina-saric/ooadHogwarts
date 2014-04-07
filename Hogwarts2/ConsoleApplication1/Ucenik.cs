using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Ucenik : Osoba
    {
        Ucenik(string ime, string prezime, DateTime datum_rodjenja, string username, string password, int godina_studija, Kuca _kuca,bool prefekt)
            : base(ime, prezime, datum_rodjenja, username, password)
        {
            Godina_studija = godina_studija;
            kuca = _kuca;
            Prefekt = prefekt;
        }
        int Godina_studija { get; set; }
        Kuca kuca { get; set; }
        bool Prefekt { get; set; }
        
        public void PovecajGodinuStudija()
        {
            if (Godina_studija > 1 && Godina_studija < 7) Godina_studija++;
        }
        public void PostaviZaPrefekta()
        {
            if (Godina_studija > 4) Prefekt = true;
        }
        public string DajKucu() 
        {
            return kuca.Ime_kuce;
        }
    }
}
