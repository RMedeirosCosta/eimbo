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
    public class CidadeRepositorioNHibernate :RepositorioNHibernate<Cidade>, ICidadeRepositorio
    {
        public CidadeRepositorioNHibernate(ISession _sessao) :base(_sessao) {}

        public Cidade ObterCidadePorNomeEEstado(CidadePorNomeEEstado especificacao)
        {
            try {
               return base._sessao.Query<Cidade>().Where(especificacao.SatisfeitoPor()).First();
            } catch (InvalidOperationException) {
                return null;
            }
        }
    }
}
