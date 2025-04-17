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
        {TipoInimigo.Esqueleto, () => new Inimigo("Esqueleto",13,50,$"Parece já ter sido um aventureiro como eu\nEspero que eu não tenha o mesmo destino")},
        {TipoInimigo.Bandido,() => new Inimigo ("Bandido", 20,60,"Um safado que fez o L")},
        {TipoInimigo.Anão, () => new Inimigo("Anão",30,45,"Asim")},
        {TipoInimigo.Slime, () => new Inimigo("Slime",20,20,"")}
    };

    public static Inimigo Criar(TipoInimigo tipo)
    {
        if (_inimigos.TryGetValue(tipo, out var construtor))
            return construtor();
        else 
            throw new ArgumentException("Tipo de inimigo inválido.");
    }
}