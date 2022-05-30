
namespace AutomatizadorDeTestes.Dominio.ModuloQuestao
{
    public class Alternativa
    {
        public int Numero { get; set; }
        public string Letra { get; set; }
        public string Descricao { get; set; }
        public Questao Questao { get; set; }
        public Alternativa()
        {

        }

        public Alternativa(string letra, string descricao, Questao questao) : this()
        {
            Letra = letra;
            Descricao = descricao;
            Questao = questao;
        }

        public override bool Equals(object obj)
        {
            return obj is Alternativa alternativa &&
                   Numero == alternativa.Numero &&
                   Letra == alternativa.Letra &&
                   Descricao == alternativa.Descricao;
        }


        public override string ToString()
        {
            return $"{Letra}) {Descricao}";
        }
    }
}