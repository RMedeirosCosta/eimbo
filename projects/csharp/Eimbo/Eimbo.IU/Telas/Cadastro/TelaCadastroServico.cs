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
    partial class TelaCadastroServico :TelaCadastroPadrao, IVisaoCadastroServico
    {
        private ControladorCadastroServico _controlador;

        public TelaCadastroServico()
        {
            InitializeComponent();
            this._controlador = new ControladorCadastroServico(this);
        }

        #region IVisaoCadastroServico
        #region Grid
        public void AdicionarServicoNoGrid(long ID, String Descricao, Decimal Valor, Boolean bloqueado)
        {
            this.dgv.Rows.Add(ID, Descricao, Valor, bloqueado);
        }

        public void AlterarServicoNoGrid(String Descricao, Decimal Valor, Boolean bloqueado)
        {
            this.dgv.CurrentRow.Cells[1].Value = Descricao;
            this.dgv.CurrentRow.Cells[2].Value = Valor;
            this.dgv.CurrentRow.Cells[3].Value = bloqueado;
        }
        #endregion

        #region Focus
        public void MandarFocoNaDescricao()
        {
            this.edtDescricao.Focus();
        }

        public void MandarFocoNoValor()
        {
            this.edtValor.Focus();
        }
        #endregion

        #region Gets e Sets
        public String GetDescricao()
        {
            return this.edtDescricao.Text;
        }

        public Decimal GetValor()
        {
            decimal result;
            Decimal.TryParse(this.edtValor.Text, out result);
            
            return result; 
        }

        public void SetDescricao(String Descricao)
        {
            this.edtDescricao.Text = Descricao;
        }

        public void SetValor(Decimal Valor)
        {
            this.edtValor.Text = Valor.ToString("N2");
        }
        #endregion
        #endregion

        #region Métodos sobrescritos

        protected override DataGridViewColumn[] RetornaArrayDeColunasDoDGV()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descricao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn valor = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn bloqueado = new DataGridViewCheckBoxColumn();

            DataGridViewColumn[] result = new DataGridViewColumn[]
            {
                id,
                descricao,
                valor,
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

            // valor             
            valor.HeaderText = "Valor";
            valor.Name = "valor";
            valor.ReadOnly = true;
            valor.Width = 50;
            valor.DefaultCellStyle.Format = "N2";
            descricao.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            //Bloqueado
            bloqueado.HeaderText = "Bloqueado";
            bloqueado.Name = "bloqueado";
            bloqueado.ReadOnly = true;
            bloqueado.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            base._indiceColunaBloqueado = 3;

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


    }
}
