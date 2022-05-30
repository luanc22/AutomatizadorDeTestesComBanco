using System.Collections.Generic;
using System.Linq;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.Dominio.ModuloQuestao;
using AutomatizadorDeTestes.Dominio.ModuloTeste;
using AutomatizadorDeTestes.Infra.Compartilhado.Serializador;

namespace AutomatizadorDeTestes.Infra.Compartilhado
{
    public class DataContext
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Disciplinas = new List<Disciplina>();
            Materias = new List<Materia>();
            Questoes = new List<Questao>();
            Alternativas = new List<Alternativa>();
            Testes = new List<Teste>();

        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Disciplina> Disciplinas { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Questao> Questoes { get; set; }
        public List<Alternativa> Alternativas { get; set; }
        public List<Teste> Testes { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Disciplinas.Any())
                this.Disciplinas.AddRange(ctx.Disciplinas);

            if (ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);

            if (ctx.Questoes.Any())
                this.Questoes.AddRange(ctx.Questoes);

            if (ctx.Alternativas.Any())
                this.Alternativas.AddRange(ctx.Alternativas);

            if (ctx.Testes.Any())
                this.Testes.AddRange(ctx.Testes);
        }
    }
}
