using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloCaixa.Tipo
{
    public enum TipoPagamentoLancamentoCaixa
    {
        Nenhum = -1,
        Dinheiro = 0,
        CartaoDebito = 1,
        CartaoCredito = 2
    }
}
