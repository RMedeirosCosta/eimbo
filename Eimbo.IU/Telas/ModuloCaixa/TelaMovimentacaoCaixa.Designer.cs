namespace Eimbo.IU.Telas.ModuloCaixa
{
    partial class TelaMovimentacaoCaixa
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
            this.edtValorMovimentacao = new System.Windows.Forms.NumericUpDown();
            this.lblNomeDaMovimentacao = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnEfetuarMovimentacao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.edtValorMovimentacao)).BeginInit();
            this.SuspendLayout();
            // 
            // edtValorMovimentacao
            // 
            this.edtValorMovimentacao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.edtValorMovimentacao.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtValorMovimentacao.Location = new System.Drawing.Point(169, 25);
            this.edtValorMovimentacao.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.edtValorMovimentacao.Name = "edtValorMovimentacao";
            this.edtValorMovimentacao.Size = new System.Drawing.Size(120, 22);
            this.edtValorMovimentacao.TabIndex = 12;
            this.edtValorMovimentacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNomeDaMovimentacao
            // 
            this.lblNomeDaMovimentacao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNomeDaMovimentacao.AutoSize = true;
            this.lblNomeDaMovimentacao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeDaMovimentacao.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblNomeDaMovimentacao.Location = new System.Drawing.Point(3, 27);
            this.lblNomeDaMovimentacao.Name = "lblNomeDaMovimentacao";
            this.lblNomeDaMovimentacao.Size = new System.Drawing.Size(136, 13);
            this.lblNomeDaMovimentacao.TabIndex = 11;
            this.lblNomeDaMovimentacao.Text = "Nome da Movimentação";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoltar.BackColor = System.Drawing.Color.Red;
            this.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(14, 64);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(120, 23);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.TabStop = false;
            this.btnVoltar.Text = "<ESC> Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnEfetuarMovimentacao
            // 
            this.btnEfetuarMovimentacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEfetuarMovimentacao.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEfetuarMovimentacao.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEfetuarMovimentacao.FlatAppearance.BorderSize = 0;
            this.btnEfetuarMovimentacao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnEfetuarMovimentacao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnEfetuarMovimentacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEfetuarMovimentacao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfetuarMovimentacao.ForeColor = System.Drawing.Color.White;
            this.btnEfetuarMovimentacao.Location = new System.Drawing.Point(169, 64);
            this.btnEfetuarMovimentacao.Name = "btnEfetuarMovimentacao";
            this.btnEfetuarMovimentacao.Size = new System.Drawing.Size(120, 23);
            this.btnEfetuarMovimentacao.TabIndex = 9;
            this.btnEfetuarMovimentacao.TabStop = false;
            this.btnEfetuarMovimentacao.Text = "Confirmar";
            this.btnEfetuarMovimentacao.UseVisualStyleBackColor = false;
            this.btnEfetuarMovimentacao.Click += new System.EventHandler(this.btnEfetuarMovimentacao_Click);
            // 
            // TelaMovimentacaoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 99);
            this.Controls.Add(this.edtValorMovimentacao);
            this.Controls.Add(this.lblNomeDaMovimentacao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnEfetuarMovimentacao);
            this.Name = "TelaMovimentacaoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.edtValorMovimentacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown edtValorMovimentacao;
        private System.Windows.Forms.Label lblNomeDaMovimentacao;
        protected System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnEfetuarMovimentacao;
    }
}