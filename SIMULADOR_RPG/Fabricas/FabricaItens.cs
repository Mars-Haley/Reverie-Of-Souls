using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public enum TipoItem 
    {
        PocaoCura
    }

    public class FabricaItens
    {
        private static readonly Dictionary<TipoItem, Func<Item>> _itens = 
            new Dictionary<TipoItem, Func<Item>>()
            {
                {TipoItem.PocaoCura, () => new Item(new List<IEfeito>{new Cura(10)},"Poção de Cura",false, true) }
            };

    public static Item Criar(TipoItem tipo)
    {
        if (_itens.TryGetValue(tipo, out var construtor))
        return construtor();

        else
        throw new ArgumentException("Tipo de item invalido");
    }

    }
}
