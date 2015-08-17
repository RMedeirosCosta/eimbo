using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloCaixa.Excecao
{
    public class ExcecaoNenhumCaixaAnterior :Exception
    {
        public ExcecaoNenhumCaixaAnterior() : base("Não foi encontrado nenhum caixa anterior!") { }
    }
}
