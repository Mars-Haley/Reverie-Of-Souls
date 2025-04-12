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
    public static Inimigo Criar(TipoInimigo tipo)
    {
        switch(tipo)
        {
            case TipoInimigo.Esqueleto: return new Inimigo("Esqueleto",10,50,$"Parece já ter sido um aventureiro como eu\nEspero que eu não tenha o mesmo destino");
            case TipoInimigo.Bandido: return new Inimigo("Bandido",20,60,"");
            case TipoInimigo.Anão: return new Inimigo("Anão",30,45,"");
            case TipoInimigo.Slime: return new Inimigo("Slime",20,20,"");
            default:throw new ArgumentException("Tipo de inimigo inválido");
        }
    }
}