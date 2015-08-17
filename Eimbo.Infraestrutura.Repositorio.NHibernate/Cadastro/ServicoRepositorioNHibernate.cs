using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Comum;

using NHibernate;
using NHibernate.Linq;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro
{
    public class ServicoRepositorioNHibernate : RepositorioNHibernate<Eimbo.Dominio.Comum.Entidade.Servico>, IServicoRepositorio
    {
        public ServicoRepositorioNHibernate(ISession _sessao) : base(_sessao) { }

        public Eimbo.Dominio.Comum.Entidade.Servico ObterServicoPelaDescricao(String Descricao)
        {
            try
            {
                return base._sessao.Query<Eimbo.Dominio.Comum.Entidade.Servico>()
                                   .SingleOrDefault(s => (s.Descricao == Descricao));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
