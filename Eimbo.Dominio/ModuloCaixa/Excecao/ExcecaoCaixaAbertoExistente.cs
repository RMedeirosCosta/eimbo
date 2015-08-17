using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloCaixa.Excecao
{
    public class ExcecaoCaixaAnteriorAberto :Exception
    {
        public ExcecaoCaixaAnteriorAberto() : base("Não é possível abrir um novo caixa com um caixa já aberto!") { }
    }
}
