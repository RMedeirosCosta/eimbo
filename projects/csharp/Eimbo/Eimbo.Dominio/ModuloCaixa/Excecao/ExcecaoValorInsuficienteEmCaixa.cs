using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloCaixa.Excecao
{
    public class ExcecaoValorInsuficienteEmCaixa :Exception
    {
        public ExcecaoValorInsuficienteEmCaixa() : base("Não há valor suficiente no caixa para realizar essa operação!") { }
    }
}
