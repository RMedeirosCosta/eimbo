using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.ModuloCaixa
{
    public class DTORecebimentoCaixa
    {
        public Decimal ValorReceber { get; set; }
        public Decimal ValorDinheiro { get; set; }
        public Decimal ValorCartaoCredito { get; set; }
        public Decimal ValorCartaoDebito { get; set; }
        public Decimal ValorSoma { get; set; }
        public Decimal ValorRestante { get; set; }
        public Decimal ValorTroco { get; set; }
    }
}
