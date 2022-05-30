using FluentValidation.Results;
using System.Collections.Generic;

namespace AutomatizadorDeTestes.Dominio.Compartilhado
{
    public interface IRepositorioBase<T> where T : EntidadeBase<T>
    {
        ValidationResult Inserir(T novoRegistro);

        ValidationResult Editar(T registro);

        ValidationResult Excluir(T registro);

        List<T> SelecionarTodos();

        T SelecionarPorNumero(int numero);
    }
}
