using System;
using SIMULADOR_RPG;

public enum TipoInimigo
{
    Esqueleto,
    Bandido,
    Anão,
    Slime,
    Goblin,
    Ogro
}

public static class FabricaInimigos
{

    private static readonly Dictionary<TipoInimigo, Func<Inimigo>> _inimigos = 
    new Dictionary<TipoInimigo, Func<Inimigo>>()
    {
        {TipoInimigo.Esqueleto, () => new Inimigo("Esqueleto",8,50,$"Parece já ter sido um aventureiro como eu\nEspero que eu não tenha o mesmo destino",FabricaArmas.Criar(TipoArma.Espada2))},
        {TipoInimigo.Bandido,() => new Inimigo ("Bandido", 10,60,"Um ladrão surrado pela estrada, coberto de cicatrizes e desconfiança. Anda com a mão sempre próxima à lâmina, os olhos varrendo o horizonte como um animal acuado. Não luta por honra, mas por sobrevivência — e não hesita em matar por uma bolsa de moedas.",FabricaArmas.Criar(TipoArma.Faca))},
        {TipoInimigo.Anão, () => new Inimigo("Anão",7,45,"Asim", FabricaArmas.Criar(TipoArma.Machado))},
        {TipoInimigo.Slime, () => new Inimigo("Slime",4,20,"Created by nilson izaias papinho",FabricaArmas.Criar(TipoArma.Gosma))},
        {TipoInimigo.Goblin, () => new Inimigo("Goblin",5,40,"Criatura esverdeada, baixinha e de dentes afiados, cheirando a mofo e crueldade. Vive em tocas imundas e se move rápido, rindo de forma irritante enquanto apunhala por trás. Covarde sozinho, perigoso em bando. Um erro comum é achá-lo burro.",FabricaArmas.Criar(TipoArma.Faca))},
        {TipoInimigo.Ogro, () => new Inimigo("Ogro",13,60,"Um monstro gigantesco, feito de músculo, fedor e brutalidade. Anda como um desmoronamento ambulante, esmagando tudo que vê sem pensar duas vezes. A fala é arrastada, o cérebro pequeno, mas a força é tanta que inteligência vira detalhe.",FabricaArmas.Criar(TipoArma.Machado))}
    };

    public static Inimigo Criar(TipoInimigo tipo)
    {
        if (_inimigos.TryGetValue(tipo, out var construtor))
            return construtor();
        else 
            throw new ArgumentException("Tipo de inimigo inválido.");
   }
    private static Random rng = new Random();

    public static Inimigo CriarAleatorio()
    {
        var funcoes = _inimigos.Values.ToArray();
        return funcoes[rng.Next(funcoes.Length)]();
    }
}
