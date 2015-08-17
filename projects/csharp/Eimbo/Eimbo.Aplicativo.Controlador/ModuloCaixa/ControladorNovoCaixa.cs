using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Visao.Comum;
using Eimbo.Aplicativo.Visao.ModuloCaixa;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.ModuloCaixa.Excecao;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.ModuloCaixa
{
    public class ControladorNovoCaixa :ControladorPadrao<IVisaoNovoCaixa> 
    {
        private IFachadaCaixa _fachada;

        public ControladorNovoCaixa(IVisaoNovoCaixa visao) :base(visao)
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCaixa>();
        }

        public void VoltaParaTelaAnterior()
        {
            this._visao.VoltarParaTelaAnterior();
        }

        public void AbrirNovoCaixa()
        {
            try
            {
                if (this._fachada.AbrirNovoCaixa(this._visao.GetSaldoAbertura()))
                    this._visao.FecharAposAbrirCaixa();
            }
            catch (Exception ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
                
        }
    }
}
