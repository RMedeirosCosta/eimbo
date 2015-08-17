using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Comum;

using NHibernate;
using NHibernate.Linq;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro
{
    public class PessoaRepositorioNHibernate :RepositorioNHibernate<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorioNHibernate(ISession _sessao) : base(_sessao) { }

        public Pessoa ObterPorDocumento(Documento documento)
        {
            try
            {
                // MUDAR_AQUI_2
                return base._sessao.Query<Pessoa>().SingleOrDefault(p => (p.Documentos.Where(d => (d.ValorDocumento == documento.ValorDocumento))
                                                                                      .Count().Equals(1)));                
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
