using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect.Componente
{
    [Serializable]
    class PlacaVideo:Componenta
    {
        public string Serie { get; set; }
        public int FrecventaProcesor { get; set; }
        public int CapacitateMemorie { get; set; }
        public string Porturi { get; set; }

        public PlacaVideo() : base() { }
        public PlacaVideo(string producator, string model, int an, string serie, int frecv, int dimen, string port)
            : base(producator, model, an)
        {
            Serie = serie;
            FrecventaProcesor = frecv;
            CapacitateMemorie = dimen;
            Porturi = port;
        }

        public override double garantieComponenta()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Componenta: Placa Video. Producator: " + Producator + ", model: " + Model + ", an fabricatie: " + AnFabricatie +
                ", serie: " + Serie + ", frevcenta procesor: " + FrecventaProcesor + " MHz, capacitate " +
                "memorie: " + CapacitateMemorie + " GB, porturi: " + Porturi +".";
        }
    }
}
