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
            double dano = (0.85 + rand.NextDouble() * 0.15) * Forca;
            inimigo.ReceberDano(dano);
            MostrarDano(dano,inimigo);
            
            Console.ReadKey();

        }
    }
}
