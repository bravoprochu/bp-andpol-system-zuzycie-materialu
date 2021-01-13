using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuzycieMaterialu.Zuzycie;

namespace ZuzycieMaterialu
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ProstokatBaseClass> obszycia = new List<ProstokatBaseClass>();
            obszycia.Add(new ProstokatBaseClass() { Dlugosc = 110, Szerokosc = 50, Name="nr1" });
            obszycia.Add(new ProstokatBaseClass() { Dlugosc = 40, Szerokosc = 40, Name = "nr2" });
            obszycia.Add(new ProstokatBaseClass() { Dlugosc = 250, Szerokosc = 20, Name = "nr3" });
            obszycia.Add(new ProstokatBaseClass() { Dlugosc = 110, Szerokosc = 5, Name = "nr4" });
            obszycia.Add(new ProstokatBaseClass() { Dlugosc = 170, Szerokosc = 110, Name = "nr5" });
            obszycia.Add(new ProstokatBaseClass() { Dlugosc = 100, Szerokosc = 10, Name = "nr6" });
            obszycia.Add(new ProstokatBaseClass() { Dlugosc = 210, Szerokosc = 95, Name = "nr7" });

            ProstokatParent pBaza = new ProstokatParent(1500, 120, obszycia);
        }
    }
}
