using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public class Arqueiro : Personagem
    {
        public Arqueiro(string nome) : base(nome)
        {
            VidaTotal = 80;
            Vida=VidaTotal;
            ForcaBase = 20;
            ManaTotal = 50;
            Mana = ManaTotal;
            ArmaEquipada = Arsenal.Criar(TipoArma.Arco);
            Forca = ForcaBase + ArmaEquipada.BonusForca;
        }

        public override void Atacar(Personagem inimigo)
        {
            double r = rand.NextDouble();
            double fator = Math.Sqrt(r);
            double dano = (0.6 + fator * 0.4) * Forca ;
            inimigo.ReceberDano(dano);
            MostrarDano(dano,inimigo);
            Console.ReadKey();

        }
    }
}
