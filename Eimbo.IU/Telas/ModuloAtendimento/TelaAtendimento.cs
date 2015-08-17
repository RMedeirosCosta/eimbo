using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Controlador.ModuloAtendimento;
using Eimbo.Aplicativo.Visao.ModuloAtendimento;

using Eimbo.IU.Telas.Comum;
using Eimbo.IU.Telas.Cadastro;

namespace Eimbo.IU.Telas.ModuloAtendimento
{
    public partial class TelaAtendimento : TelaPadrao, IVisaoAtendimento
    {
        private ControladorAtendimento _controlador;
        private TelaCadastroCliente _telaCliente;
        private TelaCadastroFormaPagamento _telaFormaPagamento;
        private TelaCadastroServico _telaServico;
        private TelaRecebimentoAtendimento _telaRecebimento;

        public TelaAtendimento()
        {
            InitializeComponent();

            this._telaCliente = new TelaCadastroCliente();
            this._telaFormaPagamento = new TelaCadastroFormaPagamento();
            this._telaServico = new TelaCadastroServico();
            this._telaRecebimento = null;

            this._telaCliente.EmBusca = true;
            this._telaFormaPagamento.EmBusca = true;
            this._telaServico.EmBusca = true;

            this._controlador = new ControladorAtendimento(this);
        }

        #region IVisaoAtendimento

        #region Ações
        public void AdicionarItem(long idServico, String descricaoServico, Decimal valorUnitario, int quantidade, Decimal valorItem)
        {
            this.dgvItens.Rows.Add(idServico, descricaoServico, valorUnitario, quantidade, valorItem);
        }

        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }

        public void LimparValores()
        {
            this.edtIdServico.Clear();
            this.edtDescricaoServico.Clear();
            this.edtValorUnitario.Clear();
            this.edtQuantidade.Value = 0m;
            this.dgvItens.Rows.Clear();
            this.lblTotalValorUnitario.Text = "0";
            this.lblTotalQuantidade.Text = "0";
            this.lblTotalValorItem.Text = "0";
            this.lblPercentualAcrescimoFormaPagamento.Text = "0%";
            this.lblPercentualDescontoFormaPagamento.Text = "0%";
            this.edtAcrescimoFormaPagamento.Clear();
            this.edtDescontoFormaPagamento.Clear();
            this.edtAcrescimo.Clear();
            this.edtDesconto.Clear();
            this.edtValorAtendimento.Clear();
            this.edtValorEntrada.Clear();
        }

        public void LimparIdServico()
        {
            this.edtIdServico.Clear();
        }

        public void LimparDescricaoServico()
        {
            this.edtDescricaoServico.Clear();
        }

        public void LimparValorUnitario()
        {
            this.edtValorUnitario.Clear();
        }

        public void LimparQuantidade()
        {
            this.edtQuantidade.Value = 0;                
        }

        public void LimparItens()
        {
            this.dgvItens.Rows.Clear();
        }

        public void LimparAtendimento()
        {
            this.edtIdCliente.Clear();
            this.edtNomeCliente.Clear();
            this.edtIdFormaPagamento.Clear();
            this.edtDescricaoFormaPagamento.Clear();
            this.edtData.Value = DateTime.Now;

            this.LimparValores();
        }

        public Boolean ReceberNoCaixa(Decimal ValorAReceber)
        {
            try
            {
                this._telaRecebimento = new TelaRecebimentoAtendimento(ValorAReceber);
                this._telaRecebimento.ShowDialog();

                return this._telaRecebimento.DialogResult.Equals(DialogResult.OK);
            }
            finally
            {
                this._telaRecebimento.Dispose();
                this._telaRecebimento = null;
            }
        }

        #endregion

        #region Busca
        public Boolean AchouCliente(out long idCliente)
        {
            this._telaCliente.ShowDialog();

            if (this._telaCliente.DialogResult == DialogResult.OK)
            {
                idCliente = this._telaCliente.GetIDSelecionado();
                return true;
            }

            idCliente = 0;
            return false;
        }

        public Boolean AchouFormaPagamento(out long idFormaPagamento)
        {
            this._telaFormaPagamento.ShowDialog();

            if (this._telaFormaPagamento.DialogResult == DialogResult.OK)
            {
                idFormaPagamento = this._telaFormaPagamento.GetIDSelecionado();
                return true;
            }

            idFormaPagamento = 0;
            return false;
        }

        public Boolean AchouServico(out long idServico)
        {
            this._telaServico.ShowDialog();

            if (this._telaServico.DialogResult == DialogResult.OK)
            {
                idServico = this._telaServico.GetIDSelecionado();
                return true;
            }

            idServico = 0;
            return false;
        }
        #endregion

        #region Comportamento
        public void HabilitarCabecalho(Boolean habilitar)
        {
            this.gbCabecalho.Enabled = habilitar;
        }

        public void MostrarBotaoVoltarParaCabecalho(Boolean mostrar)
        {
            this.btnVoltarParaCabecalho.Visible = mostrar;
        }

        public void HabilitarValores(Boolean habilitar)
        {
            this.pnlCorpo.Enabled = habilitar;
        }

        public void HabilitarBotaoConfirmarAtendimento(Boolean habilitar)
        {
            this.btnConfirmarAtendimento.Enabled = habilitar;
        }

        public void HabilitarEventosTotais(Boolean habilitar)
        {
            if (habilitar)
            {
                this.edtAcrescimo.Leave += new System.EventHandler(this.edtAcrescimo_Leave);
                this.edtDesconto.Leave += new System.EventHandler(this.edtDesconto_Leave);
            }
            else
            {
                this.edtAcrescimo.Leave -= new System.EventHandler(this.edtAcrescimo_Leave);
                this.edtDesconto.Leave -= new System.EventHandler(this.edtDesconto_Leave);
            }
        }
        #endregion

        #region Foco
        public void MandarFocoNoCliente()
        {
            this.edtIdCliente.Focus();
        }

        public void MandarFocoNaData()
        {
            this.edtData.Focus();
        }

        public void MandarFocoNaEmpresa()
        {
            this.edtIdEmpresa.Focus();
        }

        public void MandarFocoNaFormaPagamento()
        {
            this.edtIdFormaPagamento.Focus();
        }

        public void MandarFocoNoServico()
        {
            this.edtIdServico.Focus();
        }

        public void MandarFocoNoValorUnitario()
        {
            this.edtValorUnitario.Focus();
        }

        public void MandarFocoNaQuantidade()
        {
            this.edtQuantidade.Focus();
        }
        #endregion

        #region Set
        public void SetData(DateTime data)
        {
            this.edtData.Value = data;
        }

        public void SetIdEmpresa(long idEmpresa)
        {
            this.edtIdEmpresa.Text = idEmpresa.ToString();
        }

        public void SetIdCliente(long idCliente)
        {
            this.edtIdCliente.Text = idCliente.ToString();
        }

        public void SetIdFormaPagamento(long idFormaPagamento)
        {
            this.edtIdFormaPagamento.Text = idFormaPagamento.ToString();
        }

        public void SetIdServico(long idServico)
        {
            this.edtIdServico.Text = idServico.ToString();
        }

        public void SetRazaoSocialEmpresa(String razaoSocialEmpresa)
        {
            this.edtRazaoSocialEmpresa.Text = razaoSocialEmpresa;
        }

        public void SetNomeCliente(String nomeCliente)
        {
            this.edtNomeCliente.Text = nomeCliente;
        }

        public void SetDescricaoFormaPagamento(String descricaoFormaPagamento)
        {
            this.edtDescricaoFormaPagamento.Text = descricaoFormaPagamento;
        }

        public void SetDescricaoServico(String descricaoServico)
        {
            this.edtDescricaoServico.Text = descricaoServico;
        }

        public void SetTotalValorUnitario(Decimal totalValorUnitario)
        {
            this.lblTotalValorUnitario.Text = totalValorUnitario.ToString("N2");
        }

        public void SetTotalQuantidade(Decimal totalQuantidade)
        {
            this.lblTotalQuantidade.Text = totalQuantidade.ToString();
        }

        public void SetTotalValorItem(Decimal totalValorItem)
        {
            this.lblTotalValorItem.Text = totalValorItem.ToString("N2");
        }

        public void SetPercentualAcrescimo(Decimal percentualAcrescimo)
        {
            this.lblPercentualAcrescimoFormaPagamento.Text = percentualAcrescimo.ToString("N2") + "%";
        }

        public void SetAcrescimoFormaPagamento(Decimal acrescimoFormaPagamento)
        {
            this.edtAcrescimoFormaPagamento.Text = acrescimoFormaPagamento.ToString("N2");
        }

        public void SetAcrescimo(Decimal acrescimo)
        {
            this.edtAcrescimo.Text = acrescimo.ToString("N2");
        }

        public void SetPercentualDesconto(Decimal percentualDesconto)
        {
            this.lblPercentualDescontoFormaPagamento.Text = percentualDesconto.ToString("N2") + "%";
        }

        public void SetDescontoFormaPagamento(Decimal descontoFormaPagamento)
        {
            this.edtDescontoFormaPagamento.Text = descontoFormaPagamento.ToString("N2");
        }

        public void SetDesconto(Decimal desconto)
        {
            this.edtDesconto.Text = desconto.ToString("N2");
        }

        public void SetValorAtendimento(Decimal valorAtendimento)
        {
            this.edtValorAtendimento.Text = valorAtendimento.ToString("N2");
        }

        public void SetValorEntrada(Decimal valorEntrada)
        {
            this.edtValorEntrada.Text = valorEntrada.ToString("N2");
        }

        public void SetValorUnitario(Decimal valorUnitario)
        {
            this.edtValorUnitario.Text = valorUnitario.ToString("N2");
        }
        #endregion

        #region Get
        public DateTime GetData()
        {
            return this.edtData.Value;
        }

        public long GetIdEmpresa()
        {
            long id;

            long.TryParse(this.edtIdEmpresa.Text, out id);

            return id;
        }

        public long GetIdCliente()
        {
            long id;

            long.TryParse(this.edtIdCliente.Text, out id);

            return id;
        }

        public long GetIdFormaPagamento()
        {
            long id;

            long.TryParse(this.edtIdFormaPagamento.Text, out id);

            return id;
        }

        public long GetIdServico()
        {
            long id;

            long.TryParse(this.edtIdServico.Text, out id);

            return id;
        }

        public Decimal GetValorUnitario()
        {
            Decimal valorUnitario;

            Decimal.TryParse(this.edtValorUnitario.Text, out valorUnitario);

            return valorUnitario;
        }

        public int GetQuantidade()
        {
            return (int)this.edtQuantidade.Value;
        }

        public long GetIdServicoSelecionado()
        {
            try
            {
                return (long)this.dgvItens.CurrentRow.Cells[0].Value;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        public Decimal GetAcrescimo()
        {
            Decimal acrescimo;

            Decimal.TryParse(this.edtAcrescimo.Text, out acrescimo);

            return acrescimo;
        }

        public Decimal GetDesconto()
        {
            Decimal desconto;

            Decimal.TryParse(this.edtDesconto.Text, out desconto);

            return desconto;
        }

        #endregion

        #endregion

        #region Eventos

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            this._controlador.BuscarCliente(0);
        }

        private void edtDescricaoFormaPagamento_Enter(object sender, EventArgs e)
        {
            this._controlador.BuscarFormaPagamento(this.GetIdFormaPagamento());
        }

        private void btnBuscaFormaPagamento_Click(object sender, EventArgs e)
        {
            this._controlador.BuscarFormaPagamento(0);
        }

        private void pnlCorpo_Enter(object sender, EventArgs e)
        {
            this._controlador.CriarAtendimento();
        }

        private void btnVoltarParaCabecalho_Click(object sender, EventArgs e)
        {
            this._controlador.VoltarParaCabecalho();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this._controlador.VoltarParaTelaAnterior();
        }

        private void btnBuscarServico_Click(object sender, EventArgs e)
        {
            this._controlador.BuscarServico(0);
        }

        private void edtDescricaoServico_Enter(object sender, EventArgs e)
        {
            this._controlador.BuscarServico(this.GetIdServico());
        }

        private void tsmiRemover_Click(object sender, EventArgs e)
        {
            this._controlador.RemoverItem();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            this._controlador.AdicionarItem();
        }

        private void btnConfirmarAtendimento_Click(object sender, EventArgs e)
        {
            this._controlador.ConfirmarAtendimento();
        }

        private void edtNomeCliente_Enter(object sender, EventArgs e)
        {
            this._controlador.BuscarCliente(this.GetIdCliente());
        }

        #endregion

        private void edtDesconto_Leave(object sender, EventArgs e)
        {
            this._controlador.AdicionarDesconto();
        }

        private void edtAcrescimo_Leave(object sender, EventArgs e)
        {
            this._controlador.AdicionarAcrescimo();
        }

    }
}
