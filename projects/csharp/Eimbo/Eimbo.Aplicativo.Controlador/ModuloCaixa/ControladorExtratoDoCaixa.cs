using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Visao.ModuloCaixa;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.DTO.ModuloCaixa;
using Eimbo.Dominio.ModuloCaixa.Excecao;
using Eimbo.Dominio.ModuloCaixa.Tipo;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.ModuloCaixa
{
    public class ControladorExtratoDoCaixa :ControladorPadrao<IVisaoExtratoDoCaixa>
    {
        private IFachadaCaixa _fachada;

        public ControladorExtratoDoCaixa(IVisaoExtratoDoCaixa visao)
            : base(visao)
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCaixa>();

            try
            {
                DTOCaixa dto = this._fachada.ObterCaixaAtual();

                this._visao.SetDataAbertura(dto.DataAbertura);
                this._visao.SetTotalDinheiro(dto.SaldoDinheiro);
                this._visao.SetTotalCartaoCredito(dto.SaldoCartaoCredito);
                this._visao.SetTotalCartaoDebito(dto.SaldoCartaoDebito);
            }
            catch (ExcecaoNenhumCaixaAberto ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                this._visao.VoltarParaTelaAnterior();
            }

            IEnumerable<DTOLancamentoCaixa> extrato = this._fachada.ObterExtrato();

            foreach (DTOLancamentoCaixa l in extrato)
            {
                switch (l.TipoPagamento)
                {
                    case TipoPagamentoLancamentoCaixa.Dinheiro:      this._visao.AdicionarLancamento(l.DataHora, l.Descricao, l.Valor, 0, 0);
                        break;
                    case TipoPagamentoLancamentoCaixa.CartaoCredito: this._visao.AdicionarLancamento(l.DataHora, l.Descricao, 0, l.Valor, 0);
                        break;
                    case TipoPagamentoLancamentoCaixa.CartaoDebito:  this._visao.AdicionarLancamento(l.DataHora, l.Descricao, 0, 0, l.Valor);
                        break;
                }
            }
        }

        public void VoltarParaTelaAnterior()
        {
            this._visao.VoltarParaTelaAnterior();
        }
    }
}
