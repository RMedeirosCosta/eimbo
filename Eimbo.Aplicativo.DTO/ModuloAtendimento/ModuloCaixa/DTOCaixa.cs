using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.ModuloCaixa
{
    public class DTOCaixa
    {
        public Boolean EstaAberto { get; set; }
        public DateTime DataAbertura { get; set; }
        public Decimal SaldoAbertura { get; set; }
        public Decimal TotalAtendimentosDinheiro { get; set; }
        public Decimal TotalSangrias { get; set; }
        public Decimal TotalReforcos { get; set; }
        public Decimal TotalTrocos { get; set; }
        public Decimal SaldoDinheiro { get; set; }
        public Decimal SaldoCartaoCredito { get; set; }
        public Decimal SaldoCartaoDebito { get; set; }
        public Decimal SaldoGeral { get; set; }
    }
}
