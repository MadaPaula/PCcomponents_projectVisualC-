using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroiaMadalinaPaula_an3_Proiect
{
    class FrecventaException:Exception
    {
        public string Frecventa { get; set; }
        public FrecventaException() { }
    }
}
