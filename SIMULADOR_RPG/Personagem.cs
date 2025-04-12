using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public abstract class Personagem : IAtaque
    {
        public string Nome{get; set;}
        public double Vida{get; set;}
        public double VidaTotal{get;set;}
        public double Forca{get;set;}
        public double ForcaBase{get;set;}
        public int Nivel{get;set;}
        public int Xp{get;set;}
        public double Mana{get;set;}
        public Arma ArmaEquipada{get;set;}
        protected Random rand;
  

       
        public Personagem(string nome)
        { 
            Nome = nome;
            Nivel = 1;
            rand = new Random();
        }
        public static void Digitar(string texto, int velocidade = 20)
        {
            foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(velocidade); // milissegundos entre letras
        }
        Console.WriteLine();
        }
        public void ExibirInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"{Nome} {Vida:F0}/{VidaTotal}HP | Nível: {Nivel}");
            Console.WriteLine("\n");


        }
        
        public void ReceberDano(double dano)
        {
            Vida -=dano;
        }
    protected void MostrarDanoFormatado(double dano, Personagem topo, Personagem baixo, string mensagem)
    {
        Console.Clear();
        if (topo.Vida <1) topo.Vida = 0;

        topo.ExibirInfo();
        int linhaDoTexto = Console.CursorTop;

        Console.SetCursorPosition(0, linhaDoTexto);

        if (topo.Vida == 0)
        {
            Digitar($"{Nome} finaliza {topo.Nome} com {dano:F0} de dano!");
            Digitar($"{topo.Nome} morreu!");
        }
        else
        {
            baixo.ExibirInfo();
            Console.SetCursorPosition(0, linhaDoTexto);
            Digitar(mensagem);
        }
    }
    protected virtual void MostrarDano(double dano, Personagem inimigo)
    {
        MostrarDanoFormatado(dano, inimigo, this, $"{Nome} ataca {inimigo.Nome} com {ArmaEquipada.Nome} causando {dano:F0} de dano!");
    }   

        public abstract void Atacar(Personagem inimigo);
    }
}
