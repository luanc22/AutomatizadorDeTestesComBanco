using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.Dominio.ModuloQuestao;
using AutomatizadorDeTestes.Infra.Compartilhado;

namespace AutomatizadorDeTestes.Infra.Repositorios
{
    public class RepositorioQuestaoEmArquivo : RepositorioEmArquivoBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestaoEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Questoes.Count > 0)
                contador = dataContext.Questoes.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Questao novoRegistro)
        {
            var resultadoValidacao = Validar(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;
        }

        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questoes;
        }

        public List<Questao> SelecionarTodos()
        {
            return ObterRegistros().ToList();
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();

        }

        private ValidationResult Validar(Questao registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = ObterRegistros()
               .Select(x => x.Enunciado.ToLower())
               .Contains(registro.Enunciado.ToLower());

            if (nomeEncontrado && registro.Numero == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Enunciado já está cadastrado"));

            return resultadoValidacao;
        }

        public void AdicionarAlternativas(Questao questaoSelecionada, List<Alternativa> alternativas)
        {
            foreach (var a in alternativas)
            {
                questaoSelecionada.AdicionarAlternativa(a);
            }
        }

        public List<Questao> Sortear(Materia materia, int qtd)
        {
            int limite = 0;
            List<Questao> questoesSorteadas = new List<Questao>();
            List<Questao> questoesMateriaSelecionada = ObterRegistros().Where(x => x.Materia.Equals(materia)).ToList();

            Random rdm = new Random();
            List<Questao> questoes = questoesMateriaSelecionada.OrderBy(item => rdm.Next()).ToList();

            foreach (Questao q in questoes)
            {
                questoesSorteadas.Add(q);
                limite++;
                if (limite == qtd)
                    break;
            }


            return questoesSorteadas;
        }


        public List<Questao> SortearQuestoesRecuperacao(Disciplina disciplina, int qtd)
        {
            int limite = 0;
            List<Questao> questoesSorteadas = new List<Questao>();
            List<Questao> questoesDisciplinaSelecionada = ObterRegistros().Where(x => x.Disciplina.Equals(disciplina)).ToList();

            Random rdm = new Random();
            List<Questao> questoes = questoesDisciplinaSelecionada.OrderBy(item => rdm.Next()).ToList();

            foreach (Questao q in questoes)
            {
                questoesSorteadas.Add(q);
                limite++;
                if (limite == qtd)
                    break;
            }

            return questoesSorteadas;
        }

    }
}
