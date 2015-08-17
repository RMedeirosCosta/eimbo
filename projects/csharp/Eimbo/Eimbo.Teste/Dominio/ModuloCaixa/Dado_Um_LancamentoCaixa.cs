using System;

using Eimbo.Dominio.ModuloCaixa.Entidade;
using Eimbo.Dominio.ModuloCaixa.Tipo;
using Eimbo.Dominio.Comum.Excecao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eimbo.Teste.Dominio.ModuloCaixa
{
    [TestClass]
    public class Dado_Um_LancamentoCaixa
    {
        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Descricao_Invalida()
        {
            try
            {
                LancamentoCaixa lancamento = new LancamentoCaixa("", TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, 0m);
            }
            catch (ExcecaoParametroInvalido)
            {
                try
                {
                    LancamentoCaixa lancamento = new LancamentoCaixa(null, TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, 0m);
                }
                catch (ExcecaoParametroInvalido ex)
                {
                    if (ex.Message.Equals("Descricao"))
                        throw new ExcecaoParametroInvalido("Excecao");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_TipoMovimentacao_Invalido()
        {
            try
            {
                LancamentoCaixa lancamento = new LancamentoCaixa("TESTE", TipoMovimentacaoLancamentoCaixa.Nenhum, TipoPagamentoLancamentoCaixa.Dinheiro,  0m);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("TipoMovimentacao"))
                    throw new ExcecaoParametroInvalido("TipoMovimentacao");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_TipoPagamento_Invalido()
        {
            try
            {
                LancamentoCaixa lancamento = new LancamentoCaixa("TESTE", TipoMovimentacaoLancamentoCaixa.Saida, TipoPagamentoLancamentoCaixa.Nenhum, 0m);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("TipoPagamento"))
                    throw new ExcecaoParametroInvalido("TipoPagamento");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Valor_Invalido()
        {
            LancamentoCaixa lancamento;

            try
            {
                lancamento = new LancamentoCaixa("TESTE", TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, 0m);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                try
                {
                    if (ex.Message.Equals("Valor"))
                        lancamento = new LancamentoCaixa("TESTE", TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, -1);

                }catch(ExcecaoParametroInvalido e)
                {
                    if (e.Message.Equals("Valor"))
                        throw new ExcecaoParametroInvalido("Valor");
                }

            }
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Valido()
        {
            LancamentoCaixa lancamento = new LancamentoCaixa(" teste  ", TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, 10);

            Assert.AreEqual(DateTime.Now, lancamento.DiaHorario);
            Assert.AreEqual("TESTE", lancamento.Descricao);
            Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Entrada, lancamento.TipoMovimentacao);
            Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, lancamento.TipoPagamento);
            Assert.AreEqual(10, lancamento.Valor);
        }
    }
}
