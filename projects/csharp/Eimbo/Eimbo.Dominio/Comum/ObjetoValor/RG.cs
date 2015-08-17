using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class RG :Documento
    {
        public RG(String rg) :base(rg, TipoDocumento.RG) { }

        public static implicit operator RG(String rg)
        {
            return new RG(rg);
        }

        public override String MascaraParaFormatacao()
        {
            return "{0}.{1}.{2}-{3}";
        }

        public override String ToStringFormatado()
        {
            return string.Format(this.MascaraParaFormatacao(), base.ValorDocumento.Substring(0, 1), base.ValorDocumento.Substring(1, 3), base.ValorDocumento.Substring(4, 3), base.ValorDocumento.Substring(7, 1));
        }

        public override bool ValidaDocumento()
        {
            return true;
        }

    }
}
