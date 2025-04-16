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
        Buff,
        DanoDireto,
        DanoContinuo
    
    }

    public class FabricaMagias
    {
        private static readonly Dictionary<TipoMagia, Func<Magia>> _magias =
            new Dictionary<TipoMagia, Func<Magia>>() 
            {
                {TipoMagia.Cura,() => new Magia("Cura", new List<IEfeito>{new Cura(30)}) }
            };

    }
}
