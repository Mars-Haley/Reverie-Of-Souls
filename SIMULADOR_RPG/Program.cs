using System;
using System.Collections.Generic;

namespace SIMULADOR_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Personagem> personagens = new List<Personagem>();
            CriacaoPersonagem(personagens);
        }

        // ========== CRIAÇÃO DO PERSONAGEM ==========
        static void CriacaoPersonagem(List<Personagem> personagens)
        {

            string[] opcoes = { "Guerreiro", "Mago", "Arqueiro" };
            int option = Menu("Escolha sua classe: ", opcoes);
            

            SelecaoClasse(option, personagens);
        }

        static void SelecaoClasse(int option, List<Personagem> personagens)
        {
            Console.Clear();
            Console.Write("Insira o nome do personagem: ");
            string nome = Console.ReadLine();

            Personagem personagem;

            switch (option)
            {
                case 1:
                    personagem = new Guerreiro(nome);
                    break;
                case 2:
                    personagem = new Mago(nome);
                    break;
                case 3:
                    personagem = new Arqueiro(nome);
                    break;
                default:
                    throw new Exception("Selecione uma opção válida");
            }

            personagens.Add(personagem);
            Instanciar(personagem);
        }
        static int Menu(string titulo,string[] opcoes)
        {
            bool selecionado = false;
            int option = 1;
            while(!selecionado){
            Console.Clear();
            Console.WriteLine(titulo);
            for (int i= 0; i < opcoes.Length;i++)
                Console.WriteLine($"{(i+1 == option ? ">" : " ")}{opcoes[i]}");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: if (option > 1) option--; break;
                    case ConsoleKey.DownArrow: if (option < opcoes.Length) option++; break;
                    case ConsoleKey.Enter: selecionado = true; break;
                }
            }

            return option;
        }


        // ========== INÍCIO DO COMBATE ==========
        static void Instanciar(Personagem personagem)
        {
            Inimigo inimigo = FabricaInimigos.Criar(TipoInimigo.Esqueleto);
            inimigo.ArmaEquipada = Arsenal.Espada2;
            MenuCombate(personagem, inimigo);
        }

        static void MenuCombate(Personagem personagem, Inimigo inimigo)
        {
            int option = 1;
            bool selecionado = false;

            while (inimigo.Vida > 0 && personagem.Vida > 0 && !selecionado)
            {
                Console.Clear();
                inimigo.ExibirInfo();

                string[] opcoes = { "Atacar", "Checar", "Item", "Skill" };
                for (int i = 0; i < opcoes.Length; i++)
                    Console.Write($"{(i + 1 == option ? ">" : " ")}{opcoes[i]}     ");

                personagem.ExibirInfo();

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow: if (option > 1) option--; break;
                    case ConsoleKey.RightArrow: if (option < opcoes.Length) option++; break;
                    case ConsoleKey.Enter: selecionado = true; break;
                }
            }

            SelecaoCombate(personagem, inimigo, option);
            if (inimigo.Vida == 0 && personagem.Vida > 0) Instanciar(personagem);
        }

        // ========== AÇÕES DO COMBATE ==========
        static void SelecaoCombate(Personagem personagem, Inimigo inimigo, int option)
        {
            Console.Clear();

            switch (option)
            {
                case 1:
                    personagem.Atacar(inimigo);

                    if (inimigo.Vida > 0)
                        inimigo.Atacar(personagem);

                    break;

                case 2:
                    inimigo.ExibirInfo();
                    Personagem.Digitar(inimigo.Descricao, 40);
                    Console.ReadKey();
                    break;

                // Futuras opções:
                // case 3: Usar item...
                // case 4: Usar skill...
                case 4:
                foreach(var Magia in personagem.Magias)
                {
                    
                    Personagem.Digitar(Magia.Nome);
                    Console.ReadKey();
                    Magia.Usar(personagem);
                }
                break;
            }

            if (personagem.Vida > 0 && inimigo.Vida > 0)
                MenuCombate(personagem, inimigo);
        }
    }
}
