using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Controlador.ModuloCaixa.Tipo;
using Eimbo.Aplicativo.Visao.Comum;
using Eimbo.Aplicativo.Visao.ModuloCaixa;
using Eimbo.Dominio.Contrato.ModuloCaixa;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.ModuloCaixa
{
    public class ControladorMovimentacaoCaixa :ControladorPadrao<IVisaoMovimentacaoCaixa>
    {
        private delegate void EfetuarMovimentacao(IFachadaCaixa fachada);
        private          IFachadaCaixa       _fachada;
        private          EfetuarMovimentacao _efetuarMovimentacao;

        public ControladorMovimentacaoCaixa(IVisaoMovimentacaoCaixa visao, TipoEstadoTelaMovimentacao estado)
            : base(visao)
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCaixa>();

            if (estado.Equals(TipoEstadoTelaMovimentacao.Sangria))
            {
                this._visao.AlterarTituloTela("Sangria");
                this._visao.AlterarNomeMovimentacao("Valor da Sangria: ");
                this._efetuarMovimentacao = (f => f.EfetuarSangria(this._visao.GetValorMovimentacao()));
            }
            else
            {
                this._visao.AlterarTituloTela("Reforço");
                this._visao.AlterarNomeMovimentacao("Valor do Reforço: ");
                this._efetuarMovimentacao = (f => f.EfetuarReforco(this._visao.GetValorMovimentacao()));
            }
        }

        public void VoltarParaTelaAnterior()
        {
            this._visao.VoltarParaTelaAnterior();
        }

        public void EfetuarOperacao()
        {
            try
            {
                this._efetuarMovimentacao(this._fachada);
                this._visaoPadrao.Avisar("Operação realizada com sucesso!");
                this._visao.VoltarParaTelaAnterior();
            }
            catch (Exception ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
        }
    }
}
