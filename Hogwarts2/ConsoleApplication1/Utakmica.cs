using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Utakmica
    {
        Utakmica(DateTime termin, MetlobojskaEkipa tim1, MetlobojskaEkipa tim2, int bod1 = 0, int bod2 = 0, bool odigrana = false)
        {
            Termin = termin;
            Tim1 = tim1;
            Tim2 = tim2;
            Bodovi1 = bod1;
            Bodovi2 = bod2;
            Odigrana = odigrana;
        }
        DateTime Termin { get; set; }
        MetlobojskaEkipa Tim1 { get; set; }
        MetlobojskaEkipa Tim2 { get; set; }
        int Bodovi1 { get; set; }
        int Bodovi2 { get; set; }
        bool Odigrana { get; set; }

        public void OdigranaUtakmica(int bod1, int bod2)
        {
            if (bod1 > 0 && bod2 > 0 && Termin < DateTime.Now)
            {
                Bodovi1 = bod1;
                Bodovi2 = bod2;
                Odigrana = true;
                Tim1.EvidentirajBodove(bod1);
                Tim2.EvidentirajBodove(bod2);
            }
        }
        public void PromjeniTermin(DateTime novi_termin)
        {
            if (novi_termin > DateTime.Now)
            {
                Termin = novi_termin;
            }
        }
    }
}
