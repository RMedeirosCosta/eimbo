using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;using System.Globalization;

using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Controlador.ModuloCaixa;
using Eimbo.Aplicativo.Visao.ModuloCaixa;
using Eimbo.IU.Telas.Comum;

namespace Eimbo.IU.Telas.ModuloCaixa
{
    public partial class TelaExtratoDoCaixa : TelaPadrao, IVisaoExtratoDoCaixa
    {
        private ControladorExtratoDoCaixa _controlador;

        public TelaExtratoDoCaixa()
        {
            InitializeComponent();

            this.dgvExtratoDoCaixa.Rows.Clear();
            this._controlador = new ControladorExtratoDoCaixa(this);
        }

        #region Acoes
        public void AdicionarLancamento(DateTime DataHora, String Descricao, Decimal ValorDinheiro, Decimal ValorCartaoCredito, Decimal ValorCartaoDebito)
        {
            this.dgvExtratoDoCaixa.Rows.Add(DataHora, Descricao, ValorDinheiro, ValorCartaoCredito, ValorCartaoDebito);
        }
        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }
        #endregion

        #region Sets
        public void SetDataAbertura(DateTime DataAbertura)
        {
            this.lblDataAbertura.Text = "Aberto em: " + String.Format("{0:dd/MM/yyyy - HH:mm:ss}", DataAbertura);
        }

        public void SetTotalDinheiro(Decimal TotalDinheiro)
        {
            this.lblTotalDinheiro.Text = TotalDinheiro.ToString("N2");
        }

        public void SetTotalCartaoCredito(Decimal TotalCartaoCredito)
        {
            this.lblTotalCartaoCredito.Text = TotalCartaoCredito.ToString("N2");
        }

        public void SetTotalCartaoDebito(Decimal TotalCartaoDebito)
        {
            this.lblTotalCartaoDebito.Text = TotalCartaoDebito.ToString("N2");
        }
        #endregion

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this._controlador.VoltarParaTelaAnterior();
        }

    }
}
