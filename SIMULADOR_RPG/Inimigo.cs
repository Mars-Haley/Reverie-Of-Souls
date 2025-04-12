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

    protected override void MostrarDano(double dano, Personagem inimigo)
    {
        MostrarDanoFormatado(dano, this, inimigo, $"{Nome} ataca {inimigo.Nome} causando {dano:F0} de dano!");

    }

        public override void Atacar(Personagem alvo)
        {
            double dano = (0.8 + rand.NextDouble() * 0.2) * Forca * Nivel;
            alvo.ReceberDano(dano);
            MostrarDano(dano,alvo);
            Console.ReadKey();

    }

}
}