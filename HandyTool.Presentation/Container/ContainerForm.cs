using CsvHelper;
using HandyTool.HandyTool.Domain.Model;
using HandyTool.HandyTool.Infrastructure;
using HandyTool.HandyTool.Infrastructure.Config;
using HandyTool.HandyTool.Presentation.InsertUpdateBox;
using System.Globalization;

namespace HandyTool
{
    public partial class ContainerForm : Form
    {
        public ContainerForm()
        {
            InitializeComponent();
            LoadServerList();
            ListServer.SelectedIndexChanged += ListServer_SelectedIndexChanged;
        }

        private void BtnInsertServer_Click(object sender, EventArgs e)
        {
            InsertUpdateBox insertForm = new InsertUpdateBox(ContainerFormConfig.CREATE_SERVER);
            if (insertForm.ShowDialog() == DialogResult.OK)
            {
                string serverName = insertForm.serverName;
                ListServer.Items.Add(serverName);
            }
        }

        private void BtnUpdateServer_Click(object sender, EventArgs e)
        {
            if (ListServer.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InsertUpdateBox updateForm = new InsertUpdateBox(ContainerFormConfig.UPDATE_SERVER, ListServer.SelectedItem.ToString());

            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                string updatedServerName = updateForm.serverName;
                if (!string.IsNullOrEmpty(updatedServerName))
                {
                    int selectedIndex = ListServer.SelectedIndex;
                    ListServer.Items[selectedIndex] = updatedServerName;
                }
            }
        }

        private void BtnDeleteServer_Click(object sender, EventArgs e)
        {
            if (ListServer.SelectedItem == null)
            {
                MessageBox.Show("Please select a server to delete.");
                return;
            }

            string selectedServer = ListServer.SelectedItem.ToString();
            ListServer.Items.Remove(selectedServer);

            List<ServerCredential> records;
            using (var reader = new StreamReader(DatabaseCsv.FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<ServerCredential>().ToList();
            }

            var recordToDelete = records.FirstOrDefault(r => r.Server == selectedServer && r.Deleted == 0);
            if (recordToDelete != null)
            {
                recordToDelete.Deleted = -1;

                using (var writer = new StreamWriter(DatabaseCsv.FilePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<ServerCredential>();
                    csv.NextRecord();
                    csv.WriteRecords(records);
                }
            }
            else
            {
                MessageBox.Show("Server record not found in CSV.");
            }
        }

        private void ListServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListServer.SelectedItem != null)
            {
                LabelServerSelected.Text = ListServer.SelectedItem.ToString();
            }
            else
            {
                LabelServerSelected.Text = "-";
            }
        }

        public string GetSelectedServerName()
        {
            if (ListServer.SelectedItem != null)
            {
                return ListServer.SelectedItem.ToString();
            }
            else
            {
                return null;
            }
        }

        private void LoadServerList()
        {
            ListServer.Items.Clear();

            if (!File.Exists(DatabaseCsv.FilePath))
                return;

            using (var reader = new StreamReader(DatabaseCsv.FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ServerCredential>();

                foreach (var record in records)
                {
                    if (record.Deleted == 0)
                    {
                        ListServer.Items.Add(record.Server);
                    }
                }
            }
        }
    }
}
