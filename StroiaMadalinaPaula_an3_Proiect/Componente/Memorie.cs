using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect.Componente
{
    [Serializable]
    class Memorie:Componenta
    {
        public string Tip { get; set; }
        public int Capacitate { get; set; }
        public int Frecventa { get; set; }

        public Memorie() : base() { }
        public Memorie(string producator, string model, int an, string tip, int capacitate, int frecventa)
            : base(producator, model, an)
        {
            Tip = tip;
            Capacitate = capacitate;
            Frecventa = frecventa;
        }

        public override double garantieComponenta()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Componenta: Memorie. Producator: " + Producator + ", model: " + Model + ", an fabricatie: " + AnFabricatie +
                ", tip: " + Tip + ", capacitate: " + Capacitate + " GB, frecventa: " + Frecventa + " MHz.";
        }

    }
}
