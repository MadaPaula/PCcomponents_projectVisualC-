using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect.Componente
{
    [Serializable]
    class HardDisk:Componenta
    {
        public int Capacitate { get; set; }
        public int Viteza { get; set; }

        public HardDisk() : base() { }

        public HardDisk(string producator, string model, int an, int capacitate, int viteza)
            : base(producator, model, an)
        {
            Capacitate = capacitate;
            Viteza = viteza;
        }

        public override double garantieComponenta()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Componenta: Hard Disk. Producator: " + Producator + ", model: " + Model + ", an fabricatie: " + AnFabricatie +
                ", capacitate " + Capacitate + " TB, viteza: " + Viteza + "RPM.";
        }

    }
}
