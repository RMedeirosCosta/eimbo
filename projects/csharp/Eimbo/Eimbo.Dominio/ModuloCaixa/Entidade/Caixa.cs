using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.ModuloCaixa.Excecao;
using Eimbo.Dominio.ModuloCaixa.Tipo;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.ModuloCaixa.Entidade
{
    public class Caixa : Eimbo.Dominio.Comum.Entidade.Entidade
    {
        #region Constantes
        private const String SALDO_ABERTURA = "SALDO DE ABERTURA";
        private const String SANGRIA = "SANGRIA";
        private const String REFORCO = "REFORÇO";
        private const String ATENDIMENTO = "ATENDIMENTO";
        private const String TROCO = "TROCO";
        #endregion

        #region Atributos Privados
        private DateTime _dataAbertura;
        private DateTime _dataFechamento;
        private TipoSituacaoCaixa _situacao;
        private IList<LancamentoCaixa> _lancamentos;
        #endregion

        #region Construtores
        protected Caixa() { }

        public Caixa(Decimal SaldoAbertura)
        {
            if (SaldoAbertura < 0)
                throw new ExcecaoSaldoAberturaInvalido();

            this._dataAbertura = DateTime.Now;
            this._situacao = TipoSituacaoCaixa.Aberto;
            this.LancarSaldoAbertura(SaldoAbertura);
        }
        #endregion

        private void LancarSaldoAbertura(Decimal SaldoAbertura)
        {
            this._lancamentos = new List<LancamentoCaixa>();

            if (SaldoAbertura > 0)
                this._lancamentos.Add(new LancamentoCaixa(SALDO_ABERTURA, TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, SaldoAbertura));
        }

        #region Propriedades
        public virtual TipoSituacaoCaixa Situacao
        {
            get
            {
                return this._situacao;
            }
        }


        public virtual DateTime DataAbertura
        {
            get
            {
                return this._dataAbertura;
            }
        }

        public virtual DateTime DataFechamento
        {
            get
            {
                return this._dataFechamento;
            }
        }

        public virtual Boolean EstaAberto
        {
            get
            {
                return this._situacao.Equals(TipoSituacaoCaixa.Aberto);
            }
        }

        public virtual IEnumerable<LancamentoCaixa> Lancamentos
        {
            get
            {
                return this._lancamentos.OrderBy(l => l.DiaHorario);
            }
        }

        public virtual Decimal SaldoAbertura
        {
            get
            {
                try
                {
                    return this.Lancamentos.Single(l => (l.Descricao.Equals(SALDO_ABERTURA))).Valor;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public virtual Decimal TotalSangrias
        {
            get
            {
                try
                {
                    return this.Lancamentos.Where(l => (l.Descricao.Equals(SANGRIA))).Sum(l => l.Valor);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public virtual Decimal TotalReforcos
        {
            get
            {
                try
                {
                    return this.Lancamentos.Where(l => (l.Descricao.Equals(REFORCO))).Sum(l => l.Valor);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public virtual Decimal TotalAtendimentosDinheiro
        {
            get
            {
                try
                {
                    return this.Lancamentos.Where(l => ((l.Descricao.Equals(ATENDIMENTO)) && (l.TipoPagamento.Equals(TipoPagamentoLancamentoCaixa.Dinheiro))) ).Sum(l => l.Valor);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public virtual Decimal TotalTrocos
        {
            get
            {
                try
                {
                    return this.Lancamentos.Where(l => ((l.Descricao.Equals(TROCO)) && (l.TipoPagamento.Equals(TipoPagamentoLancamentoCaixa.Dinheiro)))).Sum(l => l.Valor);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public virtual Decimal SaldoDinheiro
        {
            get
            {
                return (
                         this.SaldoAbertura             +
                         this.TotalReforcos             +
                         this.TotalAtendimentosDinheiro -
                         this.TotalTrocos               -
                         this.TotalSangrias
                       );
            }
        }

        public virtual Decimal SaldoCartaoCredito
        {
            get
            {
                try
                {
                    return this.Lancamentos.Where(l => (l.TipoPagamento.Equals(TipoPagamentoLancamentoCaixa.CartaoCredito))).Sum(l => l.Valor);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public virtual Decimal SaldoCartaoDebito
        {
            get
            {
                try
                {
                    return this.Lancamentos.Where(l => (l.TipoPagamento.Equals(TipoPagamentoLancamentoCaixa.CartaoDebito))).Sum(l => l.Valor);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public virtual Decimal SaldoGeral
        {
            get
            {
                return (
                        this.SaldoDinheiro +
                        this.SaldoCartaoCredito +
                        this.SaldoCartaoDebito
                        );
            }
        }
        #endregion

        #region Métodos
        public virtual void AdicionarLancamento(LancamentoCaixa lancamento)
        {
            if (lancamento == null)
                throw new ExcecaoParametroInvalido("lancamento");

            this._lancamentos.Add(lancamento);
        }

        public virtual void EfetuarReforco(Decimal valor)
        {
            if (valor <= 0)
                throw new ExcecaoParametroInvalido("valor");

            this._lancamentos.Add(new LancamentoCaixa(REFORCO, TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, valor));
        }

        public virtual void EfetuarSangria(Decimal valor)
        {
            if (valor <= 0)
                throw new ExcecaoParametroInvalido("valor");

            if (valor > this.SaldoDinheiro)
                throw new ExcecaoValorInsuficienteEmCaixa();

            this._lancamentos.Add(new LancamentoCaixa(SANGRIA, TipoMovimentacaoLancamentoCaixa.Saida, TipoPagamentoLancamentoCaixa.Dinheiro, valor));
        }

        public virtual void ReceberAtendimentoEmDinheiro(Decimal valor)
        {
            if (valor <= 0)
                throw new ExcecaoParametroInvalido("valor");

            this._lancamentos.Add(new LancamentoCaixa(ATENDIMENTO, TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.Dinheiro, valor));
        }

        public virtual void ReceberAtendimentoCartaoCredito(Decimal valor)
        {
            if (valor <= 0)
                throw new ExcecaoParametroInvalido("valor");

            this._lancamentos.Add(new LancamentoCaixa(ATENDIMENTO, TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.CartaoCredito, valor));
        }

        public virtual void ReceberAtendimentoCartaoDebito(Decimal valor)
        {
            if (valor <= 0)
                throw new ExcecaoParametroInvalido("valor");

            this._lancamentos.Add(new LancamentoCaixa(ATENDIMENTO, TipoMovimentacaoLancamentoCaixa.Entrada, TipoPagamentoLancamentoCaixa.CartaoDebito, valor));
        }

        public virtual void EfetuarSaidaParaTroco(Decimal valor)
        {
            if (valor <= 0)
                throw new ExcecaoParametroInvalido("valor");

            if (valor > this.SaldoDinheiro)
                throw new ExcecaoValorInsuficienteEmCaixa();

            this._lancamentos.Add(new LancamentoCaixa(TROCO, TipoMovimentacaoLancamentoCaixa.Saida, TipoPagamentoLancamentoCaixa.Dinheiro, valor));
        }

        public virtual void Fechar()
        {
            this._situacao = TipoSituacaoCaixa.Fechado;
            this._dataFechamento = DateTime.Now;
        }

        public virtual void Abrir()
        {
            this._situacao = TipoSituacaoCaixa.Aberto;
            this._dataAbertura = DateTime.Now;
            this._dataFechamento = DateTime.MinValue;
        }
        #endregion

    }
}
