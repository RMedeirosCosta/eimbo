using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.ModuloCaixa.Entidade;
using Eimbo.Dominio.ModuloCaixa.Repositorio;
using Eimbo.Dominio.ModuloCaixa.Tipo;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Comum;

using NHibernate;
using NHibernate.Linq;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.ModuloCaixa
{
    public class CaixaRepositorioNHibernate :RepositorioNHibernate<Caixa>, ICaixaRepositorio
    {
        public CaixaRepositorioNHibernate(ISession _sessao) : base(_sessao) { }

        public Caixa ObterUltimoCaixaAberto()
        {
            try
            {
                return base._sessao.Query<Caixa>().Where(c => (c.Situacao == TipoSituacaoCaixa.Aberto)).OrderByDescending(c => c.DataAbertura).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Caixa ObterUltimoCaixaFechado()
        {
            try
            {
                return base._sessao.Query<Caixa>().Where(c => (c.Situacao == TipoSituacaoCaixa.Fechado)).OrderByDescending(c => c.DataAbertura).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
