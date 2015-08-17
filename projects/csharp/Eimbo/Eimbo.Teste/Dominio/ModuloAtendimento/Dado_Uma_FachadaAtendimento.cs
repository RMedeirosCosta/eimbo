using System;

using Eimbo.Dominio.DTO.ModuloAtendimento;
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.Contrato.ModuloAtendimento;
using Eimbo.Dominio.Fachada.ModuloAtendimento;
using Eimbo.Dominio.ModuloAtendimento.Entidade;
using Eimbo.Dominio.ModuloAtendimento.Excecao;
using Eimbo.Dominio.ModuloAtendimento.Repositorio;
using Eimbo.Dominio.ModuloAtendimento.Tipo;
using Eimbo.Teste.Dominio.Comum.Stub;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Eimbo.Teste.Dominio.ModuloAtendimento
{
    [TestClass]
    public class Dado_Uma_FachadaAtendimento
    {
        private IPessoaRepositorio _repositorioPessoa;
        private IFormaPagamentoRepositorio _repositorioFormaPagamento;
        private DTOCabecalhoAtendimento _dtoCabecalho;

        public Dado_Uma_FachadaAtendimento()
        {
            var pessoa = new Mock<Empresa>();
            pessoa.Setup(e => e.Id)
                  .Returns(1);

            var formaPagamento = new Mock<FormaPagamento>();
            formaPagamento.Setup(e => e.Id).Returns(1);
            formaPagamento.Setup(e => e.PercentualAcrescimo).Returns(10);
            formaPagamento.Setup(e => e.PercentualDesconto).Returns(20);

            var repositorioPessoa = new Mock<IPessoaRepositorio>();
            repositorioPessoa.Setup(f => f.Obter(1))
                             .Returns(pessoa.Object);

            var repositorioFormaPagamento = new Mock<IFormaPagamentoRepositorio>();
            repositorioFormaPagamento.Setup(f => f.Obter(1))
                                  .Returns(formaPagamento.Object);

            this._repositorioPessoa = repositorioPessoa.Object;
            this._repositorioFormaPagamento = repositorioFormaPagamento.Object;
            this._dtoCabecalho = new DTOCabecalhoAtendimento();
            this._dtoCabecalho.Data = DateTime.Now;
            this._dtoCabecalho.IdEmpresa = 1;
            this._dtoCabecalho.IdCliente = 1;
            this._dtoCabecalho.IdFormaPagamento = 1;

        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Novo_Atendimento()
        {
            var pessoa = new Mock<Empresa>();
            pessoa.Setup(e => e.Id)
                  .Returns(1);

            var formaPagamento = new Mock<FormaPagamento>();
            formaPagamento.Setup(e => e.Id).Returns(1);
            formaPagamento.Setup(e => e.PercentualAcrescimo).Returns(10);
            formaPagamento.Setup(e => e.PercentualDesconto).Returns(20);

            var repositorioPessoa = new Mock<IPessoaRepositorio>();
            repositorioPessoa.Setup(f => f.Obter(1))
                             .Returns(pessoa.Object);

            var repositorioFormaPagamento = new Mock<IFormaPagamentoRepositorio>();
            repositorioFormaPagamento.Setup(f => f.Obter(1))
                                  .Returns(formaPagamento.Object);

            IFachadaAtendimento fachada = new FachadaAtendimento(null, repositorioPessoa.Object, repositorioFormaPagamento.Object, null);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);

            repositorioPessoa.Verify(r => r.Obter(this._dtoCabecalho.IdEmpresa));
            repositorioFormaPagamento.Verify(r => r.Obter(this._dtoCabecalho.IdFormaPagamento));
        }

        [TestMethod]
        public void Devo_Conseguir_Cancelar_Digitacao_Atual()
        {
            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, null);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);
            fachada.CancelarDigitacaoAtual();
        }

        [TestMethod]
        public void Devo_Conseguir_Adicionar_Um_Item()
        {
            var servico = new Mock<Servico>();
            servico.Setup(s => s.Id)
                   .Returns(1);

            var repositorioServico = new Mock<IServicoRepositorio>();
            repositorioServico.Setup(r => r.Obter(1))
                              .Returns(servico.Object);

            DTOItem dto = new DTOItem();
            dto.IdServico = 1;
            dto.ValorUnitario = 15.23m;
            dto.Quantidade = 1;

            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, repositorioServico.Object);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);
            fachada.AdicionarItem(dto);

            repositorioServico.Verify(r => r.Obter(dto.IdServico));
        }

        [TestMethod]
        public void Devo_Conseguir_Remover_Um_Item()
        {
            Servico servico1 = ServicoStub.GetInstance(1, "SERVIÇO 1", 1);
            Servico servico2 = ServicoStub.GetInstance(2, "SERVIÇO 2", 2);

            var repositorioServico = new Mock<IServicoRepositorio>();
            repositorioServico.Setup(r => r.Obter(1))
                              .Returns(servico1);

            DTOItem dto = new DTOItem();
            dto.IdServico = 1;
            dto.ValorUnitario = 15.23m;
            dto.Quantidade = 1;

            DTOItem dto2 = new DTOItem();
            dto2.IdServico = 2;
            dto2.ValorUnitario = 15;
            dto2.Quantidade = 12;

            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, repositorioServico.Object);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);
            fachada.AdicionarItem(dto);

            repositorioServico.Setup(r => r.Obter(2)).Returns(servico2);
            fachada.AdicionarItem(dto2);

            fachada.RemoverItem(dto);

            repositorioServico.Verify(r => r.Obter(1));

            // Foi removido esse assert porque o Equals 
            Assert.AreEqual(1, fachada.ObterValoresAtendimento().NumeroItens);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCabecalhoNaoAdicionado))]
        public void Nao_Devo_Conseguir_Adicionar_Um_Item_Se_O_Atendimento_Nao_Estiver_Criado()
        {
            var servico = new Mock<Servico>();
            servico.Setup(s => s.Id)
                   .Returns(1);

            DTOItem dto = new DTOItem();
            dto.IdServico = 1;
            dto.ValorUnitario = 15.23m;
            dto.Quantidade = 1;

            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, null);
            fachada.AdicionarItem(dto);
        }

        [TestMethod]
        public void Devo_Conseguir_Retornar_Os_Valores_Do_Atendimento()
        {
            var repositorioServico = new Mock<IServicoRepositorio>();
            var formaPagamento = new Mock<FormaPagamento>();
            formaPagamento.Setup(f => f.Id).Returns(1);
            formaPagamento.Setup(f => f.PercentualAcrescimo).Returns(10);
            formaPagamento.Setup(f => f.PercentualDesconto).Returns(20);
            formaPagamento.Setup(f => f.Tipo).Returns(TipoFormaPagamento.Prazo);
            formaPagamento.Setup(f => f.Parcelamento).Returns(new ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento.ComEntrada, 3, 30));

            var repositorioFormaPagamento = new Mock<IFormaPagamentoRepositorio>();
            repositorioFormaPagamento.Setup(r => r.Obter(1)).Returns(formaPagamento.Object);

            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, repositorioFormaPagamento.Object, repositorioServico.Object);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);

            #region Item 1
            DTOItem dto1 = new DTOItem();
            dto1.IdServico = 1;
            dto1.ValorUnitario = 15m;
            dto1.Quantidade = 1;

            Servico servico1 = ServicoStub.GetInstance(1, "Serviço 1", 1);
            
            repositorioServico.Setup(r => r.Obter(1))
                              .Returns(servico1);
            
            fachada.AdicionarItem(dto1);
            repositorioServico.Verify(r => r.Obter(It.IsAny<long>()));
            #endregion

            #region Item 2
            DTOItem dto2 = new DTOItem();
            dto2.IdServico = 2;
            dto2.ValorUnitario = 10m;
            dto2.Quantidade = 2;

            Servico servico2 = ServicoStub.GetInstance(2, "Serviço 2", 1);

            repositorioServico.Setup(r => r.Obter(2))
                              .Returns(servico2);
            fachada.AdicionarItem(dto2);
            repositorioServico.Verify(r => r.Obter(It.IsAny<long>()));

            #endregion

            #region Item 3
            DTOItem dto3 = new DTOItem();
            dto3.IdServico = 2;
            dto3.ValorUnitario = 10m;
            dto3.Quantidade = 2;

            Servico servico3 = ServicoStub.GetInstance(2, "Serviço 2", 1);

            repositorioServico.Setup(r => r.Obter(2))
                              .Returns(servico3);

            fachada.AdicionarItem(dto3);
            repositorioServico.Verify(r => r.Obter(It.IsAny<long>()));

            #endregion

            #region Item 4
            DTOItem dto4 = new DTOItem();
            dto4.IdServico = 4;
            dto4.ValorUnitario = 12m;
            dto4.Quantidade = 1;

            Servico servico4 = ServicoStub.GetInstance(4, "Serviço 4", 1);

            repositorioServico.Setup(r => r.Obter(4))
                              .Returns(servico4);

            fachada.AdicionarItem(dto4);
            repositorioServico.Verify(r => r.Obter(It.IsAny<long>()));

            #endregion

            #region Acréscimos e Descontos
            fachada.AdicionarAcrescimo(10);
            fachada.AdicionarDesconto(15);
            #endregion

            DTOValoresAtendimento dto = fachada.ObterValoresAtendimento();

            foreach (DTOItem i in dto.Itens)
            {
                switch (i.IdServico)
                {
                    case 1: Assert.AreEqual(15m, i.ValorUnitario);
                            Assert.AreEqual(1, i.Quantidade);
                            Assert.AreEqual(15, i.ValorItem);
                            Assert.AreEqual("SERVIÇO 1", i.DescricaoServico);
                            break;
                    case 2: Assert.AreEqual(10m, i.ValorUnitario);
                            Assert.AreEqual(2, i.Quantidade);
                            Assert.AreEqual(20, i.ValorItem);
                            Assert.AreEqual("SERVIÇO 2", i.DescricaoServico);
                            break;
                    case 4: Assert.AreEqual(12m, i.ValorUnitario);
                            Assert.AreEqual(1, i.Quantidade);
                            Assert.AreEqual(12, i.ValorItem);
                            Assert.AreEqual("SERVIÇO 4", i.DescricaoServico);
                            break;
                }
            }

            Assert.AreEqual(10m, dto.PercentualAcrescimo);
            Assert.AreEqual(20m, dto.PercentualDesconto);
            Assert.AreEqual(10m, dto.Acrescimo);
            Assert.AreEqual(15m, dto.Desconto);
            Assert.AreEqual(3m, dto.NumeroItens);
            Assert.AreEqual(37m, dto.TotalValorUnitario);
            Assert.AreEqual(4m, dto.TotalQuantidade);
            Assert.AreEqual(47m, dto.TotalValorItens);
            Assert.AreEqual(4.7m, dto.AcrescimoFormaPagamento);
            Assert.AreEqual(9.4m, dto.DescontoFormaPagamento);
            Assert.AreEqual(37.3m, dto.ValorAtendimento);
            Assert.AreEqual(12.43m, dto.ValorEntrada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCabecalhoNaoAdicionado))]
        public void Nao_Devo_Conseguir_Retornar_Os_Valores_Do_Atendimento_Se_O_Atendimento_Nao_Estiver_Criado()
        {
            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, null);
            fachada.ObterValoresAtendimento();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCabecalhoNaoAdicionado))]
        public void Nao_Devo_Conseguir_Dar_Desconto_Se_O_Atendimento_Nao_Estiver_Criado()
        {
            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, null);
            fachada.AdicionarDesconto(100m);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCabecalhoNaoAdicionado))]
        public void Nao_Devo_Conseguir_Aplicar_Acrescimo_Se_O_Atendimento_Nao_Estiver_Criado()
        {
            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, null);
            fachada.AdicionarAcrescimo(100m);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoCabecalhoNaoAdicionado))]
        public void Nao_Devo_Conseguir_Salvar_Se_O_Atendimento_Nao_Estiver_Criado()
        {
            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, null);
            fachada.Gravar();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoAtendimentoSemItens))]
        public void Nao_Devo_Conseguir_Salvar_Sem_Itens()
        {
            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, null);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);
            fachada.Gravar();
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoAtendimentoComValorZerado))]
        public void Nao_Devo_Conseguir_Salvar_Com_Valor_Zerado()
        {
            DTOItem dto = new DTOItem();
            dto.IdServico = 1;
            dto.ValorUnitario = 15.23m;
            dto.Quantidade = 1;

            var servico = new Mock<Servico>();
            servico.Setup(s => s.Id).Returns(1);

            var repositorioServico = new Mock<IServicoRepositorio>();
            repositorioServico.Setup(r => r.Obter(It.IsAny<long>())).Returns(servico.Object);

            IFachadaAtendimento fachada = new FachadaAtendimento(null, this._repositorioPessoa, this._repositorioFormaPagamento, repositorioServico.Object);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);
            fachada.AdicionarDesconto(100);
            fachada.AdicionarItem(dto);
            fachada.Gravar();
        }

        [TestMethod]
        public void Devo_Conseguir_Salvar_Valido()
        {
            var repositorio = new Mock<IAtendimentoRepositorio>();
            repositorio.Setup(r => r.Salvar(It.IsAny<Atendimento>())).Returns(It.IsAny<Atendimento>());

            DTOItem dto = new DTOItem();
            dto.IdServico = 1;
            dto.ValorUnitario = 15.23m;
            dto.Quantidade = 1;

            var servico = new Mock<Servico>();
            servico.Setup(s => s.Id).Returns(1);

            var repositorioServico = new Mock<IServicoRepositorio>();
            repositorioServico.Setup(r => r.Obter(1)).Returns(servico.Object);

            IFachadaAtendimento fachada = new FachadaAtendimento(repositorio.Object, this._repositorioPessoa, this._repositorioFormaPagamento, repositorioServico.Object);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);
            fachada.AdicionarItem(dto);
            fachada.AdicionarAcrescimo(15);
            fachada.AdicionarDesconto(2);
            fachada.Gravar();

            repositorio.Verify(r => r.Salvar(It.IsAny<Atendimento>()));                        
        }

        [TestMethod]
        public void Devo_Conseguir_Baixar_Atendimento()
        {
            var repositorio = new Mock<IAtendimentoRepositorio>();
            repositorio.Setup(r => r.Salvar(It.IsAny<Atendimento>())).Returns(It.IsAny<Atendimento>());

            DTOItem dto = new DTOItem();
            dto.IdServico = 1;
            dto.ValorUnitario = 15.23m;
            dto.Quantidade = 1;

            var servico = new Mock<Servico>();
            servico.Setup(s => s.Id).Returns(1);

            var repositorioServico = new Mock<IServicoRepositorio>();
            repositorioServico.Setup(r => r.Obter(1)).Returns(servico.Object);

            IFachadaAtendimento fachada = new FachadaAtendimento(repositorio.Object, this._repositorioPessoa, this._repositorioFormaPagamento, repositorioServico.Object);
            fachada.CriaNovoAtendimento(this._dtoCabecalho);
            fachada.AdicionarItem(dto);
            fachada.ReceberAtendimento();

            Assert.IsTrue(fachada.AtendimentoFoiRecebido());
        }
    }
}
