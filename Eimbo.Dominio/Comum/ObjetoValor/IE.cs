using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class IE :Documento
    {
        public IE(String ie) : base(ie, TipoDocumento.IE) { }

        public static implicit operator IE(String ie)
        {
            return new IE(ie);
        }

        public override String MascaraParaFormatacao()
        {
            return "";
        }

        public override String ToStringFormatado()
        {
            return base.ToString();
        }

        public override bool ValidaDocumento()
        {
            return true;
        }        
    }
}
