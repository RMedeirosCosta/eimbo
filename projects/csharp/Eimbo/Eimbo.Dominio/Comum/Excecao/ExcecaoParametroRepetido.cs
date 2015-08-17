using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoParametroRepetido :Exception
    {
        public ExcecaoParametroRepetido(String Parametro) : base(String.Concat(Parametro, " repetido!")) { }
    }
}
