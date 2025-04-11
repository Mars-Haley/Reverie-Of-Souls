using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
{
    public class Personagem : IAtaque
    {
        private string _nome;
        private double _vida;
        private double _forca;
        private int _nivel;
        private int _xp;
        protected Random rand;
  

        public string Nome{
            get { return _nome; }
            set { _nome = value; }
        }

        public double Vida { 
            get { return _vida; }
            set { _vida = value; }
        
        }
        public double Forca
        {
            get { return _forca; }
            set { _forca = value; }
        }
        public int Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }
        public int Xp
        {
            get { return _xp; }
            set { _xp = value; }
        }
        public Personagem(string nome, double vida, double forca)
        { 
            Nome = nome;
            Vida = vida;
            Nivel = 1;
            Forca = forca;
            rand = new Random();
        }
        public virtual void Atacar(Personagem inimigo)
        {
            Console.WriteLine("Ataque comum");
            double dano = rand.NextDouble() * Forca;
            inimigo.Vida -= dano;
            Console.WriteLine($"{Nome} causou {dano:F2} de dano em {inimigo.Nome}");
        }
    }
}
