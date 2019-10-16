using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect.Componente
{
    [Serializable]
    class Procesor:Componenta
    {
        public int NumarNuclee { get; set; }
        public int NumarThreads { get; set; }
        public string Frecventa { get; set; }
        public int MemorieMax { get; set; }

        public Procesor() : base() { }
        public Procesor(string producator, string model, int an, int nrN, int nrTh, string frecventa, int memorieMax)
            : base(producator, model, an)
        {
            NumarNuclee = nrN;
            NumarThreads = nrTh;
            Frecventa = frecventa;
            MemorieMax = memorieMax;
        }
        
        public override double garantieComponenta()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Componenta: Procesor. Producator: " + Producator + ", model: " + Model + ", an fabricatie: " + AnFabricatie +
                ", numar nuclee: " + NumarNuclee + ", numar threads: " + NumarThreads + ", frecventa: " + Frecventa +
                " MHz, memorie maxima: " + MemorieMax + "GB.";
        }
    }
}
