using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Comum;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Util;
using System;
using System.Reflection;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory = null;
        private Boolean _criaScript;
        private Boolean _exportaScriptBD;

        public ISession GetSession(String host, int porta, String database, String username, String root, Boolean criaScript, Boolean exportaScriptDB)
        {
            this._criaScript = criaScript;
            this._exportaScriptBD = exportaScriptDB;
            configureSessionFactory(host, porta, database, username, root);
            return _sessionFactory.OpenSession();
        }

        private void configureSessionFactory(String host, int porta, String database, String username, String root)
        {
            if (_sessionFactory != null)
                return;

            var f = Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration
                             .Standard
                             .ConnectionString(c =>
                                                    c.Host(host)
                                                     .Port(porta)
                                                     .Database(database)
                                                     .Username(username)
                                                     .Password(root)))
                            .ExposeConfiguration(BuildSchema)

                    .Mappings(m =>
                                  m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(EstadoMap)))
                              ); //Add<EstadoMap>());
            

            var config = f.BuildConfiguration();

            try
            {
                _sessionFactory = f.BuildSessionFactory();
            }
            catch (FluentConfigurationException ex)
            {
                //Caso der algum erro, uso para verificar o que aconteceu.
                throw new Exception(ex.InnerException.Message);
            }
        }

        private void BuildSchema(Configuration config)
        {
            SchemaExport schema = new SchemaExport(config);
            schema.Drop(this._criaScript, this._exportaScriptBD);
            schema.Create(this._criaScript, this._exportaScriptBD);
            config.SetInterceptor(new SqlStatementInterceptor());
        }
    }
}
