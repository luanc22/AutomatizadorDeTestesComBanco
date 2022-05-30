namespace AutomatizadorDeTestes.WinApp.ModuloTeste
{
    partial class TelaCadastroTeste
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTituloTeste = new System.Windows.Forms.TextBox();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.comboBoxMateria = new System.Windows.Forms.ComboBox();
            this.numQuestoes = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnSortearQuestoes = new System.Windows.Forms.Button();
            this.groupBoxQuestoesSorteadas = new System.Windows.Forms.GroupBox();
            this.listBoxQuestoes = new System.Windows.Forms.ListBox();
            this.checkBoxProvaRecuperacao = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestoes)).BeginInit();
            this.groupBoxQuestoesSorteadas.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Disciplina: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Matéria: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantidade de Questões: ";
            // 
            // txtTituloTeste
            // 
            this.txtTituloTeste.Location = new System.Drawing.Point(95, 34);
            this.txtTituloTeste.Name = "txtTituloTeste";
            this.txtTituloTeste.Size = new System.Drawing.Size(273, 23);
            this.txtTituloTeste.TabIndex = 4;
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(95, 75);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(161, 23);
            this.comboBoxDisciplina.TabIndex = 5;
            this.comboBoxDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedIndexChanged);
            // 
            // comboBoxMateria
            // 
            this.comboBoxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateria.FormattingEnabled = true;
            this.comboBoxMateria.Location = new System.Drawing.Point(95, 116);
            this.comboBoxMateria.Name = "comboBoxMateria";
            this.comboBoxMateria.Size = new System.Drawing.Size(273, 23);
            this.comboBoxMateria.TabIndex = 6;
            this.comboBoxMateria.SelectedIndexChanged += new System.EventHandler(this.comboBoxMateria_SelectedIndexChanged);
            // 
            // numQuestoes
            // 
            this.numQuestoes.Enabled = false;
            this.numQuestoes.Location = new System.Drawing.Point(177, 170);
            this.numQuestoes.Name = "numQuestoes";
            this.numQuestoes.Size = new System.Drawing.Size(51, 23);
            this.numQuestoes.TabIndex = 7;
            this.numQuestoes.ValueChanged += new System.EventHandler(this.numQuestoes_ValueChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(345, 478);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(264, 478);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 30);
            this.btnGravar.TabIndex = 9;
            this.btnGravar.Text = "Confirmar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnSortearQuestoes
            // 
            this.btnSortearQuestoes.Enabled = false;
            this.btnSortearQuestoes.Location = new System.Drawing.Point(31, 441);
            this.btnSortearQuestoes.Name = "btnSortearQuestoes";
            this.btnSortearQuestoes.Size = new System.Drawing.Size(116, 30);
            this.btnSortearQuestoes.TabIndex = 11;
            this.btnSortearQuestoes.Text = "Sortear Questões";
            this.btnSortearQuestoes.UseVisualStyleBackColor = true;
            this.btnSortearQuestoes.Click += new System.EventHandler(this.btnSortearQuestoes_Click);
            // 
            // groupBoxQuestoesSorteadas
            // 
            this.groupBoxQuestoesSorteadas.Controls.Add(this.listBoxQuestoes);
            this.groupBoxQuestoesSorteadas.Location = new System.Drawing.Point(25, 199);
            this.groupBoxQuestoesSorteadas.Name = "groupBoxQuestoesSorteadas";
            this.groupBoxQuestoesSorteadas.Size = new System.Drawing.Size(395, 239);
            this.groupBoxQuestoesSorteadas.TabIndex = 13;
            this.groupBoxQuestoesSorteadas.TabStop = false;
            this.groupBoxQuestoesSorteadas.Text = "Questões Sorteadas";
            // 
            // listBoxQuestoes
            // 
            this.listBoxQuestoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxQuestoes.FormattingEnabled = true;
            this.listBoxQuestoes.ItemHeight = 15;
            this.listBoxQuestoes.Location = new System.Drawing.Point(3, 19);
            this.listBoxQuestoes.Name = "listBoxQuestoes";
            this.listBoxQuestoes.Size = new System.Drawing.Size(389, 217);
            this.listBoxQuestoes.TabIndex = 0;
            // 
            // checkBoxProvaRecuperacao
            // 
            this.checkBoxProvaRecuperacao.AutoSize = true;
            this.checkBoxProvaRecuperacao.Enabled = false;
            this.checkBoxProvaRecuperacao.Location = new System.Drawing.Point(274, 79);
            this.checkBoxProvaRecuperacao.Name = "checkBoxProvaRecuperacao";
            this.checkBoxProvaRecuperacao.Size = new System.Drawing.Size(143, 19);
            this.checkBoxProvaRecuperacao.TabIndex = 14;
            this.checkBoxProvaRecuperacao.Text = "Prova de Recuperação";
            this.checkBoxProvaRecuperacao.UseVisualStyleBackColor = true;
            this.checkBoxProvaRecuperacao.CheckedChanged += new System.EventHandler(this.checkBoxProvaRecuperacao_CheckedChanged);
            // 
            // TelaCadastroTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 520);
            this.Controls.Add(this.checkBoxProvaRecuperacao);
            this.Controls.Add(this.groupBoxQuestoesSorteadas);
            this.Controls.Add(this.btnSortearQuestoes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.numQuestoes);
            this.Controls.Add(this.comboBoxMateria);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.txtTituloTeste);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroTeste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Testes Aleatórios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroTeste_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroTeste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuestoes)).EndInit();
            this.groupBoxQuestoesSorteadas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTituloTeste;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.ComboBox comboBoxMateria;
        private System.Windows.Forms.NumericUpDown numQuestoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnSortearQuestoes;
        private System.Windows.Forms.GroupBox groupBoxQuestoesSorteadas;
        private System.Windows.Forms.ListBox listBoxQuestoes;
        private System.Windows.Forms.CheckBox checkBoxProvaRecuperacao;
    }
}