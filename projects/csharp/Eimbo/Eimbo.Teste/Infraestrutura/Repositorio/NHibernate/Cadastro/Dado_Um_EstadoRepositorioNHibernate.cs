using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro;
using Eimbo.Teste.Infraestrutura.Repositorio.NHibernate;

namespace Eimbo.Teste.Infraestrutura.Repositorio.NHibernate.Cadastro
{
    [TestClass]
    public class Dado_Um_EstadoRepositorioNHibernate :RepositorioNHibernateTeste
    {
        [TestMethod]
        public void Devo_Conseguir_Persistir_Um_Estado_Novo()
        {
            Estado estadoNovo = new Estado("PR");
            EstadoRepositorioNHibernate repositorio = new EstadoRepositorioNHibernate(GetSessao());
            repositorio.Salvar(estadoNovo);
        }
    }
}
