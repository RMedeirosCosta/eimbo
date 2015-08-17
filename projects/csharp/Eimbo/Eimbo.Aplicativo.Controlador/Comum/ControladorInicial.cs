using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Visao.Comum;
using Eimbo.Dominio.Contrato;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.DTO.ModuloCaixa;
using Eimbo.Dominio.ModuloCaixa.Excecao;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.Comum
{
    public class ControladorInicial :ControladorPadrao<IVisaoInicial>
    {
        private IFachadaCaixa _fachadaCaixa;

        public ControladorInicial(IVisaoInicial visao) :base(visao) 
        {
            // Iniciando o container de injeção de dependências
            ContainerInjecaoDependencia.Inicializar();

            this._fachadaCaixa = ObjectFactory.GetInstance<IFachadaCaixa>();

            try
            {
                this.AlterarSituacaoCaixa(this._fachadaCaixa.ObterCaixaAtual());
            }
            catch (ExcecaoNenhumCaixaAberto)
            {
                this.AlterarSituacaoCaixa(null);
            }
        }

        private void AlterarSituacaoCaixa(DTOCaixa dto)
        {
            try
            {
                if (dto.EstaAberto)
                {
                    this._visao.AlterarSituacaoCaixa(true);
                    this._visao.ExibirAvisoDataCaixaDifereDataAtual(!this._fachadaCaixa.VerificaDataAberturaIgualDiaCorrente(dto));
                }
            }
            catch (NullReferenceException)
            {
                this._visao.AlterarSituacaoCaixa(false);
                this._visao.ExibirAvisoDataCaixaDifereDataAtual(false);
            }
        }

        public void AbrirCadastrosClientes()
        {
            base._visao.AbrirCadastroClientes();
        }

        public void AbrirCadastroCidades()
        {
            this._visao.AbrirCadastroCidades();
        }

        public void AbrirCadastroEmpresas()
        {
            this._visao.AbrirCadastroEmpresas();
        }

        public void AbrirCadastroEstados()
        {
            this._visao.AbrirCadastroEstados();
        }

        public void AbrirCadastroFormasPagamento()
        {
            this._visao.AbrirCadastroFormasPagamento();
        }

        public void AbrirCadastroServicos()
        {
            this._visao.AbrirCadastroServicos();
        }

        public void AbrirTelaNovoCaixa()
        {
            if (this._visao.AbriuNovoCaixa())
                this.AlterarSituacaoCaixa(this._fachadaCaixa.ObterCaixaAtual());
        }

        public void AbrirMovimentacaoSangria()
        {
            this._visao.AbrirMovimentacaoSangria();
        }

        public void AbrirMovimentacaoReforco()
        {
            this._visao.AbrirMovimentacaoReforco();
        }

        public void AbrirSaldoDoCaixa()
        {
            this._visao.AbrirSaldoDoCaixa();
        }

        public void AbrirSaldoDetalhadoDoCaixa()
        {
            this._visao.AbrirSaldoDetalhadoDoCaixa();
        }

        public void AbrirExtratoDoCaixa()
        {
            this._visao.AbrirExtratoDoCaixa();
        }

        public void AbrirNovoAtendimento()
        {
            this._visao.AbrirNovoAtendimento();
        }

        public Boolean CancelarEncerramento()
        {
            return (!base._visaoPadrao.PedirConfirmacao("Deseja fechar o Eimbo?"));
        }

        public void FecharAplicacao()
        {
            base._visao.FecharAplicacacao();
        }

        public void ReabrirUltimoCaixa()
        {
            try
            {
                if (this._fachadaCaixa.ReabrirUltimoCaixa())
                    this.AlterarSituacaoCaixa(this._fachadaCaixa.ObterCaixaAtual());
            }
            catch (ExcecaoNenhumCaixaAnterior ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
        }

        public void FecharCaixa()
        {
            try
            {
                if (this._fachadaCaixa.FecharCaixaAtual())
                    this.AlterarSituacaoCaixa(null);
            }
            catch(ExcecaoNenhumCaixaAberto ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }              
        }
    }
}
