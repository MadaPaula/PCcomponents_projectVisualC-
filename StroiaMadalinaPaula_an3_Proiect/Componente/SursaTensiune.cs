using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect.Componente
{
    [Serializable]
    class SursaTensiune:Componenta
    {
        public int Putere { get; set; }
        public int Conectori { get; set; }

        public SursaTensiune() : base() { }
        public SursaTensiune(string producator, string model, int an, int putere, int conectori)
            : base(producator, model, an)
        {
            Putere = putere;
            Conectori = conectori;
        }
        
        public override double garantieComponenta()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Componenta: Sursa Tensiune. Producator: " + Producator + ", model: " + Model + ", an fabricatie: " + AnFabricatie +
                ", putere: " + Putere + " W, numar conectori" + Conectori + ".";
        }
    }
}
