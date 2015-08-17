using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.ModuloCaixa.Excecao
{
    public class ExcecaoSaldoAberturaInvalido : Exception
    {
        public ExcecaoSaldoAberturaInvalido()
            : base("Saldo negativo não pode ser menor que zero!") { }
    }
       
}
