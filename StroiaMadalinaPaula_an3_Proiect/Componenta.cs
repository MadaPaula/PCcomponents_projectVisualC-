using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect
{
    [Serializable]
    public abstract class Componenta
    {
        public string Producator { get; set; }
        public string Model { get; set; }
        public int AnFabricatie {get; set;}

        public Componenta() { }
        public Componenta(string producator, string model, int an)
        {
            Producator = producator;
            Model = model;
            AnFabricatie = an;
        }

        public abstract double garantieComponenta();

    }
}
