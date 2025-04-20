using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMULADOR_RPG.Fabricas;

namespace SIMULADOR_RPG
{
    public class Mago : Personagem
    {
        public Mago(string nome) : base(nome)
        {
            VidaTotal = 85;
            Vida=VidaTotal;
            ForcaBase = 15;
            ArmaEquipada = FabricaArmas.Criar(TipoArma.Cajado);
            ManaTotal = 100;
            Mana = ManaTotal;
            Forca= ForcaBase + ArmaEquipada.BonusForca;
            Magias.Add(FabricaMagias.Criar(TipoMagia.Cura));
            Magias.Add(FabricaMagias.Criar(TipoMagia.Chamas));
            Magias.Add(FabricaMagias.Criar(TipoMagia.Trovao));
            Itens.Add(FabricaItens.Criar(TipoItem.PocaoCura));
            Itens.Add(FabricaItens.Criar(TipoItem.PocaoMana));
        }
        public override void Atacar(Personagem inimigo)
        {
            double dano = (0.6 + rand.NextDouble() * 1.0) * Forca;
            inimigo.ReceberDano(dano);
            MostrarDano(dano,inimigo);
            Console.ReadKey();

        }
    }
}
