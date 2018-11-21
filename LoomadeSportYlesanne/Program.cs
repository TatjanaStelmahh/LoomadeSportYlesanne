using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LoomadeSportYlesanne
{
    class Program
    {
        static void Main(string[] args)
        {

            //Sportlane s1 = new Sportlane("Siil", "300", "2");
            //Console.WriteLine($"{s1.Nimi} {s1.Distants} {s1.Aeg}");

            string failinimi = @"..\..\tulemused.txt";
            string[] loetudread = File.ReadAllLines(failinimi);

            foreach (var rida in loetudread)
            {
                string[] jupid = rida.Trim().Split(',');

                string nimi = jupid[0].Trim();
                int distants = int.Parse(jupid[1].Trim());
                double aeg = Sekunditeks(jupid[2].Trim());

                Sportlane uus = new Sportlane(nimi, distants, aeg) { };
            }

            IEnumerable<Sportlane> sorteeritud = Sportlane.Sportlased.OrderBy(sportlane => sportlane.Aeg);

            foreach (Sportlane sportlane in sorteeritud)
            {
                Console.WriteLine($"{sportlane.Nimi} {sportlane.Distants} {sportlane.Aeg}");
            }

            Console.WriteLine("\nkoige kiirem oli");

            //Console.WriteLine(
            //    sorteeritud
            //    .Where(x => x.Distants == 100)
            //    .First()
            //    .Nimi
            //    );

            //Console.WriteLine(
            //    sorteeritud
            //    .Where(x => x.Distants == 100)
            //    .First()
            //    .Aeg
            //    );

            Sportlane kiireimsprinter =
                sorteeritud
                .Where(x => x.Distants == 100)
                .First();

            Console.WriteLine($"{kiireimsprinter.Nimi}, aeg: {kiireimsprinter.Aeg} sekundit\n");

            List<Sportlane> kiireimad100jooks = sorteeritud
                .Where(sportlane => sportlane.Distants == 100)
                .Take(3)
                .ToList();

            Console.WriteLine("Koige kiiremad 100m jooksus");

            foreach (Sportlane sportlane in kiireimad100jooks)
            {
                Console.WriteLine($"{sportlane.Nimi}, aeg: {sportlane.Aeg} sekundit");
            }

            List<Sportlane> kiireimad200jooks = sorteeritud
                .Where(sportlane => sportlane.Distants == 200)
                .Take(3)
                .ToList();

            Console.WriteLine("\nKoige kiiremad 200m jooksus");

            foreach (Sportlane sportlane in kiireimad200jooks)
            {
                Console.WriteLine($"{sportlane.Nimi}, aeg: {sportlane.Aeg} sekundit");
            }

            List<Sportlane> kiireimad400jooks = sorteeritud
                .Where(sportlane => sportlane.Distants == 400)
                .Take(3)
                .ToList();

            Console.WriteLine("\nKoige kiiremad 400m jooksus");

            foreach (Sportlane sportlane in kiireimad400jooks)
            {
                Console.WriteLine($"{sportlane.Nimi}, aeg: {sportlane.Aeg} sekundit");
            }

            //Console.WriteLine(
            //    sorteeritud
            //    .Where(sportlane => sportlane.Distants == 100)
            //    .Take(3)
            //    .ToList()[0]
            //    .Nimi
            //    );




            double Sekunditeks(string aeg)
            {
                var nullidega =
                    ("0:0:" + aeg) // lisab ette mõttetud "0:"-d
                    .Split(':')    // teeb stringi massiiviks
                    .Reverse()     // pöörab massiivi tagurpidi
                    .Take(3)       // võtab kolm esimest (ehk siis viimast)
                    .Reverse();    // pöörab uuesti tagurpidi

                string uusnullidega = string.Join(":", nullidega);

                TimeSpan kestus = TimeSpan.Parse(uusnullidega);

                return kestus.TotalSeconds;
            }
        }
    }
}
