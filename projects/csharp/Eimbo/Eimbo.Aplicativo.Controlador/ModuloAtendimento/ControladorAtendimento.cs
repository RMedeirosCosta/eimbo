using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Controlador.ModuloAtendimento.Tipo;
using Eimbo.Aplicativo.Visao.ModuloAtendimento;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.Contrato.ModuloAtendimento;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.DTO.ModuloAtendimento;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.ModuloAtendimento
{
    public class ControladorAtendimento :ControladorPadrao<IVisaoAtendimento>
    {
        private IFachadaAtendimento _fachada;
        private IFachadaEmpresa _fachadaEmpresa;
        private IFachadaCliente _fachadaCliente;
        private IFachadaFormaPagamento _fachadaFormaPagamento;
        private IFachadaServico _fachadaServico;

        public ControladorAtendimento(IVisaoAtendimento visao)
            : base(visao)
        {
            this._fachada               = ObjectFactory.GetInstance<IFachadaAtendimento>();
            this._fachadaEmpresa        = ObjectFactory.GetInstance<IFachadaEmpresa>();
            this._fachadaCliente        = ObjectFactory.GetInstance<IFachadaCliente>();
            this._fachadaFormaPagamento = ObjectFactory.GetInstance<IFachadaFormaPagamento>();
            this._fachadaServico        = ObjectFactory.GetInstance<IFachadaServico>();

            this.AlterarEstado(TipoEstadoAtendimento.DigitacaoCabecalho);
            this._visao.SetData(DateTime.Now);
            this._visao.MandarFocoNoCliente();

            try
            {
                DTOPessoa pessoa = this._fachadaEmpresa.ObterEmpresa();
                this._visao.SetIdEmpresa(pessoa.ID);
                this._visao.SetRazaoSocialEmpresa(pessoa.Nome);
            }
            catch (NullReferenceException)
            {
                this._visaoPadrao.ExibirErro("É preciso cadastrar a empresa para fazer um atendimento!");
                this._visao.VoltarParaTelaAnterior();
            }
        }

        public void AdicionarAcrescimo()
        {
            this._fachada.AdicionarAcrescimo(this._visao.GetAcrescimo());
            this.PreencherValores(this._fachada.ObterValoresAtendimento());
        }

        public void AdicionarDesconto()
        {
            this._fachada.AdicionarDesconto(this._visao.GetDesconto());
            this.PreencherValores(this._fachada.ObterValoresAtendimento());
        }

        public void AdicionarItem()
        {
            DTOItem dto = new DTOItem();

            dto.IdServico = this._visao.GetIdServico();
            //dto.DescricaoServico = this._visao.GetDescricaoServico();
            dto.ValorUnitario = this._visao.GetValorUnitario();
            dto.Quantidade = this._visao.GetQuantidade();

            try
            {
                this._fachada.AdicionarItem(dto);

                this.PreencherValores(this._fachada.ObterValoresAtendimento());
                this.LimparGrupoItem();
                this._visao.MandarFocoNoServico();
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("servico"))
                {
                    this._visaoPadrao.ExibirErro("Informe o serviço!", "edtIdServico");
                    this._visao.MandarFocoNoServico();
                }

                else if (ex.Message.Equals("valorUnitario"))
                {
                    this._visaoPadrao.ExibirErro("Informe o valor unitário!", "edtValorUnitario");
                    this._visao.MandarFocoNoValorUnitario();
                }

                else if (ex.Message.Equals("quantidade"))
                {
                    this._visaoPadrao.ExibirErro("Informe a quantidade!", "edtQuantidade");
                    this._visao.MandarFocoNaQuantidade();
                }
            }
        }

        private void AlterarEstado(TipoEstadoAtendimento tipo)
        {
            switch (tipo)
            {
                case TipoEstadoAtendimento.DigitacaoCabecalho: this._visao.HabilitarCabecalho(true);
                                                               this._visao.MostrarBotaoVoltarParaCabecalho(false);
                                                               //this._visao.HabilitarValores(false);
                                                               this._visao.HabilitarBotaoConfirmarAtendimento(false);
                                                               this._visao.LimparValores();
                    break;
                case TipoEstadoAtendimento.DigitacaoItens:     this._visao.HabilitarCabecalho(false);
                                                               this._visao.MostrarBotaoVoltarParaCabecalho(true);
                                                               //this._visao.HabilitarValores(true);
                                                               this._visao.HabilitarBotaoConfirmarAtendimento(true);                                                           
                    break;
            }
        }

        public void BuscarCliente(long idCliente)
        {
            DTOPessoa dtoCliente = this._fachadaCliente.Obter(idCliente);

            if ((dtoCliente == null) || (dtoCliente.Status.Equals(TipoStatus.Bloqueado)))
            {
                if (this._visao.AchouCliente(out idCliente))
                {
                    dtoCliente = this._fachadaCliente.Obter(idCliente);

                    if (dtoCliente != null)
                    {
                        this._visao.SetIdCliente(dtoCliente.ID);
                        this._visao.SetNomeCliente(dtoCliente.Nome);
                        return;
                    }
                }

                this._visao.SetNomeCliente(String.Empty);
                this._visao.MandarFocoNoCliente();
            }
            else
            {
                this._visao.SetIdCliente(dtoCliente.ID);
                this._visao.SetNomeCliente(dtoCliente.Nome);
            }

        }

        public void BuscarFormaPagamento(long idFormaPagamento)
        {
            DTOFormaPagamento dtoFpagto = this._fachadaFormaPagamento.Obter(idFormaPagamento);

            if ((dtoFpagto == null) || (dtoFpagto.Status.Equals(TipoStatus.Bloqueado)))
            {
                if (this._visao.AchouFormaPagamento(out idFormaPagamento))
                {
                    dtoFpagto = this._fachadaFormaPagamento.Obter(idFormaPagamento);

                    if (dtoFpagto != null)
                    {
                        this._visao.SetIdFormaPagamento(dtoFpagto.ID);
                        this._visao.SetDescricaoFormaPagamento(dtoFpagto.Descricao);
                        return;
                    }
                }

                this._visao.SetDescricaoFormaPagamento(String.Empty);
                this._visao.MandarFocoNaFormaPagamento();
            }
            else
            {
                this._visao.SetIdFormaPagamento(dtoFpagto.ID);
                this._visao.SetDescricaoFormaPagamento(dtoFpagto.Descricao);
            }
        }

        public void BuscarServico(long idServico)
        {
            DTOServico dtoServico = this._fachadaServico.Obter(idServico);

            if ((dtoServico == null) || (dtoServico.Status.Equals(TipoStatus.Bloqueado)))
            {
                if (this._visao.AchouServico(out idServico))
                {
                    dtoServico = this._fachadaServico.Obter(idServico);

                    if (dtoServico != null)
                    {
                        this._visao.SetIdServico(dtoServico.ID);
                        this._visao.SetDescricaoServico(dtoServico.Descricao);
                        this._visao.SetValorUnitario(dtoServico.Valor);
                        return;
                    }
                }

                this._visao.SetDescricaoServico(String.Empty);
                this._visao.MandarFocoNoServico();
            }
            else
            {
                this._visao.SetIdServico(dtoServico.ID);
                this._visao.SetDescricaoServico(dtoServico.Descricao);
                this._visao.SetValorUnitario(dtoServico.Valor);
            }
        }

        public void ConfirmarAtendimento()
        {
            try
            {
                this.AdicionarAcrescimo();
                this.AdicionarDesconto();

                DTOValoresAtendimento dto = this._fachada.ObterValoresAtendimento();

                if (dto.ValorEntrada > 0)
                {
                    if (this._visao.ReceberNoCaixa(dto.ValorEntrada))
                        this._fachada.ReceberAtendimento();
                }

                this._fachada.Gravar();
                this.VoltarParaCabecalho();
                this._visaoPadrao.Avisar("Atendimento gravado com sucesso!");
                this._visao.LimparAtendimento();
            }
            catch (Exception ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
        }

        public void CriarAtendimento()
        {
            DTOCabecalhoAtendimento dto = new DTOCabecalhoAtendimento();
            dto.Data = this._visao.GetData();
            dto.IdEmpresa = this._visao.GetIdEmpresa();
            dto.IdCliente = this._visao.GetIdCliente();
            dto.IdFormaPagamento = this._visao.GetIdFormaPagamento();

            try
            {
                this._fachada.CriaNovoAtendimento(dto);
                this.AlterarEstado(TipoEstadoAtendimento.DigitacaoItens);
                this.PreencherValores(this._fachada.ObterValoresAtendimento());
            }
            catch (ExcecaoParametroInvalido ex)
            {
                if (ex.Message.Equals("data"))
                {
                    this._visaoPadrao.ExibirErro("Informe a data!", "edtData");
                    this._visao.MandarFocoNaData();
                }
                else if (ex.Message.Equals("empresa"))
                {
                    this._visaoPadrao.ExibirErro("Informe a empresa!", "edtIdEmpresa");
                    this._visao.MandarFocoNaEmpresa();
                }
                else if (ex.Message.Equals("cliente"))
                {
                    this._visaoPadrao.ExibirErro("Informe o cliente!", "edtIdCliente");
                    this._visao.MandarFocoNoCliente();
                }
                else if (ex.Message.Equals("fpagto"))
                {
                    this._visaoPadrao.ExibirErro("Informe a forma de pagamento!", "edtIdFormaPagamento");
                    this._visao.MandarFocoNaFormaPagamento();
                }
            }

            this._visao.HabilitarEventosTotais(true);
        }

        public void LimparGrupoItem()
        {
            this._visao.LimparIdServico();
            this._visao.LimparDescricaoServico();
            this._visao.LimparValorUnitario();
            this._visao.LimparQuantidade();
        }

        public void PreencherValores(DTOValoresAtendimento dto)
        {
            // Itens
            this._visao.LimparItens();

            foreach (DTOItem i in dto.Itens)
                this._visao.AdicionarItem(i.IdServico, i.DescricaoServico, i.ValorUnitario, i.Quantidade, i.ValorItem);

            // Totais dos itens
            this._visao.SetTotalValorUnitario(dto.TotalValorUnitario);
            this._visao.SetTotalQuantidade(dto.TotalQuantidade);
            this._visao.SetTotalValorItem(dto.TotalValorItens);

            // Acréscimos
            this._visao.SetPercentualAcrescimo(dto.PercentualAcrescimo);
            this._visao.SetAcrescimoFormaPagamento(dto.AcrescimoFormaPagamento);
            this._visao.SetAcrescimo(dto.Acrescimo);

            //Descontos
            this._visao.SetPercentualDesconto(dto.PercentualDesconto);
            this._visao.SetDescontoFormaPagamento(dto.DescontoFormaPagamento);
            this._visao.SetDesconto(dto.Desconto);

            // Total do pedido e valor da entrada
            this._visao.SetValorAtendimento(dto.ValorAtendimento);
            this._visao.SetValorEntrada(dto.ValorEntrada);            
        }

        public void RemoverItem()
        {
            DTOItem dto = new DTOItem();
            dto.IdServico = this._visao.GetIdServicoSelecionado();

            this._fachada.RemoverItem(dto);
            this.PreencherValores(this._fachada.ObterValoresAtendimento());
        }

        public void VoltarParaCabecalho()
        {
            this._visao.HabilitarEventosTotais(false);
            this._fachada.CancelarDigitacaoAtual();
            this.AlterarEstado(TipoEstadoAtendimento.DigitacaoCabecalho);
            this._visao.MandarFocoNoCliente();
        }

        public void VoltarParaTelaAnterior()
        {
            this._visao.VoltarParaTelaAnterior();
        }
    }
}
