using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG.Magias
{
    public class Magia
    {
        public string Nome { get; }
        public List<IEfeito> Efeitos { get; }
        public bool AlvoEhInimigo {get;}

        public Magia(string nome, List<IEfeito> efeitos, bool alvoEhInimigo)
        {
            Nome = nome;
            Efeitos = efeitos;
            AlvoEhInimigo = alvoEhInimigo;
        }

        public void Usar(Personagem alvo) 
        {
            foreach (var efeito in Efeitos) 
            {
                efeito.Aplicar(alvo);
               
            }
            Personagem.Digitar($"A magia {Nome} foi aplicada em {alvo.Nome}");
            Console.ReadKey();

        }
    }
}
