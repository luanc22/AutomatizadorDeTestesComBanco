using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.Dominio.ModuloQuestao;
using AutomatizadorDeTestes.Dominio.ModuloTeste;
using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        IRepositorioTeste repositorioTeste;
        IRepositorioQuestao repositorioQuestao;
        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        TabelaTesteControl tabelaTesteControl;
        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioDisciplina repositorioDisciplina,
        IRepositorioMateria repositorioMateria, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
        }


        public override void Inserir()
        {
            TelaCadastroTeste tela = new TelaCadastroTeste(repositorioDisciplina, repositorioMateria, repositorioQuestao);
            tela.Teste = new Teste();
            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarTestes();
        }

        public override void Excluir()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Exclusão de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o teste?",
                "Exclusão de Testes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);
                CarregarTestes();
            }
        }

        private Teste ObtemTesteSelecionado()
        {
            var numero = tabelaTesteControl.ObtemNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTeste();
        }

        public override UserControl ObtemListagem()
        {
            tabelaTesteControl = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTesteControl;
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();
            tabelaTesteControl.AtualizarRegistros(testes);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando Testes");
        }

        public void Duplicar()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Duplicação de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Teste testeDuplicado = (Teste)testeSelecionado.Clone();

            TelaCadastroTeste tela = new TelaCadastroTeste(repositorioDisciplina, repositorioMateria, repositorioQuestao);
            tela.Teste = testeDuplicado;

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }

        }


        public void GerarPdf()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Geração de PDF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente gerar um pdf do teste?",
                  "Geração de PDF", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (resultado == DialogResult.OK)
            {
                #region obtem local para salvar o arquivo
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf File |*.pdf";
                #endregion
                #region gera o pdf 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                    doc.Open();

                    Paragraph pulaLinha = new Paragraph("\n");

                    Paragraph disciplina = new Paragraph($"Disciplina: {testeSelecionado.Disciplina.Nome}");
                    Paragraph materia = new Paragraph($"Matéria: {testeSelecionado.Materia.Nome}");

                    doc.Add(disciplina);
                    doc.Add(materia);


                    Paragraph titulo = new Paragraph(testeSelecionado.Titulo);

                    titulo.Alignment = Element.ALIGN_CENTER;

                    doc.Add(titulo);

                    doc.Add(pulaLinha);

                    int nQuestao = 1;
                    foreach (var q in testeSelecionado.Questoes)
                    {
                        doc.Add(new Paragraph(nQuestao + ". " + q.Enunciado));
                        foreach (var a in q.Alternativas)
                        {
                            doc.Add(new Paragraph(a.ToString()));
                        }
                        nQuestao++;
                        doc.Add(pulaLinha);
                    }

                    doc.Close();


                    MessageBox.Show("Arquivo PDF foi salvo!",
                    "Geração de PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion


            }
            CarregarTestes();
        }

    }
}
