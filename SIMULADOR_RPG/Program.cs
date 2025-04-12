using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace SIMULADOR_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personagem guerreiro1 = new Guerreiro("Mars");
            Inimigo inimigo = FabricaInimigos.Criar(TipoInimigo.Esqueleto);
            MenuCombate(guerreiro1, inimigo);
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
              Selecao(personagem,inimigo,option);
        }
        static void Selecao(Personagem personagem,Inimigo inimigo,int option)
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