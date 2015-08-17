using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class CEP :ObjetoValor
    {
        private String _cep;
        public String Cep 
        {
            get { return this._cep; }
            set
            {
                this._cep = value.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace("\\", string.Empty);
            }
        }

        public CEP(String cep)
        {
            this.Cep = cep;
        }

        protected CEP()
        {

        }

        public static implicit operator CEP(String cep)
        {
            return new CEP(cep);
        }

        public override string ToString()
        {
            return this._cep;
        }

        public String ToStringFormatado()
        {
            //01234-567
            //86430-000
            return String.Format("{0}-{1}", this.ToString().Substring(0, 5), this.ToString().Substring(4, 3));
        }

        protected override bool ComparaValor(ObjetoValor obj)
        {
            return this.ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return this._cep.GetHashCode();
        }

    }
}
