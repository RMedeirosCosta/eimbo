using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.ModuloAtendimento.Entidade;
using Eimbo.Dominio.ModuloAtendimento.Tipo;
using Eimbo.Dominio.ModuloAtendimento.ObjetoValor;
using Eimbo.Dominio.ModuloAtendimento.Excecao;

using Eimbo.Teste.Dominio.Comum.Stub;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Eimbo.Teste.Dominio.ModuloAtendimento
{
    [TestClass]
    public class Dado_Um_Atendimento
    {
        private Empresa _empresaValida;
        private Cliente _clienteValido;
        private FormaPagamento _fpagtoValida;

        public Dado_Um_Atendimento()
        {
            var empresaStub = new Mock<Empresa>();
            empresaStub.Setup(e => e.Id)
                       .Returns(1);

            var clienteStub = new Mock<Cliente>();
            clienteStub.Setup(c => c.Id)
                       .Returns(1);

            var fpagtoStub = new Mock<FormaPagamento>();
            fpagtoStub.Setup(c => c.Id)
                      .Returns(1);

            this._empresaValida = empresaStub.Object;
            this._clienteValido = clienteStub.Object;
            this._fpagtoValida = fpagtoStub.Object;
        }


        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Empresa_Invalido()
        {
            Atendimento atendimento;

            var empresaInvalida = new Mock<Empresa>();
            empresaInvalida.Setup(e => e.Id)
                           .Returns(0);

            try
            {
                atendimento = new Atendimento(DateTime.Now, null, null, null);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("empresa"))
                    atendimento = new Atendimento(DateTime.Now, empresaInvalida.Object, null, null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Cliente_Invalido()
        {
            var clienteInvalido = new Mock<Cliente>();
            clienteInvalido.Setup(c => c.Id)
                           .Returns(0);

            Atendimento atendimento;

            try
            {
                atendimento = new Atendimento(DateTime.Now, this._empresaValida, null, null);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("cliente"))
                    atendimento = new Atendimento(DateTime.Now, this._empresaValida, clienteInvalido.Object, null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Forma_De_Pagamento_Invalida()
        {
            var fpagtoInvalida = new Mock<FormaPagamento>();
            fpagtoInvalida.Setup(f => f.Id)
                          .Returns(0);

            Atendimento atendimento;

            try
            {
                atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, null);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("fpagto"))
                    atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, fpagtoInvalida.Object);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Data_Invalida()
        {
            Atendimento atendimento;

            try
            {
                atendimento = new Atendimento(DateTime.MinValue, this._empresaValida, this._clienteValido, this._fpagtoValida);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("data"))
                    atendimento = new Atendimento(DateTime.MinValue, this._empresaValida, this._clienteValido, this._fpagtoValida);
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Valido()
        {
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            Assert.AreEqual(this._empresaValida.Id, atendimento.Empresa.Id);
            Assert.AreEqual(this._clienteValido.Id, atendimento.Cliente.Id);
            Assert.AreEqual(this._fpagtoValida.Id, atendimento.FormaPagamento.Id);
            Assert.AreEqual(DateTime.Today, atendimento.Data.Date);
            Assert.AreEqual(TipoSituacaoAtendimento.Aberto, atendimento.Situacao);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Item_Com_Servico_Invalido()
        {
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            try
            {
                atendimento.AdicionarItem(null, 0m, 0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("servico"))
                {
                    var servicoInvalido = new Mock<Servico>();
                    servicoInvalido.Setup(s => s.Id)
                                   .Returns(0);

                    atendimento.AdicionarItem(servicoInvalido.Object, 0m, 0);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Item_Com_Valor_Unitario_Invalido()
        {
            var servico = new Mock<Servico>();
            servico.Setup(s => s.Id)
                   .Returns(1);

            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            try
            {
                atendimento.AdicionarItem(servico.Object, 0m, 0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("valorUnitario"))
                {
                    atendimento.AdicionarItem(servico.Object, -1m, 0);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Item_Com_Quantidade_Invalida()
        {
            var servico = new Mock<Servico>();
            servico.Setup(s => s.Id)
                   .Returns(1);

            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            try
            {
                atendimento.AdicionarItem(servico.Object, 1m, 0);
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("quantidade"))
                {
                    atendimento.AdicionarItem(servico.Object, 1m, -1);
                }
            }            
        }

        [TestMethod]
        public void Devo_Conseguir_Adicionar_Itens_Validos()
        {
            var servico1 = new Mock<Servico>();
            servico1.Setup(s => s.Id)
                    .Returns(1);

            var servico2 = new Mock<Servico>();
            servico2.Setup(s => s.Id)
                    .Returns(2);

            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            atendimento.AdicionarItem(servico1.Object, 1m, 1);
            atendimento.AdicionarItem(servico2.Object, 2m, 2);

            int contador = 1;

            foreach(ItemAtendimento i in atendimento.Itens)
            {
                switch (contador)
                {
                    // Servico 1                
                    case 1: Assert.AreEqual(1, i.Servico.Id);
                            Assert.AreEqual(1m, i.ValorUnitario);
                            Assert.AreEqual(1, i.Quantidade);
                            break;
                    // Servico 2
                    case 2: Assert.AreEqual(2, i.Servico.Id);
                            Assert.AreEqual(2m, i.ValorUnitario);
                            Assert.AreEqual(2, i.Quantidade);
                            break;
                }

                contador++;
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Remover_Um_Item()
        {
            Servico servico1 = ServicoStub.GetInstance(1, "serviço 1", 1);
            Servico servico2 = ServicoStub.GetInstance(2, "serviço 2", 2);

            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            atendimento.AdicionarItem(servico1, 1m, 1);
            atendimento.AdicionarItem(servico2, 2m, 2);

            // Primeiro verifico se foram adicionados mesmo os dois itens
            Assert.AreEqual(2, atendimento.Itens.Count());

            atendimento.RemoverItem(servico1);

            // Depois verifico se ficou apenas um item
            Assert.AreEqual(1, atendimento.Itens.Count());

            // Verifico se item é o serviço dois, pois eu tirei o serviço 1
            foreach (ItemAtendimento i in atendimento.Itens)
            {
               Assert.AreEqual(2, i.Servico.Id);
               Assert.AreEqual(2m, i.ValorUnitario);
               Assert.AreEqual(2, i.Quantidade);               
            }

            // Removo o serviço e verifico se não ficou nenhum item
            atendimento.RemoverItem(servico2);

            Assert.AreEqual(0, atendimento.Itens.Count());
        }

        [TestMethod]
        public void Devo_Conseguir_Obter_Totais()
        {
            var fpagto = new Mock<FormaPagamento>();
            fpagto.Setup(f => f.Id).Returns(1);
            fpagto.Setup(f => f.PercentualAcrescimo).Returns(10);
            fpagto.Setup(f => f.PercentualDesconto).Returns(20);

            Servico servico1 = ServicoStub.GetInstance(1, "serviço 1", 1);
            Servico servico2 = ServicoStub.GetInstance(2, "serviço 2", 2);
            Servico servico3 = ServicoStub.GetInstance(3, "serviço 3", 2);
            Servico servico4 = ServicoStub.GetInstance(4, "serviço 4", 2);
            Servico servico5 = ServicoStub.GetInstance(5, "serviço 5", 2);
            
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, fpagto.Object);

            atendimento.AdicionarItem(servico1, 10m, 3);  // 30 
            atendimento.AdicionarItem(servico2, 22m, 7);  // 184
            atendimento.AdicionarItem(servico3, 23m, 12); // 460 
            atendimento.AdicionarItem(servico4, 2m, 8);   // 476  
            atendimento.AdicionarItem(servico5, 7m, 2);   // 490 49 98 441                                        
            atendimento.Acrescimo = 132;                  // 552 
            atendimento.Desconto = 142;                   // 510 431  

            // NumeroTotalItens = 6, TotalValorUnitario = 64, TotalQuantidade = 32, TotalValorItem = 2048

            Assert.AreEqual(5,    atendimento.NumeroTotalItens);
            Assert.AreEqual(64,   atendimento.TotalValorUnitario);
            Assert.AreEqual(32,   atendimento.TotalQuantidade);
            Assert.AreEqual(490,  atendimento.TotalValorItem);
            Assert.AreEqual(132,  atendimento.Acrescimo);
            Assert.AreEqual(142,  atendimento.Desconto);
            Assert.AreEqual(49m,  atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(98,   atendimento.DescontoFormaPagamento);
            Assert.AreEqual(431,  atendimento.ValorAtendimento);
        }

        [TestMethod]
        public void Ao_Adicionar_Um_Item_Ja_Adicionado_Deve_Substituir_O_Existente()
        {
            Servico servico1 = ServicoStub.GetInstance(1, "serviço 1", 1);
            Servico servico2 = ServicoStub.GetInstance(2, "serviço 2", 2);

            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            atendimento.AdicionarItem(servico1, 10.50m, 3);
            atendimento.AdicionarItem(servico2, 22m, 7);
            atendimento.AdicionarItem(servico1, 11m, 4);

            foreach (ItemAtendimento i in atendimento.Itens)
            {
                Assert.AreEqual(11m, i.ValorUnitario);
                Assert.AreEqual(4, i.Quantidade);
                break;
            }
        }

        [TestMethod]
        public void Ao_Movimentar_Um_Item_Deve_Calcular_O_Desconto_E_O_Acrescimo_Pelo_Percentual_Da_Forma_De_Pagamento()
        {
            // Primeiro testo uma forma de pagamento que não tem nenhum percentual. Nem de acréscimo nem de desconto.
            var formaPagamentoSemDescontoSemAcrescimo = new Mock<FormaPagamento>();
            formaPagamentoSemDescontoSemAcrescimo.Setup(f => f.Id)
                                                 .Returns(1);           
            formaPagamentoSemDescontoSemAcrescimo.Setup(f => f.PercentualAcrescimo)
                          .Returns(0);
            formaPagamentoSemDescontoSemAcrescimo.Setup(f => f.PercentualDesconto)
                          .Returns(0);

            Servico servico1 = ServicoStub.GetInstance(1, "serviço 1", 1);
            Servico servico2 = ServicoStub.GetInstance(2, "serviço 2", 2);

            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, formaPagamentoSemDescontoSemAcrescimo.Object);

            atendimento.AdicionarItem(servico1, 10.50m, 3);
            Assert.AreEqual(0, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(0, atendimento.DescontoFormaPagamento);

            atendimento.AdicionarItem(servico2, 22m, 7);
            Assert.AreEqual(0, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(0, atendimento.DescontoFormaPagamento);

            atendimento.AdicionarItem(servico1, 11m, 4);
            Assert.AreEqual(0, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(0, atendimento.DescontoFormaPagamento);

            // Depois testo em uma forma de pagamento que tem percentual de acréscimo e de desconto
            var formaPagamento = new Mock<FormaPagamento>();
            formaPagamento.Setup(f => f.Id)
                          .Returns(1);           
            formaPagamento.Setup(f => f.PercentualAcrescimo)
                          .Returns(10);
            formaPagamento.Setup(f => f.PercentualDesconto)
                          .Returns(20);

            atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, formaPagamento.Object);

            atendimento.AdicionarItem(servico1, 10, 3);             // 30
            Assert.AreEqual(3m, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(6m, atendimento.DescontoFormaPagamento);

            atendimento.AdicionarItem(servico2, 22m, 7);           // 154 184 
            Assert.AreEqual(18.4m, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(36.8m, atendimento.DescontoFormaPagamento);

            atendimento.RemoverItem(servico2);                     // 154 30 
            Assert.AreEqual(3m, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(6m, atendimento.DescontoFormaPagamento);

            atendimento.AdicionarItem(servico1, 11m, 4);           // 44 
            Assert.AreEqual(4.4m, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(8.8m, atendimento.DescontoFormaPagamento);

            atendimento.AdicionarItem(servico2, 1m, 10);           // 10 54
            Assert.AreEqual(5.4m, atendimento.AcrescimoFormaPagamento);
            Assert.AreEqual(10.8m, atendimento.DescontoFormaPagamento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Dar_Desconto_Invalido()
        {
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            try
            {
                atendimento.Desconto = -1;
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("desconto"))
                    throw new ExcecaoParametroInvalido("desconto");
            }
        }

        [TestMethod]
        public void Devo_Obter_Valor_Zerado_Quando_Total_Liquido_Do_Pedido_Estiver_Negativo()
        {
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);
            atendimento.Desconto = 12;

            Assert.AreEqual(0, atendimento.ValorAtendimento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Dar_Acrescimo_Invalido()
        {
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            try
            {
                atendimento.Acrescimo = -1;
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("acrescimo"))
                    throw new ExcecaoParametroInvalido("acrescimo");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoAtendimentoSemItens))]
        public void Nao_Devo_Conseguir_Validar_Um_Atendimento_Sem_Itens()
        {
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);

            atendimento.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoAtendimentoComValorZerado))]
        public void Nao_Devo_Conseguir_Validar_Um_Atendimento_Com_Valor_Zerado()
        {
            Atendimento atendimento = new Atendimento(DateTime.Now, this._empresaValida, this._clienteValido, this._fpagtoValida);
            atendimento.AdicionarItem(ServicoStub.GetInstance(1, "TESTE", 1), 1, 1);
            atendimento.Desconto = 15;
            atendimento.Validar();
        }
    }
}
