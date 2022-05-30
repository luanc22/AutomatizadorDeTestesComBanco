namespace AutomatizadorDeTestes.Infra.Compartilhado.Serializador
{
    public interface ISerializador
    {
        DataContext CarregarDadosDoArquivo();

        void GravarDadosEmArquivo(DataContext dados);
    }
}
