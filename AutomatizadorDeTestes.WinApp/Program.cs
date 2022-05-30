
using System;
using System.Windows.Forms;
using AutomatizadorDeTestes.Infra.Compartilhado;
using AutomatizadorDeTestes.Infra.Compartilhado.Serializador;


namespace AutomatizadorDeTestes.WinApp
{
    internal static class Program
    {
        static ISerializador serializador = new SerializadorJsonDotnet();

        static DataContext context = new DataContext(serializador);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipalForm(context));
            context.GravarDados();


        }
    }
}
