using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Osoba
    {
       public Osoba(string ime, string prezime, DateTime datum_rodjenja, string username, string password) {
            Ime = ime;
            Prezime = prezime;
            Username = username;
            Password = password;
            Datum_rodjenja = datum_rodjenja;
        }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Datum_rodjenja { get; set; }
    }
}
