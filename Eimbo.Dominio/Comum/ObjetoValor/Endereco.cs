using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class Endereco :ObjetoValor
    {
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual CEP Cep { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }

        protected Endereco() { }

        public Endereco(string logradouro, string numero, CEP cep, Cidade cidade, TipoEndereco tipoEndereco)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
                throw new Excecao.ExcecaoParametroInvalido("Endereco.Logradouro");

            if (string.IsNullOrWhiteSpace(numero))
                throw new Excecao.ExcecaoParametroInvalido("Endereco.Numero");

            if ((cep == null) || (string.IsNullOrEmpty(cep.Cep.Trim())))
                throw new Excecao.ExcecaoParametroInvalido("Endereco.Cep");

            if (cidade == null)
                throw new Excecao.ExcecaoParametroInvalido("Endereco.Cidade");

            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Cep = cep;
            this.Cidade = cidade;
            this.TipoEndereco = tipoEndereco;
        }

        public override string ToString()
        {
            return (this.Logradouro + " " + this.Numero + " " + this.Cep + " " + this.Cidade.Nome + " " + this.Cidade.Estado.UF + this.TipoEndereco.ToString());
        }

        public override int GetHashCode()
        {
            return base.ToString().GetHashCode();
        }

        protected override bool ComparaValor(ObjetoValor obj)
        {
            return (this.ToString().Equals(obj.ToString()));
        }
    }
}
