using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OV = Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Dominio.ModuloAtendimento.ObjetoValor
{
    public class ItemAtendimento :OV.ObjetoValor
    {
        private Servico _servico;

        public virtual Servico Servico { get { return this._servico; } }
        public virtual Decimal ValorUnitario { get; set; }
        public virtual int Quantidade { get; set; }
        public Decimal ValorItem
        {
            get
            {
                return (this.ValorUnitario * this.Quantidade);
            }
        }

        protected ItemAtendimento() { }

        public ItemAtendimento(Servico servico, Decimal valorUnitario, int quantidade)
        {
            this._servico = servico;
            this.ValorUnitario = valorUnitario;
            this.Quantidade = quantidade;
        }

        protected override bool ComparaValor(OV.ObjetoValor obj)
        {
            return (this.Servico.Equals(((ItemAtendimento)obj).Servico));
        }

        public override int GetHashCode()
        {
            return this.Servico.GetHashCode() + this.ValorUnitario.GetHashCode() + this.Quantidade.GetHashCode();
        }

    }
}
