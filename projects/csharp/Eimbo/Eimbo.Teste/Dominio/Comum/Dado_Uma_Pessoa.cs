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
    public class Dado_Uma_Pessoa
    {
        private Pessoa _pessoaPadrao;
        private Telefone _telefonePadrao;
        private Endereco _enderecoPadrao;

        public Dado_Uma_Pessoa()
        {
            this._pessoaPadrao = new Empresa("MR VIDRAÇARIA", DateTime.Now);
            this._telefonePadrao = new Telefone("(43) 3534-2350", TipoTelefone.Comercial);
            CEP cep = "86430-000";
            Cidade cidade = CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR"));
            this._enderecoPadrao = new Endereco("RUA JOSÉ BONIFÁCIO", "834", cep, cidade, TipoEndereco.Cobranca);
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Uma_Pessoa_Valida()
        {
            Pessoa pessoa = new Empresa("Cbn Informática   ", DateTime.Now);

            Assert.AreEqual(pessoa.Nome, "CBN INFORMÁTICA");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Nome_Invalido()
        {
            Pessoa empresa = new Empresa("", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Data_Invalida()
        {
            Pessoa empresa = new Empresa("MR VIDRAÇARIA", default(System.DateTime));
        }

        #region Telefone

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Telefone_Invalido()
        {
            this._pessoaPadrao.AdicionaTelefone(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroRepetido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Telefone_Repetido()
        {
            this._pessoaPadrao.AdicionaTelefone(this._telefonePadrao);
            this._pessoaPadrao.AdicionaTelefone(this._telefonePadrao);
        }

        [TestMethod]
        public void Devo_Conseguir_Remover_Um_Telefone()
        {
            this._pessoaPadrao.AdicionaTelefone(this._telefonePadrao);
            this._pessoaPadrao.RemoveTelefone(this._telefonePadrao);
        }

        #endregion

        #region Endereco
        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Endereco_Invalido()
        {
            this._pessoaPadrao.AdicionaTelefone(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroRepetido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Endereco_Repetido()
        {
            this._pessoaPadrao.AdicionaEndereco(this._enderecoPadrao);
            this._pessoaPadrao.AdicionaEndereco(this._enderecoPadrao);
        }

        [TestMethod]
        public void Devo_Conseguir_Remover_Um_Endereco()
        {
            this._pessoaPadrao.AdicionaEndereco(this._enderecoPadrao);
            this._pessoaPadrao.RemoveEndereco(this._enderecoPadrao);
        }

        #endregion

        #region Documento
        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Documento_Invalido()
        {
            this._pessoaPadrao.AdicionaDocumento(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroRepetido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Documento_Repetido()
        {
            this._pessoaPadrao.AdicionaDocumento(new CNPJ("01934032000127"));
            this._pessoaPadrao.AdicionaDocumento(new CNPJ("019.340.32.0001-27"));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoDocumentoNaoPermitido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Documento_Nao_Permitido()
        {
            RG rg = "9.845.796-8";
            this._pessoaPadrao.AdicionaDocumento(rg);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoTipoDocumentoDuplicado))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Documento_De_Um_Tipo_Ja_Adicionado()
        {
            IE ie = "9.845.796-8";
            this._pessoaPadrao.AdicionaDocumento(new IE("98467968"));
            this._pessoaPadrao.AdicionaDocumento(ie);
        }

        [TestMethod]
        public void Devo_Conseguir_Remover_Um_Documento()
        {
            this._pessoaPadrao.AdicionaDocumento(new IE("9.845.796-8"));
            this._pessoaPadrao.RemoveDocumento(new IE("9.845.796-8"));
        }


        // MUDAR_AQUI_3
        // Para esse teste preciso verificar se o validador também funciona com CNPJ
        //[TestMethod]
        //[ExpectedException(typeof(ExcecaoValorDocumentoInvalido))]
        //public void Nao_Devo_Conseguir_Adicionar_Um_Documento_Com_Valor_Invalido()
        //{
        //    CNPJ cnpj = "00000000000";
        //    this._empresaPadrao.AdicionaDocumento(cnpj);
        //}

        #endregion

    }
}
