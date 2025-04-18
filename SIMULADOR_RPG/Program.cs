using System;
using System.Collections.Generic;
using SIMULADOR_RPG.Magias;

namespace SIMULADOR_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Personagem> personagens = new List<Personagem>();
            CriacaoPersonagem(personagens);
        }

        
        #region CRIAÇÃO DO PERSONAGEM
        static void CriacaoPersonagem(List<Personagem> personagens)
        {

            List<string> opcoes = new List<string>{ "Guerreiro", "Mago", "Arqueiro" };
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
        static int Menu(string titulo,List<string> opcoes)
        {
            bool selecionado = false;
            int option = 1;
            while(!selecionado){
            Console.Clear();
            Console.WriteLine(titulo);
            for (int i= 0; i < opcoes.Count;i++)
                Console.WriteLine($"{(i+1 == option ? ">" : " ")}{opcoes[i]}");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: if (option > 1) option--; break;
                    case ConsoleKey.DownArrow: if (option < opcoes.Count) option++; break;
                    case ConsoleKey.Enter: selecionado = true; break;
                }
            }

            return option;
        }
        #endregion

        #region INÍCIO DO COMBATE
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
        #endregion

        #region AÇÕES DO COMBATE
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
                    inimigo.Atacar(personagem);
                    Console.ReadKey();
                    break;

                case 3: 
                List<string> nomeItens = new List<string>();
                
                foreach(var Item in personagem.Itens)
                {
                    nomeItens.Add(Item.Nome);
                }
                option = Menu("Itens: ",nomeItens);
                Item itemSelecionado = personagem.Itens[option-1];
                if (itemSelecionado.AlvoEhInimigo) UsoItem(itemSelecionado,inimigo,personagem);
                else UsoItem(itemSelecionado, personagem,personagem);
                inimigo.Atacar(personagem);
                break;

                
                case 4:
                List<string> nomeMagias = new List<string>();
                

                foreach(var Magia in personagem.Magias)
                {
                    nomeMagias.Add(Magia.Nome);
                }
                option = Menu("Magias: ", nomeMagias);
                Magia magiaSelecionada = personagem.Magias[option-1];
                if (magiaSelecionada.AlvoEhInimigo) UsoMagia(magiaSelecionada,inimigo, personagem);
                else UsoMagia(magiaSelecionada, personagem, personagem);
                inimigo.Atacar(personagem);
                break;
            }
           

            if (personagem.Vida > 0 && inimigo.Vida > 0)
                MenuCombate(personagem, inimigo);
        }

        static void UsoMagia(Magia magiaSelecionada, Personagem alvo, Personagem usuario)
        {
            magiaSelecionada.Usar(usuario,alvo);
        }
        static void UsoItem(Item itemSelecionado, Personagem alvo, Personagem usuario)
        {
            itemSelecionado.Usar(usuario, alvo);
        }
        
        #endregion
    }
}
