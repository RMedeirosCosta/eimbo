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
    public partial class TelaNovoCaixa : TelaPadrao, IVisaoNovoCaixa
    {
        private ControladorNovoCaixa _controlador;

        public TelaNovoCaixa()
        {
            InitializeComponent();
            this._controlador = new ControladorNovoCaixa(this);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this._controlador.VoltaParaTelaAnterior();
        }

        private void btnAbrirNovoCaixa_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirNovoCaixa();
        }

        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }

        public Decimal GetSaldoAbertura()
        {
            return (Decimal)this.edtSaldoAbertura.Value;
        }

        public void FecharAposAbrirCaixa()
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
