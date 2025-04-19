using System.Collections.Generic;

namespace SIMULADOR_RPG
{
    public enum TipoArma
    {
        Punhos,
        Espada,
        Espada2,
        Cajado,
        Cajado2,
        Arco,
        Arco2
    }
    public static class Arsenal
    {
        private static readonly Dictionary<TipoArma, Func<Arma>>_armas =
            new Dictionary<TipoArma, Func<Arma>>()
            {
                {TipoArma.Punhos, () => new Arma("Punhos",0)},
                {TipoArma.Espada, () => new Arma("Espada Velha",6)},
                {TipoArma.Espada2, () => new Arma("Espada do Morto-Vivo",10)},
                {TipoArma.Cajado, () => new Arma("Cajado Simples",2)},
                {TipoArma.Cajado2, () => new Arma("Cajado Ancião",5)},
                {TipoArma.Arco, () => new Arma("Arco e Flecha Improvisado",4)},
                {TipoArma.Arco2, () => new Arma("Arco Elegante",15)}
            };
         public static Arma Criar(TipoArma tipo)
           {
                if (_armas.TryGetValue(tipo, out var construtor))
                return construtor();
            else 
                throw new ArgumentException("Tipo de arma inválido.");

    }

    }

}
