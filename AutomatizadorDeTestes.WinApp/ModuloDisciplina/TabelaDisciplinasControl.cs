using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloDisciplina
{
    public partial class TabelaDisciplinasControl : UserControl
    {
        public TabelaDisciplinasControl()
        {
            InitializeComponent();
            grid.ConfigurarGrid();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());

        }

        private DataGridViewColumn[] ObterColunas()
        {

            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"}
            };

            return colunas;
        }


        public void AtualizarRegistros(List<Disciplina> disciplinas)
        {
            grid.Rows.Clear();
            foreach (Disciplina d in disciplinas)
            {
                grid.Rows.Add(d.Numero, d.Nome);
            }
        }

        public int ObtemNumeroDisciplinaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

    }
}
