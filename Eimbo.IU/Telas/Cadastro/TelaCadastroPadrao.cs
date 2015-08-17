using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Eimbo.IU.Telas.Comum;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Aplicativo.Controlador.Cadastro;

namespace Eimbo.IU.Telas.Cadastro
{
    partial class TelaCadastroPadrao :TelaPadrao, IVisaoCadastroPadrao
    {
        private   Boolean _emBusca;
        protected int     _indiceColunaBloqueado;
        public    Boolean EmBusca
        { 
            get
            { 
                return this._emBusca; 
            }
            set
            {
                this._emBusca = value;

                if (this._emBusca)
                {
                    this.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    this.AlteraEstadoAtualParaPesquisa();
                    this.HabilitarComportamentoDePesquisa();
                }
                else
                    this.HabilitarComportamentoDeCadastro();
            }
        }
        
        public TelaCadastroPadrao()
        {
            InitializeComponent();

            this._indiceColunaBloqueado = -1;
            this.dgv.Columns.AddRange(this.RetornaArrayDeColunasDoDGV());                      
            this.dgv.ResumeLayout(false);
            this.dgv.PerformLayout();
            this.EmBusca = false;
        }

        #region Métodos que serão implementados nas subclasses
        
        protected virtual void AlteraEstadoAtualParaConsulta()     {throw new NotImplementedException();} 
        protected virtual void AlteraEstadoAtualParaVisualizacao() {throw new NotImplementedException();}
        protected virtual void AlteraEstadoAtualParaInclusao()     {throw new NotImplementedException();}
        protected virtual void AlteraEstadoAtualParaAlteracao()    {throw new NotImplementedException();}
        protected virtual void AlteraEstadoAtualParaPesquisa()     {throw new NotImplementedException();}
        
        protected virtual DataGridViewColumn[] RetornaArrayDeColunasDoDGV()
        {
            System.Windows.Forms.DataGridViewTextBoxColumn teste = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewColumn[] result = new System.Windows.Forms.DataGridViewColumn[]
            {
                teste
            };

            // teste
            teste.HeaderText = "Teste";
            teste.MaxInputLength = 30;
            teste.Name = "teste";
            teste.ReadOnly = true;
            teste.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            teste.Width = 100;
            teste.DefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle;

            return result;
        }

        protected virtual void ExecutaBloqueio() {}
        protected virtual void ExecutaPersistencia() {}
        protected virtual void ExecutaBusca(String palavraChave) { }
        public virtual long GetIDSelecionado() { throw new NotImplementedException(); }

        #endregion

        #region IVisaoPadrão

        public void AbrirAbaConsulta()
        {
            this.tcCadastro.SelectedIndex = 0;
        }

        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }

        public void AbrirAbaDados()
        {
            this.tcCadastro.SelectedIndex = 1;
        }

        public void HabilitarComportamentoDeCadastro()
        {
            if (!this.tcCadastro.Controls.Contains(this.tpDados))
                this.tcCadastro.Controls.Add(this.tpDados);

            this.KeyDown              -= new System.Windows.Forms.KeyEventHandler(this.AtalhosParaComportamentoDePesquisa);
            this.KeyDown              += new System.Windows.Forms.KeyEventHandler(this.AtalhosParaComportamentoDeCadastro);
            this.dgv.CellDoubleClick  += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
        }

        public void HabilitarComportamentoDePesquisa()
        {
            if (this.tcCadastro.Controls.Contains(this.tpDados))
                this.tcCadastro.Controls.Remove(this.tpDados);

            this.KeyDown             -= new System.Windows.Forms.KeyEventHandler(this.AtalhosParaComportamentoDeCadastro);
            this.KeyDown             += new System.Windows.Forms.KeyEventHandler(this.AtalhosParaComportamentoDePesquisa);
            this.dgv.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);            
        }

        public void HabilitarDados(Boolean habilita)
        {
            this.gbDados.Enabled = habilita;
        }

        public void LimparGrid()
        {
            this.dgv.Rows.Clear();
        }

        public void LimparBusca()
        {
            this.edtBusca.Clear();
        }

        public void LimparDados()
        {
            this.LimpaDados(this.gbDados);
        }

        public void LimpaDados(GroupBox gb)
        {
            foreach (Control ctrl in gb.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)(ctrl)).Clear();
                else if (ctrl is MaskedTextBox)
                    ((MaskedTextBox)ctrl).Clear();
                else if (ctrl is NumericUpDown)
                    ((NumericUpDown)(ctrl)).Value = 0m;
                else if (ctrl is ComboBox)
                    ((ComboBox)(ctrl)).SelectedIndex = -1;
                else if (ctrl is CheckBox)
                    ((CheckBox)(ctrl)).Checked = false;
                else if (ctrl is DataGridView)
                    ((DataGridView)ctrl).Rows.Clear();
                else if (ctrl is GroupBox)
                    this.LimpaDados((GroupBox)ctrl);                   
            }
        }

        public void MostrarAcoesConsulta(Boolean mostra)
        {
            this.gbAcoes.Visible = mostra;
        }

        public void MostrarAcoesDados(Boolean mostra)
        {
            this.gbOpcoesDados.Visible = mostra;
        }

        public void MostrarID(Boolean mostra)
        {
            this.lbID.Visible  = mostra;
            this.edtID.Visible = mostra;
        }

        public void MostrarBloqueado(Boolean mostra)
        {
            this.chkBloqueado.Visible = mostra;
        }

        public Boolean GetBloqueado()
        {
            return this.chkBloqueado.Checked;
        }

        public void SetBloqueado(Boolean Bloqueado)
        {
            this.chkBloqueado.Checked = Bloqueado;
        }

        public long GetID()
        {
            long result;
            long.TryParse(this.edtID.Text, out result);
            return result;
        }

        public void SetID(long id)
        {
            this.edtID.Text = id.ToString();
        }

        #endregion

        #region Eventos

        private void tcCadastro_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            // Fonte da Aba
            Font TabFont    = new Font(e.Font, FontStyle.Regular);

            // Cor de Fundo
            Brush BackBrush = new SolidBrush(this.BackColor); 

            // Cor do Texto
            Brush ForeBrush = new SolidBrush(this.ForeColor);

            String TabName  = this.tcCadastro.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment    = StringAlignment.Center;

            e.Graphics.FillRectangle(BackBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
            sf.Dispose();

            if (e.Index == this.tcCadastro.SelectedIndex)
            {
                TabFont.Dispose();
                BackBrush.Dispose();
            }

            else
            {
                BackBrush.Dispose();
                ForeBrush.Dispose();
            }
        }

        private void btnVolta_Click(object sender, EventArgs e)
        {
            this.AlteraEstadoAtualParaConsulta();
        }

        private void AtalhosParaComportamentoDeCadastro(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: this.AlteraEstadoAtualParaConsulta(); break;
                case Keys.F2: this.AlteraEstadoAtualParaVisualizacao(); break;
                case Keys.F3: this.AlteraEstadoAtualParaInclusao(); break;
                case Keys.F4: this.AlteraEstadoAtualParaAlteracao(); break;
                case Keys.F5: this.ExecutaBloqueio(); break;
                case Keys.F6: this.ExecutaPersistencia(); break;
                default: break;
            }
        }

        private void AtalhosParaComportamentoDePesquisa(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            return;
        }

        private void btnInclui_Click(object sender, EventArgs e)
        {
            this.AlteraEstadoAtualParaInclusao();
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            this.AlteraEstadoAtualParaAlteracao();
        }

        private void btnBloqueia_Click(object sender, EventArgs e)
        {
            this.ExecutaBloqueio();
        }

        private void tpConsulta_Enter(object sender, EventArgs e)
        {
            this.AlteraEstadoAtualParaConsulta();
        }

        private void tpDados_Enter(object sender, EventArgs e)
        {
            this.AlteraEstadoAtualParaVisualizacao();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            this.ExecutaPersistencia();
        }

        private void TelaCadastroPadrao_Paint(object sender, PaintEventArgs e)
        {
            this.MandarFocoNoCampoDeBusca();
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridView grid = (DataGridView)sender;

            /* Caso a linha for ímpar, pego o estilo de célula alternado*/
            //if (((e.RowIndex + 1) % 2) == 0)
                //grid.Rows[e.RowIndex].DefaultCellStyle = grid.AlternatingRowsDefaultCellStyle;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this._indiceColunaBloqueado.Equals(e.ColumnIndex))
                this.ExecutaBloqueio();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            // Para evitar a quebra de linha do grid.
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void edtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            this.ExecutaBusca(t.Text);
        }

        private void tcCadastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TabControl tc = (TabControl)sender;

            //if (tc.SelectedIndex == 0)
            //    this.AlteraEstadoAtualParaConsulta();
            //else
            //    this.AlteraEstadoAtualParaVisualizacao();
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            this.VoltarParaTelaAnterior();
        }        

        #endregion

        public void MandarFocoNoCampoDeBusca()
        {
            this.edtBusca.Focus();
        }

        public void MandarFocoNoGrid()
        {
            this.dgv.Focus();
        }

        private void tcCadastro_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                switch (e.TabPageIndex)
                {
                    // Tela de Consulta 
                    case 0: this.AlteraEstadoAtualParaConsulta(); break;

                    // Tela de Dados
                    case 1: this.AlteraEstadoAtualParaVisualizacao(); break;
                }
            }
            catch (NotImplementedException)
            {
                // Se estiver em tempo de design eu capturo a exceção.
            }
        }
    }
}
