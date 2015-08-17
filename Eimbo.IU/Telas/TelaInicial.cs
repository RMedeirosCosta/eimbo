using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.IU.Properties;
using Eimbo.IU.Telas.Comum;
using Eimbo.IU.Telas.Cadastro;
using Eimbo.IU.Telas.ModuloCaixa;
using Eimbo.IU.Telas.ModuloAtendimento;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Controlador.ModuloCaixa.Tipo;
using Eimbo.Aplicativo.Visao.Comum;

namespace IU.Telas
{
    public partial class TelaInicial : TelaPadrao, IVisaoInicial
    {
        private ControladorInicial _controlador;

        public TelaInicial()
        {
            InitializeComponent();

            this._controlador = new ControladorInicial(this);            

            String versao = "Versão " + Eimbo.Aplicativo.Properties.Resources.versao;

            this.Text           = "Eimbo - " + versao;
            this.lbVersao.Text  = versao;            
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this._controlador.FecharAplicacao();
        }

        public void FecharAplicacacao()
        {
            this.Close();
        }

        private void TelaInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this._controlador.CancelarEncerramento();
        }

        private void TelaInicial_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: this._controlador.AbrirCadastrosClientes(); break;
                case Keys.F2: this._controlador.AbrirCadastroServicos(); break;
                case Keys.F3: this._controlador.AbrirNovoAtendimento(); break;
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastrosClientes();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastrosClientes();
        }

        public void AbrirCadastroClientes()
        {
            TelaCadastroCliente tela = new TelaCadastroCliente();

            try {
                tela.ShowDialog();
            } finally {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirCadastroCidades()
        {
            TelaCadastroCidade tela = new TelaCadastroCidade();

            try {
                tela.ShowDialog();
            } finally {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirCadastroEmpresas()
        {
            TelaCadastroEmpresa tela = new TelaCadastroEmpresa();

            try {
                tela.ShowDialog();
            } finally {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirCadastroEstados()
        {
            TelaCadastroEstado tela = new TelaCadastroEstado();

            try {
                tela.ShowDialog();
            } finally {
                tela.Dispose();
                tela = null;
            }           
        }

        public void AbrirCadastroFormasPagamento()
        {
            TelaCadastroFormaPagamento tela = new TelaCadastroFormaPagamento();

            try {
                tela.ShowDialog();
            }
            finally {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirCadastroServicos()
        {
            TelaCadastroServico tela = new TelaCadastroServico();

            try
            {
                tela.ShowDialog();
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirSaldoDoCaixa()
        {
            TelaSaldoDoCaixa tela = new TelaSaldoDoCaixa();

            try
            {
                tela.ShowDialog();
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirSaldoDetalhadoDoCaixa()
        {
            TelaSaldoDetalhadoDoCaixa tela = new TelaSaldoDetalhadoDoCaixa();

            try
            {
                tela.ShowDialog();
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirExtratoDoCaixa()
        {
            TelaExtratoDoCaixa tela = new TelaExtratoDoCaixa();

            try
            {
                tela.ShowDialog();
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public Boolean AbriuNovoCaixa()
        {
            TelaNovoCaixa tela = new TelaNovoCaixa();

            try
            {
                tela.ShowDialog();

                return (tela.DialogResult.Equals(DialogResult.OK));
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirMovimentacaoSangria()
        {
            TelaMovimentacaoCaixa tela = new TelaMovimentacaoCaixa(TipoEstadoTelaMovimentacao.Sangria);

            try
            {
                tela.ShowDialog();
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirMovimentacaoReforco()
        {
            TelaMovimentacaoCaixa tela = new TelaMovimentacaoCaixa(TipoEstadoTelaMovimentacao.Reforco);

            try
            {
                tela.ShowDialog();
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public void AbrirNovoAtendimento()
        {
            TelaAtendimento tela = new TelaAtendimento();

            try
            {
                if (!tela.IsDisposed)
                    tela.ShowDialog();
            }
            finally
            {
                tela.Dispose();
                tela = null;
            }
        }

        public void ExibirAvisoDataCaixaDifereDataAtual(Boolean ExibirAviso)
        {
            this.ssDataAberturaCaixaDivergeDiaAtual.Visible = ExibirAviso;
        }

        public void AlterarSituacaoCaixa(Boolean Aberto)
        {
            this.abrirNovoCaixaToolStripMenuItem.Visible = (!Aberto);
            this.reabrirÚltimoCaixaToolStripMenuItem.Visible = (!Aberto);

            this.sangriaToolStripMenuItem.Visible = Aberto;
            this.reforçoToolStripMenuItem.Visible = Aberto;
            this.saldoDoCaixaToolStripMenuItem.Visible = Aberto;
            this.saldoDetalhadoToolStripMenuItem.Visible = Aberto;
            this.extratoDoCaixaToolStripMenuItem.Visible = Aberto;
            this.fecharCaixaToolStripMenuItem.Visible = Aberto;
            this.caixaSeparador1toolStripSeparator.Visible = false;
            this.caixaSeparador2toolStripSeparator.Visible = Aberto;
            this.caixaSeparador3toolStripSeparator.Visible = Aberto;
            this.mItAtendimentos.Enabled = Aberto;
            this.lbAtendimento.Enabled = Aberto;
            this.btnAtendimento.Enabled = Aberto;
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastroEstados();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastroCidades();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastroEmpresas();
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastroServicos();
        }

        private void servicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastroServicos();
        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirCadastroFormasPagamento();
        }

        private void reabrirÚltimoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.ReabrirUltimoCaixa();
        }

        private void abrirNovoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirTelaNovoCaixa();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.FecharCaixa();
        }

        private void sangriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirMovimentacaoSangria();
        }

        private void reforçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirMovimentacaoReforco();
        }

        private void saldoDoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirSaldoDoCaixa();
        }

        private void saldoDetalhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirSaldoDetalhadoDoCaixa();
        }

        private void extratoDoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirExtratoDoCaixa();
        }

        private void novoAtendimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirNovoAtendimento();
        }

        private void btnAtendimento_Click(object sender, EventArgs e)
        {
            this._controlador.AbrirNovoAtendimento();
        }
    }
}
