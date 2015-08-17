using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.ModuloCaixa.Tipo;

namespace Eimbo.Dominio.DTO.ModuloCaixa
{
    public class DTOLancamentoCaixa
    {
        public DateTime DataHora { get; set; }
        public String Descricao { get; set; }
        public TipoPagamentoLancamentoCaixa TipoPagamento { get; set; }
        public Decimal Valor { get; set; }
    }
}
