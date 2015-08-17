using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Repositorio;
using Eimbo.Dominio.Cadastro.ObjetoValor;

namespace Eimbo.Dominio.Cadastro.Repositorio
{
    public interface ICidadeRepositorio :IRepositorio<Cidade>
    {
        Cidade ObterCidadePorNomeEEstado(CidadePorNomeEEstado especificacao);
    }
}
