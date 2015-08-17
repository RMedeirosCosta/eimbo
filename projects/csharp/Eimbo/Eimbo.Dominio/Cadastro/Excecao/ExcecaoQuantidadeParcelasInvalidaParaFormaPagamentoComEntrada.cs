using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Cadastro.Excecao
{
    public class ExcecaoQuantidadeParcelasInvalidaParaFormaPagamentoComEntrada :NotSupportedException
    {
        public ExcecaoQuantidadeParcelasInvalidaParaFormaPagamentoComEntrada()
            : base("Para forma de pagamento a prazo com entrada é necessário ter pelo menos 2 parcelas. " +
                  "Caso contrário, será calculado como uma forma de pagamento à vista!") { }
    }
}
