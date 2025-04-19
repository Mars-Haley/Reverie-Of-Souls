using System;
using SIMULADOR_RPG;

public enum TipoInimigo
{
    Esqueleto,
    Bandido,
    Anão,
    Slime
}

public static class FabricaInimigos
{

    private static readonly Dictionary<TipoInimigo, Func<Inimigo>> _inimigos = 
    new Dictionary<TipoInimigo, Func<Inimigo>>()
    {
        {TipoInimigo.Esqueleto, () => new Inimigo("Esqueleto",13,50,$"Parece já ter sido um aventureiro como eu\nEspero que eu não tenha o mesmo destino",FabricaArmas.Criar(TipoArma.Espada2))},
        {TipoInimigo.Bandido,() => new Inimigo ("Bandido", 20,60,"Um safado que fez o L",FabricaArmas.Criar(TipoArma.Faca))},
        {TipoInimigo.Anão, () => new Inimigo("Anão",15,45,"Asim", FabricaArmas.Criar(TipoArma.Machado))},
        {TipoInimigo.Slime, () => new Inimigo("Slime",20,20,"Created by nilson izaias papinho",FabricaArmas.Criar(TipoArma.Gosma))}
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
