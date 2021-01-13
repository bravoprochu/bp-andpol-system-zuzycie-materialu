using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuzycieMaterialu.Zuzycie
{
    public static class OpisProstokata
    {
        public static string Wymiary (ProstokatBaseClass prostokat) {
            return $"dł:{prostokat.Dlugosc.ToString()}, Szer: {prostokat.Szerokosc.ToString()}";
        }

        public static string Pozycja(ProstokatBaseClass prostokat) {
            return $"startX: {prostokat.PosStartX}, startY: {prostokat.PosStartY} || endX: {prostokat.PosEndX}, endY: {prostokat.PosEndY}";
        }
    
    }
}
