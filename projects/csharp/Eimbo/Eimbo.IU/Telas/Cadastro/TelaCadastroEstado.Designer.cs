namespace Eimbo.IU.Telas.Cadastro
{
    partial class TelaCadastroEstado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.lbUF = new System.Windows.Forms.Label();
            this.edtUF = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tcCadastro.SuspendLayout();
            this.tpConsulta.SuspendLayout();
            this.tpDados.SuspendLayout();
            this.gbOpcoesDados.SuspendLayout();
            this.gbAcoes.SuspendLayout();
            this.gbDados.SuspendLayout();
            this.gbBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCadastro
            // 
            this.tcCadastro.Size = new System.Drawing.Size(638, 284);
            // 
            // tpConsulta
            // 
            this.tpConsulta.Size = new System.Drawing.Size(630, 258);
            // 
            // tpDados
            // 
            this.tpDados.Size = new System.Drawing.Size(630, 258);
            // 
            // gbOpcoesDados
            // 
            this.gbOpcoesDados.Size = new System.Drawing.Size(624, 36);
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
            // gbAcoes
            // 
            this.gbAcoes.Size = new System.Drawing.Size(638, 52);
            // 
            // btnAltera
            // 
            this.btnAltera.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAltera.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAltera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnAltera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnAltera.Location = new System.Drawing.Point(438, 21);
            this.btnAltera.Size = new System.Drawing.Size(107, 23);
            // 
            // btnInclui
            // 
            this.btnInclui.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnInclui.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnInclui.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnInclui.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnInclui.Location = new System.Drawing.Point(326, 21);
            this.btnInclui.Size = new System.Drawing.Size(105, 23);
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
            this.gbDados.Controls.Add(this.edtUF);
            this.gbDados.Controls.Add(this.lbUF);
            this.gbDados.Size = new System.Drawing.Size(624, 216);
            this.gbDados.Controls.SetChildIndex(this.chkBloqueado, 0);
            this.gbDados.Controls.SetChildIndex(this.lbID, 0);
            this.gbDados.Controls.SetChildIndex(this.edtID, 0);
            this.gbDados.Controls.SetChildIndex(this.lbUF, 0);
            this.gbDados.Controls.SetChildIndex(this.edtUF, 0);
            // 
            // gbBusca
            // 
            this.gbBusca.Size = new System.Drawing.Size(624, 45);
            // 
            // chkBloqueado
            // 
            this.chkBloqueado.Size = new System.Drawing.Size(618, 17);
            // 
            // lbUF
            // 
            this.lbUF.AutoSize = true;
            this.lbUF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUF.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbUF.Location = new System.Drawing.Point(64, 16);
            this.lbUF.Name = "lbUF";
            this.lbUF.Size = new System.Drawing.Size(21, 13);
            this.lbUF.TabIndex = 1;
            this.lbUF.Text = "UF";
            // 
            // edtUF
            // 
            this.edtUF.BackColor = System.Drawing.Color.White;
            this.edtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtUF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUF.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtUF.Location = new System.Drawing.Point(55, 32);
            this.edtUF.MaxLength = 2;
            this.edtUF.Name = "edtUF";
            this.edtUF.Size = new System.Drawing.Size(41, 22);
            this.edtUF.TabIndex = 1;
            // 
            // TelaCadastroEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 336);
            this.Name = "TelaCadastroEstado";
            this.Text = "Cadastro de Estado";
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

        private System.Windows.Forms.Label lbUF;
        private System.Windows.Forms.TextBox edtUF;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        //private System.Windows.Forms.DataGridView dgv;
    }
}