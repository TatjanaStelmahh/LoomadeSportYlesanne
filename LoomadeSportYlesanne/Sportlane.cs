using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoomadeSportYlesanne
{
    class Sportlane
    {

        public string Nimi;
        public int Distants;
        public double Aeg;

        public static List<Sportlane> Sportlased = new List<Sportlane>();

        public Sportlane(string nimi, int distants, double aeg)
        {
            Nimi = nimi;
            Distants = distants;
            Aeg = aeg;
            Sportlased.Add(this);
        }

    }
}

