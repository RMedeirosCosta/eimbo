using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Teste.Dominio.Comum.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eimbo.Teste.Dominio.Cadastro
{
    [TestClass]
    public class Dado_Um_ValidadorServico
    {
        [TestMethod]
        public void Devo_Conseguir_Validar_Um_Novo_Servico_Se_Nao_Houver_Nenhum_Com_A_Mesma_Descricao_Cadastrada()
        {
            Servico novoServico  = new Servico("Escova", 1m);
            ValidadorServico validador = new ValidadorServico(null);
            validador.ValidarNovoServico(novoServico);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoDescricaoServicoJaCadastrada))]
        public void Nao_Devo_Validar_Um_Novo_Servico_Com_Descricao_De_Outro_Servico_Cadastrado()
        {
            Servico novoServico = new Servico("ESCOVA", 1m);
            Servico servicoCadastrado = ServicoStub.GetInstance(1, "escova", 2m);
            ValidadorServico validador;

            try
            {
                validador = new ValidadorServico(servicoCadastrado);
                validador.ValidarNovoServico(novoServico);
            }
            catch (ExcecaoDescricaoServicoJaCadastrada)
            {
                novoServico = new Servico("escOvA  ", 1m);
                validador = new ValidadorServico(servicoCadastrado);
                validador.ValidarNovoServico(novoServico);
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Validar_Um_Servico_Em_Alteracao_Que_Tenha_A_Mesma_Descricao_Que_Tinha_Antes_Da_Alteracao()
        {
            Servico servicoEmAlteracao = ServicoStub.GetInstance(1, "escova", 1m);
            Servico servicoCadastrado = ServicoStub.GetInstance(1, "ESCOVA", 2m);

            ValidadorServico validador = new ValidadorServico(servicoCadastrado);
            validador.ValidarServicoEmAlteracao(servicoEmAlteracao);
        }

        [TestMethod]
        public void Devo_Conseguir_Validar_Um_Servico_Em_Alteracao_Caso_Nao_Seja_Encontrado_Nenhum_Servico_Com_A_Mesma_Descricao_Que_Ele()
        {
            Servico servicoEmAlteracao = ServicoStub.GetInstance(1, "escova", 1m);

            ValidadorServico validador = new ValidadorServico(null);
            validador.ValidarServicoEmAlteracao(servicoEmAlteracao);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoDescricaoServicoJaCadastrada))]
        public void Nao_Devo_Conseguir_Validador_Um_Servico_Em_Alteracao_Com_Descricao_Igual_De_Outro_Servico_Cadastrado()
        {
            Servico servicoEmAlteracao = ServicoStub.GetInstance(1, "escova", 1m);
            Servico servicoCadastrado = ServicoStub.GetInstance(2, "ESCOVA", 2m);            
            ValidadorServico validador;

            try
            {
                validador = new ValidadorServico(servicoCadastrado);
                validador.ValidarServicoEmAlteracao(servicoEmAlteracao);
            }
            catch (ExcecaoDescricaoServicoJaCadastrada)
            {
                servicoEmAlteracao.Descricao = "  ESCoVA";
                validador = new ValidadorServico(servicoCadastrado);
                validador.ValidarServicoEmAlteracao(servicoEmAlteracao);
            }
        }
    }
}
