using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoTipoDocumentoDuplicado :Exception
    {
        public ExcecaoTipoDocumentoDuplicado(TipoDocumento tipoDocumento) : base(RetornaMensagemErro(tipoDocumento)) { }

        private static String RetornaMensagemErro(TipoDocumento tipoDocumento)
        {
            String nomeDocumento = String.Empty;

            switch (tipoDocumento)
            {
                case TipoDocumento.RG:   nomeDocumento = "RG";   break;
                case TipoDocumento.CPF:  nomeDocumento = "CPF";  break;
                case TipoDocumento.IE:   nomeDocumento = "IE";   break;
                case TipoDocumento.CNPJ: nomeDocumento = "CNPJ"; break;
            }

            return "Apenas um " + nomeDocumento + " é permitido!";
        }
    }
}
