using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Visao.ModuloAtendimento;
using Eimbo.Aplicativo.Controlador.ModuloAtendimento;
using Eimbo.IU.Telas.Comum;

namespace Eimbo.IU.Telas.ModuloAtendimento
{
    public partial class TelaRecebimentoAtendimento : TelaPadrao, IVisaoRecebimentoAtendimento
    {
        private ControladorRecebimentoAtendimento _controlador;

        public TelaRecebimentoAtendimento(Decimal ValorAReceber)
        {
            InitializeComponent();

            this._controlador = new ControladorRecebimentoAtendimento(this, ValorAReceber);
        }

        #region IVisaoRecebimentoAtendimento
        #region Comportamento
        public void AlterarParaFaltam()
        {
            this.lblEstadoRecebimento.Text = "Faltam: ";
            this.lblEstadoRecebimento.ForeColor = Color.Red;
            this.lblResto.ForeColor = Color.Red;
        }

        public void AlterarParaTroco()
        {
            this.lblEstadoRecebimento.Text = "Troco: ";
            this.lblEstadoRecebimento.ForeColor = Color.DeepSkyBlue;
            this.lblResto.ForeColor = Color.DeepSkyBlue;
        }

        public void HabilitarBotoesRestante(Boolean habilitar)
        {
            this.btnRestoDinheiro.Enabled = habilitar;
            this.btnRestoCartaoCredito.Enabled = habilitar;
            this.btnRestoCartaoDebito.Enabled = habilitar;
        }

        public void HabilitarBotaoReceber(Boolean habilitar)
        {
            this.btnReceber.Enabled = habilitar;
        }

        #endregion

        #region Ações
        public void CancelarRecebimento()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void FinalizarRecebimento()
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region Get
        public Decimal GetValorReceber()
        {
            try
            {
                return Decimal.Parse(this.edtTotalReceber.Text);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Decimal GetValorDinheiro()
        {
            try
            {
                return Decimal.Parse(this.edtDinheiro.Text);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public Decimal GetValorCartaoCredito()
        {
            try
            {
                return Decimal.Parse(this.edtCartaoCredito.Text);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public Decimal GetValorCartaoDebito()
        {
            try
            {
                return Decimal.Parse(this.edtCartaoDebito.Text);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        #endregion

        #region Set

        public void SetValorAReceber(Decimal valorAReceber)
        {
            this.edtTotalReceber.Text = valorAReceber.ToString("N2");
        }

        public void SetValorDinheiro(Decimal valorDinheiro)
        {
            this.edtDinheiro.Text = valorDinheiro.ToString("N2");
        }

        public void SetValorCartaoCredito(Decimal valorCartaoCredito)
        {
            this.edtCartaoCredito.Text = valorCartaoCredito.ToString("N2");
        }

        public void SetValorCartaoDebito(Decimal valorCartaoDebito)
        {
            this.edtCartaoDebito.Text = valorCartaoDebito.ToString("N2");
        }

        public void SetValorSoma(Decimal valorSoma)
        {
            this.edtSoma.Text = valorSoma.ToString("N2");
        }

        public void SetValorTroco(Decimal valorTroco)
        {
            this.lblResto.Text = valorTroco.ToString("N2");
        }

        public void SetValorRestante(Decimal valorRestante)
        {
            this.lblResto.Text = valorRestante.ToString("N2");
        }
        #endregion

        #endregion

        private void btnCancelarRecebimento_Click(object sender, EventArgs e)
        {
            this._controlador.CancelarRecebimento();
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            this._controlador.Receber();
        }

        private void btnRestoDinheiro_Click(object sender, EventArgs e)
        {
            this._controlador.ReceberRestateEmDinheiro();
        }

        private void btnRestoCartaoCredito_Click(object sender, EventArgs e)
        {
            this._controlador.ReceberRestanteEmCartaoCredito();
        }

        private void btnRestoCartaoDebito_Click(object sender, EventArgs e)
        {
            this._controlador.ReceberRestanteEmCartaoDebito();
        }

        private void edtDinheiro_Leave(object sender, EventArgs e)
        {
            this._controlador.AlterarValor();
        }

        private void edtCartaoCredito_Leave(object sender, EventArgs e)
        {
            this._controlador.AlterarValor();
        }

        private void edtCartaoDebito_Leave(object sender, EventArgs e)
        {
            this._controlador.AlterarValor();
        }

    }
}
