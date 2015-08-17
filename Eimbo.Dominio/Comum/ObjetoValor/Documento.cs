using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class Documento :ObjetoValor
    {
        private   String _valorDocumento;

        public String ValorDocumento
        {
            get 
            {
                return this._valorDocumento;
            }
            set
            {
                value = this.LimpaMascara(value);
                this._valorDocumento = value;
            }
        }

        protected Documento() { }

        private TipoDocumento _tipoDocumento;
        public TipoDocumento TipoDocumento { get{ return this._tipoDocumento; } }

        public Documento(String valorDocumento, TipoDocumento tipoDocumento)
        {
            this._tipoDocumento = tipoDocumento;
            this.ValorDocumento = valorDocumento;
        }

        public override String ToString()
        {
            return this._valorDocumento;
        }

        protected override bool ComparaValor(ObjetoValor obj)
        {
            return (this.ToString().Equals(obj.ToString()));
        }

        public override int GetHashCode()
        {
            return this._valorDocumento.GetHashCode();
        }

        protected String LimpaMascara(string valorDocumento)
        {
            return valorDocumento.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace("\\", string.Empty);
        }

        public virtual String MascaraParaFormatacao()   { throw new NotImplementedException(); }
        public virtual String ToStringFormatado()       { throw new NotImplementedException(); }
        public virtual Boolean ValidaDocumento()        { throw new NotImplementedException(); }
    }
}
