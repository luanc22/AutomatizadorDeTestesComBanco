
using System;
using System.Collections.Generic;

using System.Windows.Forms;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.Infra.Repositorios;
using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private TabelaDisciplinasControl tabelaDisciplinasControl;
        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
        }

        public override void Inserir()
        {
            TelaCadastroDisciplina tela = new TelaCadastroDisciplina();
            tela.Disciplina = new Disciplina();
            tela.GravarRegistro = repositorioDisciplina.Inserir;
            
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)           
                   CarregarDisciplinas();
        }

        public override void Editar()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDisciplina tela = new TelaCadastroDisciplina();

            tela.Disciplina = disciplinaSelecionada;

            tela.GravarRegistro = repositorioDisciplina.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarDisciplinas();
            
        }

        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var materia = repositorioMateria.SelecionarTodos();

            foreach (var item in materia)
            {
                if (item.Disciplina.Nome == disciplinaSelecionada.Nome)
                {
                    MessageBox.Show("Esta disciplina está atrelada a uma matéria e não pode ser excluída",
                    "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
                "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);
                CarregarDisciplinas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxDisciplina();
        }

        public override UserControl ObtemListagem()
        {
            tabelaDisciplinasControl = new TabelaDisciplinasControl();

            CarregarDisciplinas();

            return tabelaDisciplinasControl;
        }

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplinasControl.AtualizarRegistros(disciplinas);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando Disciplinas");

        }

        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = tabelaDisciplinasControl.ObtemNumeroDisciplinaSelecionada();

            return repositorioDisciplina.SelecionarPorNumero(numero);
        }

    }
}
