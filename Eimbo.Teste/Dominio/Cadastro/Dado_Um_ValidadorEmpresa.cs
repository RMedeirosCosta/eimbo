using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Teste.Dominio.Comum.Stub;

namespace Eimbo.Teste.Dominio.Cadastro
{
    [TestClass]
    public class Dado_Um_ValidadorEmpresa
    {
        private Empresa _empresaPadrao;
        private Telefone _telefonePadrao;
        private Endereco _enderecoPadrao;

        public Dado_Um_ValidadorEmpresa()
        {
            this._empresaPadrao = EmpresaStub.GetInstance(0, "MR VIDRACARIA", DateTime.Now);
            this._telefonePadrao = new Telefone("(43) 3534-2350", TipoTelefone.Comercial);
            this._enderecoPadrao = new Endereco("Rua de teste", "823", new CEP("86430-000"), CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Comercial);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCNPJNaoInformado))]
        public void Nao_Devo_Conseguir_Validar_Sem_Nenhum_CNPJ_Adicionado()
        {
            this._empresaPadrao.AdicionaTelefone(this._telefonePadrao);
            this._empresaPadrao.AdicionaEndereco(this._enderecoPadrao);

            ValidadorEmpresa validador = new ValidadorEmpresa(null);

            try
            {
                validador.ValidarCamposObrigatorios(this._empresaPadrao);
            }
            catch (ExcecaoCNPJNaoInformado)
            {
                this._empresaPadrao.AdicionaDocumento(new IE("06388715907"));
                validador.ValidarCamposObrigatorios(this._empresaPadrao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumTelefoneInformado))]
        public void Nao_Devo_Conseguir_Validar_Sem_Nenhum_Telefone_Adicionado()
        {
            this._empresaPadrao.AdicionaDocumento(new CNPJ("12345678901234"));
            this._empresaPadrao.AdicionaEndereco(this._enderecoPadrao);

            ValidadorEmpresa validador = new ValidadorEmpresa(null);

            try
            {
                validador.ValidarCamposObrigatorios(this._empresaPadrao);
            }
            catch (ExcecaoNenhumTelefoneInformado)
            {
                this._empresaPadrao.AdicionaTelefone(this._telefonePadrao);
                this._empresaPadrao.RemoveTelefone(this._telefonePadrao);
                validador.ValidarCamposObrigatorios(this._empresaPadrao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoEnderecoComercialNaoInformado))]
        public void Nao_Devo_Conseguir_Validar_Sem_Nenhum_Endereco_Comercial()
        {
            this._empresaPadrao.AdicionaDocumento(new CNPJ("12345678901234"));
            this._empresaPadrao.AdicionaTelefone(this._telefonePadrao);

            ValidadorEmpresa validador = new ValidadorEmpresa(null);

            try
            {
                validador.ValidarCamposObrigatorios(this._empresaPadrao);
            }
            catch (ExcecaoEnderecoComercialNaoInformado)
            {
                this._empresaPadrao.AdicionaEndereco(new Endereco("Rua de teste", "823", new CEP("86430-000"), CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Cobranca));
                validador.ValidarCamposObrigatorios(this._empresaPadrao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCNPJJaCadastrado))]
        public void Nao_Devo_Conseguir_Validar_Uma_Nova_Empresa_Com_CNPJ_Cadastrado_Para_Outra_Empresa()
        {
            Empresa novaEmpresa = this._empresaPadrao;
            novaEmpresa.AdicionaDocumento(new CNPJ("12345678901234"));

            Empresa empresaCadastradaNoBancoDeDados = EmpresaStub.GetInstance(1, "UENP Universidade", DateTime.Now);
            empresaCadastradaNoBancoDeDados.AdicionaDocumento(new CNPJ("12345678901234"));

            ValidadorEmpresa validador = new ValidadorEmpresa(empresaCadastradaNoBancoDeDados);
            validador.ValidarDuplicidadeCNPJDeNovaEmpresa(novaEmpresa);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCNPJJaCadastrado))]
        public void Nao_Devo_Conseguir_Validar_Uma_Empresa_Em_Alteracao_Com_CNPJ_Cadastrado_Para_Outra_Empresa()
        {
            Empresa empresaEmAlteracao = EmpresaStub.GetInstance(1, "MR VIDRACARIA", DateTime.Now);
            empresaEmAlteracao.AdicionaDocumento(new CNPJ("12345678901234"));

            Empresa empresaCadastradaNoBancoDeDados = EmpresaStub.GetInstance(2, "UENP Universidade", DateTime.Now);
            empresaCadastradaNoBancoDeDados.AdicionaDocumento(new CNPJ("12345678901234"));

            ValidadorEmpresa validador = new ValidadorEmpresa(empresaCadastradaNoBancoDeDados);
            validador.ValidarDuplicidadeCNPJDeEmpresaEmAlteracao(empresaEmAlteracao);
        }

        [TestMethod]
        public void Devo_Conseguir_Validar_CNPJ_De_Uma_Empresa_Nova_Se_Nao_Houver_Outra_Empresa_Cadastrada()
        {
            Empresa novaEmpresa = this._empresaPadrao;
            novaEmpresa.AdicionaDocumento(new CNPJ("12345678901234"));

            ValidadorEmpresa validador = new ValidadorEmpresa(null);
            validador.ValidarDuplicidadeCNPJDeNovaEmpresa(novaEmpresa);
        }
    }
}
