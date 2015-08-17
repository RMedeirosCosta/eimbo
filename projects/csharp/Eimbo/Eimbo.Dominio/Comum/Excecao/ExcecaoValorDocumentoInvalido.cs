using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoValorDocumentoInvalido :ExcecaoParametroInvalido
    {
        public ExcecaoValorDocumentoInvalido(TipoDocumento tipoDocumento) :base(NomeTipoDocumento.ObtemString(tipoDocumento)) { }
    }
}
