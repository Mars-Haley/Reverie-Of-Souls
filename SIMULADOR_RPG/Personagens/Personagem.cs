using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SIMULADOR_RPG.Skills;

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
        public double ManaTotal{get;set;}
        public Arma ArmaEquipada{get;set;}
        public List<Skill> Skills{get;set;} = new List<Skill>();
        public List<Item> Itens{get;set;} = new List<Item>();
        public int Ouro{get;set;}
        protected Random rand;
  

       
        public Personagem(string nome)
        { 
            Nome = nome;
            Nivel = 1;
            rand = new Random();
            Ouro = 0;
            Xp = 0;
            XpTotal = 10;
        }

        public void Curar(double modificador)
        {
            Vida = Math.Min(Vida + modificador, VidaTotal);
        }
        public virtual void ExibirInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"{Nome} {Vida:F0}/{VidaTotal}HP | Nível: {Nivel}\n {Xp:F2}/{XpTotal:F2}XP\n Mana: {Mana}/ {ManaTotal}\n Ouro:{Ouro}");
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
                Texto.Digitar($"{topo.Nome} finaliza {baixo.Nome} com {dano:F0} de dano!");
                Texto.Digitar($"{baixo.Nome} morreu!");
            }
            else if (topo.Vida == 0)
            {
                Texto.Digitar($"{baixo.Nome} finaliza {topo.Nome} com {dano:F0} de dano!");
                Texto.Digitar($"{topo.Nome} morreu!");
            }

            //combate ainda ocorrendo:
            else
            {
                baixo.ExibirInfo();
                Console.SetCursorPosition(0, linhaDoTexto);
                Texto.Digitar(mensagem);
            }
        }
        protected virtual void MostrarDano(double dano, Personagem inimigo)
        {
            MostrarDanoFormatado(dano, inimigo, this, $"{Nome} ataca {inimigo.Nome} com {ArmaEquipada.Nome} causando {dano:F0} de dano!");
        }
        public void Resultados(Personagem inimigo)
        {
            double ganhoXp = (inimigo.Forca * inimigo.Nivel) / (Nivel + 1);
            Xp += ganhoXp;
            int ganhoOuro = ((int)inimigo.Forca * inimigo.Nivel) / (Nivel);
            Ouro += ganhoOuro;

            Texto.Digitar($"Você venceu e ganhou {ganhoXp:F2}XP e {ganhoOuro} de ouro!");
            Console.ReadKey();

            if (Xp >= XpTotal)
            {
                Nivel++;
                Xp -= XpTotal;
                XpTotal = XpTotal * (Nivel);
                int pontosXp = 5;
                Texto.Digitar($"Level Up: Nível {Nivel}");
                Console.ReadKey();
                AtribuirPontosXp(pontosXp);
                Restaurar();
            }


        }
        protected void UparArcana ()
        {
            foreach(var m in Skills){
                foreach(var e in m.Efeitos){
                   e.Modificador += 3; 
                }
            }
        }
        protected void AtribuirPontosXp(int pontosXp)
        {
            int option = 1;
            string[] opcoes = { "Vida", "Força","Mana","Arcano", "Confirmar e sair" };
    
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
                        if (option == 5) return; // Sai do menu
                        else
                        {
                            Console.WriteLine($"\nQuantos pontos deseja aplicar em {opcoes[option - 1]}?");
                            Console.Write("→ ");
                            if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0 && quantidade <= pontosXp)
                            {
                                if (option == 1) {VidaTotal += 20 * quantidade;}
                                else if (option == 2) {ForcaBase += 2 * quantidade;}
                                else if (option == 3) {ManaTotal += 10 * quantidade;}
                                else if (option == 4){UparArcana();}
                                pontosXp -= quantidade;
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                                Console.ReadKey();
                            }
                            Restaurar();
                        }
                        break;
                }
            }

            Console.WriteLine("Todos os pontos foram distribuídos.");
            }
            protected void Restaurar()
            {
                Vida = VidaTotal;
                Mana = ManaTotal;
                Forca = ForcaBase + ArmaEquipada.BonusForca;
            }

            
           

            public abstract void Atacar(Personagem inimigo);
        }
    }
