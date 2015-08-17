using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloAtendimento.Excecao
{
    public class ExcecaoAtendimentoSemItens :Exception
    {
        public ExcecaoAtendimentoSemItens() : base("Nenhum item informado!") { }
    }
}
