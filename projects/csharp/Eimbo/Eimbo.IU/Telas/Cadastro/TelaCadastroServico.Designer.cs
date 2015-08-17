namespace Eimbo.IU.Telas.Cadastro
{
    partial class TelaCadastroServico
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
            this.lblDescricao = new System.Windows.Forms.Label();
            this.edtDescricao = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.edtValor = new System.Windows.Forms.MaskedTextBox();
            this.tcCadastro.SuspendLayout();
            this.tpConsulta.SuspendLayout();
            this.tpDados.SuspendLayout();
            this.gbOpcoesDados.SuspendLayout();
            this.gbAcoes.SuspendLayout();
            this.gbDados.SuspendLayout();
            this.gbBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVolta
            // 
            this.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolta.FlatAppearance.BorderSize = 0;
            this.btnVolta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnVolta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            // 
            // btnSalva
            // 
            this.btnSalva.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalva.FlatAppearance.BorderSize = 0;
            this.btnSalva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSalva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
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
            this.gbDados.Controls.Add(this.edtValor);
            this.gbDados.Controls.Add(this.lblValor);
            this.gbDados.Controls.Add(this.edtDescricao);
            this.gbDados.Controls.Add(this.lblDescricao);
            this.gbDados.Controls.SetChildIndex(this.lbID, 0);
            this.gbDados.Controls.SetChildIndex(this.edtID, 0);
            this.gbDados.Controls.SetChildIndex(this.chkBloqueado, 0);
            this.gbDados.Controls.SetChildIndex(this.lblDescricao, 0);
            this.gbDados.Controls.SetChildIndex(this.edtDescricao, 0);
            this.gbDados.Controls.SetChildIndex(this.lblValor, 0);
            this.gbDados.Controls.SetChildIndex(this.edtValor, 0);
            // 
            // edtID
            // 
            this.edtID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edtID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDescricao.Location = new System.Drawing.Point(59, 15);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(56, 13);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição";
            // 
            // edtDescricao
            // 
            this.edtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtDescricao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtDescricao.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtDescricao.Location = new System.Drawing.Point(63, 31);
            this.edtDescricao.Name = "edtDescricao";
            this.edtDescricao.Size = new System.Drawing.Size(364, 22);
            this.edtDescricao.TabIndex = 1;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblValor.Location = new System.Drawing.Point(454, 15);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 4;
            this.lblValor.Text = "Valor";
            // 
            // edtValor
            // 
            this.edtValor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtValor.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtValor.Location = new System.Drawing.Point(451, 31);
            this.edtValor.Name = "edtValor";
            this.edtValor.Size = new System.Drawing.Size(75, 22);
            this.edtValor.TabIndex = 2;
            this.edtValor.ValidatingType = typeof(decimal);
            // 
            // TelaCadastroServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 336);
            this.Name = "TelaCadastroServico";
            this.Text = "Cadastro de Serviços";
            this.tcCadastro.ResumeLayout(false);
            this.tpConsulta.ResumeLayout(false);
            this.tpDados.ResumeLayout(false);
            this.gbOpcoesDados.ResumeLayout(false);
            this.gbAcoes.ResumeLayout(false);
            this.gbDados.ResumeLayout(false);
            this.gbDados.PerformLayout();
            this.gbBusca.ResumeLayout(false);
            this.gbBusca.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox edtDescricao;
        private System.Windows.Forms.MaskedTextBox edtValor;
    }
}