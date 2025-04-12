using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
{
    public class Mago : Personagem
    {
        public Mago(string nome) : base(nome)
        {
            Vida = 85;
            Forca = 30;
        }
        public override void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Ataque com magia");
            double dano = (0.5 + rand.NextDouble() * 1.0) * Forca;
            inimigo.Vida -= dano;
            Console.WriteLine($"{Nome} deu {dano:F2} dano em {inimigo.Nome}");
            Console.WriteLine($"vida do {inimigo.Nome}: {inimigo.Vida}");
            if (inimigo.Vida < 0) inimigo.Vida = 0;
            Console.ReadKey();

        }
    }
}
