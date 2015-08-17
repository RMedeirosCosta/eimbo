using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Entidade
{
    public class Cliente :Pessoa
    {
        protected Cliente() { }
        public Cliente(String Nome, DateTime DtNascimento)
            : base(Nome, DtNascimento)
        {
            base.TipoPessoa = TipoPessoa.Fisica;
            base.TipoCadastroPessoa = TipoCadastroPessoa.Cliente;
        }

        protected override TipoDocumento[] DocumentosPermitidos()
        {
            return new TipoDocumento[] { TipoDocumento.CPF, TipoDocumento.RG };
        }

        protected override TipoEndereco[] EnderecosPermitidos()
        {
            return new TipoEndereco[] { TipoEndereco.Cobranca, TipoEndereco.Comercial, TipoEndereco.Residencial };
        }

        protected override TipoTelefone[] TelefonesPermitidos()
        {
            return new TipoTelefone[] { TipoTelefone.Comercial, TipoTelefone.Fax, TipoTelefone.Celular, TipoTelefone.Residencial };
        }


    }
}
