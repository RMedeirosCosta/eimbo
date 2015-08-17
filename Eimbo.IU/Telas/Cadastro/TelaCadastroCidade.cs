using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Controlador.Cadastro;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.IU.Telas.Cadastro;

namespace Eimbo.IU.Telas.Cadastro
{
    internal partial class TelaCadastroCidade : TelaCadastroPadrao, IVisaoCadastroCidade
    {
        private ControladorCadastroCidade _controlador;
        private TelaCadastroEstado        _telaEstado;  

        public TelaCadastroCidade()
        {
            InitializeComponent();
            this._controlador = new ControladorCadastroCidade(this);
            this._telaEstado = new TelaCadastroEstado();
            this._telaEstado.EmBusca = true;
        }

        #region IVisaoCadastroCidade

        public void AdicionarCidadeNoGrid(long ID, String nome, String UF, Boolean bloqueado)
        {
            this.dgv.Rows.Add(ID, nome, UF, bloqueado);
        }

        public void AlterarCidadeNoGrid(String nome, String UF, Boolean bloqueado)
        {
            this.dgv.CurrentRow.Cells[1].Value = nome;
            this.dgv.CurrentRow.Cells[2].Value = UF;
            this.dgv.CurrentRow.Cells[3].Value = bloqueado;
        }

        public String GetIDEstado()
        {
            return this.edtIDEstado.Text;
        }

        public String GetNome()
        {
            return this.edtNome.Text;
        }

        public String GetUF()
        {
            return this.edtUF.Text;
        }

        public void MandarFocoNoIDEstado()
        {
            this.edtIDEstado.Focus();
        }

        public Boolean AchouEstado(out long ID, out String UF)
        {
            this._telaEstado.ShowDialog();

            if (this._telaEstado.DialogResult == DialogResult.OK)
            {
                ID = this._telaEstado.GetIDSelecionado();
                UF = this._telaEstado.GetUFSelecionada();
                return true;
            }

            ID = 0;
            UF = String.Empty;
            return false;
        }

        public void MandarFocoNoNome()
        {
            this.edtNome.Focus();
        }

        public void SetIDEstado(long IDEstado)
        {
            this.edtIDEstado.Text = IDEstado.ToString();
        }

        public void SetNome(String nome)
        {
            this.edtNome.Text = nome;
        }

        public void SetUF(String UF)
        {
            this.edtUF.Text = UF;
        }
        #endregion

        #region  Métodos sobrescritos

        protected override DataGridViewColumn[] RetornaArrayDeColunasDoDGV()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nome = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn uf = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn bloqueado = new DataGridViewCheckBoxColumn();

            DataGridViewColumn[] result = new DataGridViewColumn[]
            {
                id,
                nome,
                uf,
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

            // nome
            nome.HeaderText = "Nome";
            nome.MaxInputLength = 300;
            nome.Name = "nome";
            nome.ReadOnly = true;
            nome.Resizable = DataGridViewTriState.True;
            nome.Width = 300;
            nome.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            // uf             
            uf.HeaderText = "UF";
            uf.MaxInputLength = 2;
            uf.Name = "uf";
            uf.ReadOnly = true;
            uf.Width = 30;
            uf.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            //Bloqueado
            bloqueado.HeaderText = "Bloqueado";
            bloqueado.Name = "bloqueado";
            bloqueado.ReadOnly = true;
            bloqueado.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;
            this._indiceColunaBloqueado = 3;

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

        protected override void ExecutaBloqueio()
        {
            this._controlador.ExecutarAlteracaoStatus();
        }

        protected override void AlteraEstadoAtualParaPesquisa()
        {
            this._controlador.MudarEstadoAtualParaPesquisa();
        }

        protected override void ExecutaPersistencia()
        {
            this._controlador.ExecutaPersistencia();
        }

        public override long GetIDSelecionado()
        {
            if (this.dgv.CurrentRow != null)
                return (long)this.dgv.CurrentRow.Cells[0].Value;
            else
                return 0;
        }

       #endregion

        public String GetNomeSelecionada()
        {
            return this._controlador.GetNomeSelecionada();
        }

        private void btnBuscaEstado_Click(object sender, EventArgs e)
        {
            this._controlador.BuscaEstado(0);
        }

        private void btnBuscaEstado_Enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            long idEstado;
            long.TryParse(this.edtIDEstado.Text, out idEstado);
            this._controlador.BuscaEstado(idEstado);

            if (btn.Focused)
                SendKeys.Send("{TAB}");
        }

        private void btnBuscaEstado_MouseHover(object sender, EventArgs e)
        {
            //this.btnBuscaEstado.Enter -= new System.EventHandler(this.btnBuscaEstado_Enter);
        }

        private void btnBuscaEstado_MouseLeave(object sender, EventArgs e)
        {
            //this.btnBuscaEstado.Enter += new System.EventHandler(this.btnBuscaEstado_Enter);
        }
    }
}
