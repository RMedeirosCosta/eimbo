namespace Eimbo.IU.Telas.ModuloAtendimento
{
    partial class TelaRecebimentoAtendimento
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
            this.lblRecebimentoAtendimento = new System.Windows.Forms.Label();
            this.lblTotalReceber = new System.Windows.Forms.Label();
            this.edtTotalReceber = new System.Windows.Forms.TextBox();
            this.gbAcoes = new System.Windows.Forms.GroupBox();
            this.btnReceber = new System.Windows.Forms.Button();
            this.btnCancelarRecebimento = new System.Windows.Forms.Button();
            this.lblEstadoRecebimento = new System.Windows.Forms.Label();
            this.edtDinheiro = new System.Windows.Forms.TextBox();
            this.lblDinheiro = new System.Windows.Forms.Label();
            this.edtCartaoCredito = new System.Windows.Forms.TextBox();
            this.lblCartaoCredito = new System.Windows.Forms.Label();
            this.edtCartaoDebito = new System.Windows.Forms.TextBox();
            this.lblCartaoDebito = new System.Windows.Forms.Label();
            this.edtSoma = new System.Windows.Forms.TextBox();
            this.lblSoma = new System.Windows.Forms.Label();
            this.lblResto = new System.Windows.Forms.Label();
            this.btnRestoDinheiro = new System.Windows.Forms.Button();
            this.btnRestoCartaoCredito = new System.Windows.Forms.Button();
            this.btnRestoCartaoDebito = new System.Windows.Forms.Button();
            this.gbAcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRecebimentoAtendimento
            // 
            this.lblRecebimentoAtendimento.AutoSize = true;
            this.lblRecebimentoAtendimento.Font = new System.Drawing.Font("Segoe UI", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblRecebimentoAtendimento.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRecebimentoAtendimento.Location = new System.Drawing.Point(18, 34);
            this.lblRecebimentoAtendimento.Name = "lblRecebimentoAtendimento";
            this.lblRecebimentoAtendimento.Size = new System.Drawing.Size(370, 35);
            this.lblRecebimentoAtendimento.TabIndex = 20;
            this.lblRecebimentoAtendimento.Text = "Recebimento de Atendimento";
            // 
            // lblTotalReceber
            // 
            this.lblTotalReceber.AutoSize = true;
            this.lblTotalReceber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReceber.Location = new System.Drawing.Point(21, 102);
            this.lblTotalReceber.Name = "lblTotalReceber";
            this.lblTotalReceber.Size = new System.Drawing.Size(111, 17);
            this.lblTotalReceber.TabIndex = 21;
            this.lblTotalReceber.Text = "Total a Receber: ";
            // 
            // edtTotalReceber
            // 
            this.edtTotalReceber.BackColor = System.Drawing.Color.White;
            this.edtTotalReceber.ForeColor = System.Drawing.Color.LimeGreen;
            this.edtTotalReceber.Location = new System.Drawing.Point(142, 102);
            this.edtTotalReceber.Name = "edtTotalReceber";
            this.edtTotalReceber.ReadOnly = true;
            this.edtTotalReceber.Size = new System.Drawing.Size(95, 22);
            this.edtTotalReceber.TabIndex = 22;
            this.edtTotalReceber.TabStop = false;
            // 
            // gbAcoes
            // 
            this.gbAcoes.Controls.Add(this.btnReceber);
            this.gbAcoes.Controls.Add(this.btnCancelarRecebimento);
            this.gbAcoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbAcoes.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gbAcoes.Location = new System.Drawing.Point(0, 334);
            this.gbAcoes.Name = "gbAcoes";
            this.gbAcoes.Size = new System.Drawing.Size(407, 69);
            this.gbAcoes.TabIndex = 23;
            this.gbAcoes.TabStop = false;
            this.gbAcoes.Text = "Ações";
            // 
            // btnReceber
            // 
            this.btnReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceber.BackColor = System.Drawing.Color.LimeGreen;
            this.btnReceber.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceber.FlatAppearance.BorderSize = 0;
            this.btnReceber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnReceber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceber.ForeColor = System.Drawing.Color.White;
            this.btnReceber.Location = new System.Drawing.Point(307, 40);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(94, 23);
            this.btnReceber.TabIndex = 9;
            this.btnReceber.TabStop = false;
            this.btnReceber.Text = "&Receber";
            this.btnReceber.UseVisualStyleBackColor = false;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // btnCancelarRecebimento
            // 
            this.btnCancelarRecebimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelarRecebimento.BackColor = System.Drawing.Color.Red;
            this.btnCancelarRecebimento.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancelarRecebimento.FlatAppearance.BorderSize = 0;
            this.btnCancelarRecebimento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancelarRecebimento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarRecebimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarRecebimento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarRecebimento.ForeColor = System.Drawing.Color.White;
            this.btnCancelarRecebimento.Location = new System.Drawing.Point(6, 40);
            this.btnCancelarRecebimento.Name = "btnCancelarRecebimento";
            this.btnCancelarRecebimento.Size = new System.Drawing.Size(97, 23);
            this.btnCancelarRecebimento.TabIndex = 8;
            this.btnCancelarRecebimento.TabStop = false;
            this.btnCancelarRecebimento.Text = "<ESC> Cancelar";
            this.btnCancelarRecebimento.UseVisualStyleBackColor = false;
            this.btnCancelarRecebimento.Click += new System.EventHandler(this.btnCancelarRecebimento_Click);
            // 
            // lblEstadoRecebimento
            // 
            this.lblEstadoRecebimento.AutoSize = true;
            this.lblEstadoRecebimento.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoRecebimento.Location = new System.Drawing.Point(302, 221);
            this.lblEstadoRecebimento.Name = "lblEstadoRecebimento";
            this.lblEstadoRecebimento.Size = new System.Drawing.Size(69, 25);
            this.lblEstadoRecebimento.TabIndex = 24;
            this.lblEstadoRecebimento.Text = "Troco:";
            this.lblEstadoRecebimento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edtDinheiro
            // 
            this.edtDinheiro.BackColor = System.Drawing.Color.White;
            this.edtDinheiro.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtDinheiro.Location = new System.Drawing.Point(142, 185);
            this.edtDinheiro.Name = "edtDinheiro";
            this.edtDinheiro.Size = new System.Drawing.Size(95, 22);
            this.edtDinheiro.TabIndex = 0;
            this.edtDinheiro.Leave += new System.EventHandler(this.edtDinheiro_Leave);
            // 
            // lblDinheiro
            // 
            this.lblDinheiro.AutoSize = true;
            this.lblDinheiro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinheiro.Location = new System.Drawing.Point(21, 185);
            this.lblDinheiro.Name = "lblDinheiro";
            this.lblDinheiro.Size = new System.Drawing.Size(70, 17);
            this.lblDinheiro.TabIndex = 25;
            this.lblDinheiro.Text = "Dinheiro: ";
            // 
            // edtCartaoCredito
            // 
            this.edtCartaoCredito.BackColor = System.Drawing.Color.White;
            this.edtCartaoCredito.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtCartaoCredito.Location = new System.Drawing.Point(142, 213);
            this.edtCartaoCredito.Name = "edtCartaoCredito";
            this.edtCartaoCredito.Size = new System.Drawing.Size(95, 22);
            this.edtCartaoCredito.TabIndex = 1;
            this.edtCartaoCredito.Leave += new System.EventHandler(this.edtCartaoCredito_Leave);
            // 
            // lblCartaoCredito
            // 
            this.lblCartaoCredito.AutoSize = true;
            this.lblCartaoCredito.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartaoCredito.Location = new System.Drawing.Point(21, 213);
            this.lblCartaoCredito.Name = "lblCartaoCredito";
            this.lblCartaoCredito.Size = new System.Drawing.Size(124, 17);
            this.lblCartaoCredito.TabIndex = 27;
            this.lblCartaoCredito.Text = "Cartão de Crédito: ";
            // 
            // edtCartaoDebito
            // 
            this.edtCartaoDebito.BackColor = System.Drawing.Color.White;
            this.edtCartaoDebito.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtCartaoDebito.Location = new System.Drawing.Point(142, 241);
            this.edtCartaoDebito.Name = "edtCartaoDebito";
            this.edtCartaoDebito.Size = new System.Drawing.Size(95, 22);
            this.edtCartaoDebito.TabIndex = 2;
            this.edtCartaoDebito.Leave += new System.EventHandler(this.edtCartaoDebito_Leave);
            // 
            // lblCartaoDebito
            // 
            this.lblCartaoDebito.AutoSize = true;
            this.lblCartaoDebito.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartaoDebito.Location = new System.Drawing.Point(21, 241);
            this.lblCartaoDebito.Name = "lblCartaoDebito";
            this.lblCartaoDebito.Size = new System.Drawing.Size(121, 17);
            this.lblCartaoDebito.TabIndex = 29;
            this.lblCartaoDebito.Text = "Cartao de Débito: ";
            // 
            // edtSoma
            // 
            this.edtSoma.BackColor = System.Drawing.Color.White;
            this.edtSoma.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtSoma.Location = new System.Drawing.Point(142, 293);
            this.edtSoma.Name = "edtSoma";
            this.edtSoma.ReadOnly = true;
            this.edtSoma.Size = new System.Drawing.Size(95, 22);
            this.edtSoma.TabIndex = 32;
            this.edtSoma.TabStop = false;
            // 
            // lblSoma
            // 
            this.lblSoma.AutoSize = true;
            this.lblSoma.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoma.Location = new System.Drawing.Point(21, 293);
            this.lblSoma.Name = "lblSoma";
            this.lblSoma.Size = new System.Drawing.Size(50, 17);
            this.lblSoma.TabIndex = 31;
            this.lblSoma.Text = "Soma: ";
            // 
            // lblResto
            // 
            this.lblResto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResto.Location = new System.Drawing.Point(294, 250);
            this.lblResto.Name = "lblResto";
            this.lblResto.Size = new System.Drawing.Size(84, 30);
            this.lblResto.TabIndex = 33;
            this.lblResto.Text = "0";
            this.lblResto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRestoDinheiro
            // 
            this.btnRestoDinheiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoDinheiro.Location = new System.Drawing.Point(243, 185);
            this.btnRestoDinheiro.Name = "btnRestoDinheiro";
            this.btnRestoDinheiro.Size = new System.Drawing.Size(18, 23);
            this.btnRestoDinheiro.TabIndex = 34;
            this.btnRestoDinheiro.TabStop = false;
            this.btnRestoDinheiro.Text = "R";
            this.btnRestoDinheiro.UseVisualStyleBackColor = true;
            this.btnRestoDinheiro.Click += new System.EventHandler(this.btnRestoDinheiro_Click);
            // 
            // btnRestoCartaoCredito
            // 
            this.btnRestoCartaoCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoCartaoCredito.Location = new System.Drawing.Point(243, 214);
            this.btnRestoCartaoCredito.Name = "btnRestoCartaoCredito";
            this.btnRestoCartaoCredito.Size = new System.Drawing.Size(18, 23);
            this.btnRestoCartaoCredito.TabIndex = 35;
            this.btnRestoCartaoCredito.TabStop = false;
            this.btnRestoCartaoCredito.Text = "R";
            this.btnRestoCartaoCredito.UseVisualStyleBackColor = true;
            this.btnRestoCartaoCredito.Click += new System.EventHandler(this.btnRestoCartaoCredito_Click);
            // 
            // btnRestoCartaoDebito
            // 
            this.btnRestoCartaoDebito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoCartaoDebito.Location = new System.Drawing.Point(243, 239);
            this.btnRestoCartaoDebito.Name = "btnRestoCartaoDebito";
            this.btnRestoCartaoDebito.Size = new System.Drawing.Size(18, 23);
            this.btnRestoCartaoDebito.TabIndex = 36;
            this.btnRestoCartaoDebito.TabStop = false;
            this.btnRestoCartaoDebito.Text = "R";
            this.btnRestoCartaoDebito.UseVisualStyleBackColor = true;
            this.btnRestoCartaoDebito.Click += new System.EventHandler(this.btnRestoCartaoDebito_Click);
            // 
            // TelaRecebimentoAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 403);
            this.Controls.Add(this.btnRestoCartaoDebito);
            this.Controls.Add(this.btnRestoCartaoCredito);
            this.Controls.Add(this.btnRestoDinheiro);
            this.Controls.Add(this.lblResto);
            this.Controls.Add(this.edtSoma);
            this.Controls.Add(this.lblSoma);
            this.Controls.Add(this.edtCartaoDebito);
            this.Controls.Add(this.lblCartaoDebito);
            this.Controls.Add(this.edtCartaoCredito);
            this.Controls.Add(this.lblCartaoCredito);
            this.Controls.Add(this.edtDinheiro);
            this.Controls.Add(this.lblDinheiro);
            this.Controls.Add(this.lblEstadoRecebimento);
            this.Controls.Add(this.gbAcoes);
            this.Controls.Add(this.edtTotalReceber);
            this.Controls.Add(this.lblTotalReceber);
            this.Controls.Add(this.lblRecebimentoAtendimento);
            this.Name = "TelaRecebimentoAtendimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recebimento de Atendimento";
            this.gbAcoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecebimentoAtendimento;
        private System.Windows.Forms.Label lblTotalReceber;
        private System.Windows.Forms.TextBox edtTotalReceber;
        private System.Windows.Forms.GroupBox gbAcoes;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.Button btnCancelarRecebimento;
        private System.Windows.Forms.Label lblEstadoRecebimento;
        private System.Windows.Forms.TextBox edtDinheiro;
        private System.Windows.Forms.Label lblDinheiro;
        private System.Windows.Forms.TextBox edtCartaoCredito;
        private System.Windows.Forms.Label lblCartaoCredito;
        private System.Windows.Forms.TextBox edtCartaoDebito;
        private System.Windows.Forms.Label lblCartaoDebito;
        private System.Windows.Forms.TextBox edtSoma;
        private System.Windows.Forms.Label lblSoma;
        private System.Windows.Forms.Label lblResto;
        private System.Windows.Forms.Button btnRestoDinheiro;
        private System.Windows.Forms.Button btnRestoCartaoCredito;
        private System.Windows.Forms.Button btnRestoCartaoDebito;
    }
}