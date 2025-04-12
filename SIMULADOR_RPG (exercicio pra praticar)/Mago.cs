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
            Forca = 20;
        }
        public override void Atacar(Personagem inimigo)
        {
            double dano = (0.5 + rand.NextDouble() * 1.0) * Forca;
            inimigo.ReceberDano(dano);
            MostrarDano(dano,inimigo);
            Console.ReadKey();

        }
    }
}
