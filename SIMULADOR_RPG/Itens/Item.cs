using System;

namespace SIMULADOR_RPG
{
	public class Item
	{
		public List<IEfeito>Efeitos {get;}
		public string Nome{get;}
		public bool AlvoEhInimigo{get;}
        public bool EhEmpilhavel{get;}

		public Item(List<IEfeito>efeitos, string nome, bool alvoEhInimigo, bool ehEmpilhavel)
		{	
			Efeitos = efeitos;
			Nome = nome;
			AlvoEhInimigo = alvoEhInimigo;
            EhEmpilhavel = ehEmpilhavel;
		}
		public void Usar(Personagem usuario,Personagem alvo) 
        {
            foreach (var efeito in Efeitos) 
            {
                efeito.Aplicar(alvo);
            }
            Personagem.Digitar($"{usuario.Nome} usou o item {Nome}");
            Console.ReadKey();
        }
	}
	
}
