using HandyTool.HandyTool.Domain.Model;
using System.Globalization;

namespace HandyTool.HandyTool.Infrastructure
{
    public class DatabaseCsv
    {
        public static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HandyToolsServer.csv");

        public static void CheckCSV()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    List<ServerCredential> credentials = new List<ServerCredential>();
                    var configCredential = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true
                    };

                    using (var streamWriter = new StreamWriter(FilePath))
                    using (var csvWriter = new CsvHelper.CsvWriter(streamWriter, configCredential))
                    {
                        csvWriter.WriteHeader<ServerCredential>();
                        csvWriter.NextRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating CSV file:\n" + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
