namespace AutomatizadorDeTestes.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questoesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnDuplicar = new System.Windows.Forms.ToolStripButton();
            this.btnGerarPdf = new System.Windows.Forms.ToolStripButton();
            this.barraRodape = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.labelTipoCadastro = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.barraRodape.SuspendLayout();
            this.panelRegistros.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testesMenuItem,
            this.questoesMenuItem,
            this.materiaMenuItem,
            this.disciplinasMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // testesMenuItem
            // 
            this.testesMenuItem.Name = "testesMenuItem";
            this.testesMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testesMenuItem.Text = "Testes";
            this.testesMenuItem.Click += new System.EventHandler(this.testesMenuItem_Click);
            // 
            // questoesMenuItem
            // 
            this.questoesMenuItem.Name = "questoesMenuItem";
            this.questoesMenuItem.Size = new System.Drawing.Size(180, 22);
            this.questoesMenuItem.Text = "Questões";
            this.questoesMenuItem.Click += new System.EventHandler(this.questoesMenuItem_Click);
            // 
            // materiaMenuItem
            // 
            this.materiaMenuItem.Name = "materiaMenuItem";
            this.materiaMenuItem.Size = new System.Drawing.Size(180, 22);
            this.materiaMenuItem.Text = "Matérias";
            this.materiaMenuItem.Click += new System.EventHandler(this.materiaMenuItem_Click);
            // 
            // disciplinasMenuItem
            // 
            this.disciplinasMenuItem.Name = "disciplinasMenuItem";
            this.disciplinasMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disciplinasMenuItem.Text = "Disciplinas";
            this.disciplinasMenuItem.Click += new System.EventHandler(this.disciplinasMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir,
            this.btnDuplicar,
            this.btnGerarPdf});
            this.toolStrip.Location = new System.Drawing.Point(0, 50);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            this.toolStrip.Visible = false;
            // 
            // btnInserir
            // 
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInserir.Image = global::AutomatizadorDeTestes.WinApp.Properties.Resources.add_box_FILL0_wght400_GRAD0_opsz48;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(23, 22);
            this.btnInserir.Text = "toolStripButton1";
            this.btnInserir.ToolTipText = "Inserir";
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::AutomatizadorDeTestes.WinApp.Properties.Resources.edit_FILL0_wght400_GRAD0_opsz48;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(23, 22);
            this.btnEditar.Text = "toolStripButton2";
            this.btnEditar.ToolTipText = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Image = global::AutomatizadorDeTestes.WinApp.Properties.Resources.delete_FILL0_wght400_GRAD0_opsz48;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(23, 22);
            this.btnExcluir.Text = "toolStripButton3";
            this.btnExcluir.ToolTipText = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnDuplicar
            // 
            this.btnDuplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDuplicar.Image = global::AutomatizadorDeTestes.WinApp.Properties.Resources.copy_all_FILL0_wght400_GRAD0_opsz48;
            this.btnDuplicar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicar.Name = "btnDuplicar";
            this.btnDuplicar.Size = new System.Drawing.Size(23, 22);
            this.btnDuplicar.Text = "Clonar";
            this.btnDuplicar.Click += new System.EventHandler(this.btnDuplicar_Click);
            // 
            // btnGerarPdf
            // 
            this.btnGerarPdf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGerarPdf.Image = global::AutomatizadorDeTestes.WinApp.Properties.Resources.picture_as_pdf_FILL0_wght400_GRAD0_opsz48;
            this.btnGerarPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGerarPdf.Name = "btnGerarPdf";
            this.btnGerarPdf.Size = new System.Drawing.Size(23, 22);
            this.btnGerarPdf.Text = "PDF";
            this.btnGerarPdf.Click += new System.EventHandler(this.btnGerarPdf_Click);
            // 
            // barraRodape
            // 
            this.barraRodape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtRodape});
            this.barraRodape.Location = new System.Drawing.Point(0, 428);
            this.barraRodape.Name = "barraRodape";
            this.barraRodape.Size = new System.Drawing.Size(800, 22);
            this.barraRodape.TabIndex = 5;
            this.barraRodape.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // txtRodape
            // 
            this.txtRodape.Name = "txtRodape";
            this.txtRodape.Size = new System.Drawing.Size(52, 17);
            this.txtRodape.Text = "[rodape]";
            // 
            // panelRegistros
            // 
            this.panelRegistros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelRegistros.Controls.Add(this.labelTipoCadastro);
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 24);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(800, 404);
            this.panelRegistros.TabIndex = 4;
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.AutoSize = true;
            this.labelTipoCadastro.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTipoCadastro.Location = new System.Drawing.Point(570, 368);
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(218, 25);
            this.labelTipoCadastro.TabIndex = 6;
            this.labelTipoCadastro.Text = "Automatizador de Testes";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.barraRodape);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaPrincipalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "           Automatizador de Testes da Dona Mariana         ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.barraRodape.ResumeLayout(false);
            this.barraRodape.PerformLayout();
            this.panelRegistros.ResumeLayout(false);
            this.panelRegistros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questoesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinasMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.StatusStrip barraRodape;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtRodape;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripButton btnDuplicar;
        private System.Windows.Forms.ToolStripButton btnGerarPdf;
        private System.Windows.Forms.Label labelTipoCadastro;
    }
}
