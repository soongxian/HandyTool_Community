using CsvHelper;
using HandyTool.HandyTool.Domain.Model;
using HandyTool.HandyTool.Infrastructure;
using HandyTool.HandyTool.Infrastructure.Config;
using System.Globalization;

namespace HandyTool.HandyTool.Presentation.InsertUpdateBox
{
    public partial class InsertUpdateBox : Form
    {
        private string formTitle;
        private Guid existingGuid = Guid.Empty;
        public string serverName => serverTextBox.Text;
        public bool loginNeeded => loginNeededCheckbox.Checked;
        public string userName => userNameTextBox.Text;
        public string password => passwordTextBox.Text;
        public InsertUpdateBox(string title, string serverSelected = "")
        {
            InitializeComponent();
            formTitle = title;
            this.Text = (formTitle == ContainerFormConfig.CREATE_SERVER) ? ContainerFormConfig.CREATE_SERVER : ContainerFormConfig.UPDATE_SERVER;

            if (formTitle == ContainerFormConfig.UPDATE_SERVER)
            {
                UpdateServerPrefilled(serverSelected);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serverName))
            {
                MessageBox.Show("Please enter a server name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (loginNeeded)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        throw new ArgumentException("Please enter a username.");
                    }

                    if (string.IsNullOrWhiteSpace(password))
                    {
                        throw new ArgumentException("Please enter a password.");
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ServerCredential record = new ServerCredential
            {
                Id = Guid.NewGuid(),
                Server = serverName,
                LoginNeeded = loginNeeded,
                Username = userName,
                Password = password
            };

            if (formTitle == ContainerFormConfig.CREATE_SERVER)
            {
                DatabaseCsv.CheckCSV();
                using (var stream = File.Open(DatabaseCsv.FilePath, FileMode.Append, FileAccess.Write))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecord(record);
                    csv.NextRecord();
                }
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            List<ServerCredential> records;
            using (var reader = new StreamReader(DatabaseCsv.FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<ServerCredential>().ToList();
            }

            var existing = records.FirstOrDefault(r => r.Id == existingGuid);
            if (existing != null)
            {
                existing.Server = record.Server;
                existing.LoginNeeded = record.LoginNeeded;
                existing.Username = record.Username;
                existing.Password = record.Password;
            }
            else
            {
                MessageBox.Show("Server not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var writer = new StreamWriter(DatabaseCsv.FilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateServerPrefilled(string serverSelected)
        {
            if (!File.Exists(DatabaseCsv.FilePath))
            {
                MessageBox.Show("Server data file not found.");
                return;
            }

            using (var reader = new StreamReader(DatabaseCsv.FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ServerCredential>().ToList();

                var match = records
                    .Where(r => r.Deleted == 0)
                    .FirstOrDefault(r => r.Server == serverSelected);

                if (match != null)
                {
                    existingGuid = match.Id;
                    serverTextBox.Text = match.Server;
                    loginNeededCheckbox.Checked = match.LoginNeeded;
                    userNameTextBox.Text = match.Username;
                    passwordTextBox.Text = match.Password;
                }
                else
                {
                    MessageBox.Show("Server entry not found in CSV.");
                }
            }
        }
    }
}
