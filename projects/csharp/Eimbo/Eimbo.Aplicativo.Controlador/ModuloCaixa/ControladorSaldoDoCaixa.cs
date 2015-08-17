using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Visao.ModuloCaixa;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.DTO.ModuloCaixa;
using Eimbo.Dominio.ModuloCaixa.Excecao;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.ModuloCaixa
{
    public class ControladorSaldoDoCaixa :ControladorPadrao<IVisaoSaldoDoCaixa>
    {
        private IFachadaCaixa _fachada;

        public ControladorSaldoDoCaixa(IVisaoSaldoDoCaixa visao) : base(visao) 
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCaixa>();

            DTOCaixa dto = null;

            try
            {
                dto = this._fachada.ObterCaixaAtual();
            }
            catch (ExcecaoNenhumCaixaAberto ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                this._visao.VoltarParaTelaAnterior();
            }

            this._visao.SetDataAbertura(dto.DataAbertura);

            if (dto.SaldoDinheiro > 0)
            {
                this._visao.MostrarSaldoDinheiro(true);
                this._visao.SetSaldoDinheiro(dto.SaldoDinheiro);
            }
            else
                this._visao.MostrarSaldoDinheiro(false);

            if (dto.SaldoCartaoCredito > 0)
            {
                this._visao.MostrarSaldoCartaoCredito(true);
                this._visao.SetSaldoCartaoCredito(dto.SaldoCartaoCredito);
            }
            else
                this._visao.MostrarSaldoCartaoCredito(false);


            if (dto.SaldoCartaoDebito > 0)
            {
                this._visao.MostrarSaldoCartaoDebito(true);
                this._visao.SetSaldoCartaoDebito(dto.SaldoCartaoDebito);
            }
            else
                this._visao.MostrarSaldoCartaoDebito(false);

        }

        public void VoltarParaTelaAnterior()
        {
            this._visao.VoltarParaTelaAnterior();
        }
    }
}
