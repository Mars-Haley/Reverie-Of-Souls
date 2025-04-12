using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
{
    public class Arqueiro : Personagem
    {
        public Arqueiro(string nome) : base(nome)
        {
            Vida = 80;
            Forca = 25;
        }

        public override void Atacar(Personagem inimigo)
        {
            double r = rand.NextDouble();
            double fator = Math.Sqrt(r);
            double dano = (0.6 + fator * 0.4) * Forca ;
            inimigo.Vida -=dano;
            if (inimigo.Vida < 0) inimigo.Vida = 0;
            Console.WriteLine("Ataque com flechas");
            Console.WriteLine($"{Nome} deu {dano:F2} dano em {inimigo.Nome}");
            Console.WriteLine($"vida do inimigo: {inimigo.Vida:F2}");
            
            Console.ReadKey();

        }
    }
}
