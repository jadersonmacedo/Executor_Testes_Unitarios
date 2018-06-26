namespace Executor_Testes.Exec.For
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpCenariosTeste = new System.Windows.Forms.TabPage();
            this.trvCenarios = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tspArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tspRelatorioExecução = new System.Windows.Forms.ToolStripMenuItem();
            this.tspOpcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.tspConfigurar = new System.Windows.Forms.ToolStripMenuItem();
            this.tspCriarMassaDados = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxProjetos = new System.Windows.Forms.ComboBox();
            this.lblProjetos = new System.Windows.Forms.Label();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnCarregarCenarios = new System.Windows.Forms.Button();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.lblCenariosDeTetes = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbpCenariosTeste.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpCenariosTeste);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpCenariosTeste
            // 
            this.tbpCenariosTeste.Controls.Add(this.trvCenarios);
            this.tbpCenariosTeste.Location = new System.Drawing.Point(4, 22);
            this.tbpCenariosTeste.Name = "tbpCenariosTeste";
            this.tbpCenariosTeste.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCenariosTeste.Size = new System.Drawing.Size(748, 342);
            this.tbpCenariosTeste.TabIndex = 1;
            this.tbpCenariosTeste.Text = "Cenarios de teste";
            this.tbpCenariosTeste.UseVisualStyleBackColor = true;
            // 
            // trvCenarios
            // 
            this.trvCenarios.CheckBoxes = true;
            this.trvCenarios.Location = new System.Drawing.Point(6, 6);
            this.trvCenarios.Name = "trvCenarios";
            this.trvCenarios.Size = new System.Drawing.Size(736, 330);
            this.trvCenarios.TabIndex = 0;
            this.trvCenarios.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvExecucao_AfterCheck);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspArquivo,
            this.tspOpcoes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tspArquivo
            // 
            this.tspArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspRelatorioExecução});
            this.tspArquivo.Name = "tspArquivo";
            this.tspArquivo.Size = new System.Drawing.Size(61, 20);
            this.tspArquivo.Text = "Arquivo";
            // 
            // tspRelatorioExecução
            // 
            this.tspRelatorioExecução.Name = "tspRelatorioExecução";
            this.tspRelatorioExecução.Size = new System.Drawing.Size(173, 22);
            this.tspRelatorioExecução.Text = "Relatorio Execução";
            this.tspRelatorioExecução.Click += new System.EventHandler(this.tspRelatorioExecução_Click);
            // 
            // tspOpcoes
            // 
            this.tspOpcoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspConfigurar,
            this.tspCriarMassaDados});
            this.tspOpcoes.Name = "tspOpcoes";
            this.tspOpcoes.Size = new System.Drawing.Size(59, 20);
            this.tspOpcoes.Text = "Opções";
            // 
            // tspConfigurar
            // 
            this.tspConfigurar.Name = "tspConfigurar";
            this.tspConfigurar.Size = new System.Drawing.Size(171, 22);
            this.tspConfigurar.Text = "Configurar";
            this.tspConfigurar.Click += new System.EventHandler(this.tspConfigurar_Click);
            // 
            // tspCriarMassaDados
            // 
            this.tspCriarMassaDados.Name = "tspCriarMassaDados";
            this.tspCriarMassaDados.Size = new System.Drawing.Size(171, 22);
            this.tspCriarMassaDados.Text = "Criar Massa Dados";
            this.tspCriarMassaDados.Click += new System.EventHandler(this.tspCriarMassaDados_Click);
            // 
            // cbxProjetos
            // 
            this.cbxProjetos.FormattingEnabled = true;
            this.cbxProjetos.Location = new System.Drawing.Point(142, 419);
            this.cbxProjetos.Name = "cbxProjetos";
            this.cbxProjetos.Size = new System.Drawing.Size(221, 21);
            this.cbxProjetos.TabIndex = 2;
            // 
            // lblProjetos
            // 
            this.lblProjetos.AutoSize = true;
            this.lblProjetos.Location = new System.Drawing.Point(9, 427);
            this.lblProjetos.Name = "lblProjetos";
            this.lblProjetos.Size = new System.Drawing.Size(110, 13);
            this.lblProjetos.TabIndex = 6;
            this.lblProjetos.Text = "Projeto Automatizado:";
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(601, 418);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(167, 21);
            this.btnExecutar.TabIndex = 7;
            this.btnExecutar.Text = "Executar Cenarios";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // btnCarregarCenarios
            // 
            this.btnCarregarCenarios.Location = new System.Drawing.Point(418, 418);
            this.btnCarregarCenarios.Name = "btnCarregarCenarios";
            this.btnCarregarCenarios.Size = new System.Drawing.Size(167, 21);
            this.btnCarregarCenarios.TabIndex = 8;
            this.btnCarregarCenarios.Text = "Carregar Cenarios";
            this.btnCarregarCenarios.UseVisualStyleBackColor = true;
            this.btnCarregarCenarios.Click += new System.EventHandler(this.btnCarregarCenarios_Click);
            // 
            // pgbStatus
            // 
            this.pgbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pgbStatus.Location = new System.Drawing.Point(418, 470);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(350, 23);
            this.pgbStatus.TabIndex = 9;
            // 
            // lblCenariosDeTetes
            // 
            this.lblCenariosDeTetes.AutoSize = true;
            this.lblCenariosDeTetes.Location = new System.Drawing.Point(139, 480);
            this.lblCenariosDeTetes.Name = "lblCenariosDeTetes";
            this.lblCenariosDeTetes.Size = new System.Drawing.Size(0, 13);
            this.lblCenariosDeTetes.TabIndex = 10;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 505);
            this.Controls.Add(this.lblCenariosDeTetes);
            this.Controls.Add(this.pgbStatus);
            this.Controls.Add(this.btnCarregarCenarios);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.lblProjetos);
            this.Controls.Add(this.cbxProjetos);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.Text = "Majin  Buu";
            this.Load += new System.EventHandler(this.Home_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpCenariosTeste.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpCenariosTeste;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tspArquivo;
        private System.Windows.Forms.ComboBox cbxProjetos;
        private System.Windows.Forms.Label lblProjetos;
        private System.Windows.Forms.ToolStripMenuItem tspOpcoes;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.ToolStripMenuItem tspConfigurar;
        private System.Windows.Forms.ToolStripMenuItem tspCriarMassaDados;
        private System.Windows.Forms.TreeView trvCenarios;
        private System.Windows.Forms.ToolStripMenuItem tspRelatorioExecução;
        private System.Windows.Forms.Button btnCarregarCenarios;
        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.Label lblCenariosDeTetes;
    }
}