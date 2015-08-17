using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class Telefone :ObjetoValor
    {
        private String _codigoArea;
        private String _primeiraSequencia;
        private String _segundaSequencia;
        private TipoTelefone _tipo;

        public TipoTelefone Tipo { get { return this._tipo; } }

        public String ValorTelefone 
        {
            get
            {
                return this.ToString();
            }
            set 
            {
                this._codigoArea = String.Empty;
                this._primeiraSequencia = String.Empty;
                this._segundaSequencia = String.Empty;

                if (String.IsNullOrWhiteSpace(value))
                    throw new ExcecaoParametroInvalido("Telefone.telefone");

                value = this.LimpaMascara(value);

                if (!value.Length.Equals(10))
                    throw new ExcecaoParametroInvalido("Telefone.telefone");

                this._codigoArea = value.Substring(0, 2);
                this._primeiraSequencia = value.Substring(2, 4);
                this._segundaSequencia = value.Substring(6, 4);
            }
        }

        protected Telefone() { }

        public Telefone(String telefone, TipoTelefone tipo)
        {
            this.ValorTelefone = telefone;
            this._tipo = tipo;
        }

        public override String ToString()
        {
            return (this._codigoArea + this._primeiraSequencia + this._segundaSequencia); // + this.Tipo.ToString());
        }

        public String ToStringFormatado()
        {
            //(xx) xxxx-xxxx
            return ("(" + this._codigoArea + ") " + this._primeiraSequencia + "-" + this._segundaSequencia);
        }

        protected override bool ComparaValor(ObjetoValor obj)
        {
            Telefone t = (Telefone)obj;
            return ((t.ValorTelefone + t.Tipo.ToString()).Equals(this.ValorTelefone + this._tipo.ToString()));
        }

        public override int GetHashCode()
        {
            return (this._codigoArea.GetHashCode()+this._primeiraSequencia.GetHashCode()+this._segundaSequencia.GetHashCode()+this._tipo.GetHashCode());
        }

        protected String LimpaMascara(String telefone)
        {
            return telefone.Replace(".", String.Empty).Replace("-", String.Empty).Replace("/", String.Empty).Replace("\\", String.Empty).Replace("(",String.Empty).Replace(")",String.Empty).Replace(" ", String.Empty);
        }
    }
}
