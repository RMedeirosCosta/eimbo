using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio;
using Eimbo.Dominio.DTO.ModuloCaixa;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.Fachada.ModuloCaixa;
using Eimbo.Dominio.ModuloCaixa.Entidade;
using Eimbo.Dominio.ModuloCaixa.Repositorio;
using Eimbo.Dominio.ModuloCaixa.Excecao;
using Eimbo.Dominio.ModuloCaixa.Tipo;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Eimbo.Teste.Dominio.ModuloCaixa
{
    [TestClass]
    public class Dado_Uma_FachadaCaixa
    {
        [TestMethod]
        public void Devo_Conseguir_Abrir_Novo_Caixa()
        {
            Decimal saldoAbertura = 150m;

            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.DataAbertura).Returns(DateTime.Now);
            caixa.Setup(c => c.SaldoAbertura).Returns(150m);
            caixa.Setup(c => c.EstaAberto).Returns(true);

            var repositorioCaixa = new Mock<ICaixaRepositorio>();

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            Assert.IsTrue(fachada.AbrirNovoCaixa(saldoAbertura));

            repositorioCaixa.Verify(r => r.Salvar(It.IsAny<Caixa>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCaixaAnteriorAberto))]
        public void Nao_Devo_Conseguir_Abrir_Novo_Caixa_Se_Ja_Existir_Um_Caixa_Anterior_Aberto()
        {
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto).Returns(true);

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns(caixa.Object);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            Assert.IsTrue(fachada.AbrirNovoCaixa(0));
        }

        [TestMethod]
        public void Devo_Conseguir_Efetuar_Uma_Sangria()
        {
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto).Returns(true);
            caixa.Setup(c => c.EfetuarSangria(It.IsAny<Decimal>()));

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns(caixa.Object);


            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            Assert.IsTrue(fachada.EfetuarSangria(100));
            caixa.Verify(c => c.EfetuarSangria(It.IsAny<Decimal>()));
            repositorioCaixa.Verify(r => r.Salvar(caixa.Object));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumCaixaAberto))]
        public void Nao_Devo_Efetuar_Uma_Sangria_Sem_Nenhum_Caixa_Aberto()
        {
            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns<Caixa>(null);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            fachada.EfetuarSangria(100);
        }

        [TestMethod]
        public void Devo_Conseguir_Efetuar_Um_Reforco()
        {
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto).Returns(true);
            caixa.Setup(c => c.EfetuarReforco(100));

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns(caixa.Object);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            Assert.IsTrue(fachada.EfetuarReforco(100));
            caixa.Verify(c => c.EfetuarReforco(100));
            repositorioCaixa.Verify(r => r.Salvar(caixa.Object));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumCaixaAberto))]
        public void Nao_Devo_Conseguir_Efetuar_Um_Reforco_Sem_Nenhum_Caixa_Aberto()
        {
            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns<Caixa>(null);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            fachada.EfetuarReforco(100);
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_Um_Extrato_Do_Caixa()
        {
            IList<LancamentoCaixa> lancamentos = new List<LancamentoCaixa>();
            lancamentos.Add(new LancamentoCaixa("SALDO DE ABERTURA", TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, 130));
            lancamentos.Add(new LancamentoCaixa("SANGRIA",           TipoMovimentacaoLancamentoCaixa.Saida,   TipoPagamentoLancamentoCaixa.Dinheiro, 30));
            lancamentos.Add(new LancamentoCaixa("REFORÇO",           TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, 150));
            lancamentos.Add(new LancamentoCaixa("REFORÇO",           TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, 200));
            
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto).Returns(true);
            caixa.SetupGet(c => c.Lancamentos).Returns(lancamentos);

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns(caixa.Object);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            IEnumerable<DTOLancamentoCaixa> extrato = fachada.ObterExtrato();

            int contador = 0;

            foreach(DTOLancamentoCaixa dto in extrato)
            {
                switch(contador)
                {
                    case 0: Assert.AreEqual("SALDO DE ABERTURA",                   dto.Descricao);
                            Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, dto.TipoPagamento);
                            Assert.AreEqual(130m,                                  dto.Valor);
                        break;
                    case 1: Assert.AreEqual("SANGRIA",                             dto.Descricao);
                            Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, dto.TipoPagamento);
                            Assert.AreEqual(-30m,                                  dto.Valor);
                        break;
                    case 2: Assert.AreEqual("REFORÇO",                             dto.Descricao);
                            Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, dto.TipoPagamento);
                            Assert.AreEqual(150m,                                  dto.Valor);
                        break;
                    case 3: Assert.AreEqual("REFORÇO",                            dto.Descricao);
                            Assert.AreEqual(TipoPagamentoLancamentoCaixa.Dinheiro, dto.TipoPagamento);
                            Assert.AreEqual(200m,                                  dto.Valor);
                        break;
                }
                
                contador++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumCaixaAberto))]
        public void Nao_Devo_Conseguir_Obtem_Um_Extrato_Sem_Nenhum_Caixa_Aberto()
        {
            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns<Caixa>(null);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            fachada.ObterExtrato();
        }

        [TestMethod]
        public void Devo_Conseguir_Fechar_Caixa_Atual()
        {
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto)
                 .Returns(true);

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns(caixa.Object);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            Assert.IsTrue(fachada.FecharCaixaAtual());
            repositorioCaixa.Verify(r => r.Salvar(caixa.Object), Times.AtLeastOnce());                            
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumCaixaAberto))]
        public void Nao_Devo_Conseguir_Fechar_Sem_Nenhum_Caixa_Aberto()
        {
            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns<Caixa>(null);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);
            fachada.FecharCaixaAtual();
        }

        [TestMethod]
        public void Devo_Conseguir_Reabrir_O_Ultimo_Caixa()
        {
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto)                  
                 .Returns(false);

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(c => c.ObterUltimoCaixaFechado())
                            .Returns(caixa.Object);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);

            Assert.IsTrue(fachada.ReabrirUltimoCaixa());

            caixa.Verify(c => c.Abrir(), Times.AtLeastOnce());
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCaixaAnteriorAberto))]
        public void Nao_Devo_Conseguir_Reabrir_O_Ultimo_Caixa_Se_Ja_Existir_Um_Caixa_Aberto()
        {
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto)
                 .Returns(true);

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(c => c.ObterUltimoCaixaAberto())
                            .Returns(caixa.Object);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);
            fachada.ReabrirUltimoCaixa();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumCaixaAnterior))]
        public void Nao_Devo_Conseguir_Reabrir_O_Ultimo_Caixa_Se_Nao_Existir_Nenhum_Caixa_Anterior()
        {
            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(c => c.ObterUltimoCaixaFechado())
                            .Returns<Caixa>(null);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);
            fachada.ReabrirUltimoCaixa();
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_O_Caixa_Aberto_Atual_Com_Os_Valores_De_Saldo_Detalhado()
        {
            var caixa = new Mock<Caixa>();
            caixa.Setup(c => c.EstaAberto).Returns(true);
            caixa.Setup(c => c.DataAbertura).Returns(DateTime.Now);

            caixa.Setup(c => c.SaldoAbertura).Returns(100);
            caixa.Setup(c => c.TotalAtendimentosDinheiro).Returns(3000);
            caixa.Setup(c => c.TotalSangrias).Returns(300);            
            caixa.Setup(c => c.TotalReforcos).Returns(100);
            caixa.Setup(c => c.TotalTrocos).Returns(100);

            caixa.Setup(c => c.SaldoDinheiro).Returns(2900);
            caixa.Setup(c => c.SaldoCartaoCredito).Returns(232);
            caixa.Setup(c => c.SaldoCartaoDebito).Returns(87);
            caixa.Setup(c => c.SaldoGeral).Returns(3219);

            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns(caixa.Object);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);
            DTOCaixa dto = fachada.ObterCaixaAtual();

            Assert.IsTrue(dto.EstaAberto);
            Assert.AreEqual(DateTime.Today, dto.DataAbertura.Date);
            Assert.AreEqual(100m, dto.SaldoAbertura);
            Assert.AreEqual(3000m, dto.TotalAtendimentosDinheiro);
            Assert.AreEqual(300m, dto.TotalSangrias);
            Assert.AreEqual(100m, dto.TotalReforcos);
            Assert.AreEqual(2900m, dto.SaldoDinheiro);
            Assert.AreEqual(232m, dto.SaldoCartaoCredito);
            Assert.AreEqual(87m, dto.SaldoCartaoDebito);
            Assert.AreEqual(3219m, dto.SaldoGeral);
            Assert.AreEqual(100, dto.TotalTrocos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumCaixaAberto))]
        public void Nao_Devo_Conseguir_Obter_O_Caixa_Atual_Aberto_Se_Nao_Houver_Nenhum_Caixa_Aberto()
        {
            var repositorioCaixa = new Mock<ICaixaRepositorio>();
            repositorioCaixa.Setup(r => r.ObterUltimoCaixaAberto())
                            .Returns<Caixa>(null);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixa.Object);
            DTOCaixa dto = fachada.ObterCaixaAtual();
        }

        [TestMethod]
        public void Devo_Conseguir_Verificar_Data_Abertura_Caixa_Atual_Igual_Dia_Corrente()
        {
            DTOCaixa caixaDTO = new DTOCaixa();
            caixaDTO.DataAbertura = Convert.ToDateTime("01/01/2013");

            IFachadaCaixa fachadaCaixa = new FachadaCaixa(null);

            Assert.IsFalse(fachadaCaixa.VerificaDataAberturaIgualDiaCorrente(caixaDTO));

            caixaDTO.DataAbertura = DateTime.Now;

            Assert.IsTrue(fachadaCaixa.VerificaDataAberturaIgualDiaCorrente(caixaDTO));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Verificar_Data_Abertura_Caixa_Igual_Dia_Corrente_Se_O_Caixa_Atual_Estiver_Invalido()
        {
            IFachadaCaixa fachadaCaixa = new FachadaCaixa(null);

            Assert.IsFalse(fachadaCaixa.VerificaDataAberturaIgualDiaCorrente(null));
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_Valor_Restante_Ao_Calcular_Recebimento()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();

            dto.ValorReceber = 100;
            dto.ValorDinheiro = 30;
            dto.ValorCartaoCredito = 30;
            dto.ValorCartaoDebito = 30;

            Caixa caixa = new Caixa(100m);

            IFachadaCaixa fachada = new FachadaCaixa(null);

            DTORecebimentoCaixa dtoRetorno = fachada.CalcularRecebimento(dto);

            Assert.AreEqual(10, dtoRetorno.ValorRestante);
        }

        [TestMethod]
        public void Devo_Obter_Valor_Restante_Zerado_Se_A_Soma_For_Maior_Que_O_Valor_A_Receber()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();

            dto.ValorReceber = 100;
            dto.ValorDinheiro = 50;
            dto.ValorCartaoCredito = 30;
            dto.ValorCartaoDebito = 30;

            Caixa caixa = new Caixa(100m);

            IFachadaCaixa fachada = new FachadaCaixa(null);

            DTORecebimentoCaixa dtoRetorno = fachada.CalcularRecebimento(dto);

            Assert.AreEqual(0, dtoRetorno.ValorRestante);
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_Valor_Troco_Se_A_Soma_For_Maior_Que_O_Valor_A_Receber()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();

            dto.ValorReceber = 100;
            dto.ValorDinheiro = 50;
            dto.ValorCartaoCredito = 30;
            dto.ValorCartaoDebito = 30;

            Caixa caixa = new Caixa(100m);

            IFachadaCaixa fachada = new FachadaCaixa(null);

            DTORecebimentoCaixa dtoRetorno = fachada.CalcularRecebimento(dto);

            Assert.AreEqual(10, dtoRetorno.ValorTroco);
        }

        [TestMethod]
        public void Devo_Conseguir_Receber_Valor_Restante_Com_Dinheiro()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();

            dto.ValorReceber = 100;
            dto.ValorDinheiro = 10;
            dto.ValorCartaoCredito = 30;
            dto.ValorCartaoDebito = 30;

            Caixa caixa = new Caixa(100m);

            IFachadaCaixa fachada = new FachadaCaixa(null);

            DTORecebimentoCaixa dtoRetorno = fachada.ReceberRestanteComDinheiro(dto);

            Assert.AreEqual(40, dtoRetorno.ValorDinheiro);
            Assert.AreEqual(0, dtoRetorno.ValorRestante);
            Assert.AreEqual(0, dtoRetorno.ValorTroco);
        }

        [TestMethod]
        public void Devo_Conseguir_Receber_Valor_Restante_Com_CartaoCredito()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();

            dto.ValorReceber = 100;
            dto.ValorDinheiro = 10;
            dto.ValorCartaoCredito = 10;
            dto.ValorCartaoDebito = 30;

            Caixa caixa = new Caixa(100m);

            IFachadaCaixa fachada = new FachadaCaixa(null);

            DTORecebimentoCaixa dtoRetorno = fachada.ReceberRestanteComCartaoCredito(dto);

            Assert.AreEqual(60, dtoRetorno.ValorCartaoCredito);
            Assert.AreEqual(0, dtoRetorno.ValorRestante);
            Assert.AreEqual(0, dtoRetorno.ValorTroco);
        }

        [TestMethod]
        public void Devo_Conseguir_Receber_Valor_Restante_Com_CartaoDebito()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();

            dto.ValorReceber = 100;
            dto.ValorDinheiro = 10;
            dto.ValorCartaoCredito = 10;
            dto.ValorCartaoDebito = 10;

            Caixa caixa = new Caixa(100m);

            IFachadaCaixa fachada = new FachadaCaixa(null);

            DTORecebimentoCaixa dtoRetorno = fachada.ReceberRestanteComCartaoDebito(dto);

            Assert.AreEqual(80, dtoRetorno.ValorCartaoDebito);
            Assert.AreEqual(0, dtoRetorno.ValorRestante);
            Assert.AreEqual(0, dtoRetorno.ValorTroco);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoValorPagoMenorQueValorAReceber))]
        public void Nao_Devo_Conseguir_Receber_Se_O_Valor_Restante_For_Maior_Que_Zero()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();

            dto.ValorRestante = 15;

            IFachadaCaixa fachada = new FachadaCaixa(null);

            fachada.Receber(dto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoValorInsuficienteEmCaixa))]
        public void Nao_Devo_Conseguir_Receber_Se_O_Valor_Do_Troco_For_Maior_Que_O_Saldo_Em_Dinheiro_Do_Caixa()
        {
            Caixa caixa = new Caixa(100);

            var repositorioCaixaStub = new Mock<ICaixaRepositorio>();
            repositorioCaixaStub.Setup(r => r.ObterUltimoCaixaAberto()).Returns(caixa);

            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();
            dto.ValorTroco = 120;

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixaStub.Object);
            fachada.Receber(dto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoNenhumCaixaAberto))]
        public void Nao_Devo_Conseguir_Receber_Se_Nao_Houver_Nenhum_Caixa_Aberto()
        {
            var repositorioCaixaStub = new Mock<ICaixaRepositorio>();
            repositorioCaixaStub.Setup(r => r.ObterUltimoCaixaAberto()).Returns<Caixa>(null);

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixaStub.Object);

            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();
            dto.ValorDinheiro = 100;
            dto.ValorReceber = 100;

            fachada.Receber(dto);
        }

        [TestMethod]
        public void Devo_Conseguir_Receber()
        {
            Caixa caixa = new Caixa(100);

            var repositorioCaixaStub = new Mock<ICaixaRepositorio>();
            repositorioCaixaStub.Setup(r => r.ObterUltimoCaixaAberto()).Returns(caixa);
            repositorioCaixaStub.Setup(r => r.Salvar(caixa));

            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();
            dto.ValorDinheiro = 50;
            dto.ValorCartaoDebito = 25;
            dto.ValorCartaoCredito = 25;
            dto.ValorReceber = 90;
            dto.ValorTroco = 10;

            IFachadaCaixa fachada = new FachadaCaixa(repositorioCaixaStub.Object);
            fachada.Receber(dto);

            repositorioCaixaStub.Verify(r => r.ObterUltimoCaixaAberto());
            repositorioCaixaStub.Verify(r => r.Salvar(caixa));

            Assert.AreEqual(140, caixa.SaldoDinheiro);
            Assert.AreEqual(25, caixa.SaldoCartaoCredito);
            Assert.AreEqual(25, caixa.SaldoCartaoDebito);
            Assert.AreEqual(190, caixa.SaldoGeral);
        }
    }
}
