using FluentValidation;

namespace AutomatizadorDeTestes.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Disciplina)
              .NotNull().NotEmpty();

            RuleFor(x => x.Nome)
              .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Serie)
              .NotNull().NotEmpty();
        }
    }
}
