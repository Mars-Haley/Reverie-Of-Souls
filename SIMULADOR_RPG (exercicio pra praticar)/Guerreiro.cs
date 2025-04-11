using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
{
    public class Guerreiro : Personagem
    {
        public Guerreiro(string nome, double vida, double forca, int xp) : base(nome, vida, forca, xp) 
        {
            vida = 100;
            forca = 30.5;
        }
        public override void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Ataque com espada");
            double dano = (0.85 + rand.NextDouble() * 0.15) * Forca;
            inimigo.Vida -= dano;
            Console.WriteLine($"{Nome} deu {dano} dano em {inimigo.Nome}");
        }
    }
}
