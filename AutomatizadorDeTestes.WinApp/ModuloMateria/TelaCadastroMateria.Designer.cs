namespace AutomatizadorDeTestes.WinApp.ModuloMateria
{
    partial class TelaCadastroMateria
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
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeMateria = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.radioButton1serie = new System.Windows.Forms.RadioButton();
            this.radioButton2serie = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disciplina:";
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(88, 24);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(184, 23);
            this.comboBoxDisciplina.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Série: ";
            // 
            // txtNomeMateria
            // 
            this.txtNomeMateria.Location = new System.Drawing.Point(88, 72);
            this.txtNomeMateria.Name = "txtNomeMateria";
            this.txtNomeMateria.Size = new System.Drawing.Size(264, 23);
            this.txtNomeMateria.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(272, 152);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 32);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(192, 152);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(72, 32);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Confirmar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // radioButton1serie
            // 
            this.radioButton1serie.AutoSize = true;
            this.radioButton1serie.Location = new System.Drawing.Point(88, 132);
            this.radioButton1serie.Name = "radioButton1serie";
            this.radioButton1serie.Size = new System.Drawing.Size(36, 19);
            this.radioButton1serie.TabIndex = 8;
            this.radioButton1serie.TabStop = true;
            this.radioButton1serie.Text = "1º";
            this.radioButton1serie.UseVisualStyleBackColor = true;
            // 
            // radioButton2serie
            // 
            this.radioButton2serie.AutoSize = true;
            this.radioButton2serie.Location = new System.Drawing.Point(136, 132);
            this.radioButton2serie.Name = "radioButton2serie";
            this.radioButton2serie.Size = new System.Drawing.Size(36, 19);
            this.radioButton2serie.TabIndex = 9;
            this.radioButton2serie.TabStop = true;
            this.radioButton2serie.Text = "2º";
            this.radioButton2serie.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 200);
            this.Controls.Add(this.radioButton2serie);
            this.Controls.Add(this.radioButton1serie);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtNomeMateria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroMateria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Matéria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroMateria_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroMateria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeMateria;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.RadioButton radioButton1serie;
        private System.Windows.Forms.RadioButton radioButton2serie;
    }
}