using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public class Guerreiro : Personagem
    {
        public Guerreiro(string nome) : base(nome) 
        {
            VidaTotal = 100;
            Vida=VidaTotal;
            ForcaBase = 20.5;
            ManaTotal = 50;
            Mana = ManaTotal;
            ArmaEquipada = FabricaArmas.Criar(TipoArma.Espada);
            Forca= ForcaBase+ ArmaEquipada.BonusForca;
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
