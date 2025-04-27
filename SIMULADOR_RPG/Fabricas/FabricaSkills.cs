using SIMULADOR_RPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG.Fabricas
{
    public enum TipoSkill
    {
        Cura,
        BuffForca,
        Chamas,
        Trovao,
        Veneno,
        Berserk
    
    }

    public class FabricaSkills
    {
        private static readonly Dictionary<TipoSkill, Func<Skill>> _magias =
            new Dictionary<TipoSkill, Func<Skill>>() 
            {
                {TipoSkill.Cura,() => new Skill("Cura", new List<Efeito>{new Cura(20)},false, 15)},
                {TipoSkill.Chamas,() => new Skill("Chamas", new List<Efeito> {new DanoDireto(20)},true, 20)},
                {TipoSkill.Trovao, ()=> new Skill ("Trovão", new List<Efeito>{new DanoDireto(30)}, true, 25)},
                {TipoSkill.BuffForca, ()=> new Skill("Fúria", new List<Efeito>{new BuffForca(30)}, true, 30)}
            };
    public static Skill Criar(TipoSkill tipo)
    {
        if (_magias.TryGetValue(tipo, out var construtor))
        return construtor();

        else
        throw new ArgumentException("Tipo de magia invalido");
    }
    }

}
