using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public class Arma
    {
        public string Nome{get;set;}
        public double BonusForca{get;set;}

        public Arma(string nome, double bonusforca)
        {
            Nome = nome;
            BonusForca = bonusforca;
        }

    }

}
