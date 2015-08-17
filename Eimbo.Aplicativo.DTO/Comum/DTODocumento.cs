using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.DTO.Comum
{
    public class DTODocumento
    {
        public String ValorDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }

        public Documento ConverteDTOParaDocumento()
        {
            Documento doc;

            switch (this.TipoDocumento)
            {
                case TipoDocumento.CNPJ: doc = new CNPJ(this.ValorDocumento);
                    break;
                case TipoDocumento.CPF: doc = new CPF(this.ValorDocumento);
                    break;
                case TipoDocumento.IE: doc = new IE(this.ValorDocumento);
                    break;
                case TipoDocumento.RG: doc = new RG(this.ValorDocumento);
                    break;
                default: doc = null;
                    break;
            }

            return doc;
        }
    }
}
