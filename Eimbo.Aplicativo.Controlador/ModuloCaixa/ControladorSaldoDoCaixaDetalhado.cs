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
    public class ControladorSaldoDoCaixaDetalhado :ControladorPadrao<IVisaoSaldoDoCaixaDetalhado>
    {
        private IFachadaCaixa _fachada;

        public ControladorSaldoDoCaixaDetalhado(IVisaoSaldoDoCaixaDetalhado visao)
            : base(visao)
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCaixa>();

            try
            {
                DTOCaixa dto = this._fachada.ObterCaixaAtual();

                this._visao.SetDataAbertura(dto.DataAbertura);

                // Dinheiro
                if (dto.SaldoDinheiro > 0)
                {
                    // Saldo de abertura
                    if (dto.SaldoAbertura > 0)
                        this._visao.SetSaldoAbertura(dto.SaldoAbertura);                    
                    else
                        this._visao.OcultarSaldoAbertura();

                    // Total de Atendimentos
                    if (dto.TotalAtendimentosDinheiro > 0)
                        this._visao.SetTotalAtendimentosDinheiro(dto.TotalAtendimentosDinheiro);
                    else
                        this._visao.OcultarTotalAtendimentosDinheiro();

                    // Reforços
                    if (dto.TotalReforcos > 0)
                        this._visao.SetTotalReforcos(dto.TotalReforcos);
                    else
                        this._visao.OcultarTotalReforcos();

                    // Sangrias
                    if (dto.TotalSangrias > 0)
                        this._visao.SetTotalSangrias(dto.TotalSangrias);
                    else
                        this._visao.OcultarTotalSangrias();

                    // Trocos
                    if (dto.TotalTrocos > 0)
                        this._visao.SetTotalTrocos(dto.TotalTrocos);
                    else
                        this._visao.OcultarTotalTrocos();

                    // Saldo
                    this._visao.SetSaldoDinheiro(dto.SaldoDinheiro);
                }
                else
                    this._visao.OcultarDinheiro();

                // Cartão de Crédito
                if (dto.SaldoCartaoCredito > 0)
                {
                    this._visao.SetTotalAtendimentosCartaoCredito(dto.SaldoCartaoCredito);
                    this._visao.SetSaldoCartaoCredito(dto.SaldoCartaoCredito);
                }
                else
                    this._visao.OcultarCartaoCredito();

                // Cartão de Débito
                if (dto.SaldoCartaoDebito > 0)
                {
                    this._visao.SetTotalAtendimentosCartaoDebito(dto.SaldoCartaoDebito);
                    this._visao.SetSaldoCartaoDebito(dto.SaldoCartaoDebito);
                }
                else
                    this._visao.OcultarCartaoDebito();
            }
            catch(ExcecaoNenhumCaixaAberto ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                this._visao.VoltarParaTelaAnterior();
            }

        }

        public void VoltarParaTelaAnterior()
        {
            this._visao.VoltarParaTelaAnterior();
        }
    }
}
