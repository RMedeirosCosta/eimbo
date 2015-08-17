using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.ModuloAtendimento
{
    public class DTOValoresAtendimento
    {
        public IEnumerable<DTOItem> Itens { get; set; }
        public Decimal PercentualAcrescimo { get; set; }
        public Decimal PercentualDesconto { get; set; }
        public Decimal Acrescimo { get; set; }
        public Decimal Desconto { get; set; }
        public int NumeroItens { get; set; }
        public Decimal TotalValorUnitario { get; set; }
        public Decimal TotalQuantidade { get; set; }
        public Decimal TotalValorItens { get; set; }
        public Decimal AcrescimoFormaPagamento { get; set; }
        public Decimal DescontoFormaPagamento { get; set; }
        public Decimal ValorAtendimento { get; set; }
        public Decimal ValorEntrada { get; set; }

        public DTOValoresAtendimento()
        {
            this.Itens = new List<DTOItem>();
        }

        public void AdicionarItem(DTOItem item)
        {
            ((IList<DTOItem>)this.Itens).Add(item);
        }
    }
}
