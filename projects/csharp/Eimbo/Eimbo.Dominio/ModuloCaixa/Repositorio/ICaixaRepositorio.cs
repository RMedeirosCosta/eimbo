using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Repositorio;
using Eimbo.Dominio.ModuloCaixa.Entidade;

namespace Eimbo.Dominio.ModuloCaixa.Repositorio
{
    public interface ICaixaRepositorio :IRepositorio<Caixa>
    {
        Caixa ObterUltimoCaixaAberto();
        Caixa ObterUltimoCaixaFechado();
    }
}
