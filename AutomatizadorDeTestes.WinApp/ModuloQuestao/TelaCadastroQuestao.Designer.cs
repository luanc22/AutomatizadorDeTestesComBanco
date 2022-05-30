namespace AutomatizadorDeTestes.WinApp.ModuloQuestao
{
    partial class TelaCadastroQuestao
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
            this.txtMateria = new System.Windows.Forms.Label();
            this.comboBoxMaterias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDisciplinas = new System.Windows.Forms.ComboBox();
            this.txtEnunciado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLetraAlternativa = new System.Windows.Forms.ComboBox();
            this.txtDescricaoAlternativa = new System.Windows.Forms.TextBox();
            this.btnAddAlternativa = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listAlternativas = new System.Windows.Forms.ListBox();
            this.btnExcluirAlternativa = new System.Windows.Forms.Button();
            this.comboBoxAlternativaCorreta = new System.Windows.Forms.ComboBox();
            this.groupBoxAlternativas = new System.Windows.Forms.GroupBox();
            this.groupBoxAlternativas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMateria
            // 
            this.txtMateria.AutoSize = true;
            this.txtMateria.Location = new System.Drawing.Point(45, 67);
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(50, 15);
            this.txtMateria.TabIndex = 0;
            this.txtMateria.Text = "Matéria:";
            // 
            // comboBoxMaterias
            // 
            this.comboBoxMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaterias.FormattingEnabled = true;
            this.comboBoxMaterias.Location = new System.Drawing.Point(106, 59);
            this.comboBoxMaterias.Name = "comboBoxMaterias";
            this.comboBoxMaterias.Size = new System.Drawing.Size(196, 23);
            this.comboBoxMaterias.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descrição:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(411, 479);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(330, 479);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 30);
            this.btnGravar.TabIndex = 8;
            this.btnGravar.Text = "Confirmar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Disciplina: ";
            // 
            // comboBoxDisciplinas
            // 
            this.comboBoxDisciplinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisciplinas.FormattingEnabled = true;
            this.comboBoxDisciplinas.Location = new System.Drawing.Point(106, 26);
            this.comboBoxDisciplinas.Name = "comboBoxDisciplinas";
            this.comboBoxDisciplinas.Size = new System.Drawing.Size(196, 23);
            this.comboBoxDisciplinas.TabIndex = 11;
            this.comboBoxDisciplinas.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciplinas_SelectedIndexChanged);
            // 
            // txtEnunciado
            // 
            this.txtEnunciado.Location = new System.Drawing.Point(106, 109);
            this.txtEnunciado.Multiline = true;
            this.txtEnunciado.Name = "txtEnunciado";
            this.txtEnunciado.Size = new System.Drawing.Size(347, 30);
            this.txtEnunciado.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Letra: ";
            // 
            // comboBoxLetraAlternativa
            // 
            this.comboBoxLetraAlternativa.DropDownHeight = 60;
            this.comboBoxLetraAlternativa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLetraAlternativa.DropDownWidth = 35;
            this.comboBoxLetraAlternativa.FormattingEnabled = true;
            this.comboBoxLetraAlternativa.IntegralHeight = false;
            this.comboBoxLetraAlternativa.ItemHeight = 15;
            this.comboBoxLetraAlternativa.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.comboBoxLetraAlternativa.Location = new System.Drawing.Point(49, 37);
            this.comboBoxLetraAlternativa.Name = "comboBoxLetraAlternativa";
            this.comboBoxLetraAlternativa.Size = new System.Drawing.Size(50, 23);
            this.comboBoxLetraAlternativa.TabIndex = 1;
            // 
            // txtDescricaoAlternativa
            // 
            this.txtDescricaoAlternativa.Location = new System.Drawing.Point(105, 37);
            this.txtDescricaoAlternativa.Name = "txtDescricaoAlternativa";
            this.txtDescricaoAlternativa.Size = new System.Drawing.Size(271, 23);
            this.txtDescricaoAlternativa.TabIndex = 2;
            // 
            // btnAddAlternativa
            // 
            this.btnAddAlternativa.Location = new System.Drawing.Point(382, 37);
            this.btnAddAlternativa.Name = "btnAddAlternativa";
            this.btnAddAlternativa.Size = new System.Drawing.Size(70, 23);
            this.btnAddAlternativa.TabIndex = 6;
            this.btnAddAlternativa.Text = "Adicionar";
            this.btnAddAlternativa.UseVisualStyleBackColor = true;
            this.btnAddAlternativa.Click += new System.EventHandler(this.btnAddAlternativa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Alternativa Correta: ";
            // 
            // listAlternativas
            // 
            this.listAlternativas.FormattingEnabled = true;
            this.listAlternativas.ItemHeight = 15;
            this.listAlternativas.Location = new System.Drawing.Point(11, 78);
            this.listAlternativas.Name = "listAlternativas";
            this.listAlternativas.Size = new System.Drawing.Size(441, 184);
            this.listAlternativas.TabIndex = 7;
            // 
            // btnExcluirAlternativa
            // 
            this.btnExcluirAlternativa.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluirAlternativa.Location = new System.Drawing.Point(382, 274);
            this.btnExcluirAlternativa.Name = "btnExcluirAlternativa";
            this.btnExcluirAlternativa.Size = new System.Drawing.Size(70, 23);
            this.btnExcluirAlternativa.TabIndex = 8;
            this.btnExcluirAlternativa.Text = "Excluir";
            this.btnExcluirAlternativa.UseVisualStyleBackColor = true;
            this.btnExcluirAlternativa.Click += new System.EventHandler(this.btnExcluirAlternativa_Click);
            // 
            // comboBoxAlternativaCorreta
            // 
            this.comboBoxAlternativaCorreta.DropDownHeight = 60;
            this.comboBoxAlternativaCorreta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlternativaCorreta.DropDownWidth = 35;
            this.comboBoxAlternativaCorreta.FormattingEnabled = true;
            this.comboBoxAlternativaCorreta.IntegralHeight = false;
            this.comboBoxAlternativaCorreta.ItemHeight = 15;
            this.comboBoxAlternativaCorreta.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.comboBoxAlternativaCorreta.Location = new System.Drawing.Point(129, 274);
            this.comboBoxAlternativaCorreta.Name = "comboBoxAlternativaCorreta";
            this.comboBoxAlternativaCorreta.Size = new System.Drawing.Size(50, 23);
            this.comboBoxAlternativaCorreta.TabIndex = 13;
            // 
            // groupBoxAlternativas
            // 
            this.groupBoxAlternativas.Controls.Add(this.comboBoxAlternativaCorreta);
            this.groupBoxAlternativas.Controls.Add(this.btnExcluirAlternativa);
            this.groupBoxAlternativas.Controls.Add(this.listAlternativas);
            this.groupBoxAlternativas.Controls.Add(this.label4);
            this.groupBoxAlternativas.Controls.Add(this.btnAddAlternativa);
            this.groupBoxAlternativas.Controls.Add(this.txtDescricaoAlternativa);
            this.groupBoxAlternativas.Controls.Add(this.comboBoxLetraAlternativa);
            this.groupBoxAlternativas.Controls.Add(this.label1);
            this.groupBoxAlternativas.Location = new System.Drawing.Point(21, 153);
            this.groupBoxAlternativas.Name = "groupBoxAlternativas";
            this.groupBoxAlternativas.Size = new System.Drawing.Size(465, 309);
            this.groupBoxAlternativas.TabIndex = 5;
            this.groupBoxAlternativas.TabStop = false;
            this.groupBoxAlternativas.Text = "Alternativas";
            // 
            // TelaCadastroQuestao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 521);
            this.Controls.Add(this.txtEnunciado);
            this.Controls.Add(this.comboBoxDisciplinas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.groupBoxAlternativas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMaterias);
            this.Controls.Add(this.txtMateria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroQuestao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Questão";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroQuestao_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroQuestao_Load);
            this.groupBoxAlternativas.ResumeLayout(false);
            this.groupBoxAlternativas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtMateria;
        private System.Windows.Forms.ComboBox comboBoxMaterias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDisciplinas;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLetraAlternativa;
        private System.Windows.Forms.TextBox txtDescricaoAlternativa;
        private System.Windows.Forms.Button btnAddAlternativa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listAlternativas;
        private System.Windows.Forms.Button btnExcluirAlternativa;
        private System.Windows.Forms.ComboBox comboBoxAlternativaCorreta;
        private System.Windows.Forms.GroupBox groupBoxAlternativas;
    }
}