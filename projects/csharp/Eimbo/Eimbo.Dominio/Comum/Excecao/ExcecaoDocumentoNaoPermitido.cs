using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoDocumentoNaoPermitido :Exception
    {
        public ExcecaoDocumentoNaoPermitido
        (TipoPessoa tipoPessoa, TipoDocumento tipoDocumento)
        :base(RetornaMensagemErro(tipoPessoa, tipoDocumento)) { }

        private static String RetornaMensagemErro(TipoPessoa tipoPessoa, TipoDocumento tipoDocumento)
        {
            return NomeTipoPessoa.Obtem(tipoPessoa) + " não pode conter " + NomeTipoDocumento.ObtemString(tipoDocumento) + "!";
        }
        
    }
}
