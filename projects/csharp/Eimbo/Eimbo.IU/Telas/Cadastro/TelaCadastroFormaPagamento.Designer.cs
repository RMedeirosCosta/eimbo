namespace Eimbo.IU.Telas.Cadastro
{
    partial class TelaCadastroFormaPagamento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private new System.ComponentModel.IContainer components = null;

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
            this.edtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblPercentualAcrescimo = new System.Windows.Forms.Label();
            this.edtPercentualAcrescimo = new System.Windows.Forms.NumericUpDown();
            this.lblPercentualDesconto = new System.Windows.Forms.Label();
            this.edtPercentualDesconto = new System.Windows.Forms.NumericUpDown();
            this.cbTipoFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblTipoFormaPagamento = new System.Windows.Forms.Label();
            this.gbParcelamento = new System.Windows.Forms.GroupBox();
            this.edtIntervaloEntreParcelas = new System.Windows.Forms.NumericUpDown();
            this.edtQuantidadeParcelas = new System.Windows.Forms.NumericUpDown();
            this.cbTipoParcelamento = new System.Windows.Forms.ComboBox();
            this.lblIntervaloEntreParcelas = new System.Windows.Forms.Label();
            this.lblTipoParcelamento = new System.Windows.Forms.Label();
            this.lblQuantidadeParcelas = new System.Windows.Forms.Label();
            this.tcCadastro.SuspendLayout();
            this.tpConsulta.SuspendLayout();
            this.tpDados.SuspendLayout();
            this.gbOpcoesDados.SuspendLayout();
            this.gbAcoes.SuspendLayout();
            this.gbDados.SuspendLayout();
            this.gbBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPercentualAcrescimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPercentualDesconto)).BeginInit();
            this.gbParcelamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntervaloEntreParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuantidadeParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolta
            // 
            this.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolta.FlatAppearance.BorderSize = 0;
            this.btnVolta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnVolta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnVolta.Location = new System.Drawing.Point(201, 10);
            // 
            // btnSalva
            // 
            this.btnSalva.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalva.FlatAppearance.BorderSize = 0;
            this.btnSalva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSalva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSalva.Location = new System.Drawing.Point(311, 10);
            // 
            // btnAltera
            // 
            this.btnAltera.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAltera.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAltera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnAltera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            // 
            // btnInclui
            // 
            this.btnInclui.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnInclui.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnInclui.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnInclui.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            // 
            // btnFecha
            // 
            this.btnFecha.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFecha.FlatAppearance.BorderSize = 0;
            this.btnFecha.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnFecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            // 
            // gbDados
            // 
            this.gbDados.Controls.Add(this.lblTipoFormaPagamento);
            this.gbDados.Controls.Add(this.cbTipoFormaPagamento);
            this.gbDados.Controls.Add(this.lblPercentualDesconto);
            this.gbDados.Controls.Add(this.edtPercentualDesconto);
            this.gbDados.Controls.Add(this.lblPercentualAcrescimo);
            this.gbDados.Controls.Add(this.edtPercentualAcrescimo);
            this.gbDados.Controls.Add(this.lblDescricao);
            this.gbDados.Controls.Add(this.edtDescricao);
            this.gbDados.Controls.Add(this.gbParcelamento);
            this.gbDados.Controls.SetChildIndex(this.lbID, 0);
            this.gbDados.Controls.SetChildIndex(this.edtID, 0);
            this.gbDados.Controls.SetChildIndex(this.chkBloqueado, 0);
            this.gbDados.Controls.SetChildIndex(this.gbParcelamento, 0);
            this.gbDados.Controls.SetChildIndex(this.edtDescricao, 0);
            this.gbDados.Controls.SetChildIndex(this.lblDescricao, 0);
            this.gbDados.Controls.SetChildIndex(this.edtPercentualAcrescimo, 0);
            this.gbDados.Controls.SetChildIndex(this.lblPercentualAcrescimo, 0);
            this.gbDados.Controls.SetChildIndex(this.edtPercentualDesconto, 0);
            this.gbDados.Controls.SetChildIndex(this.lblPercentualDesconto, 0);
            this.gbDados.Controls.SetChildIndex(this.cbTipoFormaPagamento, 0);
            this.gbDados.Controls.SetChildIndex(this.lblTipoFormaPagamento, 0);
            // 
            // edtID
            // 
            this.edtID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edtID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // edtDescricao
            // 
            this.edtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtDescricao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtDescricao.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtDescricao.Location = new System.Drawing.Point(54, 31);
            this.edtDescricao.Name = "edtDescricao";
            this.edtDescricao.Size = new System.Drawing.Size(553, 22);
            this.edtDescricao.TabIndex = 0;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDescricao.Location = new System.Drawing.Point(54, 15);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(56, 13);
            this.lblDescricao.TabIndex = 3;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblPercentualAcrescimo
            // 
            this.lblPercentualAcrescimo.AutoSize = true;
            this.lblPercentualAcrescimo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentualAcrescimo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPercentualAcrescimo.Location = new System.Drawing.Point(7, 64);
            this.lblPercentualAcrescimo.Name = "lblPercentualAcrescimo";
            this.lblPercentualAcrescimo.Size = new System.Drawing.Size(73, 13);
            this.lblPercentualAcrescimo.TabIndex = 7;
            this.lblPercentualAcrescimo.Text = "% Acréscimo";
            // 
            // edtPercentualAcrescimo
            // 
            this.edtPercentualAcrescimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtPercentualAcrescimo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPercentualAcrescimo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtPercentualAcrescimo.Location = new System.Drawing.Point(6, 80);
            this.edtPercentualAcrescimo.Name = "edtPercentualAcrescimo";
            this.edtPercentualAcrescimo.Size = new System.Drawing.Size(83, 22);
            this.edtPercentualAcrescimo.TabIndex = 1;
            this.edtPercentualAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPercentualDesconto
            // 
            this.lblPercentualDesconto.AutoSize = true;
            this.lblPercentualDesconto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentualDesconto.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPercentualDesconto.Location = new System.Drawing.Point(111, 64);
            this.lblPercentualDesconto.Name = "lblPercentualDesconto";
            this.lblPercentualDesconto.Size = new System.Drawing.Size(69, 13);
            this.lblPercentualDesconto.TabIndex = 9;
            this.lblPercentualDesconto.Text = "% Desconto";
            // 
            // edtPercentualDesconto
            // 
            this.edtPercentualDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtPercentualDesconto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPercentualDesconto.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtPercentualDesconto.Location = new System.Drawing.Point(110, 80);
            this.edtPercentualDesconto.Name = "edtPercentualDesconto";
            this.edtPercentualDesconto.Size = new System.Drawing.Size(80, 22);
            this.edtPercentualDesconto.TabIndex = 2;
            this.edtPercentualDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbTipoFormaPagamento
            // 
            this.cbTipoFormaPagamento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoFormaPagamento.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.cbTipoFormaPagamento.FormattingEnabled = true;
            this.cbTipoFormaPagamento.Items.AddRange(new object[] {
            "À Vista",
            "A Prazo"});
            this.cbTipoFormaPagamento.Location = new System.Drawing.Point(209, 79);
            this.cbTipoFormaPagamento.Name = "cbTipoFormaPagamento";
            this.cbTipoFormaPagamento.Size = new System.Drawing.Size(179, 21);
            this.cbTipoFormaPagamento.TabIndex = 3;
            this.cbTipoFormaPagamento.SelectedIndexChanged += new System.EventHandler(this.cbTipoFormaPagamento_SelectedIndexChanged);
            // 
            // lblTipoFormaPagamento
            // 
            this.lblTipoFormaPagamento.AutoSize = true;
            this.lblTipoFormaPagamento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFormaPagamento.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTipoFormaPagamento.Location = new System.Drawing.Point(205, 64);
            this.lblTipoFormaPagamento.Name = "lblTipoFormaPagamento";
            this.lblTipoFormaPagamento.Size = new System.Drawing.Size(161, 13);
            this.lblTipoFormaPagamento.TabIndex = 11;
            this.lblTipoFormaPagamento.Text = "Tipo da Forma de Pagamento";
            // 
            // gbParcelamento
            // 
            this.gbParcelamento.Controls.Add(this.edtIntervaloEntreParcelas);
            this.gbParcelamento.Controls.Add(this.edtQuantidadeParcelas);
            this.gbParcelamento.Controls.Add(this.cbTipoParcelamento);
            this.gbParcelamento.Controls.Add(this.lblIntervaloEntreParcelas);
            this.gbParcelamento.Controls.Add(this.lblTipoParcelamento);
            this.gbParcelamento.Controls.Add(this.lblQuantidadeParcelas);
            this.gbParcelamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbParcelamento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbParcelamento.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gbParcelamento.Location = new System.Drawing.Point(6, 108);
            this.gbParcelamento.Name = "gbParcelamento";
            this.gbParcelamento.Size = new System.Drawing.Size(601, 82);
            this.gbParcelamento.TabIndex = 4;
            this.gbParcelamento.TabStop = false;
            this.gbParcelamento.Text = "Parcelamento";
            // 
            // edtIntervaloEntreParcelas
            // 
            this.edtIntervaloEntreParcelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtIntervaloEntreParcelas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtIntervaloEntreParcelas.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtIntervaloEntreParcelas.Location = new System.Drawing.Point(336, 45);
            this.edtIntervaloEntreParcelas.Name = "edtIntervaloEntreParcelas";
            this.edtIntervaloEntreParcelas.Size = new System.Drawing.Size(140, 22);
            this.edtIntervaloEntreParcelas.TabIndex = 2;
            this.edtIntervaloEntreParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtQuantidadeParcelas
            // 
            this.edtQuantidadeParcelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtQuantidadeParcelas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtQuantidadeParcelas.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtQuantidadeParcelas.Location = new System.Drawing.Point(170, 45);
            this.edtQuantidadeParcelas.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.edtQuantidadeParcelas.Name = "edtQuantidadeParcelas";
            this.edtQuantidadeParcelas.Size = new System.Drawing.Size(140, 22);
            this.edtQuantidadeParcelas.TabIndex = 1;
            this.edtQuantidadeParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbTipoParcelamento
            // 
            this.cbTipoParcelamento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoParcelamento.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.cbTipoParcelamento.FormattingEnabled = true;
            this.cbTipoParcelamento.Items.AddRange(new object[] {
            "Com Entrada",
            "Sem Entrada"});
            this.cbTipoParcelamento.Location = new System.Drawing.Point(5, 44);
            this.cbTipoParcelamento.Name = "cbTipoParcelamento";
            this.cbTipoParcelamento.Size = new System.Drawing.Size(140, 21);
            this.cbTipoParcelamento.TabIndex = 0;
            // 
            // lblIntervaloEntreParcelas
            // 
            this.lblIntervaloEntreParcelas.AutoSize = true;
            this.lblIntervaloEntreParcelas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntervaloEntreParcelas.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblIntervaloEntreParcelas.Location = new System.Drawing.Point(336, 28);
            this.lblIntervaloEntreParcelas.Name = "lblIntervaloEntreParcelas";
            this.lblIntervaloEntreParcelas.Size = new System.Drawing.Size(142, 13);
            this.lblIntervaloEntreParcelas.TabIndex = 2;
            this.lblIntervaloEntreParcelas.Text = "Intervalo entre as parcelas";
            // 
            // lblTipoParcelamento
            // 
            this.lblTipoParcelamento.AutoSize = true;
            this.lblTipoParcelamento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoParcelamento.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTipoParcelamento.Location = new System.Drawing.Point(7, 28);
            this.lblTipoParcelamento.Name = "lblTipoParcelamento";
            this.lblTipoParcelamento.Size = new System.Drawing.Size(120, 13);
            this.lblTipoParcelamento.TabIndex = 1;
            this.lblTipoParcelamento.Text = "Tipo de Parcelamento";
            // 
            // lblQuantidadeParcelas
            // 
            this.lblQuantidadeParcelas.AutoSize = true;
            this.lblQuantidadeParcelas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeParcelas.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblQuantidadeParcelas.Location = new System.Drawing.Point(166, 28);
            this.lblQuantidadeParcelas.Name = "lblQuantidadeParcelas";
            this.lblQuantidadeParcelas.Size = new System.Drawing.Size(129, 13);
            this.lblQuantidadeParcelas.TabIndex = 0;
            this.lblQuantidadeParcelas.Text = "Quantidade de Parcelas";
            // 
            // TelaCadastroFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 336);
            this.Name = "TelaCadastroFormaPagamento";
            this.Text = "Cadastro de Formas de Pagamento";
            this.tcCadastro.ResumeLayout(false);
            this.tpConsulta.ResumeLayout(false);
            this.tpDados.ResumeLayout(false);
            this.gbOpcoesDados.ResumeLayout(false);
            this.gbAcoes.ResumeLayout(false);
            this.gbDados.ResumeLayout(false);
            this.gbDados.PerformLayout();
            this.gbBusca.ResumeLayout(false);
            this.gbBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPercentualAcrescimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPercentualDesconto)).EndInit();
            this.gbParcelamento.ResumeLayout(false);
            this.gbParcelamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntervaloEntreParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuantidadeParcelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox edtDescricao;
        private System.Windows.Forms.Label lblPercentualDesconto;
        private System.Windows.Forms.NumericUpDown edtPercentualDesconto;
        private System.Windows.Forms.Label lblPercentualAcrescimo;
        private System.Windows.Forms.NumericUpDown edtPercentualAcrescimo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblTipoFormaPagamento;
        private System.Windows.Forms.ComboBox cbTipoFormaPagamento;
        private System.Windows.Forms.GroupBox gbParcelamento;
        private System.Windows.Forms.Label lblTipoParcelamento;
        private System.Windows.Forms.Label lblQuantidadeParcelas;
        private System.Windows.Forms.NumericUpDown edtIntervaloEntreParcelas;
        private System.Windows.Forms.NumericUpDown edtQuantidadeParcelas;
        private System.Windows.Forms.ComboBox cbTipoParcelamento;
        private System.Windows.Forms.Label lblIntervaloEntreParcelas;
    }
}