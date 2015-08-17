using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Contrato.ModuloAtendimento;
using Eimbo.Dominio.DTO.ModuloAtendimento;
using Eimbo.Dominio.ModuloAtendimento.Entidade;
using Eimbo.Dominio.ModuloAtendimento.Excecao;
using Eimbo.Dominio.ModuloAtendimento.ObjetoValor;
using Eimbo.Dominio.ModuloAtendimento.Repositorio;
using Eimbo.Dominio.ModuloAtendimento.Tipo;

namespace Eimbo.Dominio.Fachada.ModuloAtendimento
{
    public class FachadaAtendimento :IFachadaAtendimento
    {
        private IAtendimentoRepositorio    _repositorio;
        private IPessoaRepositorio         _repositoriPessoa;
        private IFormaPagamentoRepositorio _repositorioFormaPagamento;
        private IServicoRepositorio        _repositorioServico; 
        private Atendimento                _atendimento; 

        public FachadaAtendimento(IAtendimentoRepositorio repositorio,
                                  IPessoaRepositorio repositorioPessoa,
                                  IFormaPagamentoRepositorio repositorioFormaPagamento,
                                  IServicoRepositorio repositorioServico)
        {
            this._repositorio = repositorio;
            this._repositoriPessoa = repositorioPessoa;
            this._repositorioFormaPagamento = repositorioFormaPagamento;
            this._repositorioServico = repositorioServico;
            this._atendimento = null;
        }

        public Decimal ObtemValorEntrada()
        {
            // Se o pedido for à vista, o valor da entrada é igual o valor do atendimento
            if (this._atendimento.FormaPagamento.Tipo.Equals(TipoFormaPagamento.Vista))
                return this._atendimento.ValorAtendimento;

            else
            {
                // Se o pedido for a prazo, mas não tiver entrada, então não há valor de entrada
                if (this._atendimento.FormaPagamento.Parcelamento.Tipo.Equals(TipoParcelamentoFormaPagamento.SemEntrada))
                    return 0;
                else
                    return Decimal.Round((this._atendimento.ValorAtendimento / this._atendimento.FormaPagamento.Parcelamento.QuantidadeParcelas), 2);
            }
        }

        public void CancelarDigitacaoAtual()
        {
            this._atendimento = null;
        }

        public void CriaNovoAtendimento(DTOCabecalhoAtendimento dto)
        {
            Pessoa empresa = this._repositoriPessoa.Obter(dto.IdEmpresa);
            Pessoa cliente = this._repositoriPessoa.Obter(dto.IdCliente);
            FormaPagamento fpagto = this._repositorioFormaPagamento.Obter(dto.IdFormaPagamento);

            this._atendimento = new Atendimento(dto.Data, empresa, cliente, fpagto);
        }

        public void AdicionarItem(DTOItem dto)
        {
            if (this._atendimento == null)
                throw new ExcecaoCabecalhoNaoAdicionado();

            Servico servico = this._repositorioServico.Obter(dto.IdServico);

            this._atendimento.AdicionarItem(servico, dto.ValorUnitario, dto.Quantidade);
        }

        public void RemoverItem(DTOItem dto)
        {
            if (this._atendimento == null)
                throw new ExcecaoCabecalhoNaoAdicionado();

            Servico servico = this._repositorioServico.Obter(dto.IdServico);

            this._atendimento.RemoverItem(servico);
        }

        public DTOValoresAtendimento ObterValoresAtendimento()
        {
            if (this._atendimento == null)
                throw new ExcecaoCabecalhoNaoAdicionado();

            DTOValoresAtendimento dto = new DTOValoresAtendimento();
                        
            foreach(ItemAtendimento i in this._atendimento.Itens)
            {
                DTOItem dtoItem = new DTOItem();
                dtoItem.IdServico = i.Servico.Id;
                dtoItem.DescricaoServico = i.Servico.Descricao;
                dtoItem.ValorUnitario = i.ValorUnitario;
                dtoItem.Quantidade = i.Quantidade;
                dtoItem.ValorItem = i.ValorItem;

                dto.AdicionarItem(dtoItem);
            }

            dto.Acrescimo = this._atendimento.Acrescimo;
            dto.Desconto = this._atendimento.Desconto;
            dto.AcrescimoFormaPagamento = this._atendimento.AcrescimoFormaPagamento;
            dto.DescontoFormaPagamento = this._atendimento.DescontoFormaPagamento;
            dto.PercentualAcrescimo = this._atendimento.FormaPagamento.PercentualAcrescimo;
            dto.PercentualDesconto = this._atendimento.FormaPagamento.PercentualDesconto;
            dto.NumeroItens = this._atendimento.NumeroTotalItens;
            dto.TotalQuantidade = this._atendimento.TotalQuantidade;
            dto.TotalValorItens = this._atendimento.TotalValorItem;
            dto.TotalValorUnitario = this._atendimento.TotalValorUnitario;
            dto.ValorAtendimento = this._atendimento.ValorAtendimento;
            dto.ValorEntrada = this.ObtemValorEntrada();

            return dto;
        }

        public void AdicionarAcrescimo(Decimal acrescimo)
        {
            if (this._atendimento == null)
                throw new ExcecaoCabecalhoNaoAdicionado();

            this._atendimento.Acrescimo = acrescimo;
        }

        public void AdicionarDesconto(Decimal desconto)
        {
            if (this._atendimento == null)
                throw new ExcecaoCabecalhoNaoAdicionado();

            this._atendimento.Desconto = desconto;
        }

        public void Gravar()
        {
            if (this._atendimento == null)
                throw new ExcecaoCabecalhoNaoAdicionado();

            this._atendimento.Validar();

            this._repositorio.Salvar(this._atendimento);
        }

        public Boolean AtendimentoFoiRecebido()
        {
            return this._atendimento.Situacao.Equals(TipoSituacaoAtendimento.Fechado);
        }

        public void ReceberAtendimento()
        {
            this._atendimento.Situacao = TipoSituacaoAtendimento.Fechado;
        }
    }
}
