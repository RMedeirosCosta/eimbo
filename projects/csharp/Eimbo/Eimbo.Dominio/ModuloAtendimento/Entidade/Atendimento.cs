using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.ModuloAtendimento.Tipo;
using Eimbo.Dominio.ModuloAtendimento.ObjetoValor;
using Eimbo.Dominio.ModuloAtendimento.Excecao;

namespace Eimbo.Dominio.ModuloAtendimento.Entidade
{
    public class Atendimento :Eimbo.Dominio.Comum.Entidade.Entidade
    {
        private DateTime _data;
        private Pessoa _empresa;
        private Pessoa _cliente;
        private FormaPagamento _formaPagamento;
        private TipoSituacaoAtendimento _situacao;
        private IList<ItemAtendimento> _itens;
        private Decimal _acrescimoFormaPagamento;
        private Decimal _acrescimo;
        private Decimal _descontoFormaPagamento;
        private Decimal _desconto;

        public virtual DateTime Data
        {
            get
            {
                return this._data;
            }
        }

        public virtual Pessoa Empresa
        {
            get
            {
                return this._empresa;
            }
        }

        public virtual Pessoa Cliente
        {
            get
            {
                return this._cliente;
            }
        }

        public virtual FormaPagamento FormaPagamento
        {
            get
            {
                return this._formaPagamento;
            }
        }

        public virtual TipoSituacaoAtendimento Situacao
        {
            get
            {
                return this._situacao;
            }

            set
            {
                this._situacao = value;
            }
        }

        public virtual IEnumerable<ItemAtendimento> Itens
        {
            get
            {
                return this._itens;
            }
        }

        public virtual Decimal Acrescimo
        { 
            get
            {
                return this._acrescimo;
            }
            set
            {
                if (value < 0)
                    throw new ExcecaoParametroInvalido("acrescimo");

                this._acrescimo = value;
            }
        }
        public virtual Decimal Desconto 
        { 
            get
            {
                return this._desconto;
            }
            set
            {
                if (value < 0)
                    throw new ExcecaoParametroInvalido("desconto");

                this._desconto = value;
            }
        }

        public virtual Int32 NumeroTotalItens
        {
            get
            {
                return this._itens.Count();
            }
        }

        public virtual Decimal TotalValorUnitario
        {
            get
            {
                return this._itens.Sum(i => i.ValorUnitario);
            }
        }

        public virtual Int64 TotalQuantidade
        {
            get
            {
                return this._itens.Sum(i => i.Quantidade);
            }
        }

        public virtual Decimal TotalValorItem
        {
            get
            {
                return this._itens.Sum(i => i.ValorItem);
            }
        }

        public virtual Decimal AcrescimoFormaPagamento
        {
            get
            {
                return this._acrescimoFormaPagamento;
            }
        }

        public virtual Decimal DescontoFormaPagamento 
        {
            get
            {
                return this._descontoFormaPagamento;
            }
        }

        public virtual Decimal ValorAtendimento
        {
            get
            {
                Decimal valorAtendimento = (
                                            this.TotalValorItem +           // Bruto
                                            this.AcrescimoFormaPagamento +  // Gerado pela alíquota na forma de pagamento
                                            this.Acrescimo -
                                            this.DescontoFormaPagamento -
                                            this.Desconto
                                           );

                if (valorAtendimento < 0)
                    valorAtendimento = 0;

                return valorAtendimento;
            }
        }

        protected Atendimento() {}
        
        public Atendimento(DateTime data, Pessoa empresa, Pessoa cliente, FormaPagamento fpagto)
        {
            if (DateTime.MinValue.Equals(data))
                throw new ExcecaoParametroInvalido("data");

            if ((empresa == null)  || (empresa.Id <= 0))
                throw new ExcecaoParametroInvalido("empresa");

            if ((cliente == null) || (cliente.Id <= 0))
                throw new ExcecaoParametroInvalido("cliente");

            if ((fpagto == null) || (fpagto.Id <= 0))
                throw new ExcecaoParametroInvalido("fpagto");

            this._data = data;
            this._cliente = cliente;
            this._empresa = empresa;
            this._formaPagamento = fpagto;
            this._situacao = TipoSituacaoAtendimento.Aberto;
            this._itens = new List<ItemAtendimento>();
        }

        public virtual void AdicionarItem(Servico servico, Decimal valorUnitario, int quantidade)
        {
            if ((servico == null) || (servico.Id <= 0))
                throw new ExcecaoParametroInvalido("servico");

            if (valorUnitario <= 0)
                throw new ExcecaoParametroInvalido("valorUnitario");

            if (quantidade <= 0)
                throw new ExcecaoParametroInvalido("quantidade");
            
            ItemAtendimento item = new ItemAtendimento(servico, valorUnitario, quantidade);

            try
            {
                if (this._itens.Contains(item))
                {
                    ItemAtendimento itemEncontrado = this._itens.Single(i => (i.Equals(item)));

                    itemEncontrado.ValorUnitario = item.ValorUnitario;
                    itemEncontrado.Quantidade = item.Quantidade;
                    return;
                }

                this._itens.Add(item);
            }
            finally
            {
                this._acrescimoFormaPagamento = ((this.TotalValorItem * this._formaPagamento.PercentualAcrescimo) / 100);
                this._descontoFormaPagamento = ((this.TotalValorItem * this._formaPagamento.PercentualDesconto) / 100);
            }
        }

        public virtual void RemoverItem(Servico servico)
        {
            try
            {
                this._itens.Remove(new ItemAtendimento(servico, 0, 0));
            }
            finally
            {
                this._acrescimoFormaPagamento = ((this.TotalValorItem * this._formaPagamento.PercentualAcrescimo) / 100);
                this._descontoFormaPagamento = ((this.TotalValorItem * this._formaPagamento.PercentualDesconto) / 100);
            }
        }

        public virtual void Validar()
        {
            if (this._itens.Count <= 0)
                throw new ExcecaoAtendimentoSemItens();

            if (this.ValorAtendimento.Equals(0))
                throw new ExcecaoAtendimentoComValorZerado();
        }
    }
}
