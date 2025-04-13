using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading;

namespace SIMULADOR_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Personagem> personagens = new List<Personagem>();
            CriacaoPersonagem(personagens);

        }

        static void CriacaoPersonagem(List<Personagem> personagens)
        {
             int option =1;
            bool selecionado = false;
            while (!selecionado){
            Console.Clear();
            string[] opcoes = new string []
            {
                "Guerreiro",
                "Mago",
                "Arqueiro"
            };
            for (int i = 0; i < opcoes.Length;i++)
            {
                Console.WriteLine($"{(i+1==option ? ">" : " ")}{opcoes[i]}     ");
            }
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch(key.Key)
            {
                case ConsoleKey.UpArrow: if (option > 1) option--;
                break;

                case ConsoleKey.DownArrow: if (option < opcoes.Length) option++;
                break;

                case ConsoleKey.Enter:
                selecionado = true;
                break;
            }
        }
        SelecaoClasse(option,personagens);
        }

        static void SelecaoClasse(int option,List<Personagem> personagens)
        {
            switch (option)
            {
                case 1:
                Console.Clear();
                Console.WriteLine("Insira o nome do guerreiro:");
                string nome = Console.ReadLine();
                Personagem gr = new Guerreiro(nome);
                personagens.Add(gr);
                Instanciar(gr);
                break;

                case 2:
                Console.Clear();
                Console.WriteLine("Insira o nome do mago:");
                nome = Console.ReadLine();
                Personagem mg = new Mago(nome);
                personagens.Add(mg);
                Instanciar(mg);
                break;

                case 3:
                Console.Clear();
                Console.WriteLine("Insira o nome do arqueiro:");
                nome = Console.ReadLine();
                Personagem ar = new Arqueiro(nome);
                personagens.Add(ar);
                Instanciar(ar);
                break;

                break;
                default: throw new Exception("Selecione uma opção válida");
            }
        }
        static void Instanciar(Personagem personagem)
        {
            Inimigo inimigo = FabricaInimigos.Criar(TipoInimigo.Esqueleto);

            MenuCombate(personagem,inimigo);

        }

        static void MenuCombate(Personagem personagem, Inimigo inimigo)
        {
            
            int option =1;
            bool selecionado = false;
            while (inimigo.Vida > 0 && !selecionado){
            Console.Clear();
            inimigo.ExibirInfo();
            string[] opcoes = new string []
            {
                "Atacar",
                "Checar",
                "Item",
                "Skill"
            };

            for (int i = 0; i < opcoes.Length;i++)
            {
                Console.Write($"{(i+1==option ? ">" : " ")}{opcoes[i]}     ");
            }
            personagem.ExibirInfo();
        
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch(key.Key)
            {
                case ConsoleKey.LeftArrow: if (option > 1) option--;
                break;

                case ConsoleKey.RightArrow: if (option < opcoes.Length) option++;
                break;

                case ConsoleKey.Enter:
                selecionado = true;
                break;
            }
            }
              SelecaoCombate(personagem,inimigo,option);
        }

        static void SelecaoCombate(Personagem personagem,Inimigo inimigo,int option)
        {
            Console.Clear();
            switch(option)
            {
                case 1:
                personagem.Atacar(inimigo);
                if(inimigo.Vida > 0)
                {
                inimigo.Atacar(personagem);
                MenuCombate(personagem, inimigo);
                }
                break;
                case 2:
                inimigo.ExibirInfo();
                Personagem.Digitar(inimigo.Descricao,40);
                Console.ReadKey();
                MenuCombate(personagem,inimigo);
                break;
            }
        }
    }
}