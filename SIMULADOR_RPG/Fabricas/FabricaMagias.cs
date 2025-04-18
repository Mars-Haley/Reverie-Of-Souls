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
        Veneno
    
    }

    public class FabricaMagias
    {
        private static readonly Dictionary<TipoMagia, Func<Magia>> _magias =
            new Dictionary<TipoMagia, Func<Magia>>() 
            {
                {TipoMagia.Cura,() => new Magia("Cura", new List<IEfeito>{new Cura(20)},false) },
                {TipoMagia.Chamas,() => new Magia("Chamas", new List<IEfeito> {new Chama(20)},true)}
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
