using System;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Teste.Dominio.Comum.Stub;

using Moq;
using Moq.Properties;
using Moq.Protected;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eimbo.Teste.Dominio.Cadastro
{
    [TestClass]
    public class Dado_Um_ValidadorFormaPagamento
    {
        [TestMethod]
        public void Devo_Validar_Uma_Nova_Forma_Pagamento()
        {
            var mockFormaPagamentoNova = new Mock<FormaPagamento>();

            mockFormaPagamentoNova.Setup(f => f.Id).Returns(0);
            mockFormaPagamentoNova.Setup(f => f.Descricao).Returns("À vista");

            ValidadorFormaPagamento validador = new ValidadorFormaPagamento(null);
            validador.ValidarNovaFormaPagamento(mockFormaPagamentoNova.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoDescricaoFormaPagamentoJaCadastrada))]
        public void Nao_Devo_Validar_Uma_Nova_Forma_Pagamento_Com_Descricao_De_Outra_Forma_Pagamento_Cadastrada()
        {
            var mockFormaPagamentoNova = new Mock<FormaPagamento>();

            mockFormaPagamentoNova.Setup(f => f.Id).Returns(0);
            mockFormaPagamentoNova.Setup(f => f.Descricao).Returns("À vista");


            var mockFormaPagamentoEncontradaNoBD = new Mock<FormaPagamento>();

            mockFormaPagamentoEncontradaNoBD.Setup(f => f.Id).Returns(1);
            mockFormaPagamentoEncontradaNoBD.Setup(f => f.Descricao).Returns("À vista");

            ValidadorFormaPagamento validador = new ValidadorFormaPagamento(mockFormaPagamentoEncontradaNoBD.Object);
            validador.ValidarNovaFormaPagamento(mockFormaPagamentoNova.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoDescricaoFormaPagamentoJaCadastrada))]
        public void Nao_Devo_Validar_Uma_Forma_Pagamento_Em_Alteracao_Com_Descricao_Igual_De_Outra_Forma_Pagamento_Cadastrada()
        {
            var mockFormaPagamentoEmAlteracao = new Mock<FormaPagamento>();

            mockFormaPagamentoEmAlteracao.Setup(f => f.Id).Returns(1);
            mockFormaPagamentoEmAlteracao.Setup(f => f.Descricao).Returns("À vista");

            var mockFormaPagamentoEncontradaNoBD = new Mock<FormaPagamento>();

            mockFormaPagamentoEncontradaNoBD.Setup(f => f.Id).Returns(2);
            mockFormaPagamentoEncontradaNoBD.Setup(f => f.Descricao).Returns("À vista");

            ValidadorFormaPagamento validador = new ValidadorFormaPagamento(mockFormaPagamentoEncontradaNoBD.Object);
            validador.ValidarFormaPagamentoEmAlteracao(mockFormaPagamentoEmAlteracao.Object);
        }

        [TestMethod]
        public void Devo_Validar_Uma_Forma_Pagamento_Em_Alteracao_Se_Nao_Houver_Nenhuma_Outra_Forma_Pagamento_Cadastrada_Com_Essa_Descricao()
        {
            var mockFormaPagamentoEmAlteracao = new Mock<FormaPagamento>();

            mockFormaPagamentoEmAlteracao.Setup(f => f.Id).Returns(1);
            mockFormaPagamentoEmAlteracao.Setup(f => f.Descricao).Returns("À vista");

            ValidadorFormaPagamento validador = new ValidadorFormaPagamento(null);
            validador.ValidarFormaPagamentoEmAlteracao(mockFormaPagamentoEmAlteracao.Object);
        }
    }
}
