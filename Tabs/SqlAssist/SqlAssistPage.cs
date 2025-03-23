using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandyTool.Tabs.SqlAssist
{
    public partial class SqlAssistPage : UserControlMain
    {
        private readonly ContainerForm ContainerFormFromMain;

        SqlConnection connect;
        public SqlAssistPage(ContainerForm form)
        {
            InitializeComponent();
            ContainerFormFromMain = form;
        }

        private void BtnShowQuery_Click(object sender, EventArgs e)
        {
            string server = ContainerFormFromMain.GetSelectedServerName();
            if (server != null)
            {
                InitializeSqlConnection(server);
                try
                {
                    connect.Open();
                    TextBox query = TextBoxQuery as TextBox;
                    string QueryText = query.Text;
                    DataTable dataTable = new DataTable();

                    using (SqlCommand cmd = new SqlCommand(QueryText, connect))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                            DataGridViewDisplayQuery.DataSource = dataTable;
                            DataGridViewDisplayQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();
                }
            }
        }

        private void InitializeSqlConnection(string server)
        {
            if (!string.IsNullOrEmpty(server))
            {
                connect = new SqlConnection($"Server={server};Trusted_Connection=true;TrustServerCertificate=true");
            }
        }
    }
}
