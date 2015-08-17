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
    partial class TelaCadastroEstado: TelaCadastroPadrao, IVisaoCadastroEstado
    {
        private ControladorCadastroEstado _controlador;

        public TelaCadastroEstado()
        {
            InitializeComponent();
            this._controlador = new ControladorCadastroEstado(this);
        }

        #region IVisaoCadastroEstado
        public void SetUF(String UF)
        {
            this.edtUF.Text = UF;
        }

        public void MandarFocoNaUF()
        {
            this.edtUF.Focus();
        }

        public String GetUF()
        {
            return this.edtUF.Text;
        }

        public override long GetIDSelecionado()
        {
            if (this.dgv.CurrentRow != null)
                return (long)this.dgv.CurrentRow.Cells[0].Value;
            else
                return 0;
        }

        public void AdicionarEstadoNoGrid(long ID, String UF, Boolean bloqueado)
        {
            this.dgv.Rows.Add(ID, UF, bloqueado);
        }

        public void AlterarEstadoNoGrid(String UF, Boolean bloqueado)
        {
            this.dgv.CurrentRow.Cells[1].Value = UF;
            this.dgv.CurrentRow.Cells[2].Value = bloqueado;
        }

        #endregion

        #region Métodos sobrescritos

        protected override DataGridViewColumn[] RetornaArrayDeColunasDoDGV()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn uf = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn bloqueado = new DataGridViewCheckBoxColumn();

            DataGridViewColumn[] result = new DataGridViewColumn[]
            {
                id,
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

        #endregion

        public String GetUFSelecionada()
        {
            return this._controlador.GetUFSelecionada();
        }
    }  
}
