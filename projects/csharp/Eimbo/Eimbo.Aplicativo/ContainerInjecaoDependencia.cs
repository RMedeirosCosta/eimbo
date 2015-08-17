using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Eimbo
#region Domínio
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.Contrato.ModuloAtendimento;

using Eimbo.Dominio.Fachada.Cadastro;
using Eimbo.Dominio.Fachada.ModuloCaixa;
using Eimbo.Dominio.Fachada.ModuloAtendimento;
using Eimbo.Dominio.ModuloCaixa.Repositorio;
using Eimbo.Dominio.ModuloAtendimento.Repositorio;
#endregion

#region Infraestrutura
using Eimbo.Infraestrutura.Repositorio.NHibernate;
using Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro;
using Eimbo.Infraestrutura.Repositorio.NHibernate.ModuloCaixa;
using Eimbo.Infraestrutura.Repositorio.NHibernate.ModuloAtendimento;
#endregion
#endregion

using NHibernate;
using StructureMap;

namespace Eimbo.Aplicativo
{
    public class ContainerInjecaoDependencia
    {
        public static ISession GetSessao()
        {
            NHibernateHelper _helper = new NHibernateHelper();
            int porta;
            int.TryParse(Aplicativo.Properties.Resources.porta, out porta);

            return _helper.GetSession(
                                      Aplicativo.Properties.Resources.host,                                       //Nome do host
                                      porta,                                                                      //Porta
                                      Aplicativo.Properties.Resources.database,                                   //Nome do Banco de Dados
                                      Aplicativo.Properties.Resources.username,                                   //Usuário do banco de dados
                                      Aplicativo.Properties.Resources.password,                                   //Senha do banco de dados
                                      Aplicativo.Properties.Resources.cria_script.ToLower().Equals("s"),          //Para saber se o hibernate deve criar os scripts sql
                                      Aplicativo.Properties.Resources.exporta_script_db.ToLower().Equals("s"));   //para saber se o hibernate deve exportar esse script para o banco de dados
        }

        public static void Inicializar()
        {
            ObjectFactory.Initialize(e =>
            {
                e.For<ISession>().Use(GetSessao());

                #region Repositórios
                e.For<IEstadoRepositorio>().Use<EstadoRepositorioNHibernate>();
                e.For<ICidadeRepositorio>().Use<CidadeRepositorioNHibernate>();
                e.For<IPessoaRepositorio>().Use<PessoaRepositorioNHibernate>();
                e.For<IServicoRepositorio>().Use<ServicoRepositorioNHibernate>();
                e.For<IFormaPagamentoRepositorio>().Use<FormaPagamentoRepositorioNHibernate>();
                e.For<ICaixaRepositorio>().Use<CaixaRepositorioNHibernate>();
                e.For<IAtendimentoRepositorio>().Use<AtendimentoRepositorioNHibernate>();
                #endregion

                #region Fachadas
                e.For<IFachadaEstado>().Use<FachadaEstado>();
                e.For<IFachadaCidade>().Use<FachadaCidade>();
                e.For<IFachadaPessoa>().Use<FachadaPessoa>();
                e.For<IFachadaEmpresa>().Use<FachadaEmpresa>();
                e.For<IFachadaCliente>().Use<FachadaCliente>();
                e.For<IFachadaServico>().Use<FachadaServico>();
                e.For<IFachadaFormaPagamento>().Use<FachadaFormaPagamento>();
                e.For<IFachadaCaixa>().Use<FachadaCaixa>();
                e.For<IFachadaAtendimento>().Use<FachadaAtendimento>();
                #endregion
            });
        }
    }
}
