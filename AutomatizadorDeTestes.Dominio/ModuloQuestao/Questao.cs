using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizadorDeTestes.Dominio.Compartilhado;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;

namespace AutomatizadorDeTestes.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }
        public string Resposta { get; set; }
        public List<Alternativa> Alternativas { get => alternativas; set => alternativas = value; }
        private List<Alternativa> alternativas = new List<Alternativa>();

        public Questao()
        {
        }

        public Questao(Disciplina disciplina, Materia materia, string enunciado, List<Alternativa> alternativas, string alternativaCorreta) : this()
        {
            Disciplina = disciplina;
            Materia = materia;
            Enunciado = enunciado;
            Alternativas = alternativas;
            Resposta = alternativaCorreta;
        }

        public override void Atualizar(Questao registro)
        {
            this.Enunciado = registro.Enunciado;
            this.Materia = registro.Materia;
            this.Resposta = registro.Resposta;
            this.alternativas = registro.Alternativas;
        }

        public bool AdicionarAlternativa(Alternativa alternativa)
        {
            if (Alternativas.Exists(x => x.Equals(alternativa)) == false)
            {
                alternativa.Questao = this;
                alternativas.Add(alternativa);
                return true;


            }
            return false;
        }

        public override string ToString()
        {
            return $"Enunciado: {Enunciado}";
        }
    }
}
