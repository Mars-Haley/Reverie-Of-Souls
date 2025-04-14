using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public class Cura : Efeito
    {
        public double Modificador { get; set; }
        public Cura(double modificador)
        {
            Modificador = modificador;
        }

        
    }
}
