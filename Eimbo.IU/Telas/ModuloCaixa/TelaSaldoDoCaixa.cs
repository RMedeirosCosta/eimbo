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
    public partial class TelaSaldoDoCaixa : TelaPadrao, IVisaoSaldoDoCaixa
    {
        private ControladorSaldoDoCaixa _controlador;

        public TelaSaldoDoCaixa()
        {
            InitializeComponent();

            this._controlador = new ControladorSaldoDoCaixa(this);
        }

        #region Ações
        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }
        #endregion

        #region Comportamentos da Tela
        public void MostrarSaldoDinheiro(Boolean Mostrar)
        {
            this.lblSaldoDinheiro.Visible = Mostrar;
            this.edtSaldoDinheiro.Visible = Mostrar;
        }

        public void MostrarSaldoCartaoCredito(Boolean Mostrar)
        {
            this.lblSaldoCartaoCredito.Visible = Mostrar;
            this.edtSaldoCartaoCredito.Visible = Mostrar;
        }

        public void MostrarSaldoCartaoDebito(Boolean Mostrar)
        {
            this.lblSaldoCartaoDebito.Visible = Mostrar;
            this.edtSaldoCartaoDebito.Visible = Mostrar;
        }
        #endregion

        #region Sets
        public void SetDataAbertura(DateTime DataAbertura)
        {
            this.lblDataAbertura.Text = "Aberto em: " + String.Format("{0:dd/MM/yyyy - HH:mm:ss}", DataAbertura);
        }
        public void SetSaldoDinheiro(Decimal SaldoDinheiro)
        {
            this.edtSaldoDinheiro.Text = SaldoDinheiro.ToString("N2");
        }

        public void SetSaldoCartaoCredito(Decimal SaldoCartaoCredito)
        {
            this.edtSaldoCartaoCredito.Text = SaldoCartaoCredito.ToString("N2");
        }

        public void SetSaldoCartaoDebito(Decimal SaldoCartaoDebito)
        {
            this.edtSaldoCartaoDebito.Text = SaldoCartaoDebito.ToString("N2");
        }
        #endregion

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this._controlador.VoltarParaTelaAnterior();
        }

    }
}
