using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizadorDeTestes.Dominio.Compartilhado;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;

namespace AutomatizadorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public Disciplina Disciplina { get; set; }
        public string Nome { get; set; }
        public int Serie { get; set; }

        public Materia()
        {

        }

        public Materia(int numero, Disciplina disciplina, string nome, int serie) : this()
        {
            Numero = numero;
            Disciplina = disciplina;
            Nome = nome;
            Serie = serie;
        }
        public override void Atualizar(Materia registro)
        {
            this.Nome = registro.Nome;
            this.Disciplina = registro.Disciplina;
            this.Serie = registro.Serie;

        }

        public override string ToString()
        {
            if (this.Serie == 0)
            {
                return $"{Nome}";
            }
            else
            {

                return $"{Nome} - {Serie}ºsérie";
            }
        }
    }
}
