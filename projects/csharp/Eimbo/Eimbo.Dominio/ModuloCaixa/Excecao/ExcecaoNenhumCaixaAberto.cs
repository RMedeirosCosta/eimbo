using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloCaixa.Excecao
{
    public class ExcecaoNenhumCaixaAberto :Exception
    {
        public ExcecaoNenhumCaixaAberto() : base("Não é possível realizar essa operação, pois não há nenhum caixa aberto!") { }
    }
}
