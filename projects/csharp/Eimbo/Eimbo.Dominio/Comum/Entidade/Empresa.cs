using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Entidade
{
    public class Empresa :Pessoa
    {
        protected Empresa() { }
        public Empresa(String Nome, DateTime DtNascimento) :base(Nome, DtNascimento)
        {
            base.TipoPessoa = TipoPessoa.Juridica;
            base.TipoCadastroPessoa = TipoCadastroPessoa.Empresa;
        }

        protected override TipoDocumento[] DocumentosPermitidos()
        {
            return new TipoDocumento[] { TipoDocumento.CNPJ, TipoDocumento.IE };
        }

        protected override TipoEndereco[] EnderecosPermitidos()
        {
            return new TipoEndereco[] { TipoEndereco.Cobranca, TipoEndereco.Comercial };
        }

        protected override TipoTelefone[] TelefonesPermitidos()
        {
            return new TipoTelefone[] { TipoTelefone.Comercial, TipoTelefone.Fax, TipoTelefone.Celular };
        }

    }
}
