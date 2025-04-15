using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public interface IEfeito
    {
        public void Aplicar(Personagem alvo);
    }
}
