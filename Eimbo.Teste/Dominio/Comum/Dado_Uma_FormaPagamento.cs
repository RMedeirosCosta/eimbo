using System;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eimbo.Eimbo.Dominio.Comum
{
    [TestClass]
    public class Dado_Uma_FormaPagamento
    {
        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Descricao_Invalida()
        {
            FormaPagamento formaPagamento;

            try
            {
                formaPagamento = new FormaPagamento(null, TipoFormaPagamento.Vista, 20, 10);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("Descricao"))
                    formaPagamento = new FormaPagamento("", TipoFormaPagamento.Vista, 20, 10);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Desconto_Invalido()
        {
            FormaPagamento formaPagamento;

            try
            {
                formaPagamento = new FormaPagamento("À VISTA", TipoFormaPagamento.Vista, 10, -1);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("Desconto"))
                    formaPagamento = new FormaPagamento("À VISTA", TipoFormaPagamento.Vista, 10, -1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Acrescimo_Invalido()
        {
            FormaPagamento formaPagamento;
            try
            {
                formaPagamento = new FormaPagamento("À VISTA", TipoFormaPagamento.Vista, -1, 1);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("Acrescimo"))
                    formaPagamento = new FormaPagamento("À VISTA", TipoFormaPagamento.Vista, -1, 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Tipo_Invalido()
        {
            FormaPagamento formaPagamento;
            try
            {
                formaPagamento = new FormaPagamento("À VISTA", TipoFormaPagamento.Nenhum, 0, 0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("Tipo"))
                    formaPagamento = new FormaPagamento("À VISTA", TipoFormaPagamento.Nenhum, 0, 0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCampoNaoPermitido))]
        public void Nao_Devo_Conseguir_Criar_Forma_Pagamento_A_Vista_Com_Parcelamento()
        {
            try
            {
                FormaPagamento formaPagamento = new FormaPagamento("À Vista",
                                                                   TipoFormaPagamento.Vista,
                                                                   0,
                                                                   0,
                                                                   new ParcelamentoFormaPagamento(
                                                                                                  TipoParcelamentoFormaPagamento.ComEntrada,
                                                                                                  1,
                                                                                                  30));
            } catch(ExcecaoCampoNaoPermitido ex){
                if (ex.Message.Contains("parcelamento"))
                    throw new ExcecaoCampoNaoPermitido("parcelamento", "forma de pagamento à vista");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCampoObrigatorioNaoInformado))]
        public void Nao_Devo_Conseguir_Criar_Uma_Forma_Pagamento_A_Prazo_Sem_Parcelamento()
        {
            try
            {
                FormaPagamento formaPagamento = new FormaPagamento("30 dias com desconto",
                                                                   TipoFormaPagamento.Prazo,
                                                                   0,
                                                                   5);
            } catch(ExcecaoCampoObrigatorioNaoInformado ex){
                if (ex.Message.Contains("Parcelamento"))
                    throw new ExcecaoCampoObrigatorioNaoInformado("Parcelamento");
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Uma_Forma_De_Pagamento_A_Vista_Valida()
        {
            FormaPagamento formaPagamento = new FormaPagamento("À Vista", TipoFormaPagamento.Vista, 1, 1);

            Assert.AreEqual(formaPagamento.Descricao, "À VISTA");
            Assert.AreEqual(formaPagamento.Tipo, TipoFormaPagamento.Vista);
            Assert.AreEqual(formaPagamento.PercentualAcrescimo, 1);
            Assert.AreEqual(formaPagamento.PercentualDesconto, 1);
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Uma_Forma_Pagamento_A_Prazo_Valida()
        {
            Int16 quantidadeDeParcelas = 1;
            Int16 intervaloEntreParcelas = 30;

            ParcelamentoFormaPagamento parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.SemEntrada,
                                                                                     quantidadeDeParcelas,
                                                                                     intervaloEntreParcelas);
            
            FormaPagamento formaPagamento = new FormaPagamento("30 dias",
                                                               TipoFormaPagamento.Prazo,
                                                               0,
                                                               0,
                                                               parcelamento);

            Assert.AreEqual(formaPagamento.Descricao, "30 DIAS");            
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Uma_Forma_Pagamento_A_Prazo_Com_Parcelamento_Invalido()
        {
            try
            {
                FormaPagamento formaPagamento = new FormaPagamento("30 dias",
                                                                   TipoFormaPagamento.Prazo,
                                                                   0,
                                                                   0,
                                                                   null);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("Parcelamento"))
                    throw new ExcecaoParametroInvalido("Parcelamento");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCampoNaoPermitido))]
        public void Nao_Devo_Conseguir_Alterar_Parcelamento_De_Uma_Forma_Pagamento_A_Vista()
        {
            try
            {
                FormaPagamento formaPagamento = new FormaPagamento("À Vista",
                                                                   TipoFormaPagamento.Vista,
                                                                   0,
                                                                   0);
                formaPagamento.Parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.ComEntrada,
                                                                             1,
                                                                             30);
            }
            catch (ExcecaoCampoNaoPermitido ex)
            {
                if (ex.Message.Contains("parcelamento"))
                    throw new ExcecaoCampoNaoPermitido("parcelamento", "forma de pagamento à vista");
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Alterar_Parcelamento_De_Uma_Forma_Pagamento_A_Prazo()
        {
            try
            {
                FormaPagamento formaPagamento = new FormaPagamento("30/60/90",
                                                                   TipoFormaPagamento.Prazo,
                                                                   0,
                                                                   0,
                                                                   new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.ComEntrada,
                                                                                                  2,
                                                                                                  30));
                formaPagamento.Parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.SemEntrada,
                                                                             2,
                                                                             30);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("Parcelamento"))
                    throw new ExcecaoParametroInvalido("Parcelamento");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Uma_Forma_Pagamento_A_Prazo_Com_Intervalo_De_Parcelas_Invalido()
        {
            Int16 quantidadeDeParcelas = 1;
            Int16 intervaloEntreParcelas = 0;

            ParcelamentoFormaPagamento parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.SemEntrada,
                                                                                     quantidadeDeParcelas,
                                                                                     intervaloEntreParcelas);
            FormaPagamento formaPagamento;

            // Primeiro verifico se igual a zero gera a exceção
            try
            {
                formaPagamento = new FormaPagamento("30 dias",
                                                    TipoFormaPagamento.Prazo,
                                                    0,
                                                    0,
                                                    parcelamento);
            }
            catch (ExcecaoParametroInvalido)
            {
                parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.SemEntrada,
                                                              quantidadeDeParcelas,
                                                              -1);

                // Depois verifico se menor que zero gera a exceção
                try
                {
                    formaPagamento = new FormaPagamento("30 dias",
                                                        TipoFormaPagamento.Prazo,
                                                        0,
                                                        0,
                                                        parcelamento);
                }
                // Depois faço igual aos outros métoos e verifico se parâmetro que gerou a exceção é mesmo
                // IntervaloParcelas
                catch (ExcecaoParametroInvalido exMessage)
                {
                    if (exMessage.Message.Contains("IntervaloParcelas"))
                        throw new ExcecaoParametroInvalido("IntervaloParcelas");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Uma_Forma_Pagamento_A_Prazo_Com_Quantidade_De_Parcelas_Invalido()
        {
            
            Int16 quantidadeDeParcelas = 0;
            Int16 intervaloEntreParcelas = 30;

            ParcelamentoFormaPagamento parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.SemEntrada,
                                                                                     quantidadeDeParcelas,
                                                                                     intervaloEntreParcelas);
            FormaPagamento formaPagamento;

            // Primeiro verifico se igual a zero gera a exceção
            try
            {
                formaPagamento = new FormaPagamento("30 dias",
                                                    TipoFormaPagamento.Prazo,
                                                    0,
                                                    0,
                                                    parcelamento);
            }
            catch (ExcecaoParametroInvalido)
            {
                parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.SemEntrada,
                                                              -1,
                                                              30);

                // Depois verifico se menor que zero gera a exceção
                try
                {
                    formaPagamento = new FormaPagamento("30 dias",
                                                        TipoFormaPagamento.Prazo,
                                                        0,
                                                        0,
                                                        parcelamento);
                }
                // Depois faço igual aos outros métoos e verifico se parâmetro que gerou a exceção é mesmo
                // QuantidadeParcelas
                catch (ExcecaoParametroInvalido exMessage)
                {
                    if (exMessage.Message.Contains("QuantidadeParcelas"))
                        throw new ExcecaoParametroInvalido("QuantidadeParcelas");
                }
            }            
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoQuantidadeParcelasInvalidaParaFormaPagamentoComEntrada))]
        public void Nao_Devo_Conseguir_Criar_Uma_Forma_Pagamento_A_Prazo_Com_Entrada_E_Apenas_Uma_Parcela()
        {
            Int16 quantidadeDeParcelas = 1;
            Int16 intervaloEntreParcelas = 30;

            ParcelamentoFormaPagamento parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.ComEntrada,
                                                                                     quantidadeDeParcelas,
                                                                                     intervaloEntreParcelas);
            FormaPagamento formaPagamento = new FormaPagamento("30 dias", 
                                                               TipoFormaPagamento.Prazo,
                                                               0,
                                                               0,
                                                               parcelamento);            
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Uma_Forma_Pagamento_A_Prazo_Com_Tipo_Parcelamento_Invalido()
        {
            Int16 quantidadeDeParcelas = 1;
            Int16 intervaloEntreParcelas = 1;

            ParcelamentoFormaPagamento parcelamento = new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.Nenhum,
                                                                                     quantidadeDeParcelas,
                                                                                     intervaloEntreParcelas);
            FormaPagamento formaPagamento;            
            try
            {
                formaPagamento = new FormaPagamento("30 dias",
                                                    TipoFormaPagamento.Prazo,
                                                    0,
                                                    0,
                                                    parcelamento);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Contains("TipoParcelamento"))
                    throw new ExcecaoParametroInvalido("TipoParcelamento");
            }
        }
    }
}
