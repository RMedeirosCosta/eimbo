using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Visao.ModuloCaixa;
using Eimbo.Aplicativo.Controlador.ModuloCaixa;
using Eimbo.Aplicativo.Controlador.ModuloCaixa.Tipo;
using Eimbo.IU.Telas.Comum;

namespace Eimbo.IU.Telas.ModuloCaixa
{
    public partial class TelaMovimentacaoCaixa : TelaPadrao, IVisaoMovimentacaoCaixa
    {
        private ControladorMovimentacaoCaixa _controlador;

        public TelaMovimentacaoCaixa(TipoEstadoTelaMovimentacao Estado)
        {
            InitializeComponent();
            this._controlador = new ControladorMovimentacaoCaixa(this, Estado);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this._controlador.VoltarParaTelaAnterior();
        }

        private void btnEfetuarMovimentacao_Click(object sender, EventArgs e)
        {
            this._controlador.EfetuarOperacao();
        }

        public void AlterarNomeMovimentacao(String NomeMovimentacao)
        {
            this.lblNomeDaMovimentacao.Text = NomeMovimentacao;
        }

        public void AlterarTituloTela(String Titulo)
        {
            this.Text = Titulo;
        }

        public Decimal GetValorMovimentacao()
        {
            return this.edtValorMovimentacao.Value;
        }

        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }
    }
}
