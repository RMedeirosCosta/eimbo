using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.ModuloCaixa.Tipo;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.ModuloCaixa.Entidade
{
    public class LancamentoCaixa : Eimbo.Dominio.Comum.Entidade.Entidade
    {
        #region Atributos Privados
        private DateTime _diaHorario;
        private String _descricao;
        private TipoMovimentacaoLancamentoCaixa _tipoMovimentacao;
        private TipoPagamentoLancamentoCaixa _tipoPagamento;
        private Decimal _valor;
        #endregion

        #region Construtores
        protected LancamentoCaixa() { }

        public LancamentoCaixa(String descricao, TipoMovimentacaoLancamentoCaixa tipoMovimentacao, TipoPagamentoLancamentoCaixa tipoPagamento, Decimal valor)
        {
            if (String.IsNullOrEmpty(descricao))
                throw new ExcecaoParametroInvalido("Descricao");

            if ((!tipoMovimentacao.Equals(TipoMovimentacaoLancamentoCaixa.Entrada)) &&
                (!tipoMovimentacao.Equals(TipoMovimentacaoLancamentoCaixa.Saida)))
                throw new ExcecaoParametroInvalido("TipoMovimentacao");

            if ((!tipoPagamento.Equals(TipoPagamentoLancamentoCaixa.Dinheiro))     &&
                (!tipoPagamento.Equals(TipoPagamentoLancamentoCaixa.CartaoDebito)) &&
                (!tipoPagamento.Equals(TipoPagamentoLancamentoCaixa.CartaoCredito)))
                throw new ExcecaoParametroInvalido("TipoPagamento");

            if (valor <= 0)
                throw new ExcecaoParametroInvalido("Valor");

            this._diaHorario = DateTime.Now;
            this._descricao = descricao;
            this._tipoPagamento = tipoPagamento;
            this._tipoMovimentacao = tipoMovimentacao;            
            this._valor = valor;
        }
        #endregion

        #region Propriedades
        public virtual DateTime DiaHorario
        {
            get
            {
                return this._diaHorario;
            }
        }

        public virtual String Descricao
        {
            get
            {
                return this._descricao.Trim().ToUpper();
            }
        }

        public virtual TipoMovimentacaoLancamentoCaixa TipoMovimentacao
        {
            get
            {
                return this._tipoMovimentacao;
            }
        }

        public virtual TipoPagamentoLancamentoCaixa TipoPagamento
        {
            get
            {
                return this._tipoPagamento;
            }
        }

        public virtual Decimal Valor
        {
            get
            {
                return this._valor;
            }
        }

        #endregion
    }
}
