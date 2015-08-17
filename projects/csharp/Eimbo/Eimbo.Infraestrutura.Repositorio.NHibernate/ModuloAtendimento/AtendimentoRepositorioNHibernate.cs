using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.ModuloAtendimento.Entidade;
using Eimbo.Dominio.ModuloAtendimento.Repositorio;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Comum;

using NHibernate;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.ModuloAtendimento
{
    public class AtendimentoRepositorioNHibernate :RepositorioNHibernate<Atendimento>, IAtendimentoRepositorio
    {
        public AtendimentoRepositorioNHibernate(ISession _sessao) : base(_sessao) { }
    }
}
