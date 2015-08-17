using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoParametroInvalido : Exception
    {
        public ExcecaoParametroInvalido(string parametro) :base(parametro) {}
    }
}
