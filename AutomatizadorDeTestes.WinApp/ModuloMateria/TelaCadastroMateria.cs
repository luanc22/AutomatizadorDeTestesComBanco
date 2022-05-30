using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.Infra.Compartilhado;
using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloMateria
{
    public partial class TelaCadastroMateria : Form
    {

        IRepositorioDisciplina repositorioDisciplina;
        ValidadorRegex validador = new ValidadorRegex();

        private Materia materia;

        public TelaCadastroMateria(IRepositorioDisciplina repositorioDisciplina)
        {
            InitializeComponent();
            this.repositorioDisciplina = repositorioDisciplina;
            CarregarDisciplinas();
        }

        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        public Materia Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;
                txtNomeMateria.Text = materia.Nome;
                comboBoxDisciplina.SelectedItem = materia.Disciplina;
                GravarSerie();

            }
        }

        private void GravarSerie()
        {
            if (materia.Serie == 1)
            {
                radioButton1serie.Checked = true;
            }
            else if (materia.Serie == 2)
            {
                radioButton2serie.Checked = true;
            }
        }

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();
            foreach (Disciplina d in disciplinas)
            {
                comboBoxDisciplina.Items.Add(d);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (validador.ApenasLetra(txtNomeMateria.Text))
            {
                materia.Nome = txtNomeMateria.Text;
                materia.Serie = ObtemSerie();
                materia.Disciplina = (Disciplina)comboBoxDisciplina.SelectedItem;

                var resultadoValidacao = GravarRegistro(Materia);
                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Insira apenas letras no campo 'Nome'",
                "Cadastro de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }
        }

        private int ObtemSerie()
        {
            int n = 0;
            if (radioButton1serie.Checked)
                n = 1;
            else if (radioButton2serie.Checked)
                n = 2;

            return n;
        }

        #region rodapé
        private void TelaCadastroMateria_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");

        }

        private void TelaCadastroMateria_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
        #endregion
    }
}
