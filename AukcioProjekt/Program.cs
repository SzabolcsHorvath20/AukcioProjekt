using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AukcioProjekt
{ 
    class Program
    {
        static List<Festmeny> Festmenyek = new List<Festmeny>();
        static void Feltoltes()
        {
            Festmenyek.Add(new Festmeny("Krumplistészta", "VincentVanPetofi","Impresszionizmus"));
            Festmenyek.Add(new Festmeny("Fák", "József", "Minimalizmus"));
        }
        static void Bekeres()
        {
            Console.WriteLine("Hány festményt szeretne eladni?");
            int bekert = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < bekert; i++)
            {
                string cim = Console.ReadLine();
                string festo = Console.ReadLine();
                string stilus = Console.ReadLine();
                Festmenyek.Add(new Festmeny(cim, festo, stilus));
            }
        }
        static void Beolvasas()
        {
            StreamReader olvas = new StreamReader("festmenyek.csv");
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] split = sor.Split(';');
                Festmenyek.Add(new Festmeny(split[0], split[1], split[2]));
            }
        }
        static void Licitalas()
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                Festmenyek[rnd.Next(0, Festmenyek.Count)].Licit();
            }
        }
        static void UserLicitalas()
        {
            int sorszam;
            do
            {
                Console.WriteLine("Hanyadik festményre szeretne licitálni?");
                sorszam = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (sorszam > Festmenyek.Count - 1)
                    {
                        while (sorszam <= Festmenyek.Count - 1)
                        {
                            Console.WriteLine("Nincs ilyen festmény, kérem adjon meg egy új sorszámot!");
                            sorszam = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    TimeSpan ts = DateTime.Now - Festmenyek[sorszam - 1].LegutolsoLicitIdeje;
                    if (ts.TotalMinutes > 2)
                    {
                        Festmenyek[sorszam - 1].Elkelt = true;
                    }
                    if (Festmenyek[sorszam - 1].Elkelt == true)
                    {
                        while (Festmenyek[sorszam - 1].Elkelt == false)
                        {
                            Console.WriteLine("A festmény elkelt, kérem adjon meg egy új sorszámot!");
                            sorszam = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    
                    Console.WriteLine("Kérem adja meg, hogy milyen mértékkel szeretne licitálni!");
                    string mérték = Console.ReadLine();
                    if (mérték == "")
                    {
                        Festmenyek[sorszam-1].Licit(10);
                    }
                    else
                    {
                        Festmenyek[sorszam - 1].Licit(Convert.ToInt32(mérték));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Nem számot adott meg, a program leáll.");
                }
            } while (sorszam != 0);
            foreach (var item in Festmenyek)
            {
                if (item.LicitekSzama > 0)
                {
                    item.Elkelt = true;
                }
                if (item.LicitekSzama == 0)
                {
                    item.Elkelt = false;
                }
            }
        }
        static void Legdragabb()
        {
            Festmeny seged = Festmenyek[0];
            Console.WriteLine("A legdrágábban eladott festmény:");
            foreach (var item in Festmenyek)
            {
                if (item.LegmagasabbLicit > seged.LegmagasabbLicit)
                {
                    seged = item;
                }
            }

        }
        static void Tizneltobb()
        {
            int seged = 0;
            foreach (var item in Festmenyek)
            {
                if (item.LicitekSzama > 10)
                {
                    seged++;
                }
            }
            Console.WriteLine(seged + " olyan festmény van amire 10-nél többször licitáltak.");
        }
        static void NemKeltEl()
        {
            int seged = 0;
            foreach (var item in Festmenyek)
            {
                if (item.Elkelt == false)
                {
                    seged++;
                }
            }
            Console.WriteLine(seged + " festmény van ami nem kelt el.");
        }
        static void Rendezes()
        {
            Festmenyek.Sort((y,x) => x.LegmagasabbLicit.CompareTo(y.LegmagasabbLicit));
            foreach (var item in Festmenyek)
            {
                Console.WriteLine(item);
            }
        }
        static void Fajlbairas()
        {
            StreamWriter iras = new StreamWriter("festmenyek_rendezett.csv");
            foreach (var item in Festmenyek)
            {
                iras.WriteLine("{0},{1},{2}",item.Cim, item.Festo, item.Stilus);
            }
            iras.Close();
        }
        static void Main(string[] args)
        {
            Feltoltes();
           // Bekeres();
            Beolvasas();
            Licitalas();
            UserLicitalas();
            foreach (var item in Festmenyek)
            {
                Console.WriteLine(item);
            }
            Legdragabb();
            Tizneltobb();
            NemKeltEl();
            Rendezes();
            Fajlbairas();
            Console.ReadKey();
        }
    }
}
