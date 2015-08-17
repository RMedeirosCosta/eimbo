using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Controlador.Cadastro;
using Eimbo.Aplicativo.Visao.Cadastro;

namespace Eimbo.IU.Telas.Cadastro
{
    partial class TelaCadastroFormaPagamento : TelaCadastroPadrao, IVisaoCadastroFormaPagamento
    {
        private ControladorCadastroFormaPagamento _controlador;

        public TelaCadastroFormaPagamento()
        {
            InitializeComponent();
            this._controlador = new ControladorCadastroFormaPagamento(this);
        }

        #region IVisaoCadastroFormaPagamento

        #region Grid
        public void AdicionarFormaPagamentoNoGrid(long ID, String Descricao, Boolean bloqueado)
        {
            this.dgv.Rows.Add(ID, Descricao, bloqueado);
        }

        public void AlterarFormaPagamentoNoGrid(String Descricao, Boolean bloqueado)
        {
            this.dgv.CurrentRow.Cells[1].Value = Descricao;
            this.dgv.CurrentRow.Cells[2].Value = bloqueado;
        }
        #endregion

        #region Comportamento
        public void HabilitarGrupoParcelamento(Boolean Habilitar)
        {
            this.gbParcelamento.Visible = Habilitar;
        }
        #endregion

        #region Focus
        public void MandarFocoNaDescricao()
        {
            this.edtDescricao.Focus();
        }

        public void MandarFocoNoAcrescimo()
        {
            this.edtPercentualAcrescimo.Focus();
        }

        public void MandarFocoNoDesconto()
        {
            this.edtPercentualDesconto.Focus();
        }

        public void MandarFocoNoIntervaloEntreParcelas()
        {
            this.edtIntervaloEntreParcelas.Focus();
        }

        public void MandarFocoNaQuantidadeDeParcelas()
        {
            this.edtQuantidadeParcelas.Focus();
        }

        #endregion

        #region Gets e Sets
        public String GetDescricao()
        {
            return this.edtDescricao.Text;
        }

        public int GetTipo()
        {
            return this.cbTipoFormaPagamento.SelectedIndex;
        }

        public Decimal GetPercentualAcrescimo()
        {
            return this.edtPercentualAcrescimo.Value;
        }

        public Decimal GetPercentualDesconto()
        {
            return this.edtPercentualDesconto.Value;
        }

        public int GetTipoParcelamento()
        {
            return this.cbTipoParcelamento.SelectedIndex;
        }

        public int GetQuantidadeParcelas()
        {
            return (int)this.edtQuantidadeParcelas.Value;
        }

        public int GetIntervaloEntreParcelas()
        {
            return (int)this.edtIntervaloEntreParcelas.Value;
        }

        public void SetDescricao(String Descricao)
        {
            this.edtDescricao.Text = Descricao;
        }

        public void SetTipo(int Tipo)
        {
            this.cbTipoFormaPagamento.SelectedIndex = Tipo;            
        }

        public void SetPercentualAcrescimo(Decimal Acrescimo)
        {
            this.edtPercentualAcrescimo.Value = Acrescimo;
        }

        public void SetPercentualDesconto(Decimal Desconto)
        {
            this.edtPercentualDesconto.Value = Desconto;
        }

        public void SetTipoParcelamento(int Tipo)
        {
            this.cbTipoParcelamento.SelectedIndex = Tipo;
        }

        public void SetQuantidadeParcelas(int QuantidadeParcelas)
        {
            this.edtQuantidadeParcelas.Value = (decimal)QuantidadeParcelas;
        }

        public void SetIntervaloEntreParcelas(int IntervaloEntreParcelas)
        {
            this.edtIntervaloEntreParcelas.Value = (decimal)IntervaloEntreParcelas;
        }
        #endregion
        #endregion 

        #region Métodos sobrescritos

        protected override DataGridViewColumn[] RetornaArrayDeColunasDoDGV()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descricao = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn bloqueado = new DataGridViewCheckBoxColumn();

            DataGridViewColumn[] result = new DataGridViewColumn[]
            {
                id,
                descricao,
                bloqueado
            };

            // id
            id.HeaderText = "ID";
            id.MaxInputLength = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.True;
            id.Width = 30;
            id.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            // descricao             
            descricao.HeaderText = "Descrição";
            descricao.Name = "descricao";
            descricao.ReadOnly = true;
            descricao.Width = 150;
            descricao.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            //Bloqueado
            bloqueado.HeaderText = "Bloqueado";
            bloqueado.Name = "bloqueado";
            bloqueado.ReadOnly = true;
            bloqueado.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            base._indiceColunaBloqueado = 2;

            return result;
        }

        protected override void ExecutaBusca(string palavraChave)
        {
            this._controlador.ExecutarBusca(palavraChave);
        }

        protected override void AlteraEstadoAtualParaConsulta()
        {
            this._controlador.MudarEstadoAtualParaConsulta();
        }

        protected override void AlteraEstadoAtualParaVisualizacao()
        {
            this._controlador.MudarEstadoAtualParaVisualizacao();
        }

        protected override void AlteraEstadoAtualParaInclusao()
        {
            this._controlador.MudarEstadoAtualParaInclusao();
        }

        protected override void AlteraEstadoAtualParaAlteracao()
        {
            this._controlador.MudarEstadoAtualParaAlteracao();
        }

        protected override void AlteraEstadoAtualParaPesquisa()
        {
            this._controlador.MudarEstadoAtualParaPesquisa();
        }

        protected override void ExecutaBloqueio()
        {
            this._controlador.ExecutarAlteracaoStatus();
        }

        protected override void ExecutaPersistencia()
        {
            this._controlador.ExecutaPersistencia();
        }

        public override long GetIDSelecionado()
        {
            try
            {
                return (long)this.dgv.CurrentRow.Cells[0].Value;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        #endregion

        private void cbTipoFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HabilitarGrupoParcelamento(this.cbTipoFormaPagamento.SelectedIndex == 1);
        }

    }
}
