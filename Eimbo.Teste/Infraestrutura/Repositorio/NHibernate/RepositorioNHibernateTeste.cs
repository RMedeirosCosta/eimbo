using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;

using Eimbo.Infraestrutura.Repositorio.NHibernate;

namespace Eimbo.Teste.Infraestrutura.Repositorio.NHibernate
{
    [TestClass]
    public abstract class RepositorioNHibernateTeste
    {
        protected static ISession GetSessao()
        {
            NHibernateHelper _helper = new NHibernateHelper();
            int porta;
            int.TryParse(Properties.Resources.porta, out porta);

            return _helper.GetSession(
                                      Properties.Resources.host,                                       //Nome do host
                                      porta,                                                           //Porta
                                      Properties.Resources.database,                                   //Nome do Banco de Dados
                                      Properties.Resources.username,                                   //Usuário do banco de dados
                                      Properties.Resources.password,                                   //Senha do banco de dados
                                      Properties.Resources.cria_script.ToLower().Equals("s"),          //Para saber se o hibernate deve criar os scripts sql
                                      Properties.Resources.exporta_script_db.ToLower().Equals("s"));   //para saber se o hibernate deve exportar esse script para o banco de dados
        }
    }
}
