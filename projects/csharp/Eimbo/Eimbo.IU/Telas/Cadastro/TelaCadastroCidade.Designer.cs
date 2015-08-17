namespace Eimbo.IU.Telas.Cadastro
{
    partial class TelaCadastroCidade
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
            this.lbNome = new System.Windows.Forms.Label();
            this.edtNome = new System.Windows.Forms.TextBox();
            this.gbEstado = new System.Windows.Forms.GroupBox();
            this.btnBuscaEstado = new System.Windows.Forms.Button();
            this.edtUF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edtIDEstado = new System.Windows.Forms.TextBox();
            this.lbIDEstado = new System.Windows.Forms.Label();
            this.tcCadastro.SuspendLayout();
            this.tpConsulta.SuspendLayout();
            this.tpDados.SuspendLayout();
            this.gbOpcoesDados.SuspendLayout();
            this.gbAcoes.SuspendLayout();
            this.gbDados.SuspendLayout();
            this.gbBusca.SuspendLayout();
            this.gbEstado.SuspendLayout();
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
            this.gbDados.Controls.Add(this.gbEstado);
            this.gbDados.Controls.Add(this.edtNome);
            this.gbDados.Controls.Add(this.lbNome);
            this.gbDados.Controls.SetChildIndex(this.chkBloqueado, 0);
            this.gbDados.Controls.SetChildIndex(this.lbID, 0);
            this.gbDados.Controls.SetChildIndex(this.edtID, 0);
            this.gbDados.Controls.SetChildIndex(this.lbNome, 0);
            this.gbDados.Controls.SetChildIndex(this.edtNome, 0);
            this.gbDados.Controls.SetChildIndex(this.gbEstado, 0);
            // 
            // edtID
            // 
            this.edtID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edtID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbNome.Location = new System.Drawing.Point(65, 16);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(39, 13);
            this.lbNome.TabIndex = 1;
            this.lbNome.Text = "Nome";
            // 
            // edtNome
            // 
            this.edtNome.BackColor = System.Drawing.Color.White;
            this.edtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtNome.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtNome.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtNome.Location = new System.Drawing.Point(69, 32);
            this.edtNome.MaxLength = 300;
            this.edtNome.Name = "edtNome";
            this.edtNome.Size = new System.Drawing.Size(541, 22);
            this.edtNome.TabIndex = 1;
            // 
            // gbEstado
            // 
            this.gbEstado.Controls.Add(this.btnBuscaEstado);
            this.gbEstado.Controls.Add(this.edtUF);
            this.gbEstado.Controls.Add(this.label1);
            this.gbEstado.Controls.Add(this.edtIDEstado);
            this.gbEstado.Controls.Add(this.lbIDEstado);
            this.gbEstado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstado.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gbEstado.Location = new System.Drawing.Point(10, 58);
            this.gbEstado.Name = "gbEstado";
            this.gbEstado.Size = new System.Drawing.Size(125, 69);
            this.gbEstado.TabIndex = 2;
            this.gbEstado.TabStop = false;
            this.gbEstado.Text = "Estado";
            // 
            // btnBuscaEstado
            // 
            this.btnBuscaEstado.FlatAppearance.BorderSize = 0;
            this.btnBuscaEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaEstado.Image = global::Eimbo.IU.Properties.Resources.Find;
            this.btnBuscaEstado.Location = new System.Drawing.Point(41, 43);
            this.btnBuscaEstado.Name = "btnBuscaEstado";
            this.btnBuscaEstado.Size = new System.Drawing.Size(19, 16);
            this.btnBuscaEstado.TabIndex = 4;
            this.btnBuscaEstado.UseVisualStyleBackColor = true;
            this.btnBuscaEstado.Click += new System.EventHandler(this.btnBuscaEstado_Click);
            this.btnBuscaEstado.Enter += new System.EventHandler(this.btnBuscaEstado_Enter);
            this.btnBuscaEstado.MouseLeave += new System.EventHandler(this.btnBuscaEstado_MouseLeave);
            this.btnBuscaEstado.MouseHover += new System.EventHandler(this.btnBuscaEstado_MouseHover);
            // 
            // edtUF
            // 
            this.edtUF.BackColor = System.Drawing.Color.White;
            this.edtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtUF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUF.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtUF.Location = new System.Drawing.Point(73, 42);
            this.edtUF.MaxLength = 2;
            this.edtUF.Name = "edtUF";
            this.edtUF.ReadOnly = true;
            this.edtUF.Size = new System.Drawing.Size(42, 22);
            this.edtUF.TabIndex = 8;
            this.edtUF.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(80, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "UF";
            // 
            // edtIDEstado
            // 
            this.edtIDEstado.BackColor = System.Drawing.Color.White;
            this.edtIDEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtIDEstado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtIDEstado.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtIDEstado.Location = new System.Drawing.Point(5, 42);
            this.edtIDEstado.MaxLength = 6;
            this.edtIDEstado.Name = "edtIDEstado";
            this.edtIDEstado.Size = new System.Drawing.Size(29, 22);
            this.edtIDEstado.TabIndex = 3;
            // 
            // lbIDEstado
            // 
            this.lbIDEstado.AutoSize = true;
            this.lbIDEstado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDEstado.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbIDEstado.Location = new System.Drawing.Point(8, 26);
            this.lbIDEstado.Name = "lbIDEstado";
            this.lbIDEstado.Size = new System.Drawing.Size(18, 13);
            this.lbIDEstado.TabIndex = 5;
            this.lbIDEstado.Text = "ID";
            // 
            // TelaCadastroCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 336);
            this.Name = "TelaCadastroCidade";
            this.Text = "Cadastro de Cidades";
            this.tcCadastro.ResumeLayout(false);
            this.tpConsulta.ResumeLayout(false);
            this.tpDados.ResumeLayout(false);
            this.gbOpcoesDados.ResumeLayout(false);
            this.gbAcoes.ResumeLayout(false);
            this.gbDados.ResumeLayout(false);
            this.gbDados.PerformLayout();
            this.gbBusca.ResumeLayout(false);
            this.gbBusca.PerformLayout();
            this.gbEstado.ResumeLayout(false);
            this.gbEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox edtNome;
        private System.Windows.Forms.GroupBox gbEstado;
        private System.Windows.Forms.Label lbIDEstado;
        private System.Windows.Forms.TextBox edtIDEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtUF;
        private System.Windows.Forms.Button btnBuscaEstado;
    }
}
