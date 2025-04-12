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
        protected double _vida;
        protected double _forca;
        protected int _nivel;
        protected int _xp;
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
        public Personagem(string nome)
        { 
            Vida = 100;
            Forca = 30;
            Nome = nome;
            Nivel = 1;
            rand = new Random();
        }
        public virtual void Atacar(Personagem inimigo)
        {
            Console.Clear();
            Console.WriteLine("Ataque comum");
            double dano = (0.5 + rand.NextDouble() * 0.5) * Forca;
            inimigo.Vida -= dano;
            if (inimigo.Vida < 0) inimigo.Vida = 0;
            Console.WriteLine($"{Nome} causou {dano:F2} de dano em {inimigo.Nome}");
            Console.WriteLine($"vida de {inimigo.Nome}: {inimigo.Vida:F2}");
            
            Console.ReadKey();
        }
    }
}
