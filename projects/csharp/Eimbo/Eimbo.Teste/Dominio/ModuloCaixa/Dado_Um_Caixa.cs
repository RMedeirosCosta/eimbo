using System;
using System.Collections.Generic;

using Eimbo.Dominio.ModuloCaixa.Entidade;
using Eimbo.Dominio.ModuloCaixa.Excecao;
using Eimbo.Dominio.ModuloCaixa.Tipo;
using Eimbo.Dominio.Comum.Excecao;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Eimbo.Teste.Dominio.ModuloCaixa
{
    [TestClass]
    public class Dado_Um_Caixa
    {
        private Caixa _caixa;

        public Dado_Um_Caixa()
        {
            // Instancializo um pequeno caixa para verificar se os valores irão bater.
            this._caixa = new Caixa(130);
            this._caixa.EfetuarSangria(30);
            this._caixa.EfetuarReforco(10);
            this._caixa.EfetuarReforco(50);
            this._caixa.ReceberAtendimentoCartaoCredito(150);
            this._caixa.ReceberAtendimentoCartaoCredito(150);
            this._caixa.ReceberAtendimentoCartaoDebito(100);
            this._caixa.ReceberAtendimentoCartaoDebito(100);
            this._caixa.ReceberAtendimentoCartaoDebito(1200);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoSaldoAberturaInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Saldo_Negativo()
        {
            Caixa caixa = new Caixa(-1);
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Valido()
        {
            decimal SaldoAbertura = 100m;
            Caixa caixa = new Caixa(SaldoAbertura);

            Assert.IsTrue(caixa.EstaAberto);
            Assert.AreEqual(DateTime.Today, caixa.DataAbertura.Date);
            Assert.AreEqual(100m, caixa.SaldoGeral);
        }

        [TestMethod]
        public void Devo_Conseguir_Abrir_Um_Caixa_Fechado()
        {
            Caixa caixa = new Caixa(0);
            caixa.Fechar();
            caixa.Abrir();

            Assert.IsTrue(caixa.EstaAberto);
            Assert.AreEqual(DateTime.Today, caixa.DataAbertura.Date);
            Assert.AreEqual(DateTime.MinValue, caixa.DataFechamento);
        }

        [TestMethod]
        public void Se_Nao_Possuir_Lancamentos_Saldo_Deve_Retornar_Zerado()
        {
            Caixa caixa = new Caixa(0);

            Assert.IsTrue(caixa.EstaAberto);
            Assert.AreEqual(DateTime.Today, caixa.DataAbertura.Date);
            Assert.AreEqual(0, caixa.SaldoGeral);
        }

        [TestMethod]
        public void Devo_Conseguir_Efetuar_Reforco()
        {
            Caixa caixa = new Caixa(0);
            caixa.EfetuarReforco(200);

            foreach(LancamentoCaixa l in caixa.Lancamentos)
            {
                Assert.AreEqual(200, l.Valor);
                Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Entrada, l.TipoMovimentacao);
                Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, l.TipoPagamento);
                Assert.AreEqual("REFORÇO", l.Descricao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Efetuar_Reforco_Invalido()
        {
            Caixa caixa = new Caixa(0);
            try
            {
                caixa.EfetuarReforco(-200);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("valor"))
                {
                    try
                    {
                        caixa.EfetuarReforco(0);
                    }
                    catch (ExcecaoParametroInvalido e)
                    {
                        if (e.Message.Equals("valor"))
                            throw new ExcecaoParametroInvalido(ex.Message);
                    }
                }
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Efetuar_Sangria()
        {
            Caixa caixa = new Caixa(201);
            caixa.EfetuarSangria(200);

            foreach (LancamentoCaixa l in caixa.Lancamentos)
            {
                if (l.Descricao.Equals("SALDO DE ABERTURA"))
                    continue;

                Assert.AreEqual(200, l.Valor);
                Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Saida, l.TipoMovimentacao);
                Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, l.TipoPagamento);
                Assert.AreEqual("SANGRIA", l.Descricao);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Efetuar_Sangria_Invalida()
        {
            Caixa caixa = new Caixa(0);
            try
            {
                caixa.EfetuarSangria(-200);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("valor"))
                {
                    try
                    {
                        caixa.EfetuarSangria(0);
                    }
                    catch (ExcecaoParametroInvalido e)
                    {
                        if (e.Message.Equals("valor"))
                            throw new ExcecaoParametroInvalido(ex.Message);
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoValorInsuficienteEmCaixa))]
        public void Nao_Devo_Conseguir_Efetuar_Sangria_Caso_O_Valor_Da_Sangria_For_Maior_Que_O_Saldo_Em_Dinheiro_Do_Caixa()
        {
            Caixa caixa = new Caixa(175);
            caixa.EfetuarSangria(200);
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_Extrato_Ordenado()
        {
            int contador = 0;

            foreach (LancamentoCaixa l in this._caixa.Lancamentos)
            {
                switch (contador)
                {
                    case 0:
                            Assert.AreEqual("SALDO DE ABERTURA", l.Descricao);
                            Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Entrada, l.TipoMovimentacao);
                            Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, l.TipoPagamento);
                            Assert.AreEqual(130, l.Valor);
                         break;
                    case 1:
                         Assert.AreEqual("SANGRIA", l.Descricao);
                         Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Saida, l.TipoMovimentacao);
                         Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, l.TipoPagamento);
                         Assert.AreEqual(30, l.Valor);
                         break;
                    case 2:
                         Assert.AreEqual("REFORÇO", l.Descricao);
                         Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Entrada, l.TipoMovimentacao);
                         Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, l.TipoPagamento);
                         Assert.AreEqual(10, l.Valor);
                         break;
                    case 3:
                         Assert.AreEqual("REFORÇO", l.Descricao);
                         Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Entrada, l.TipoMovimentacao);
                         Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, l.TipoPagamento);
                         Assert.AreEqual(50, l.Valor);
                         break;
                    case 4:
                         Assert.AreEqual("ATENDIMENTO", l.Descricao);
                         Assert.AreEqual(TipoMovimentacaoLancamentoCaixa.Entrada, l.TipoMovimentacao);
                         Assert.AreEqual(TipoPagamentoLancamentoCaixa.CartaoCredito, l.TipoPagamento);
                         Assert.AreEqual(150, l.Valor);
                         break;
                }

                contador++;
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Fechar()
        {
            Caixa caixa = new Caixa(100);
            caixa.Fechar();

            Assert.IsFalse(caixa.EstaAberto);
            Assert.AreEqual(DateTime.Now, caixa.DataFechamento);
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_SaldoAbertura_TotalAtendimentos_TotalSangrias_TotalReforcos_TotalTrocos()
        {
            this._caixa.EfetuarSaidaParaTroco(10);

            Assert.AreEqual(130, this._caixa.SaldoAbertura);
            Assert.AreEqual(30, this._caixa.TotalSangrias);
            Assert.AreEqual(60, this._caixa.TotalReforcos);
            Assert.AreEqual(0, this._caixa.TotalAtendimentosDinheiro);
            Assert.AreEqual(10, this._caixa.TotalTrocos);
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_SaldoDinheiro_SaldoCartaoCredito_SaldoCartaoDebito_SaldoGeral()
        {
            Assert.AreEqual(160, this._caixa.SaldoDinheiro);
            Assert.AreEqual(300, this._caixa.SaldoCartaoCredito);
            Assert.AreEqual(1400, this._caixa.SaldoCartaoDebito);
            Assert.AreEqual(1860, this._caixa.SaldoGeral);
        }

        [TestMethod]
        public void Devo_Conseguir_Receber_Atendimento_Pago_Em_Dinheiro()
        {
            Caixa caixa = new Caixa(100);
            caixa.ReceberAtendimentoEmDinheiro(15.25m);

            Assert.AreEqual(115.25m, caixa.SaldoGeral);
            Assert.AreEqual(15.25m, caixa.TotalAtendimentosDinheiro);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Receber_Atendimento_Pago_Em_Dinheiro_Com_Valor_Invalido()
        {
            Caixa caixa = new Caixa(0);
            try
            {
                caixa.ReceberAtendimentoEmDinheiro(0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("valor"))
                {
                    try
                    {
                        caixa.ReceberAtendimentoEmDinheiro(-12m);
                    }
                    catch (ExcecaoParametroInvalido e)
                    {
                        if (e.Message.Equals("valor"))
                            throw new ExcecaoParametroInvalido("valor");
                    }
                }
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Receber_Atendimento_Pago_Com_Cartao_Credito()
        {
            Caixa caixa = new Caixa(100);
            caixa.ReceberAtendimentoCartaoCredito(15.25m);

            Assert.AreEqual(115.25m, caixa.SaldoGeral);
            Assert.AreEqual(15.25m, caixa.SaldoCartaoCredito);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Receber_Atendimento_Pago_Com_Cartao_Credito_Com_Valor_Invalido()
        {
            Caixa caixa = new Caixa(0);
            try
            {
                caixa.ReceberAtendimentoCartaoCredito(0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("valor"))
                {
                    try
                    {
                        caixa.ReceberAtendimentoCartaoCredito(-12m);
                    }
                    catch (ExcecaoParametroInvalido e)
                    {
                        if (e.Message.Equals("valor"))
                            throw new ExcecaoParametroInvalido("valor");
                    }
                }
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Receber_Atendimento_Pago_Com_Cartao_Debito()
        {
            Caixa caixa = new Caixa(100);
            caixa.ReceberAtendimentoCartaoDebito(15.25m);

            Assert.AreEqual(115.25m, caixa.SaldoGeral);
            Assert.AreEqual(15.25m, caixa.SaldoCartaoDebito);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Receber_Atendimento_Pago_Com_Cartao_Debito_Com_Valor_Invalido()
        {
            Caixa caixa = new Caixa(0);
            try
            {
                caixa.ReceberAtendimentoCartaoDebito(0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("valor"))
                {
                    try
                    {
                        caixa.ReceberAtendimentoCartaoDebito(-12m);
                    }
                    catch (ExcecaoParametroInvalido e)
                    {
                        if (e.Message.Equals("valor"))
                            throw new ExcecaoParametroInvalido("valor");
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Efetuar_Uma_Saida_Para_Troco_Invalida()
        {
            Caixa caixa = new Caixa(100);
            try
            {
                caixa.EfetuarSaidaParaTroco(0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("valor"))
                    caixa.EfetuarSaidaParaTroco(-1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoValorInsuficienteEmCaixa))]
        public void Nao_Devo_Conseguir_Efetuar_Uma_Saida_Para_Troco_Se_O_Valor_Do_Troco_For_Maior_Que_O_Saldo_Em_Dinheiro()
        {
            Caixa caixa = new Caixa(100m);
            caixa.EfetuarSaidaParaTroco(125m);
        }

        [TestMethod]
        public void Devo_Conseguir_Efetuar_Uma_Saida_Para_Troco()
        {
            Caixa caixa = new Caixa(100m);
            caixa.EfetuarSaidaParaTroco(90);

            Assert.AreEqual(90, caixa.TotalTrocos);
            Assert.AreEqual(10, caixa.SaldoDinheiro);
            Assert.AreEqual(10, caixa.SaldoGeral);
        }
    }
}
