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
    public interface IRepositorioQuestao : IRepositorioBase<Questao>
    {
        void AdicionarAlternativas(Questao q, List<Alternativa> a);
         List<Questao> Sortear(Materia materia, int qtd);
        List<Questao> SortearQuestoesRecuperacao(Disciplina disciplina, int qtd);
    }
}
