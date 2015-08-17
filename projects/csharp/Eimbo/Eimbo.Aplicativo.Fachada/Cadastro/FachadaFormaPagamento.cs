using System;
using System.Collections.Generic;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.Cadastro.ObjetoValor;
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Fachada.Cadastro
{
    public class FachadaFormaPagamento :IFachadaFormaPagamento
    {
        private IFormaPagamentoRepositorio _repositorio;

        public FachadaFormaPagamento(IFormaPagamentoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public Boolean AlterarStatus(DTOFormaPagamento dtoSelecionado)
        {
            if (dtoSelecionado == null) 
                return false;

            FormaPagamento fpagto = this._repositorio.Obter(dtoSelecionado.ID);
            fpagto.AlteraStatus();
            this._repositorio.Salvar(fpagto);

            return true;
        }

        public IEnumerable<DTOFormaPagamento> Buscar(String palavraChave = "")
        {
            IEnumerable<FormaPagamento> fpagtos = this._repositorio.Consultar(new FormaPagamentoPorParteIdDescricao(palavraChave, palavraChave));

            if (fpagtos == null) fpagtos = this._repositorio.ObterTodos();

            IList<DTOFormaPagamento> result = new List<DTOFormaPagamento>();

            foreach(FormaPagamento fpagto in fpagtos)
            {
                DTOFormaPagamento d = new DTOFormaPagamento();
                d.ID = fpagto.Id;
                d.Status = fpagto.Status;
                d.Descricao = fpagto.Descricao;
                d.PercentualAcrescimo = fpagto.PercentualAcrescimo;
                d.PercentualDesconto = fpagto.PercentualDesconto;
                d.Parcelamento = fpagto.Parcelamento;

                result.Add(d);
            }

            if (result.Count <= 0)
                return null;
            else 
                return result;             
        }

        public Boolean Gravar(DTOFormaPagamento dtoFormaPagamento)
        {
            if (dtoFormaPagamento == null)
                return false;

            FormaPagamento fpagto = this._repositorio.Obter(dtoFormaPagamento.ID);

            if (fpagto == null)
            {                
                if (dtoFormaPagamento.Parcelamento == null)
                    fpagto = new FormaPagamento(dtoFormaPagamento.Descricao, dtoFormaPagamento.Tipo, dtoFormaPagamento.PercentualAcrescimo, dtoFormaPagamento.PercentualDesconto);
                else
                    fpagto = new FormaPagamento(dtoFormaPagamento.Descricao, dtoFormaPagamento.Tipo, dtoFormaPagamento.PercentualAcrescimo, dtoFormaPagamento.PercentualDesconto, dtoFormaPagamento.Parcelamento);
            }

            else
            {
                fpagto.Descricao = dtoFormaPagamento.Descricao;
                fpagto.PercentualAcrescimo = dtoFormaPagamento.PercentualAcrescimo;
                fpagto.PercentualDesconto = dtoFormaPagamento.PercentualDesconto;
                fpagto.Tipo = dtoFormaPagamento.Tipo;

                if (dtoFormaPagamento.Parcelamento != null)
                    fpagto.Parcelamento = dtoFormaPagamento.Parcelamento;
            }

            FormaPagamento fpagtoEncontradaNoBD = this._repositorio.ObterFormaPagamentoPorDescricao(dtoFormaPagamento.Descricao);
            ValidadorFormaPagamento validador   = new ValidadorFormaPagamento(fpagtoEncontradaNoBD);

            if (dtoFormaPagamento.IsNovo())
                validador.ValidarNovaFormaPagamento(fpagto);
            else 
                validador.ValidarFormaPagamentoEmAlteracao (fpagto);

            this._repositorio.Salvar(fpagto);
            dtoFormaPagamento.ID = fpagto.Id;
            
            return true;
        }

        public DTOFormaPagamento Obter(long id)
        {
            FormaPagamento fpagto = this._repositorio.Obter(id);

            try
            {
                DTOFormaPagamento dto = new DTOFormaPagamento();
                dto.ID = fpagto.Id;
                dto.Status = fpagto.Status;
                dto.Tipo = fpagto.Tipo;
                dto.Descricao = fpagto.Descricao;
                dto.PercentualAcrescimo = fpagto.PercentualAcrescimo;
                dto.PercentualDesconto = fpagto.PercentualDesconto;
                dto.Parcelamento = fpagto.Parcelamento;

                return dto;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
