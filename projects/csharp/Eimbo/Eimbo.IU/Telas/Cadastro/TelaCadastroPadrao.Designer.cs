namespace Eimbo.IU.Telas.Cadastro
{
    partial class TelaCadastroPadrao//<Controlador>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
            this.teste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcCadastro = new System.Windows.Forms.TabControl();
            this.tpConsulta = new System.Windows.Forms.TabPage();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbBusca = new System.Windows.Forms.GroupBox();
            this.edtBusca = new System.Windows.Forms.TextBox();
            this.tpDados = new System.Windows.Forms.TabPage();
            this.gbDados = new System.Windows.Forms.GroupBox();
            this.chkBloqueado = new System.Windows.Forms.CheckBox();
            this.edtID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.gbOpcoesDados = new System.Windows.Forms.GroupBox();
            this.btnVolta = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.gbAcoes = new System.Windows.Forms.GroupBox();
            this.btnAltera = new System.Windows.Forms.Button();
            this.btnInclui = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.tcCadastro.SuspendLayout();
            this.tpConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gbBusca.SuspendLayout();
            this.tpDados.SuspendLayout();
            this.gbDados.SuspendLayout();
            this.gbOpcoesDados.SuspendLayout();
            this.gbAcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // teste
            // 
            this.teste.HeaderText = "teste";
            this.teste.Name = "teste";
            // 
            // tcCadastro
            // 
            this.tcCadastro.Controls.Add(this.tpConsulta);
            this.tcCadastro.Controls.Add(this.tpDados);
            this.tcCadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCadastro.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tcCadastro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcCadastro.Location = new System.Drawing.Point(0, 0);
            this.tcCadastro.Name = "tcCadastro";
            this.tcCadastro.SelectedIndex = 0;
            this.tcCadastro.Size = new System.Drawing.Size(633, 284);
            this.tcCadastro.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcCadastro.TabIndex = 5;
            this.tcCadastro.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcCadastro_DrawItem);
            this.tcCadastro.SelectedIndexChanged += new System.EventHandler(this.tcCadastro_SelectedIndexChanged);
            this.tcCadastro.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcCadastro_Selected);
            // 
            // tpConsulta
            // 
            this.tpConsulta.BackColor = System.Drawing.Color.White;
            this.tpConsulta.Controls.Add(this.dgv);
            this.tpConsulta.Controls.Add(this.gbBusca);
            this.tpConsulta.ForeColor = System.Drawing.Color.SteelBlue;
            this.tpConsulta.Location = new System.Drawing.Point(4, 22);
            this.tpConsulta.Name = "tpConsulta";
            this.tpConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsulta.Size = new System.Drawing.Size(625, 258);
            this.tpConsulta.TabIndex = 0;
            this.tpConsulta.Text = "<F1> Consulta";
            this.tpConsulta.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.White;
            this.dgv.Location = new System.Drawing.Point(3, 55);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(619, 200);
            this.dgv.TabIndex = 10;
            // 
            // gbBusca
            // 
            this.gbBusca.BackColor = System.Drawing.Color.White;
            this.gbBusca.Controls.Add(this.edtBusca);
            this.gbBusca.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbBusca.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBusca.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gbBusca.Location = new System.Drawing.Point(3, 3);
            this.gbBusca.Name = "gbBusca";
            this.gbBusca.Size = new System.Drawing.Size(619, 52);
            this.gbBusca.TabIndex = 9;
            this.gbBusca.TabStop = false;
            this.gbBusca.Text = "Buscar";
            // 
            // edtBusca
            // 
            this.edtBusca.BackColor = System.Drawing.Color.White;
            this.edtBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtBusca.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBusca.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtBusca.Location = new System.Drawing.Point(7, 19);
            this.edtBusca.Name = "edtBusca";
            this.edtBusca.Size = new System.Drawing.Size(603, 22);
            this.edtBusca.TabIndex = 0;
            this.edtBusca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtBusca_KeyUp);
            // 
            // tpDados
            // 
            this.tpDados.BackColor = System.Drawing.Color.White;
            this.tpDados.Controls.Add(this.gbDados);
            this.tpDados.Controls.Add(this.gbOpcoesDados);
            this.tpDados.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tpDados.Location = new System.Drawing.Point(4, 22);
            this.tpDados.Name = "tpDados";
            this.tpDados.Padding = new System.Windows.Forms.Padding(3);
            this.tpDados.Size = new System.Drawing.Size(625, 258);
            this.tpDados.TabIndex = 1;
            this.tpDados.Text = "<F2> Dados";
            // 
            // gbDados
            // 
            this.gbDados.Controls.Add(this.chkBloqueado);
            this.gbDados.Controls.Add(this.edtID);
            this.gbDados.Controls.Add(this.lbID);
            this.gbDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDados.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDados.Location = new System.Drawing.Point(3, 3);
            this.gbDados.Name = "gbDados";
            this.gbDados.Size = new System.Drawing.Size(619, 216);
            this.gbDados.TabIndex = 2;
            this.gbDados.TabStop = false;
            // 
            // chkBloqueado
            // 
            this.chkBloqueado.AutoSize = true;
            this.chkBloqueado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkBloqueado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBloqueado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBloqueado.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.chkBloqueado.Location = new System.Drawing.Point(3, 196);
            this.chkBloqueado.Name = "chkBloqueado";
            this.chkBloqueado.Size = new System.Drawing.Size(613, 17);
            this.chkBloqueado.TabIndex = 1;
            this.chkBloqueado.TabStop = false;
            this.chkBloqueado.Text = "Bloqueado";
            this.chkBloqueado.UseVisualStyleBackColor = true;
            this.chkBloqueado.Visible = false;
            // 
            // edtID
            // 
            this.edtID.BackColor = System.Drawing.Color.White;
            this.edtID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.edtID.Location = new System.Drawing.Point(7, 31);
            this.edtID.MaxLength = 6;
            this.edtID.Name = "edtID";
            this.edtID.ReadOnly = true;
            this.edtID.Size = new System.Drawing.Size(29, 22);
            this.edtID.TabIndex = 0;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbID.Location = new System.Drawing.Point(10, 15);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            // 
            // gbOpcoesDados
            // 
            this.gbOpcoesDados.Controls.Add(this.btnVolta);
            this.gbOpcoesDados.Controls.Add(this.btnSalva);
            this.gbOpcoesDados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbOpcoesDados.Location = new System.Drawing.Point(3, 219);
            this.gbOpcoesDados.Name = "gbOpcoesDados";
            this.gbOpcoesDados.Size = new System.Drawing.Size(619, 36);
            this.gbOpcoesDados.TabIndex = 1;
            this.gbOpcoesDados.TabStop = false;
            // 
            // btnVolta
            // 
            this.btnVolta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVolta.BackColor = System.Drawing.Color.Red;
            this.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolta.FlatAppearance.BorderSize = 0;
            this.btnVolta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnVolta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolta.ForeColor = System.Drawing.Color.White;
            this.btnVolta.Location = new System.Drawing.Point(213, 10);
            this.btnVolta.Name = "btnVolta";
            this.btnVolta.Size = new System.Drawing.Size(104, 23);
            this.btnVolta.TabIndex = 3;
            this.btnVolta.TabStop = false;
            this.btnVolta.Text = "<F1> Voltar";
            this.btnVolta.UseVisualStyleBackColor = false;
            this.btnVolta.Click += new System.EventHandler(this.btnVolta_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalva.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSalva.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalva.FlatAppearance.BorderSize = 0;
            this.btnSalva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnSalva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalva.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalva.ForeColor = System.Drawing.Color.White;
            this.btnSalva.Location = new System.Drawing.Point(324, 10);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(104, 23);
            this.btnSalva.TabIndex = 2;
            this.btnSalva.TabStop = false;
            this.btnSalva.Text = "<F6> Salvar";
            this.btnSalva.UseVisualStyleBackColor = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // gbAcoes
            // 
            this.gbAcoes.Controls.Add(this.btnAltera);
            this.gbAcoes.Controls.Add(this.btnInclui);
            this.gbAcoes.Controls.Add(this.btnFecha);
            this.gbAcoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbAcoes.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gbAcoes.Location = new System.Drawing.Point(0, 284);
            this.gbAcoes.Name = "gbAcoes";
            this.gbAcoes.Size = new System.Drawing.Size(633, 52);
            this.gbAcoes.TabIndex = 4;
            this.gbAcoes.TabStop = false;
            this.gbAcoes.Text = "Ações";
            // 
            // btnAltera
            // 
            this.btnAltera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAltera.BackColor = System.Drawing.Color.White;
            this.btnAltera.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAltera.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAltera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnAltera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnAltera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltera.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltera.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAltera.Location = new System.Drawing.Point(509, 23);
            this.btnAltera.Name = "btnAltera";
            this.btnAltera.Size = new System.Drawing.Size(118, 23);
            this.btnAltera.TabIndex = 2;
            this.btnAltera.TabStop = false;
            this.btnAltera.Text = "<F4> Alterar";
            this.btnAltera.UseVisualStyleBackColor = false;
            this.btnAltera.Click += new System.EventHandler(this.btnAltera_Click);
            // 
            // btnInclui
            // 
            this.btnInclui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInclui.BackColor = System.Drawing.Color.White;
            this.btnInclui.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnInclui.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnInclui.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnInclui.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnInclui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInclui.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInclui.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInclui.Location = new System.Drawing.Point(381, 23);
            this.btnInclui.Name = "btnInclui";
            this.btnInclui.Size = new System.Drawing.Size(120, 23);
            this.btnInclui.TabIndex = 1;
            this.btnInclui.TabStop = false;
            this.btnInclui.Text = "<F3> Incluir";
            this.btnInclui.UseVisualStyleBackColor = false;
            this.btnInclui.Click += new System.EventHandler(this.btnInclui_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFecha.BackColor = System.Drawing.Color.Red;
            this.btnFecha.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFecha.FlatAppearance.BorderSize = 0;
            this.btnFecha.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnFecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecha.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecha.ForeColor = System.Drawing.Color.White;
            this.btnFecha.Location = new System.Drawing.Point(14, 23);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(120, 23);
            this.btnFecha.TabIndex = 0;
            this.btnFecha.TabStop = false;
            this.btnFecha.Text = "<ESC> Fechar";
            this.btnFecha.UseVisualStyleBackColor = false;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // TelaCadastroPadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 336);
            this.ControlBox = false;
            this.Controls.Add(this.tcCadastro);
            this.Controls.Add(this.gbAcoes);
            this.Name = "TelaCadastroPadrao";
            this.Text = "Cadastro Padrão";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TelaCadastroPadrao_Paint);
            this.tcCadastro.ResumeLayout(false);
            this.tpConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gbBusca.ResumeLayout(false);
            this.gbBusca.PerformLayout();
            this.tpDados.ResumeLayout(false);
            this.gbDados.ResumeLayout(false);
            this.gbDados.PerformLayout();
            this.gbOpcoesDados.ResumeLayout(false);
            this.gbAcoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TabControl tcCadastro;
        protected System.Windows.Forms.TabPage tpConsulta;
        protected System.Windows.Forms.TabPage tpDados;
        protected System.Windows.Forms.GroupBox gbOpcoesDados;
        protected System.Windows.Forms.Button btnVolta;
        protected System.Windows.Forms.Button btnSalva;
        protected System.Windows.Forms.GroupBox gbAcoes;
        protected System.Windows.Forms.Button btnAltera;
        protected System.Windows.Forms.Button btnInclui;
        protected System.Windows.Forms.Button btnFecha;
        protected System.Windows.Forms.GroupBox gbDados;
        protected System.Windows.Forms.Label lbID;
        protected System.Windows.Forms.TextBox edtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn teste;
        protected System.Windows.Forms.DataGridView dgv;
        protected System.Windows.Forms.GroupBox gbBusca;
        protected System.Windows.Forms.TextBox edtBusca;
        protected System.Windows.Forms.CheckBox chkBloqueado;
    }
}