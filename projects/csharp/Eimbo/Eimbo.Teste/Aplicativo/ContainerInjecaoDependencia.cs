using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using StructureMap;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.Fachada.Cadastro;
using Eimbo.Dominio.Cadastro.Repositorio;

using Eimbo.Infraestrutura.Repositorio.NHibernate;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro;

namespace Eimbo.Aplicativo
{
    public class ContainerInjecaoDependencia
    {
        public static ISession GetSessao()
        {
            NHibernateHelper _helper = new NHibernateHelper();
            int porta;
            int.TryParse(Teste.Properties.Resources.porta, out porta);

            return _helper.GetSession(
                                      Teste.Properties.Resources.host,                                       //Nome do host
                                      porta,                                                                      //Porta
                                      Teste.Properties.Resources.database,                                   //Nome do Banco de Dados
                                      Teste.Properties.Resources.username,                                   //Usuário do banco de dados
                                      Teste.Properties.Resources.password,                                   //Senha do banco de dados
                                      Teste.Properties.Resources.cria_script.ToLower().Equals("s"),          //Para saber se o hibernate deve criar os scripts sql
                                      Teste.Properties.Resources.exporta_script_db.ToLower().Equals("s"));   //para saber se o hibernate deve exportar esse script para o banco de dados
        }

        public static void Inicializar()
        {
            ObjectFactory.Initialize(e =>
            {
                e.For<ISession>().Use(GetSessao());

                // Fachadas
                e.For<IEstadoRepositorio>().Use<EstadoRepositorioNHibernate>();
                e.For<ICidadeRepositorio>().Use<CidadeRepositorioNHibernate>();
                e.For<IPessoaRepositorio>().Use<PessoaRepositorioNHibernate>();
                e.For<IServicoRepositorio>().Use<ServicoRepositorioNHibernate>();
                e.For<IFormaPagamentoRepositorio>().Use<FormaPagamentoRepositorioNHibernate>();

                // Repositórios
                e.For<IFachadaEstado>().Use<FachadaEstado>();
                e.For<IFachadaCidade>().Use<FachadaCidade>();
                e.For<IFachadaPessoa>().Use<FachadaPessoa>();
                e.For<IFachadaEmpresa>().Use<FachadaEmpresa>();
                e.For<IFachadaCliente>().Use<FachadaCliente>();
                e.For<IFachadaServico>().Use<FachadaServico>();
                e.For<IFachadaFormaPagamento>().Use<FachadaFormaPagamento>();
                //e.For<IFachada>
            });
        }
    }
}
