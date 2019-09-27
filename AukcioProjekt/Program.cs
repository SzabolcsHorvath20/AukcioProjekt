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
            }
        }
        static void Legdragabb()
        {

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
            Console.ReadKey();
        }
    }
}
