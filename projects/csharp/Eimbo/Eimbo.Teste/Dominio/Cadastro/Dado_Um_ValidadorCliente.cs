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
    public class Dado_Um_ValidadorCliente
    {
        private Cliente _clientePadrao;
        private Endereco _enderecoPadrao;
        private Telefone _telefonePadrao;

        public Dado_Um_ValidadorCliente()
        {
            this._clientePadrao = ClienteStub.GetInstance(0, "RICARDO MEDEIROS DA COSTA JUNIOR", Convert.ToDateTime("14/08/1991"));
            this._enderecoPadrao = new Endereco("RUA JOSÉ BONIFÁCIO", "834", new CEP("86430-000"), CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", EstadoStub.GetInstance(1, "PR")), TipoEndereco.Residencial);
            this._telefonePadrao = new Telefone("(43) 9957-9663", TipoTelefone.Celular);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCPFNaoInformado))]
        public void Nao_Devo_Conseguir_Validar_Sem_Nenhum_CPF_Adicionado()
        {
            this._clientePadrao.AdicionaTelefone(this._telefonePadrao);
            this._clientePadrao.AdicionaEndereco(this._enderecoPadrao);

            ValidadorCliente validador = new ValidadorCliente(null);

            try
            {
                // Primeiro testo se não há nenhum cpf com a coleção nula
                validador.ValidarCamposObrigatorios(this._clientePadrao);
            }
            catch (ExcecaoCPFNaoInformado)
            {
                // Depois testo com a coleção instânciada
                this._clientePadrao.AdicionaDocumento(new RG("89457968"));
                validador.ValidarCamposObrigatorios(this._clientePadrao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumTelefoneInformado))]
        public void Nao_Devo_Conseguir_Validar_Sem_Nenhum_Telefone_Adicionado()
        {
            this._clientePadrao.AdicionaDocumento(new CPF("12345678901234"));
            this._clientePadrao.AdicionaEndereco(this._enderecoPadrao);

            ValidadorCliente validador = new ValidadorCliente(null);

            try
            {
                validador.ValidarCamposObrigatorios(this._clientePadrao);
            }
            catch(ExcecaoNenhumTelefoneInformado)
            {
                this._clientePadrao.AdicionaTelefone(this._telefonePadrao);
                this._clientePadrao.RemoveTelefone(this._telefonePadrao);
                validador.ValidarCamposObrigatorios(this._clientePadrao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumEnderecoInformado))]
        public void Nao_Devo_Conseguir_Validar_Sem_Nenhum_Endereco()
        {
            this._clientePadrao.AdicionaDocumento(new CPF("12345678901234"));
            this._clientePadrao.AdicionaTelefone(this._telefonePadrao);

            ValidadorCliente validador = new ValidadorCliente(null);

            try
            {
                validador.ValidarCamposObrigatorios(this._clientePadrao);
            }
            catch (ExcecaoNenhumEnderecoInformado)
            {
                this._clientePadrao.AdicionaEndereco(this._enderecoPadrao);
                this._clientePadrao.RemoveEndereco(this._enderecoPadrao);
                validador.ValidarCamposObrigatorios(this._clientePadrao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCPFJaCadastrado))]
        public void Nao_Devo_Conseguir_Validar_Um_Novo_Cliente_Com_CPF_Cadastrado_Para_Outro_Cliente()
        {
            Cliente novoCliente = ClienteStub.GetInstance(0, "LIONEL MESSI", DateTime.Now);
            novoCliente.AdicionaDocumento(new CPF("12345678901234"));

            Cliente clienteCadastradoNoBancoDeDados = this._clientePadrao;
            clienteCadastradoNoBancoDeDados.AdicionaDocumento(new CPF("12345678901234"));

            ValidadorCliente validador = new ValidadorCliente(clienteCadastradoNoBancoDeDados);
            validador.ValidarDuplicidadeCPFDeNovoCliente(novoCliente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCPFJaCadastrado))]
        public void Nao_Devo_Conseguir_Validar_Um_Cliente_Em_Alteracao_Com_CPF_Cadastrado_Para_Outro_Cliente()
        {
            Cliente clienteEmAlteracao = ClienteStub.GetInstance(1, "LIONEL MESSI", DateTime.Now);
            clienteEmAlteracao.AdicionaDocumento(new CPF("12345678901234"));

            Cliente clienteCadastradoNoBancoDeDados = ClienteStub.GetInstance(2, "LIONEL MESSI", DateTime.Now);
            clienteCadastradoNoBancoDeDados.AdicionaDocumento(new CPF("12345678901234"));

            ValidadorCliente validador = new ValidadorCliente(clienteCadastradoNoBancoDeDados);
            validador.ValidarDuplicidadeCPFDeClienteEmAlteracao(clienteEmAlteracao);
        }

        [TestMethod]
        public void Devo_Conseguir_Validar_Um_Cliente_Em_Alteracao_Se_Nao_For_Encontrado_Nenhum_CPF_Igual_Ao_Dele()
        {
            Cliente clienteEmAlteracao = ClienteStub.GetInstance(1, "LIONEL MESSI", DateTime.Now);
            clienteEmAlteracao.AdicionaDocumento(new CPF("12345678901234"));

            ValidadorCliente validador = new ValidadorCliente(null);
            validador.ValidarDuplicidadeCPFDeClienteEmAlteracao(clienteEmAlteracao);
        }
    }
}
