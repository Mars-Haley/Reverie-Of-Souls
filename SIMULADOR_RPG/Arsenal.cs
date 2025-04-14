using System.Collections.Generic;

namespace SIMULADOR_RPG
{
    public static class Arsenal
    {
        public static Arma Espada = new Arma("Espada Velha", 6);
        public static Arma Espada2 = new Arma("Espada do morto-vivo", 10);
        public static Arma Cajado = new Arma("Cajado Simples", 2);
        public static Arma Cajado2 = new Arma("Cajado Ancião",5);
        public static Arma Arco = new Arma("Arco e Flecha Improvisado",4);
        public static Arma Arco2 = new Arma("Arco Elegante", 15);

        public static List<Arma> TodasArmas = new List<Arma> {Espada, Espada2, Cajado, Cajado2, Arco, Arco2}; 
    }

}