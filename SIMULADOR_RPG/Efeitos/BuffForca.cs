using System;

namespace SIMULADOR_RPG{
    public class BuffForca: Efeito{
        public BuffForca(double modificador) : base(modificador){
            Modificador = modificador;
        }
        public override void Aplicar(Personagem alvo)
        {
           alvo.Forca += Modificador;          
        }

    }
}
