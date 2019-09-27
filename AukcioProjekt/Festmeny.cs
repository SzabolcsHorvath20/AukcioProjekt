using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukcioProjekt
{
    class Festmeny
    {
        private string cim;
        private string festo;
        private string stilus;
        private int licitekSzama;
        private int legmagasabbLicit;
        private DateTime legutolsoLicitIdeje;
        private bool elkelt;

        public Festmeny(string cim, string festo, string stilus)
        {
            this.cim = cim;
            this.festo = festo;
            this.stilus = stilus;
        }

        public string Cim { get => cim;}
        public string Festo { get => festo;}
        public string Stilus { get => stilus;}
        public int LicitekSzama { get => licitekSzama;}
        public int LegmagasabbLicit { get => legmagasabbLicit; }
        public DateTime LegutolsoLicitIdeje { get => legutolsoLicitIdeje;}
        public bool Elkelt { get => elkelt; set => elkelt = value; }

        public void Licit()
        {
            if (this.elkelt == true)
            {
                Console.WriteLine("A festmény már elkelt!");
                Console.ReadKey();
            }
            else
            {
                if (this.licitekSzama == 0)
                {
                    this.legmagasabbLicit = 100;
                    this.licitekSzama = 1;
                    this.legutolsoLicitIdeje = DateTime.Now;
                }
                if (this.licitekSzama > 0)
                {
                    Licit(10);
                }
            }
        }
        public void Licit(int mertek)
        {
            if (mertek <=100 && mertek >= 10)
            {
                if (this.elkelt == true)
                {
                    Console.WriteLine("A festmény már elkelt!");
                    Console.ReadKey();
                }
                else
                {
                    if (this.licitekSzama == 0)
                    {
                        this.legmagasabbLicit = 100;
                        this.licitekSzama = 1;
                        this.legutolsoLicitIdeje = DateTime.Now;
                    }
                    if(this.licitekSzama > 0)
                    {
                        double szorzo = 1 + (mertek / 100.0);
                        double segeddouble = legmagasabbLicit * szorzo;
                        string seged = Convert.ToString(segeddouble);
                        string seged2 = seged.Substring(0, 2);
                        string seged3 = seged.Substring(2);
                        string seged4 = "";
                        for (int i = 0; i < seged3.Length; i++)
                        {
                            seged4 += "0";
                        }
                        int seged5 = Convert.ToInt32(seged2 + seged4);

                        this.legmagasabbLicit = seged5;
                        this.licitekSzama += 1;
                        this.legutolsoLicitIdeje = DateTime.Now;
                    }
                }
            }
            else
            {
                Console.WriteLine("Hibás érték!");
                Console.ReadKey();
            }
        }
        public override string ToString()
        {
            if (elkelt == true)
            {
                return this.festo + ": " + this.cim + "(" + this.stilus + ")\n" +
                    "elkelt\n" +
                    this.legmagasabbLicit + "$" + " -" +
                this.legutolsoLicitIdeje + " összesen: " + this.licitekSzama + " db)";
            }
            else
            {
                return this.festo + ": " + this.cim + "(" + this.stilus + ")\n" +
                    this.legmagasabbLicit + "$" + " -" +
                this.legutolsoLicitIdeje + " összesen: " + this.licitekSzama + " db)";
            }
        }
    }
}
