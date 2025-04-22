using SIMULADOR_RPG.Magias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG.Fabricas
{
    public enum TipoMagia
    {
        Cura,
        BuffForca,
        Chamas,
        Trovao,
        Veneno
    
    }

    public class FabricaMagias
    {
        private static readonly Dictionary<TipoMagia, Func<Magia>> _magias =
            new Dictionary<TipoMagia, Func<Magia>>() 
            {
                {TipoMagia.Cura,() => new Magia("Cura", new List<Efeito>{new Cura(20)},false, 15)},
                {TipoMagia.Chamas,() => new Magia("Chamas", new List<Efeito> {new DanoDireto(20)},true, 20)},
                {TipoMagia.Trovao, ()=> new Magia ("Trovão", new List<Efeito>{new DanoDireto(30)}, true, 25)}
            };
    public static Magia Criar(TipoMagia tipo)
    {
        if (_magias.TryGetValue(tipo, out var construtor))
        return construtor();

        else
        throw new ArgumentException("Tipo de magia invalido");
    }
    }

}
