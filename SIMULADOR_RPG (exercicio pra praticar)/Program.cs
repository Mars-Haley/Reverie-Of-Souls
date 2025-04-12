using System.Runtime.InteropServices;

namespace SIMULADOR_RPG__exercicio_pra_praticar_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personagem guerreiro1 = new Guerreiro("mars");
            Personagem inimigo = new Personagem("esqueleto");
            MenuCombate(guerreiro1, inimigo);
        }

        static void MenuCombate(Personagem personagem, Personagem inimigo)
        {
            
            int option =1;
            bool selecionado = false;
            while (inimigo.Vida > 0 && !selecionado){
            Console.Clear();
            string[] opcoes = new string []
            {
                "Atacar",
                "Checar",
                "Item",
                "Skill"
            };

            for (int i = 0; i < opcoes.Length;i++)
            {
                Console.WriteLine($"{(i+1==option ? ">" : " ")}{opcoes[i]}");
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
              Selecao(personagem,inimigo,option);
        }
        static void Selecao(Personagem personagem,Personagem inimigo,int option)
        {
            Console.Clear();
            switch(option)
            {
                case 1:
                personagem.Atacar(inimigo);
                if(inimigo.Vida > 0){
                inimigo.Atacar(personagem);
                MenuCombate(personagem, inimigo);}
                break;
            }
        }
    }
}