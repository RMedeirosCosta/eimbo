using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Comum;

using NHibernate;
using NHibernate.Linq;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro
{
    public class FormaPagamentoRepositorioNHibernate :RepositorioNHibernate<FormaPagamento>,
                                                      IFormaPagamentoRepositorio
    {
        public FormaPagamentoRepositorioNHibernate(ISession _sessao) : base(_sessao) { }

        public FormaPagamento ObterFormaPagamentoPorDescricao(String Descricao)
        {
            try {
                return base._sessao.Query<FormaPagamento>().Where(f => (f.Descricao == Descricao)).FirstOrDefault();
            }
            catch (InvalidOperationException){
                return null;
            }
        }
    }
}
