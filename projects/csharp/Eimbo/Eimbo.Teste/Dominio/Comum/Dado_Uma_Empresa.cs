using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Teste.Dominio.Comum.Stub;

namespace Eimbo.Eimbo.Dominio.Comum
{
    [TestClass]
    public class Dado_Uma_Empresa
    {
        private Empresa _empresaPadrao;

        public Dado_Uma_Empresa()
        {
            this._empresaPadrao = new Empresa("MR VIDRAÇARIA", DateTime.Now);
        }

        #region Telefone

        [TestMethod]
        [ExpectedException(typeof(ExcecaoTelefoneNaoPermitido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Telefone_Residencial()
        {
            this._empresaPadrao.AdicionaTelefone(new Telefone("(43) 3534-2350", TipoTelefone.Residencial));
        }

        [TestMethod]
        public void Devo_Conseguir_Adicionar_Telefones_Do_Tipo_Celular_Fax_Residencial()
        {
            this._empresaPadrao.AdicionaTelefone(new Telefone("(43) 3534-2350", TipoTelefone.Comercial));
            this._empresaPadrao.AdicionaTelefone(new Telefone("(43) 9957-9663", TipoTelefone.Celular));
            this._empresaPadrao.AdicionaTelefone(new Telefone("(43) 3534-2350", TipoTelefone.Fax));
        }

        #endregion Telefone

        #region Endereço

        [TestMethod]
        [ExpectedException(typeof(ExcecaoEnderecoNaoPermitido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Endereco_Residencial()
        {
            CEP cep = "86430-000";
            this._empresaPadrao.AdicionaEndereco(new Endereco("RUA JOSÉ BONIFÁCIO", "1231", cep, CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Residencial));
        }

        [TestMethod]
        public void Devo_Conseguir_Adicionar_Enderecos_Do_Tipo_Comercial_Cobranca()
        {
            CEP cep = "86430-000";
            this._empresaPadrao.AdicionaEndereco(new Endereco("RUA JOSÉ BONIFÁCIO", "1231", cep, CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Comercial));
            this._empresaPadrao.AdicionaEndereco(new Endereco("RUA JOSÉ BONIFÁCIO", "1231", cep, CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Cobranca));
        }

        #endregion
    }
}
