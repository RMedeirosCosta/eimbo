using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using dominio = Eimbo.Dominio.Comum.Repositorio;
using objetoValor = Eimbo.Dominio.Comum.ObjetoValor;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Comum
{
    public abstract class RepositorioNHibernate<T> : dominio.IRepositorio<T>
    {
        protected ISession _sessao;

        public RepositorioNHibernate(ISession sessao)
        {
            this._sessao = sessao;
        }

        public T Salvar(T value)
        {
            using (ITransaction trans = this._sessao.BeginTransaction())
            {
                this._sessao.Clear();
                this._sessao.SaveOrUpdate(value);
                trans.Commit();
            }
            return value;
        }

        public void Apagar(T value)
        {
            using (ITransaction trans = this._sessao.BeginTransaction())
            {
                this._sessao.Clear();
                this._sessao.Delete(value);
                trans.Commit();
            }
        }

        public T Obter(long identidade)
        {
            return this._sessao.Get<T>(identidade);
        }

        public IEnumerable<T> ObterTodos()
        {
             var qry = from c in this._sessao.Query<T>()
                       select c;
             return qry.ToList();
        }

        public IEnumerable<T> Consultar(objetoValor.Especificacao<T> especificacao)
        {
            var qry = this._sessao.Query<T>().Where(especificacao.SatisfeitoPor());

            try
            {
                return qry.ToList<T>();
            }
            catch (NotSupportedException)
            {
                return null;
            }
        }
    }
}
