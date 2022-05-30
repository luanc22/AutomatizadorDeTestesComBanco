using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorDeTestes.WinApp.Compartilhado
{
    public class ValidadorRegex
    {
        public bool ApenasLetra(string letra)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(letra, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$");

            return estaValido;
        }
    }
}
