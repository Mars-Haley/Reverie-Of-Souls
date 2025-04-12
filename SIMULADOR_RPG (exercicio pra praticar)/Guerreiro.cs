using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
{
    public class Guerreiro : Personagem
    {
        public Guerreiro(string nome) : base(nome) 
        {
            Vida = 100;
            Forca = 30.5;
        }
        public override void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Ataque com espada");
            double dano = (0.85 + rand.NextDouble() * 0.15) * Forca;
            inimigo.Vida -= dano;
            if (inimigo.Vida < 0) inimigo.Vida = 0;
            Console.WriteLine($"{Nome} deu {dano:F2} dano em {inimigo.Nome}");
            if(inimigo.Vida > 0)
            Console.WriteLine($"vida de {inimigo.Nome}: {inimigo.Vida:F2}");
            else
            Console.WriteLine("O inimigo morreu!");
            
            Console.ReadKey();

        }
    }
}
