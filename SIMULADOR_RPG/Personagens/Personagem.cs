using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        public double Xp{get;set;}
        public double XpTotal{get;set;}
        public double Mana{get;set;}
        public Arma ArmaEquipada{get;set;}

        protected Random rand;
  

       
        public Personagem(string nome)
        { 
            Nome = nome;
            Nivel = 1;
            rand = new Random();
            Xp = 0;
            XpTotal = 10;
        }

        public void Curar(double modificador)
        {
            Vida = Math.Min(Vida + modificador, VidaTotal);
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
        public virtual void ExibirInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"{Nome} {Vida:F0}/{VidaTotal}HP | Nível: {Nivel}\n {Xp:F2}/{XpTotal:F2}XP");
            Console.WriteLine("\n");
        }
        
        public void ReceberDano(double dano)
        {
            Vida -=dano;
        }
        protected void MostrarDanoFormatado(double dano, Personagem topo, Personagem baixo, string mensagem)
        {
            Console.Clear();
            if (topo.Vida < 1) topo.Vida = 0;
            if (baixo.Vida < 1) baixo.Vida = 0;

            topo.ExibirInfo();
            int linhaDoTexto = Console.CursorTop;

            Console.SetCursorPosition(0, linhaDoTexto);
            //fim do combate:
            if (baixo.Vida == 0)
            {
                Digitar($"{topo.Nome} finaliza {baixo.Nome} com {dano:F0} de dano!");
                Digitar($"{baixo.Nome} morreu!");
            }
            else if (topo.Vida == 0)
            {
                Digitar($"{baixo.Nome} finaliza {topo.Nome} com {dano:F0} de dano!");
                Digitar($"{topo.Nome} morreu!");
                Resultados(topo);
            }

            //combate ainda ocorrendo:
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
        protected void Resultados(Personagem inimigo)
        {
            double ganhoXp = (inimigo.Forca * inimigo.Nivel) / (Nivel + 1);
            Xp += ganhoXp;

            Digitar($"Você venceu e ganhou {ganhoXp:F2}XP!");

            if (Xp >= XpTotal)
            {
                Nivel++;
                Xp -= XpTotal;
                XpTotal = XpTotal * (Nivel +1);
                int pontosXp = 5;
                Digitar($"Level Up: Nível {Nivel}");
                Console.ReadKey();
                AtribuirPontosXp(pontosXp);
            }


        }
        protected void AtribuirPontosXp(int pontosXp)
        {
            int option = 1;
            string[] opcoes = { "Vida", "Força", "Confirmar e sair" };
    
            while (pontosXp > 0)
            {
                Console.Clear();
                Console.WriteLine($"Pontos de atributo disponíveis: {pontosXp}");
                Console.WriteLine("Use ↑ e ↓ para navegar, Enter para selecionar:\n");

                for (int i = 0; i < opcoes.Length; i++)
                    Console.WriteLine($"{(i + 1 == option ? "> " : "  ")}{opcoes[i]}");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (option > 1) option--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (option < opcoes.Length) option++;
                        break;
                    case ConsoleKey.Enter:
                        if (option == 3) return; // Sai do menu
                        else
                        {
                            Console.WriteLine($"\nQuantos pontos deseja aplicar em {opcoes[option - 1]}?");
                            Console.Write("→ ");
                            if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0 && quantidade <= pontosXp)
                            {
                                if (option == 1) {VidaTotal += 20 * quantidade;}
                                else if (option == 2) {ForcaBase += 2 * quantidade; AtualizarForca();}

                                pontosXp -= quantidade;
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                                Console.ReadKey();
                            }
                        }
                        break;
                }
                AtualizarVida();
            }

            Console.WriteLine("Todos os pontos foram distribuídos.");
            }
            protected void AtualizarVida()
                {
                Vida = VidaTotal;
            }
            protected void AtualizarForca()
            {
                Forca = ForcaBase + ArmaEquipada.BonusForca;
            }

            
           

            public abstract void Atacar(Personagem inimigo);
        }
    }
