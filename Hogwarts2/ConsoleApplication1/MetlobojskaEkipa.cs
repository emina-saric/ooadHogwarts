using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MetlobojskaEkipa
    {
        public MetlobojskaEkipa(string ime_kuce, Ucenik kapiten) 
        {
            Ime_kuce = ime_kuce;
            Kapiten = kapiten;
        }
        string Ime_kuce { get; set; }
        Ucenik Kapiten { get; set;}
        int Bodovi {get; set;}
        
        public void PostaviKapitena(Ucenik ucenik)
        {
            if(ucenik.DajKucu()== Ime_kuce) Kapiten = ucenik;
        }
        public void EvidentirajBodove(int i) 
        {
            Bodovi += i;

        }
    }
}
