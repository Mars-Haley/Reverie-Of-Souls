using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG.Skills
{
    public class Skill
    {
        public string Nome { get; }
        public List<Efeito> Efeitos { get; }
        public bool AlvoEhInimigo {get;}
        public double GastoMana {get;}
        public string Descricao {get;}

        public Skill(string nome, List<Efeito> efeitos, bool alvoEhInimigo, double gastoMana)
        {
            Nome = nome;
            Efeitos = efeitos;
            AlvoEhInimigo = alvoEhInimigo;
            GastoMana = gastoMana;
            Descricao = $"Gasto de mana: {gastoMana}";
        }
        double modificador;

        public void Usar(Personagem usuario,Personagem alvo) 
        {
            if (usuario.Mana < 0) usuario.Mana = 0;
            if(usuario.Mana - GastoMana >= 0){
            foreach (var efeito in Efeitos) 
            {
                efeito.Aplicar(alvo);
                modificador+= efeito.Modificador;
            }
            Texto.Digitar($"{usuario.Nome} usou a magia {Nome}");
            usuario.Mana -= GastoMana;
            Console.ReadKey();
            }
            else
            {
                Texto.Digitar($"{usuario.Nome} tentou usar {Nome} mas não tinha mana o suficiente!");
                Console.ReadKey();
            }
        }
    }
}
