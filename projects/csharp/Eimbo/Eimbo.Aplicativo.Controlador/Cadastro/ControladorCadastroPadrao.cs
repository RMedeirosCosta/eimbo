using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Controlador.Cadastro.Tipo;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Aplicativo.Controlador.Cadastro
{
    public abstract class ControladorCadastroPadrao<Visao, DTO> :ControladorPadrao<IVisaoCadastroPadrao>
    {
        private       TipoEstadoCadastro   _estadoAtual;
        new protected Visao                _visao;
            protected IVisaoCadastroPadrao _visaoCadastroPadrao { get { return base._visao; } }

        public TipoEstadoCadastro EstadoAtual
        {
            set
            {
                base._visao.MostrarBloqueado(false);

                switch (value)
                {
                    case TipoEstadoCadastro.Consulta: base._visao.AbrirAbaConsulta();
                        base._visao.MostrarAcoesConsulta(true);
                        base._visao.MostrarAcoesDados(true);                        
                        base._visao.LimparBusca();
                        this._visaoCadastroPadrao.MandarFocoNoGrid();

                        break;

                    case TipoEstadoCadastro.Visualizacao: if (this.EstadoAtual != TipoEstadoCadastro.Consulta)
                                                            return;

                        base._visao.AbrirAbaDados();
                        base._visao.LimparDados();
                        this.MostrarDados(this.GetDTOSelecionado());
                        base._visao.MostrarAcoesConsulta(false);
                        base._visao.MostrarAcoesDados(false);
                        base._visao.MostrarID(true);
                        //base._visao.MostrarBloqueado(false);
                        base._visao.HabilitarDados(false);                        
                        break;

                    case TipoEstadoCadastro.Inclusao: if (this.EstadoAtual != TipoEstadoCadastro.Consulta)
                                                        return;

                        base._visao.AbrirAbaDados();
                        base._visao.LimparDados();
                        base._visao.MostrarAcoesConsulta(false);
                        base._visao.MostrarAcoesDados(true);
                        base._visao.MostrarID(false);
                        //base._visao.MostrarBloqueado(false);
                        base._visao.HabilitarDados(true);
                        this.MandarFocoNoCampoPadrao();                        
                        break;

                    case TipoEstadoCadastro.Alteracao: if (this.EstadoAtual != TipoEstadoCadastro.Consulta)
                                                        return;

                        base._visao.AbrirAbaDados();
                        base._visao.LimparDados();
                        this.MostrarDados(this.GetDTOSelecionado());
                        base._visao.MostrarAcoesConsulta(false);
                        base._visao.MostrarAcoesDados(true);
                        base._visao.MostrarID(true);
                        //base._visao.MostrarBloqueado(false);
                        base._visao.HabilitarDados(true);
                        this.MandarFocoNoCampoPadrao();                        
                        break;

                    case TipoEstadoCadastro.Pesquisa:
                        this._estadoAtual = value;
                        this.CarregarTodosRegistros();
                        base._visao.AbrirAbaConsulta();
                        base._visao.MostrarAcoesConsulta(false);
                        base._visao.MostrarAcoesDados(false);                        
                        base._visao.LimparBusca();
                        this._visaoCadastroPadrao.MandarFocoNoCampoDeBusca();

                        break;

                    default: break;
                }

                this._estadoAtual = value;
            }

            get{ return this._estadoAtual; }   
        }


        public ControladorCadastroPadrao(IVisaoCadastroPadrao visao) : base(visao)
        {
            this._visao = (Visao)visao;
            this.InicializarFachada();
            this.EstadoAtual  = TipoEstadoCadastro.Consulta;
            this.CarregarTodosRegistros();
        }

        #region Métodos que serão implementados nas subclasses

        protected abstract void AdicionarRegistro(DTO dto);
        protected abstract void AlterarRegistro(DTO dto);
        protected abstract Boolean AlterarStatus(DTO dtoSelecionado);
        protected abstract IEnumerable<DTO> Buscar(String palavraChave);
        protected abstract void MandarFocoNoCampoPadrao();
        protected abstract void MostrarDados          (DTO dtoSelecionado);
        protected abstract void CarregarConsulta      (IEnumerable<DTO> conjuntoDados);        
        protected abstract DTO GetDTOQueVaiSerPersistido();
        protected abstract DTO GetDTOSelecionado();
        protected abstract Boolean Gravar(DTO dtoQueVaiSerPersistido);
        protected abstract void InicializarFachada();
        protected abstract IEnumerable<DTO> Ordenar(IEnumerable<DTO> conjuntoDados);

        #endregion

        protected void VoltaParaTelaAnterior()
        {
            this._visaoCadastroPadrao.VoltarParaTelaAnterior();
        }


        public void MudarEstadoAtualParaConsulta()
        {
            this.EstadoAtual = TipoEstadoCadastro.Consulta;
        }

        public void MudarEstadoAtualParaVisualizacao()
        {
            this.EstadoAtual = TipoEstadoCadastro.Visualizacao;
        }

        public void MudarEstadoAtualParaInclusao()
        {
            this.EstadoAtual = TipoEstadoCadastro.Inclusao;
        }

        public void MudarEstadoAtualParaAlteracao()
        {
            this.EstadoAtual = TipoEstadoCadastro.Alteracao;
        }

        public void MudarEstadoAtualParaPesquisa()
        {
            this.EstadoAtual = TipoEstadoCadastro.Pesquisa;
        }

        public void ExecutarAlteracaoStatus()
        {
            if ((this.EstadoAtual != TipoEstadoCadastro.Consulta) || (!base._visaoPadrao.PedirConfirmacao("Deseja bloquear/desbloquear registro?")))
                return;

            if (this.AlterarStatus(this.GetDTOSelecionado()))
            {
                // Retirado por questão de usabilidade
                //base._visaoPadrao.Avisar("Bloqueio/Desbloqueio realizado com sucesso!");
                DTO dto = this.GetDTOSelecionado();
                this.AlterarRegistro(dto);
            }

        }

        public void MandaFocoNoCampoDeBusca()
        {
            this._visaoCadastroPadrao.MandarFocoNoCampoDeBusca();
        }

        public void ExecutaPersistencia()
        {
            if (((this.EstadoAtual == TipoEstadoCadastro.Consulta) || (this.EstadoAtual == TipoEstadoCadastro.Visualizacao)) || (!base._visaoPadrao.PedirConfirmacao("Confirma a operação?")))
                return;

            DTO dto = this.GetDTOQueVaiSerPersistido();

            if (!this.Gravar(dto))
                return;

            base._visaoPadrao.Avisar("Dados salvos com sucesso!");

            if (this.EstadoAtual.Equals(TipoEstadoCadastro.Inclusao)) this.AdicionarRegistro(dto);
            else                                                      this.AlterarRegistro(dto);

            this.EstadoAtual = TipoEstadoCadastro.Consulta;            
        }

        public void ExecutarBusca(String palavraChave)
        {
            IEnumerable<DTO> conjuntoDados = this.Buscar(palavraChave);

            try
            {
                // Em caso de pesquisa, não se pode mostrar os bloqueados.
                if (this.EstadoAtual.Equals(TipoEstadoCadastro.Pesquisa))
                    conjuntoDados = conjuntoDados.Cast<DTOBloqueavel>().Where(dto => (dto.Status.Equals(TipoStatus.Normal))).Cast<DTO>();

                conjuntoDados = this.Ordenar(conjuntoDados);
            }
            catch (ArgumentNullException)
            {
                // Se for nulo apenas não deixo dar a mensagem. Pois o CarregarConsulta(IEnumerable<DTO>) já trata
                // se for nulo.
            }            

            this.CarregarConsulta(conjuntoDados);
        }

        public void CarregarTodosRegistros()
        {
            this.ExecutarBusca(String.Empty);
        }
    }
}
