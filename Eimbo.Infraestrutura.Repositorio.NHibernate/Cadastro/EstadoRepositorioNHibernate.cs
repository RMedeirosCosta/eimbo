using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region NHibernate
using NHibernate;
using NHibernate.Linq;
#endregion

#region Infraestrutura.NHibernate
using Eimbo.Infraestrutura.Repositorio.NHibernate.Comum;
#endregion

#region Dominio
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Cadastro.ObjetoValor;
#endregion

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro
{
    public class EstadoRepositorioNHibernate :RepositorioNHibernate<Estado>, IEstadoRepositorio
    {
        public EstadoRepositorioNHibernate(ISession _sessao) :base(_sessao) {}

        public Estado ObterEstadoPorUF(EstadoPorUF especificacao)
        {
            try
            {
                return base._sessao.Query<Estado>().Where(especificacao.SatisfeitoPor()).First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

    }
}
