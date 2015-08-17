using System;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class ParcelamentoFormaPagamento :ObjetoValor
    {
        private TipoParcelamentoFormaPagamento _tipo;
        private int _quantidadeParcelas;
        private int _intervaloEntreParcelas;

        public virtual TipoParcelamentoFormaPagamento Tipo { get { return this._tipo; } }
        public virtual int QuantidadeParcelas { get { return this._quantidadeParcelas; } }
        public virtual int IntervaloEntreParcelas { get { return this._intervaloEntreParcelas; } }

        protected ParcelamentoFormaPagamento() { }

        protected override bool ComparaValor(ObjetoValor obj)
        {
            ParcelamentoFormaPagamento p = (ParcelamentoFormaPagamento) obj;

            return ((this.Tipo.Equals(p.Tipo)) &&
                    (this.QuantidadeParcelas.Equals(p.QuantidadeParcelas)) &&
                    (this.IntervaloEntreParcelas.Equals(p.IntervaloEntreParcelas)));
        }

        public override int GetHashCode()
        {
            return this.Tipo.GetHashCode() + this.QuantidadeParcelas.GetHashCode() + this.IntervaloEntreParcelas.GetHashCode();
        }

        public ParcelamentoFormaPagamento(TipoParcelamentoFormaPagamento tipo, int quantidadeParcelas, int intervaloEntreParcelas)
        {
            this._tipo = tipo;
            this._quantidadeParcelas = quantidadeParcelas;
            this._intervaloEntreParcelas = intervaloEntreParcelas;
        }
    }
}
