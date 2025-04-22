using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public class DanoDireto : Efeito
    {
        public DanoDireto(double modificador) :base(modificador)
        {
        }
        public override void Aplicar(Personagem alvo)
        {
            alvo.ReceberDano(Modificador);
        }
    }
}
