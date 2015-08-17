namespace Eimbo.IU.Telas.ModuloCaixa
{
    partial class TelaNovoCaixa
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
            this.edtSaldoAbertura = new System.Windows.Forms.NumericUpDown();
            this.lblSaldoAbertura = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAbrirNovoCaixa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldoAbertura)).BeginInit();
            this.SuspendLayout();
            // 
            // edtSaldoAbertura
            // 
            this.edtSaldoAbertura.BackColor = System.Drawing.Color.White;
            this.edtSaldoAbertura.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtSaldoAbertura.Location = new System.Drawing.Point(118, 51);
            this.edtSaldoAbertura.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.edtSaldoAbertura.Name = "edtSaldoAbertura";
            this.edtSaldoAbertura.Size = new System.Drawing.Size(120, 22);
            this.edtSaldoAbertura.TabIndex = 8;
            this.edtSaldoAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldoAbertura
            // 
            this.lblSaldoAbertura.AutoSize = true;
            this.lblSaldoAbertura.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoAbertura.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSaldoAbertura.Location = new System.Drawing.Point(119, 35);
            this.lblSaldoAbertura.Name = "lblSaldoAbertura";
            this.lblSaldoAbertura.Size = new System.Drawing.Size(101, 13);
            this.lblSaldoAbertura.TabIndex = 7;
            this.lblSaldoAbertura.Text = "Saldo de Abertura";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoltar.BackColor = System.Drawing.Color.Red;
            this.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(14, 98);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(120, 23);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.TabStop = false;
            this.btnVoltar.Text = "<ESC> Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAbrirNovoCaixa
            // 
            this.btnAbrirNovoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirNovoCaixa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAbrirNovoCaixa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAbrirNovoCaixa.FlatAppearance.BorderSize = 0;
            this.btnAbrirNovoCaixa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAbrirNovoCaixa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnAbrirNovoCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirNovoCaixa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirNovoCaixa.ForeColor = System.Drawing.Color.White;
            this.btnAbrirNovoCaixa.Location = new System.Drawing.Point(227, 98);
            this.btnAbrirNovoCaixa.Name = "btnAbrirNovoCaixa";
            this.btnAbrirNovoCaixa.Size = new System.Drawing.Size(120, 23);
            this.btnAbrirNovoCaixa.TabIndex = 5;
            this.btnAbrirNovoCaixa.TabStop = false;
            this.btnAbrirNovoCaixa.Text = "Confirmar";
            this.btnAbrirNovoCaixa.UseVisualStyleBackColor = false;
            this.btnAbrirNovoCaixa.Click += new System.EventHandler(this.btnAbrirNovoCaixa_Click);
            // 
            // TelaNovoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 133);
            this.Controls.Add(this.edtSaldoAbertura);
            this.Controls.Add(this.lblSaldoAbertura);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAbrirNovoCaixa);
            this.Name = "TelaNovoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Caixa";
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldoAbertura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirNovoCaixa;
        protected System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblSaldoAbertura;
        private System.Windows.Forms.NumericUpDown edtSaldoAbertura;

    }
}