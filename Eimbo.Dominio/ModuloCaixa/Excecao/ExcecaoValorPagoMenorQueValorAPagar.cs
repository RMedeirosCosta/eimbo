using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloCaixa.Excecao
{
    public class ExcecaoValorPagoMenorQueValorAReceber :Exception
    {
        public ExcecaoValorPagoMenorQueValorAReceber() : base("Não é possível realizar esse recebimento. O valor pago está menor que o valor a receber") { }
    }
}
