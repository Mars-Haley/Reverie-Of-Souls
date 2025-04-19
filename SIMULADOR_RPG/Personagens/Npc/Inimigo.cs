namespace SIMULADOR_RPG
{
    public class Inimigo : Personagem
    {
        public string Descricao{get;set;}

        public Inimigo(string nome, double forca, double vida, string descricao):base(nome)
        {
            Forca =forca;
            VidaTotal=vida;
            Vida=VidaTotal;
            Descricao = descricao;
            Itens.Add(FabricaItens.Criar(TipoItem.PocaoCura)); 
        }
        public override void ExibirInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"{Nome} {Vida:F0}/{VidaTotal}HP | Nível: {Nivel}");
            Console.WriteLine("\n");


        }

        protected override void MostrarDano(double dano, Personagem alvo)
        {
            MostrarDanoFormatado(dano, this, alvo, $"{Nome} ataca {alvo.Nome} com {ArmaEquipada.Nome} causando {dano:F0} de dano!");
            Console.ReadKey();

        }

        public override void Atacar(Personagem alvo)
        {
            int chance = rand.Next(1,3);
            if(EstaDesesperado() && chance ==2 )
            {
                AcoesDesesperado(alvo);
            }
            else
            {
            double dano = (0.6 + rand.NextDouble() * 0.4) * Forca * Nivel;
            alvo.ReceberDano(dano);
            MostrarDano(dano,alvo);
            if (alvo.Vida <= 0) Console.ReadKey();
            }
        }
        
        public void AcoesDesesperado(Personagem alvo)
        {
            int chance = rand.Next(1,4);
            Console.Clear();
            Console.WriteLine($"{Nome} está desesperado!");
            Console.ReadKey();
            switch(chance)
            {
               case 1:
                   foreach (var Item in Itens)
                   {
                   Item.Usar(this, this);
                   }
                   break;
                case 2:
                   Desarmar(alvo);
                   break;
                case 3:
                   AtacarDesesperado(alvo);
                   break;
            }
        }
        public void AtacarDesesperado(Personagem alvo)
        {
            Console.Clear();
            Console.WriteLine($"{Nome} ataca desesperadamente!");
            double dano = (0.9 + rand.NextDouble() * 0.5) * Forca * Nivel;
            alvo.ReceberDano(dano);
            MostrarDano(dano,alvo);
            if (alvo.Vida <= 0) Console.ReadKey();
        }
        public void Desarmar(Personagem alvo)
        {
            Console.WriteLine($"{Nome} desarmou {alvo.Nome}!");
            Console.ReadKey();
            alvo.ArmaEquipada = Arsenal.Punhos;
        }


        public bool EstaDesesperado()
        {
            return Vida <= VidaTotal * 0.2;
        }
}
}
