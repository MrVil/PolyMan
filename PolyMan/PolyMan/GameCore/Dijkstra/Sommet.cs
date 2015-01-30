using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolyMan.GameCore.Dijkstra
{
    public class Sommet
    {
        public const int INFINI = 1000000;
        public int Potentiel;
        public bool Marque;
        public Coord Suivant;

        public Sommet()
        {
            Potentiel = INFINI;
            Marque = false;
            Suivant = null;
        }
    }
}
