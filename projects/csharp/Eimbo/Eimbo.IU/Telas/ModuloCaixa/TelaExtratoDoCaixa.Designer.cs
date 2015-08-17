namespace Eimbo.IU.Telas.ModuloCaixa
{
    partial class TelaExtratoDoCaixa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDataAbertura = new System.Windows.Forms.Label();
            this.lblExtratoDoCaixa = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dgvExtratoDoCaixa = new System.Windows.Forms.DataGridView();
            this.DataHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dinheiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartaoCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartaoDebito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotais = new System.Windows.Forms.Panel();
            this.lblTotalCartaoDebito = new System.Windows.Forms.Label();
            this.lblTotalCartaoCredito = new System.Windows.Forms.Label();
            this.lblTotalDinheiro = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtratoDoCaixa)).BeginInit();
            this.pnlTotais.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDataAbertura
            // 
            this.lblDataAbertura.AutoSize = true;
            this.lblDataAbertura.Font = new System.Drawing.Font("Segoe UI", 6.25F);
            this.lblDataAbertura.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDataAbertura.Location = new System.Drawing.Point(279, 59);
            this.lblDataAbertura.Name = "lblDataAbertura";
            this.lblDataAbertura.Size = new System.Drawing.Size(129, 12);
            this.lblDataAbertura.TabIndex = 20;
            this.lblDataAbertura.Text = "Aberto em: 23/10/2013 - 23:34";
            // 
            // lblExtratoDoCaixa
            // 
            this.lblExtratoDoCaixa.AutoSize = true;
            this.lblExtratoDoCaixa.Font = new System.Drawing.Font("Segoe UI", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblExtratoDoCaixa.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblExtratoDoCaixa.Location = new System.Drawing.Point(240, 24);
            this.lblExtratoDoCaixa.Name = "lblExtratoDoCaixa";
            this.lblExtratoDoCaixa.Size = new System.Drawing.Size(207, 35);
            this.lblExtratoDoCaixa.TabIndex = 19;
            this.lblExtratoDoCaixa.Text = "Extrato do Caixa";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVoltar.BackColor = System.Drawing.Color.Red;
            this.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(292, 506);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(103, 23);
            this.btnVoltar.TabIndex = 21;
            this.btnVoltar.TabStop = false;
            this.btnVoltar.Text = "<ESC> Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dgvExtratoDoCaixa
            // 
            this.dgvExtratoDoCaixa.BackgroundColor = System.Drawing.Color.White;
            this.dgvExtratoDoCaixa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvExtratoDoCaixa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExtratoDoCaixa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExtratoDoCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtratoDoCaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataHora,
            this.Descricao,
            this.Dinheiro,
            this.CartaoCredito,
            this.CartaoDebito});
            this.dgvExtratoDoCaixa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvExtratoDoCaixa.EnableHeadersVisualStyles = false;
            this.dgvExtratoDoCaixa.GridColor = System.Drawing.Color.White;
            this.dgvExtratoDoCaixa.Location = new System.Drawing.Point(17, 83);
            this.dgvExtratoDoCaixa.Name = "dgvExtratoDoCaixa";
            this.dgvExtratoDoCaixa.ReadOnly = true;
            this.dgvExtratoDoCaixa.RowHeadersVisible = false;
            this.dgvExtratoDoCaixa.Size = new System.Drawing.Size(652, 364);
            this.dgvExtratoDoCaixa.TabIndex = 22;
            // 
            // DataHora
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.DataHora.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataHora.Frozen = true;
            this.DataHora.HeaderText = "Data e Hora";
            this.DataHora.Name = "DataHora";
            this.DataHora.ReadOnly = true;
            this.DataHora.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataHora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Descricao
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descricao.Frozen = true;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Descricao.Width = 250;
            // 
            // Dinheiro
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Dinheiro.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dinheiro.HeaderText = "Dinheiro";
            this.Dinheiro.Name = "Dinheiro";
            this.Dinheiro.ReadOnly = true;
            this.Dinheiro.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dinheiro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CartaoCredito
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.CartaoCredito.DefaultCellStyle = dataGridViewCellStyle5;
            this.CartaoCredito.HeaderText = "Cartão de Crédito";
            this.CartaoCredito.Name = "CartaoCredito";
            this.CartaoCredito.ReadOnly = true;
            this.CartaoCredito.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CartaoCredito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CartaoDebito
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.CartaoDebito.DefaultCellStyle = dataGridViewCellStyle6;
            this.CartaoDebito.HeaderText = "Cartão de Débito";
            this.CartaoDebito.Name = "CartaoDebito";
            this.CartaoDebito.ReadOnly = true;
            this.CartaoDebito.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CartaoDebito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlTotais
            // 
            this.pnlTotais.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlTotais.Controls.Add(this.lblTotalCartaoDebito);
            this.pnlTotais.Controls.Add(this.lblTotalCartaoCredito);
            this.pnlTotais.Controls.Add(this.lblTotalDinheiro);
            this.pnlTotais.Controls.Add(this.lblTotal);
            this.pnlTotais.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTotais.ForeColor = System.Drawing.Color.White;
            this.pnlTotais.Location = new System.Drawing.Point(17, 453);
            this.pnlTotais.Name = "pnlTotais";
            this.pnlTotais.Size = new System.Drawing.Size(652, 22);
            this.pnlTotais.TabIndex = 23;
            // 
            // lblTotalCartaoDebito
            // 
            this.lblTotalCartaoDebito.AutoSize = true;
            this.lblTotalCartaoDebito.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartaoDebito.Location = new System.Drawing.Point(596, 5);
            this.lblTotalCartaoDebito.Name = "lblTotalCartaoDebito";
            this.lblTotalCartaoDebito.Size = new System.Drawing.Size(13, 13);
            this.lblTotalCartaoDebito.TabIndex = 5;
            this.lblTotalCartaoDebito.Text = "0";
            // 
            // lblTotalCartaoCredito
            // 
            this.lblTotalCartaoCredito.AutoSize = true;
            this.lblTotalCartaoCredito.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartaoCredito.Location = new System.Drawing.Point(499, 5);
            this.lblTotalCartaoCredito.Name = "lblTotalCartaoCredito";
            this.lblTotalCartaoCredito.Size = new System.Drawing.Size(13, 13);
            this.lblTotalCartaoCredito.TabIndex = 4;
            this.lblTotalCartaoCredito.Text = "0";
            // 
            // lblTotalDinheiro
            // 
            this.lblTotalDinheiro.AutoSize = true;
            this.lblTotalDinheiro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDinheiro.Location = new System.Drawing.Point(393, 5);
            this.lblTotalDinheiro.Name = "lblTotalDinheiro";
            this.lblTotalDinheiro.Size = new System.Drawing.Size(13, 13);
            this.lblTotalDinheiro.TabIndex = 2;
            this.lblTotalDinheiro.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(4, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Totais:";
            // 
            // TelaExtratoDoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 541);
            this.Controls.Add(this.pnlTotais);
            this.Controls.Add(this.dgvExtratoDoCaixa);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblDataAbertura);
            this.Controls.Add(this.lblExtratoDoCaixa);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TelaExtratoDoCaixa";
            this.Text = "Extrato do Caixa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtratoDoCaixa)).EndInit();
            this.pnlTotais.ResumeLayout(false);
            this.pnlTotais.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataAbertura;
        private System.Windows.Forms.Label lblExtratoDoCaixa;
        protected System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dgvExtratoDoCaixa;
        private System.Windows.Forms.Panel pnlTotais;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalCartaoDebito;
        private System.Windows.Forms.Label lblTotalCartaoCredito;
        private System.Windows.Forms.Label lblTotalDinheiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dinheiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartaoCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartaoDebito;
    }
}