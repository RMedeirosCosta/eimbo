using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Controlador.ModuloCaixa;
using Eimbo.Aplicativo.Visao.ModuloCaixa;
using Eimbo.IU.Telas.Comum;

namespace Eimbo.IU.Telas.ModuloCaixa
{
    public partial class TelaSaldoDetalhadoDoCaixa : TelaPadrao, IVisaoSaldoDoCaixaDetalhado
    {
        private ControladorSaldoDoCaixaDetalhado _controlador;

        public TelaSaldoDetalhadoDoCaixa()
        {
            InitializeComponent();

            this._controlador = new ControladorSaldoDoCaixaDetalhado(this);
        }

        #region Acoes
        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }
        #endregion

        #region Comportamentos da Tela

        #region Dinheiro
        public void OcultarDinheiro()
        {
            this.pnlDinheiro.Visible = false;
        }

        public void OcultarSaldoAbertura()
        {
            this.pnlSaldoAbertura.Visible = false;
        }

        public void OcultarTotalAtendimentosDinheiro()
        {
            this.pnlTotalAtendimentosDinheiro.Visible = false;
        }

        public void OcultarTotalReforcos()
        {
            this.pnlReforcos.Visible = false;
        }

        public void OcultarTotalSangrias()
        {
            this.pnlSangrias.Visible = false;
        }

        public void OcultarTotalTrocos()
        {
            this.pnlTrocos.Visible = false;
        }
        #endregion 

        #region Cartão de Crédito
        public void OcultarCartaoCredito()
        {
            this.pnlCartaoCredito.Visible = false;
        }
        #endregion

        #region Cartão de Débito
        public void OcultarCartaoDebito()
        {
            this.pnlCartaoDebito.Visible = false;
        }
        #endregion

        #endregion

        #region Sets

        public void SetDataAbertura(DateTime DataAbertura)
        {
            this.lblDataAbertura.Text = "Aberto em: " + String.Format("{0:dd/MM/yyyy - HH:mm:ss}", DataAbertura);
        }

        #region Dinheiro
        public void SetSaldoDinheiro(Decimal SaldoDinheiro)
        {
            this.lblValorSaldoDinheiro.Text = SaldoDinheiro.ToString("N2");
        }

        public void SetSaldoAbertura(Decimal SaldoAbertura)
        {
            this.lblValorSaldoAbertura.Text = SaldoAbertura.ToString("N2");
        }

        public void SetTotalAtendimentosDinheiro(Decimal TotalAtendimentos)
        {
            this.lblValorTotalAtendimentosDinheiro.Text = TotalAtendimentos.ToString("N2");
        }

        public void SetTotalReforcos(Decimal TotalReforcos)
        {
            this.lblValorTotalReforcos.Text = TotalReforcos.ToString("N2");
        }

        public void SetTotalSangrias(Decimal TotalSangrias)
        {
            this.lblValorTotalSangrias.Text = TotalSangrias.ToString("N2");
        }

        public void SetTotalTrocos(Decimal TotalTrocos)
        {
            this.lblValorTotalTrocos.Text = TotalTrocos.ToString("N2");
        }
        #endregion

        #region Cartão de Crédito
        public void SetSaldoCartaoCredito(Decimal SaldoCartaoCredito)
        {
            this.lblValorSaldoCartaoCredito.Text = SaldoCartaoCredito.ToString("N2");
        }

        public void SetTotalAtendimentosCartaoCredito(Decimal TotalAtendimentosCartaoCredito)
        {
            this.lblValorTotalAtendimentosCartaoCredito.Text = TotalAtendimentosCartaoCredito.ToString("N2");
        }

        #endregion

        #region Cartão de Débito
        public void SetSaldoCartaoDebito(Decimal SaldoCartaoDebito)
        {
            this.lblValorSaldoCartaoDebito.Text = SaldoCartaoDebito.ToString("N2");
        }

        public void SetTotalAtendimentosCartaoDebito(Decimal TotalAtendimentosCartaoDebito)
        {
            this.lblValorTotalAtendimentosCartaoDebito.Text = TotalAtendimentosCartaoDebito.ToString("N2");
        }
        #endregion

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this._controlador.VoltarParaTelaAnterior();
        }

        #endregion
    }
}
