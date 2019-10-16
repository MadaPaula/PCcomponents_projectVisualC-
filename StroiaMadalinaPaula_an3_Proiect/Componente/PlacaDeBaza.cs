using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect
{
    [Serializable]
    class PlacaDeBaza : Componenta
    {
        public string Format { get; set; }
        public int NumarSloturi { get; set; }
        public int Conectori { get; set; }

        public PlacaDeBaza() : base() { }
        public PlacaDeBaza(string producator, string model, int an, string format, int nrSloturi, int conectori)
            : base(producator, model, an)
        {
            Format = format;
            NumarSloturi = nrSloturi;
            Conectori = conectori;
        }

        public override double garantieComponenta()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Componenta: Placa de baza. Producator: " + Producator + ", model: " + Model + ", an fabricatie: " + AnFabricatie +
                ", format: " + Format + ", numar sloturi: " + NumarSloturi + ", numar conectori: " + Conectori + ".";
        }

    }
}
