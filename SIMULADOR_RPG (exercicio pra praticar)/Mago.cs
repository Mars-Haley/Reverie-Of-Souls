using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
{
    public class Mago : Personagem
    {
        public Mago(string nome, double vida, double forca, int xp) : base(nome, vida, forca, xp)
        {
            vida = 85;
            forca = 30;
        }
        public override void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Ataque com magia");
            double dano = (0.5 + rand.NextDouble() * 1.0) * Forca;
            inimigo.Vida -= dano;
            Console.WriteLine($"{Nome} deu {dano:F2} dano em {inimigo.Nome}");
        }
    }
}
