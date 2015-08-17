using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eimbo.Dominio.Comum.ObjetoValor;

namespace Eimbo.Dominio.Comum.Repositorio
{
    public interface IRepositorio<T> 
    {
        T Salvar(T value);

        void Apagar(T value);

        T Obter(long identidade);

        IEnumerable<T> ObterTodos();

        IEnumerable<T> Consultar(Especificacao<T> especificacao);
    }
}
