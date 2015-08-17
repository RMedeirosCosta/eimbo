namespace IU.Telas
{
    partial class TelaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInicial));
            this.ssDataAberturaCaixaDivergeDiaAtual = new System.Windows.Forms.StatusStrip();
            this.tsslDataAberturaDivergenteDiaAtual = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbFechar = new System.Windows.Forms.Label();
            this.lbFinanceiro = new System.Windows.Forms.Label();
            this.lbAtendimento = new System.Windows.Forms.Label();
            this.lbServicos = new System.Windows.Forms.Label();
            this.lbClientes = new System.Windows.Forms.Label();
            this.btnFinanceiro = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnAtendimento = new System.Windows.Forms.Button();
            this.btnServicos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.lbVersao = new System.Windows.Forms.Label();
            this.msInicial = new System.Windows.Forms.MenuStrip();
            this.mItFinanceiro = new System.Windows.Forms.ToolStripMenuItem();
            this.mItAtendimentos = new System.Windows.Forms.ToolStripMenuItem();
            this.novoAtendimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirNovoCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reabrirÚltimoCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaSeparador1toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.sangriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reforçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaSeparador2toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saldoDoCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldoDetalhadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extratoDoCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaSeparador3toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.fecharCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.cidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasDePagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssDataAberturaCaixaDivergeDiaAtual.SuspendLayout();
            this.msInicial.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssDataAberturaCaixaDivergeDiaAtual
            // 
            this.ssDataAberturaCaixaDivergeDiaAtual.BackColor = System.Drawing.Color.SteelBlue;
            this.ssDataAberturaCaixaDivergeDiaAtual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ssDataAberturaCaixaDivergeDiaAtual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ssDataAberturaCaixaDivergeDiaAtual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslDataAberturaDivergenteDiaAtual});
            this.ssDataAberturaCaixaDivergeDiaAtual.Location = new System.Drawing.Point(0, 592);
            this.ssDataAberturaCaixaDivergeDiaAtual.Name = "ssDataAberturaCaixaDivergeDiaAtual";
            this.ssDataAberturaCaixaDivergeDiaAtual.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssDataAberturaCaixaDivergeDiaAtual.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ssDataAberturaCaixaDivergeDiaAtual.Size = new System.Drawing.Size(989, 22);
            this.ssDataAberturaCaixaDivergeDiaAtual.TabIndex = 18;
            // 
            // tsslDataAberturaDivergenteDiaAtual
            // 
            this.tsslDataAberturaDivergenteDiaAtual.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tsslDataAberturaDivergenteDiaAtual.ForeColor = System.Drawing.Color.Yellow;
            this.tsslDataAberturaDivergenteDiaAtual.Name = "tsslDataAberturaDivergenteDiaAtual";
            this.tsslDataAberturaDivergenteDiaAtual.Size = new System.Drawing.Size(972, 17);
            this.tsslDataAberturaDivergenteDiaAtual.Spring = true;
            this.tsslDataAberturaDivergenteDiaAtual.Text = "ATENÇÃO! A data de abertura do caixa diverge do dia atual.";
            this.tsslDataAberturaDivergenteDiaAtual.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsslDataAberturaDivergenteDiaAtual.ToolTipText = "O correto é abrir um caixa por dia!";
            // 
            // lbFechar
            // 
            this.lbFechar.AutoSize = true;
            this.lbFechar.BackColor = System.Drawing.Color.Transparent;
            this.lbFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbFechar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbFechar.Location = new System.Drawing.Point(890, 110);
            this.lbFechar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFechar.Name = "lbFechar";
            this.lbFechar.Size = new System.Drawing.Size(79, 13);
            this.lbFechar.TabIndex = 16;
            this.lbFechar.Text = "<ESC> Fechar";
            // 
            // lbFinanceiro
            // 
            this.lbFinanceiro.AutoSize = true;
            this.lbFinanceiro.BackColor = System.Drawing.Color.Transparent;
            this.lbFinanceiro.Enabled = false;
            this.lbFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbFinanceiro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinanceiro.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbFinanceiro.Location = new System.Drawing.Point(641, 110);
            this.lbFinanceiro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFinanceiro.Name = "lbFinanceiro";
            this.lbFinanceiro.Size = new System.Drawing.Size(92, 13);
            this.lbFinanceiro.TabIndex = 15;
            this.lbFinanceiro.Text = "<F4> Financeiro";
            this.lbFinanceiro.Visible = false;
            // 
            // lbAtendimento
            // 
            this.lbAtendimento.AutoSize = true;
            this.lbAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.lbAtendimento.Enabled = false;
            this.lbAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbAtendimento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAtendimento.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbAtendimento.Location = new System.Drawing.Point(523, 110);
            this.lbAtendimento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAtendimento.Name = "lbAtendimento";
            this.lbAtendimento.Size = new System.Drawing.Size(107, 13);
            this.lbAtendimento.TabIndex = 14;
            this.lbAtendimento.Text = "<F3> Atendimento";
            // 
            // lbServicos
            // 
            this.lbServicos.AutoSize = true;
            this.lbServicos.BackColor = System.Drawing.Color.Transparent;
            this.lbServicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbServicos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServicos.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbServicos.Location = new System.Drawing.Point(425, 110);
            this.lbServicos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbServicos.Name = "lbServicos";
            this.lbServicos.Size = new System.Drawing.Size(80, 13);
            this.lbServicos.TabIndex = 13;
            this.lbServicos.Text = "<F2> Serviços";
            // 
            // lbClientes
            // 
            this.lbClientes.AutoSize = true;
            this.lbClientes.BackColor = System.Drawing.Color.Transparent;
            this.lbClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbClientes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientes.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbClientes.Location = new System.Drawing.Point(311, 110);
            this.lbClientes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbClientes.Name = "lbClientes";
            this.lbClientes.Size = new System.Drawing.Size(79, 13);
            this.lbClientes.TabIndex = 11;
            this.lbClientes.Text = "<F1> Clientes";
            // 
            // btnFinanceiro
            // 
            this.btnFinanceiro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinanceiro.BackColor = System.Drawing.Color.Transparent;
            this.btnFinanceiro.Enabled = false;
            this.btnFinanceiro.FlatAppearance.BorderSize = 0;
            this.btnFinanceiro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFinanceiro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanceiro.ForeColor = System.Drawing.Color.White;
            this.btnFinanceiro.Image = global::Eimbo.IU.Properties.Resources.FTP;
            this.btnFinanceiro.Location = new System.Drawing.Point(655, 33);
            this.btnFinanceiro.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(64, 64);
            this.btnFinanceiro.TabIndex = 10;
            this.btnFinanceiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFinanceiro.UseVisualStyleBackColor = false;
            this.btnFinanceiro.Visible = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.ForeColor = System.Drawing.Color.DarkGray;
            this.btnFechar.Image = global::Eimbo.IU.Properties.Resources.Turn_off;
            this.btnFechar.Location = new System.Drawing.Point(897, 33);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(64, 64);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnAtendimento
            // 
            this.btnAtendimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.btnAtendimento.Enabled = false;
            this.btnAtendimento.FlatAppearance.BorderSize = 0;
            this.btnAtendimento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAtendimento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtendimento.ForeColor = System.Drawing.Color.White;
            this.btnAtendimento.Image = global::Eimbo.IU.Properties.Resources.Powerpoint;
            this.btnAtendimento.Location = new System.Drawing.Point(544, 33);
            this.btnAtendimento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAtendimento.Name = "btnAtendimento";
            this.btnAtendimento.Size = new System.Drawing.Size(64, 64);
            this.btnAtendimento.TabIndex = 8;
            this.btnAtendimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtendimento.UseVisualStyleBackColor = false;
            this.btnAtendimento.Click += new System.EventHandler(this.btnAtendimento_Click);
            // 
            // btnServicos
            // 
            this.btnServicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServicos.BackColor = System.Drawing.Color.Transparent;
            this.btnServicos.FlatAppearance.BorderSize = 0;
            this.btnServicos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnServicos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnServicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicos.ForeColor = System.Drawing.Color.White;
            this.btnServicos.Image = global::Eimbo.IU.Properties.Resources.Gimp;
            this.btnServicos.Location = new System.Drawing.Point(433, 33);
            this.btnServicos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnServicos.Name = "btnServicos";
            this.btnServicos.Size = new System.Drawing.Size(64, 64);
            this.btnServicos.TabIndex = 6;
            this.btnServicos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnServicos.UseVisualStyleBackColor = false;
            this.btnServicos.Click += new System.EventHandler(this.btnServicos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.Location = new System.Drawing.Point(322, 33);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(64, 64);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // lbVersao
            // 
            this.lbVersao.AutoSize = true;
            this.lbVersao.BackColor = System.Drawing.Color.Transparent;
            this.lbVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersao.ForeColor = System.Drawing.Color.LightGray;
            this.lbVersao.Location = new System.Drawing.Point(70, 541);
            this.lbVersao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbVersao.Name = "lbVersao";
            this.lbVersao.Size = new System.Drawing.Size(180, 31);
            this.lbVersao.TabIndex = 0;
            this.lbVersao.Text = "Versão x.xxxx";
            // 
            // msInicial
            // 
            this.msInicial.BackColor = System.Drawing.Color.Transparent;
            this.msInicial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItFinanceiro,
            this.mItAtendimentos,
            this.mItCaixa,
            this.mItCadastros});
            this.msInicial.Location = new System.Drawing.Point(0, 0);
            this.msInicial.Name = "msInicial";
            this.msInicial.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msInicial.Size = new System.Drawing.Size(989, 24);
            this.msInicial.TabIndex = 1;
            // 
            // mItFinanceiro
            // 
            this.mItFinanceiro.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mItFinanceiro.Enabled = false;
            this.mItFinanceiro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mItFinanceiro.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.mItFinanceiro.Name = "mItFinanceiro";
            this.mItFinanceiro.Size = new System.Drawing.Size(94, 20);
            this.mItFinanceiro.Text = "&4 - Financeiro";
            this.mItFinanceiro.Visible = false;
            // 
            // mItAtendimentos
            // 
            this.mItAtendimentos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mItAtendimentos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoAtendimentoToolStripMenuItem});
            this.mItAtendimentos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mItAtendimentos.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.mItAtendimentos.Name = "mItAtendimentos";
            this.mItAtendimentos.Size = new System.Drawing.Size(116, 20);
            this.mItAtendimentos.Text = "&3 - Atendimentos";
            // 
            // novoAtendimentoToolStripMenuItem
            // 
            this.novoAtendimentoToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.novoAtendimentoToolStripMenuItem.Name = "novoAtendimentoToolStripMenuItem";
            this.novoAtendimentoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.novoAtendimentoToolStripMenuItem.Text = "Novo Atendimento";
            this.novoAtendimentoToolStripMenuItem.Click += new System.EventHandler(this.novoAtendimentoToolStripMenuItem_Click);
            // 
            // mItCaixa
            // 
            this.mItCaixa.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mItCaixa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirNovoCaixaToolStripMenuItem,
            this.reabrirÚltimoCaixaToolStripMenuItem,
            this.caixaSeparador1toolStripSeparator,
            this.sangriaToolStripMenuItem,
            this.reforçoToolStripMenuItem,
            this.caixaSeparador2toolStripSeparator,
            this.saldoDoCaixaToolStripMenuItem,
            this.saldoDetalhadoToolStripMenuItem,
            this.extratoDoCaixaToolStripMenuItem,
            this.caixaSeparador3toolStripSeparator,
            this.fecharCaixaToolStripMenuItem});
            this.mItCaixa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mItCaixa.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.mItCaixa.Name = "mItCaixa";
            this.mItCaixa.Size = new System.Drawing.Size(66, 20);
            this.mItCaixa.Text = "&2 - Caixa";
            // 
            // abrirNovoCaixaToolStripMenuItem
            // 
            this.abrirNovoCaixaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.abrirNovoCaixaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.abrirNovoCaixaToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.abrirNovoCaixaToolStripMenuItem.Name = "abrirNovoCaixaToolStripMenuItem";
            this.abrirNovoCaixaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.abrirNovoCaixaToolStripMenuItem.Text = "Abrir Novo Caixa";
            this.abrirNovoCaixaToolStripMenuItem.Click += new System.EventHandler(this.abrirNovoCaixaToolStripMenuItem_Click);
            // 
            // reabrirÚltimoCaixaToolStripMenuItem
            // 
            this.reabrirÚltimoCaixaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.reabrirÚltimoCaixaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.reabrirÚltimoCaixaToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.reabrirÚltimoCaixaToolStripMenuItem.Name = "reabrirÚltimoCaixaToolStripMenuItem";
            this.reabrirÚltimoCaixaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reabrirÚltimoCaixaToolStripMenuItem.Text = "Reabrir Último Caixa";
            this.reabrirÚltimoCaixaToolStripMenuItem.Click += new System.EventHandler(this.reabrirÚltimoCaixaToolStripMenuItem_Click);
            // 
            // caixaSeparador1toolStripSeparator
            // 
            this.caixaSeparador1toolStripSeparator.BackColor = System.Drawing.Color.White;
            this.caixaSeparador1toolStripSeparator.ForeColor = System.Drawing.Color.RoyalBlue;
            this.caixaSeparador1toolStripSeparator.Name = "caixaSeparador1toolStripSeparator";
            this.caixaSeparador1toolStripSeparator.Size = new System.Drawing.Size(185, 6);
            // 
            // sangriaToolStripMenuItem
            // 
            this.sangriaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.sangriaToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.sangriaToolStripMenuItem.Name = "sangriaToolStripMenuItem";
            this.sangriaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.sangriaToolStripMenuItem.Text = "- Sangria";
            this.sangriaToolStripMenuItem.Click += new System.EventHandler(this.sangriaToolStripMenuItem_Click);
            // 
            // reforçoToolStripMenuItem
            // 
            this.reforçoToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.reforçoToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.reforçoToolStripMenuItem.Name = "reforçoToolStripMenuItem";
            this.reforçoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reforçoToolStripMenuItem.Text = "+ Reforço";
            this.reforçoToolStripMenuItem.Click += new System.EventHandler(this.reforçoToolStripMenuItem_Click);
            // 
            // caixaSeparador2toolStripSeparator
            // 
            this.caixaSeparador2toolStripSeparator.BackColor = System.Drawing.Color.White;
            this.caixaSeparador2toolStripSeparator.ForeColor = System.Drawing.Color.RoyalBlue;
            this.caixaSeparador2toolStripSeparator.Name = "caixaSeparador2toolStripSeparator";
            this.caixaSeparador2toolStripSeparator.Size = new System.Drawing.Size(185, 6);
            // 
            // saldoDoCaixaToolStripMenuItem
            // 
            this.saldoDoCaixaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saldoDoCaixaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.saldoDoCaixaToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.saldoDoCaixaToolStripMenuItem.Name = "saldoDoCaixaToolStripMenuItem";
            this.saldoDoCaixaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saldoDoCaixaToolStripMenuItem.Text = "Saldo do Caixa";
            this.saldoDoCaixaToolStripMenuItem.Click += new System.EventHandler(this.saldoDoCaixaToolStripMenuItem_Click);
            // 
            // saldoDetalhadoToolStripMenuItem
            // 
            this.saldoDetalhadoToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saldoDetalhadoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.saldoDetalhadoToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.saldoDetalhadoToolStripMenuItem.Name = "saldoDetalhadoToolStripMenuItem";
            this.saldoDetalhadoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saldoDetalhadoToolStripMenuItem.Text = "Saldo Detalhado";
            this.saldoDetalhadoToolStripMenuItem.Click += new System.EventHandler(this.saldoDetalhadoToolStripMenuItem_Click);
            // 
            // extratoDoCaixaToolStripMenuItem
            // 
            this.extratoDoCaixaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.extratoDoCaixaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.extratoDoCaixaToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.extratoDoCaixaToolStripMenuItem.Name = "extratoDoCaixaToolStripMenuItem";
            this.extratoDoCaixaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.extratoDoCaixaToolStripMenuItem.Text = "Extrato do Caixa";
            this.extratoDoCaixaToolStripMenuItem.Click += new System.EventHandler(this.extratoDoCaixaToolStripMenuItem_Click);
            // 
            // caixaSeparador3toolStripSeparator
            // 
            this.caixaSeparador3toolStripSeparator.BackColor = System.Drawing.Color.White;
            this.caixaSeparador3toolStripSeparator.ForeColor = System.Drawing.Color.RoyalBlue;
            this.caixaSeparador3toolStripSeparator.Name = "caixaSeparador3toolStripSeparator";
            this.caixaSeparador3toolStripSeparator.Size = new System.Drawing.Size(185, 6);
            // 
            // fecharCaixaToolStripMenuItem
            // 
            this.fecharCaixaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.fecharCaixaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.fecharCaixaToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.fecharCaixaToolStripMenuItem.Name = "fecharCaixaToolStripMenuItem";
            this.fecharCaixaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.fecharCaixaToolStripMenuItem.Text = "Fechar Caixa";
            this.fecharCaixaToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // mItCadastros
            // 
            this.mItCadastros.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mItCadastros.BackColor = System.Drawing.Color.White;
            this.mItCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cidadesToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.empresasToolStripMenuItem,
            this.estadoToolStripMenuItem,
            this.formasDePagamentoToolStripMenuItem,
            this.servicosToolStripMenuItem});
            this.mItCadastros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mItCadastros.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.mItCadastros.Name = "mItCadastros";
            this.mItCadastros.Size = new System.Drawing.Size(90, 20);
            this.mItCadastros.Text = "&1 - Cadastros";
            // 
            // cidadesToolStripMenuItem
            // 
            this.cidadesToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.cidadesToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.cidadesToolStripMenuItem.Name = "cidadesToolStripMenuItem";
            this.cidadesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.cidadesToolStripMenuItem.Text = "Cidades";
            this.cidadesToolStripMenuItem.Click += new System.EventHandler(this.cidadesToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // empresasToolStripMenuItem
            // 
            this.empresasToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.empresasToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
            this.empresasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.empresasToolStripMenuItem.Text = "Empresa";
            this.empresasToolStripMenuItem.Click += new System.EventHandler(this.empresasToolStripMenuItem_Click);
            // 
            // estadoToolStripMenuItem
            // 
            this.estadoToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.estadoToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.estadoToolStripMenuItem.Name = "estadoToolStripMenuItem";
            this.estadoToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.estadoToolStripMenuItem.Text = "Estados";
            this.estadoToolStripMenuItem.Click += new System.EventHandler(this.estadoToolStripMenuItem_Click);
            // 
            // formasDePagamentoToolStripMenuItem
            // 
            this.formasDePagamentoToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.formasDePagamentoToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.formasDePagamentoToolStripMenuItem.Name = "formasDePagamentoToolStripMenuItem";
            this.formasDePagamentoToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.formasDePagamentoToolStripMenuItem.Text = "Formas de Pagamento";
            this.formasDePagamentoToolStripMenuItem.Click += new System.EventHandler(this.formasDePagamentoToolStripMenuItem_Click);
            // 
            // servicosToolStripMenuItem
            // 
            this.servicosToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.servicosToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.servicosToolStripMenuItem.Name = "servicosToolStripMenuItem";
            this.servicosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.servicosToolStripMenuItem.Text = "Serviços";
            this.servicosToolStripMenuItem.Click += new System.EventHandler(this.servicosToolStripMenuItem_Click);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Eimbo.IU.Properties.Resources.Inicial;
            this.ClientSize = new System.Drawing.Size(989, 614);
            this.Controls.Add(this.ssDataAberturaCaixaDivergeDiaAtual);
            this.Controls.Add(this.lbFechar);
            this.Controls.Add(this.lbFinanceiro);
            this.Controls.Add(this.lbAtendimento);
            this.Controls.Add(this.lbServicos);
            this.Controls.Add(this.lbClientes);
            this.Controls.Add(this.btnFinanceiro);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnAtendimento);
            this.Controls.Add(this.btnServicos);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.lbVersao);
            this.Controls.Add(this.msInicial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msInicial;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TelaInicial";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaInicial_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TelaInicial_KeyDown);
            this.ssDataAberturaCaixaDivergeDiaAtual.ResumeLayout(false);
            this.ssDataAberturaCaixaDivergeDiaAtual.PerformLayout();
            this.msInicial.ResumeLayout(false);
            this.msInicial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVersao;
        private System.Windows.Forms.MenuStrip msInicial;
        private System.Windows.Forms.ToolStripMenuItem mItFinanceiro;
        private System.Windows.Forms.ToolStripMenuItem mItCaixa;
        private System.Windows.Forms.ToolStripMenuItem mItAtendimentos;
        private System.Windows.Forms.ToolStripMenuItem mItCadastros;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnServicos;
        private System.Windows.Forms.Button btnAtendimento;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnFinanceiro;
        private System.Windows.Forms.Label lbClientes;
        private System.Windows.Forms.Label lbServicos;
        private System.Windows.Forms.Label lbAtendimento;
        private System.Windows.Forms.Label lbFinanceiro;
        private System.Windows.Forms.Label lbFechar;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empresasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasDePagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirNovoCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reabrirÚltimoCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator caixaSeparador1toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem sangriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reforçoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator caixaSeparador2toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saldoDoCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldoDetalhadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extratoDoCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator caixaSeparador3toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem fecharCaixaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssDataAberturaCaixaDivergeDiaAtual;
        private System.Windows.Forms.ToolStripStatusLabel tsslDataAberturaDivergenteDiaAtual;
        private System.Windows.Forms.ToolStripMenuItem novoAtendimentoToolStripMenuItem;
    }
}