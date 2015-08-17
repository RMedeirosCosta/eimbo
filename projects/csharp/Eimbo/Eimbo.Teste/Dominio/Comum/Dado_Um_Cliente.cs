using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Teste.Dominio.Comum.Stub;

namespace Eimbo.Teste.Dominio.Comum
{
    [TestClass]
    public class Dado_Um_Cliente
    {
        private Cliente _clientePadrao;

        public Dado_Um_Cliente()
        {
            this._clientePadrao = new Cliente("RICARDO MEDEIROS DA COSTA JUNIOR", Convert.ToDateTime("14/08/1991"));
        }

        #region Telefone
        [TestMethod]
        public void Devo_Conseguir_Adicionar_Telefones_Do_Tipo_Residencial_Celular_Fax_Residencial()
        {
            this._clientePadrao.AdicionaTelefone(new Telefone("(43) 3534-1350", TipoTelefone.Residencial));
            this._clientePadrao.AdicionaTelefone(new Telefone("(43) 3534-2350", TipoTelefone.Comercial));
            this._clientePadrao.AdicionaTelefone(new Telefone("(43) 9957-9663", TipoTelefone.Celular));
            this._clientePadrao.AdicionaTelefone(new Telefone("(43) 3534-2350", TipoTelefone.Fax));
        }
        #endregion Telefone

        #region Endereço
        [TestMethod]
        public void Devo_Conseguir_Adicionar_Enderecos_Do_Tipo_Residencial_Comercial_Cobranca()
        {
            CEP cep = "86430-000";
            this._clientePadrao.AdicionaEndereco(new Endereco("RUA JOSÉ BONIFÁCIO", "1231", cep, CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Comercial));
            this._clientePadrao.AdicionaEndereco(new Endereco("RUA JOSÉ BONIFÁCIO", "1231", cep, CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Cobranca));
            this._clientePadrao.AdicionaEndereco(new Endereco("RUA JOSÉ BONIFÁCIO", "1231", cep, CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Residencial));
        }
        #endregion

    }
}
