using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZuzycieMaterialu.Zuzycie
{

    public class ProstokatBaseClass
    {
        public ProstokatBaseClass(int posX = 0, int posY = 0)
        {
            PosStartX = posX;
            PosStartY = posY;
        }
        public string Name { get; set; }
        public int Dlugosc { get; set; }
        public int PosStartX { get; set; }
        public int PosStartY { get; set; }
        public int PosEndX {get { return this.PosStartX+this.Dlugosc; }}
        public int PosEndY { get { return this.PosStartY+this.Szerokosc; }}
        public int Szerokosc { get; set; }
        public double PolePowierzchni
        {
            get { return this.Dlugosc*this.Szerokosc; }
        }
    }


    public class ProstokatParent:ProstokatBaseClass
    {
        public ProstokatParent(int dl, int szer,  List<ProstokatBaseClass> ListaProstokatowDoPrzeliczenia)
        {
            this.Dlugosc = dl;
            this.Szerokosc = szer;
            this.ProstokatyDoPrzeliczenia = ListaProstokatowDoPrzeliczenia;
            this.PosStartX = 100;
            PosStartY = 200;
            Name = "bazaaa";
            Init();
        }

        public double PoleSumaOdpad { get { return SumaPowierzchniWm2(ProstokatyOdpad); } }
        public double PoleSumaPasujace { get { return SumaPowierzchniWm2(ProstokatyPasujace); } }
        public double PoleSumaDoPrzeliczenia { get { return SumaPowierzchniWm2(ProstokatyDoPrzeliczenia); } }
        public double OdrzutPowierzchnia { get; set; }






        private void Init()
        {
            //foreach (var item in ProstokatyDoPrzeliczenia)
            //{
            //    ProstokatyOdrzutuWylicz(item);
            //}
            //ProstokatyOdrzutuWylicz(ProstokatyDoPrzeliczenia.Select(s=>s).OrderByDescending(o=>o.Dlugosc).First(),ProstokatyDoPrzeliczenia);
            Rozmiesc((ProstokatBaseClass)this, ProstokatyDoPrzeliczenia);
        }

        private double SumaPowierzchniWm2(ICollection<ProstokatBaseClass> ListToCount)
        {
            if (ListToCount.Count() == 0) { return 0; }
            double result = 0;
            result = ListToCount.Sum(s => s.PolePowierzchni);
            return result / 10000;
        }

        private BelkaRozmieszczenie ProstokatPoukladaj() {

            BelkaRozmieszczenie br = new BelkaRozmieszczenie();




            return br;
        }

        private void Rozmiesc(ProstokatBaseClass baza, List<ProstokatBaseClass> listaDoUlozenia)
        {


        }

        private List<ProstokatBaseClass> ProstokatyOdrzutuWylicz(ProstokatBaseClass child, List<ProstokatBaseClass> listaDoUlozenia)
        {
            ProstokatBaseClass baza = (ProstokatBaseClass)this;

            List<ProstokatBaseClass> odrzutAlternatywy = new List<ProstokatBaseClass>();

            ProstokatBaseClass pRH = new ProstokatBaseClass();
            ProstokatBaseClass pRV = new ProstokatBaseClass();
            ProstokatBaseClass pTH = new ProstokatBaseClass();
            if (child.Dlugosc < baza.Dlugosc && child.Szerokosc < baza.Szerokosc) {
                pRH.Name = baza.Name +"-"+ child.Name + "-pRH";
                pRH.Dlugosc = baza.Dlugosc - child.Dlugosc;
                pRH.Szerokosc = child.Szerokosc;
                pRH.PosStartX = baza.PosStartX+child.Dlugosc;
                pRH.PosStartY = baza.PosStartY;

                pRV.Name = baza.Name + "-" + child.Name + "-pRV";
                pRV.Dlugosc = pRH.Dlugosc;
                pRV.Szerokosc = baza.Szerokosc;
                pRV.PosStartX = pRH.PosStartX;
                pRV.PosStartY = pRH.PosStartY;


                pTH.Name = baza.Name + "-" + child.Name + "-PTH";
                pTH.Dlugosc = baza.Dlugosc;
                pTH.Szerokosc = baza.Szerokosc - child.Szerokosc;
                pTH.PosStartX = baza.PosStartX;
                pTH.PosStartY = baza.PosStartY + child.Szerokosc;

                odrzutAlternatywy.Add(pRH);
                odrzutAlternatywy.Add(pRV);
                odrzutAlternatywy.Add(pTH);

            } else {
                throw new Exception("Do dupy, szerokość/długość child jest większa od szerokość/długość bazy "+child.Name);
            }

            Console.WriteLine("---Start: baza: "+baza.Name);
            Console.WriteLine(OpisProstokata.Wymiary(baza)+" "+OpisProstokata.Pozycja(baza));
            Console.WriteLine("---child: "+ child.Name);
            Console.WriteLine(OpisProstokata.Wymiary(child) + " " + OpisProstokata.Pozycja(child));
            Console.WriteLine("_____________________");
            foreach (var item in odrzutAlternatywy)
            {       
                var p= (ProstokatBaseClass)item;
                Console.WriteLine(item.Name);
                Console.WriteLine(OpisProstokata.Wymiary(p)+" "+OpisProstokata.Pozycja(p));
            }
            Console.WriteLine("---------------------");


            while (listaDoUlozenia.Any(a=>a.Szerokosc<=pTH.Szerokosc))
            {

                Console.WriteLine(OpisProstokata.Wymiary((ProstokatBaseClass)listaDoUlozenia.First()));
                pTH.Szerokosc -= listaDoUlozenia.First().Szerokosc;

                listaDoUlozenia.Remove(listaDoUlozenia.First());
            }



            return odrzutAlternatywy;
        }


        private List<ProstokatBaseClass> ProstokatyDoPrzeliczenia { get; set; }
        private List<ProstokatBaseClass> ProstokatyPasujace { get; set; }
        private List<ProstokatBaseClass> ProstokatyOdpad { get; set; }

    }

    class BelkaRozmieszczenie
    {
        public int Id { get; set; }
        public List<ProstokatBaseClass> Umieszczone { get; set; }
        public List<ProstokatBaseClass> Odrzut { get; set; }
        public List<ProstokatBaseClass> Inne { get; set; }

    }


    public class ProstokatListaWynikow
    {
        private List<ProstokatBaseClass> ProstokatyDoPrzeliczenia { get; set; }
        private List<ProstokatBaseClass> ProstokatyPasujace { get; set; }
        private List<ProstokatBaseClass> ProstokatyOdpad { get; set; }
    }
}