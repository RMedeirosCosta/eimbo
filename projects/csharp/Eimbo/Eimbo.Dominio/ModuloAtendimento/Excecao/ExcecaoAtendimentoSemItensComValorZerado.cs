using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloAtendimento.Excecao
{
    public class ExcecaoAtendimentoComValorZerado :Exception
    {
        public ExcecaoAtendimentoComValorZerado() : base("O atendimento está com o valor zerado. Verifique!") { }
    }
}
