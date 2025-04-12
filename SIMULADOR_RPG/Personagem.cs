using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
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
    protected void MostrarDano(double dano, Personagem inimigo)
    {
        Console.Clear();
        if(inimigo.Vida < 1) inimigo.Vida =0;

        if(inimigo.Vida == 0) {
            Digitar($"{Nome} finaliza {inimigo.Nome} com {dano:F0} de dano!");
            Digitar($"{inimigo.Nome} morreu!");
            }
        else {
            Digitar($"{Nome} ataca causando {dano:F0} de dano!");
            Digitar($"{inimigo.Nome}: {inimigo.Vida:F0}/{inimigo.VidaTotal}HP");
        }
        
    }

        public abstract void Atacar(Personagem inimigo);
    }
}
