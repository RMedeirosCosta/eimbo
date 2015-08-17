using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Repositorio;

namespace Eimbo.Dominio.Cadastro.Repositorio
{
    public interface IFormaPagamentoRepositorio :IRepositorio<FormaPagamento>
    {
        FormaPagamento ObterFormaPagamentoPorDescricao(String Descricao);
    }
}
