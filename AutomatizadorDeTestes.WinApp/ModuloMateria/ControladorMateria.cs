using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        IRepositorioMateria repositorioMateria;
        IRepositorioDisciplina repositorioDisciplina;
        TabelaMateriaControl tabelaMateria;

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            TelaCadastroMateria tela = new TelaCadastroMateria(repositorioDisciplina);
            tela.Materia = new Materia();

            tela.GravarRegistro = repositorioMateria.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarMaterias();
        }

        public override void Editar()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Edição de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroMateria tela = new TelaCadastroMateria(repositorioDisciplina);

            tela.Materia = materiaSelecionada;

            tela.GravarRegistro = repositorioMateria.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Editar(tela.Materia);
                CarregarMaterias();
            }
        }

        public override void Excluir()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Exclusão de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a matéria?",
                "Exclusão de Matérias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionada);
                CarregarMaterias();
            }
        }

        private Materia ObtemMateriaSelecionada()
        {
            var numero = tabelaMateria.ObtemNumeroMateriaSelecionada();

            return repositorioMateria.SelecionarPorNumero(numero);
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        public override UserControl ObtemListagem()
        {
            tabelaMateria = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMateria;
        }

        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();
            tabelaMateria.AtualizarRegistros(materias);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando Matérias");

        }
    }
}
