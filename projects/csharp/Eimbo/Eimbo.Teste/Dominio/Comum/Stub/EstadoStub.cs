using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Teste.Dominio.Comum.Stub
{
    public class EstadoStub :Estado
    {
        public static Estado GetInstance(long id, String UF)
        {
            var estado = new EstadoStub();
            estado.UF = UF;
            estado.Id = id;

            return (Estado)estado;
        }
    }
}
