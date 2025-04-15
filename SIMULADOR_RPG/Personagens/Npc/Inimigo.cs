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
            double dano = (0.6 + rand.NextDouble() * 0.4) * Forca * Nivel;
            alvo.ReceberDano(dano);
            MostrarDano(dano,alvo);
            if (alvo.Vida <= 0) Console.ReadKey();

        }

}
}