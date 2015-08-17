using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Repositorio;
using Eimbo.Dominio.Cadastro.ObjetoValor;

namespace Eimbo.Dominio.Cadastro.Repositorio
{
    public interface IServicoRepositorio : IRepositorio<Eimbo.Dominio.Comum.Entidade.Servico>
    {
        Eimbo.Dominio.Comum.Entidade.Servico ObterServicoPelaDescricao(String Descricao);
    }
}
