using HandyTool.HandyTool.Infrastructure;

namespace HandyTool
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DatabaseCsv.CheckCSV();
            Form containerForm = new ContainerForm();
            containerForm.Text = "HandyTool Community Edition";
            containerForm.ShowDialog();
        }
    }
}