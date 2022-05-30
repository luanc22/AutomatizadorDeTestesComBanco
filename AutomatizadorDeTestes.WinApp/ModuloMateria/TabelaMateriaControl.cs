using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        public TabelaMateriaControl()
        {
            InitializeComponent();
            grid.ConfigurarGrid();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina.Nome", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Série"}

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();
            foreach (Materia m in materias)
            {
                grid.Rows.Add(m.Numero, m.Disciplina.Nome, m.Nome, m.Serie);
            }
        }

        public int ObtemNumeroMateriaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
