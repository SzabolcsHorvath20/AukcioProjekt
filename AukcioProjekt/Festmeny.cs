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
    }
}
