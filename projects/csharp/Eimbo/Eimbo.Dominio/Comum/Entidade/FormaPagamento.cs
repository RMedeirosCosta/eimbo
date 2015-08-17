using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Entidade
{
    public class FormaPagamento :EntidadeBloqueavel
    {
        protected FormaPagamento() { }

        private String _descricao;        
        private Decimal _percentualAcrescimo;
        private Decimal _percentualDesconto;
        private TipoFormaPagamento _tipo;

        private IList<ParcelamentoFormaPagamento> _parcelamentos;
        public virtual IEnumerable<ParcelamentoFormaPagamento> Parcelamentos { get { return this._parcelamentos; } }

        public virtual String Descricao
        {
            get { return this._descricao.ToUpper().Trim(); }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ExcecaoParametroInvalido("Descricao");

                this._descricao = value;
            }
        }

        public virtual Decimal PercentualAcrescimo
        {
            get { return this._percentualAcrescimo; }
            set
            {
                if (value < 0)
                    throw new ExcecaoParametroInvalido("Acrescimo");

                this._percentualAcrescimo = value;
            }
        }

        public virtual Decimal PercentualDesconto
        {
            get { return this._percentualDesconto; }
            set
            {
                if (value < 0)
                    throw new ExcecaoParametroInvalido("Desconto");

                this._percentualDesconto = value;
            }
        }

        public virtual TipoFormaPagamento Tipo 
        {
            get { return this._tipo;  }
            set
            {
                if ((!value.Equals(TipoFormaPagamento.Vista)) && (!value.Equals(TipoFormaPagamento.Prazo)))
                    throw new ExcecaoParametroInvalido("Tipo");

                if ((value.Equals(TipoFormaPagamento.Vista)) && (this._parcelamentos != null))
                    this._parcelamentos = null;

                this._tipo = value;
            }
        }

        public virtual ParcelamentoFormaPagamento Parcelamento 
        { 
            get 
            {
                try
                {
                    return this._parcelamentos.First();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set 
            {
                if (value == null)
                    throw new ExcecaoParametroInvalido("Parcelamento");

                if (TipoFormaPagamento.Vista.Equals(this.Tipo))
                    throw new ExcecaoCampoNaoPermitido("parcelamento", "forma de pagamento à vista");

                if ((!value.Tipo.Equals(TipoParcelamentoFormaPagamento.ComEntrada)) && (!value.Tipo.Equals(TipoParcelamentoFormaPagamento.SemEntrada)))
                    throw new ExcecaoParametroInvalido("TipoParcelamento");

                if (value.IntervaloEntreParcelas <= 0)
                    throw new ExcecaoParametroInvalido("IntervaloParcelas");

                if (value.QuantidadeParcelas <= 0)
                    throw new ExcecaoParametroInvalido("QuantidadeParcelas");

                if ((value.QuantidadeParcelas < 2) && (TipoParcelamentoFormaPagamento.ComEntrada.Equals(value.Tipo)))
                    throw new ExcecaoQuantidadeParcelasInvalidaParaFormaPagamentoComEntrada();

                if (this._parcelamentos == null)
                    this._parcelamentos = new List<ParcelamentoFormaPagamento>();

                this._parcelamentos.Clear();                

                this._parcelamentos.Add(value);
            }
        }

        // Constructor para forma de pagamento à vista
        public FormaPagamento(String Descricao,
                              TipoFormaPagamento TipoFormaPagamento,
                              Decimal percentualAcrescimo,
                              Decimal percentualDesconto)
        {
            if (TipoFormaPagamento.Prazo.Equals(TipoFormaPagamento))
                throw new ExcecaoCampoObrigatorioNaoInformado("Parcelamento");

            this.Descricao = Descricao;
            this.PercentualAcrescimo = percentualAcrescimo;
            this.PercentualDesconto = percentualDesconto;
            this.Tipo = TipoFormaPagamento;
            this._parcelamentos = null;
        }

        // Constructor para forma de pagamento a prazo
        public FormaPagamento(String Descricao,
                              TipoFormaPagamento TipoFormaPagamento,
                              Decimal percentualAcrescimo,
                              Decimal percentualDesconto,
                              ParcelamentoFormaPagamento parcelamento)
        {

            this.Descricao = Descricao;
            this.PercentualAcrescimo = percentualAcrescimo;
            this.PercentualDesconto = percentualDesconto;
            this.Tipo = TipoFormaPagamento;
            this.Parcelamento = parcelamento;
        }
    }
}
