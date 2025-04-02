using HandyTool.HandyTool.Infrastructure;
using HandyTool.HandyTool.Presentation.Control;
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
        DataTable DataTableFilled = new DataTable();
        public SqlAssistPage(ContainerForm form)
        {
            InitializeComponent();
            ContainerFormFromMain = form;
        }

        private void BtnShowQuery_Click(object sender, EventArgs e)
        {
            DataTableFilled = new DataTable();
            string server = ContainerFormFromMain.GetSelectedServerName();
            if (server != null)
            {
                connect = SqlConnectionHelper.InitializeSqlConnection(server);
                try
                {
                    connect.Open();
                    TextBox query = TextBoxQuery as TextBox;
                    string QueryText = query.Text;

                    using (SqlCommand cmd = new SqlCommand(QueryText, connect))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(DataTableFilled);
                            DataGridViewDisplayQuery.DataSource = DataTableFilled;
                            DataGridViewDisplayQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            CheckedListBoxQueryParam.Items.Clear();
                            foreach (DataGridViewColumn column in DataGridViewDisplayQuery.Columns)
                            {
                                if (column.ValueType == typeof(DateTime))
                                {
                                    column.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                                    CheckedListBoxQueryParam.Items.Add($"{column.Name}");
                                }
                                else
                                {
                                    CheckedListBoxQueryParam.Items.Add(column.Name);
                                }
                            }

                            for (int i = 0; i < CheckedListBoxQueryParam.Items.Count; i++)
                            {
                                CheckedListBoxQueryParam.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();
                }
            }
        }

        private void BtnGenerateQuery_Click(object sender, EventArgs e)
        {
            string server = ContainerFormFromMain.GetSelectedServerName();
            if (server != null)
            {
                connect = SqlConnectionHelper.InitializeSqlConnection(server);
                try
                {
                    connect.Open();

                    TextBox query = TextBoxQuery as TextBox;
                    string QueryText = query.Text;
                    string TableNameFromQuery = GetTableNameFromQuery(QueryText);

                    var CheckedColumns = CheckedListBoxQueryParam.CheckedItems
                        .Cast<object>()
                        .Select(item => item.ToString())
                        .ToList();

                    string QueryGenerated = null;

                    string SelectedQueryType = ComboBoxGenerateType.SelectedItem?.ToString();

                    switch (SelectedQueryType)
                    {
                        case "INSERT":
                            if (DataTableFilled.Rows.Count > 0)
                            {
                                StringBuilder InsertQueries = new StringBuilder();

                                foreach (DataRow row in DataTableFilled.Rows)
                                {
                                    var ColumnValues = CheckedColumns
                                        .Select(col => {
                                            if (row[col] == DBNull.Value)
                                            {
                                                return "NULL";
                                            }
                                            else if (row.Table.Columns[col].DataType == typeof(DateTime))
                                            {
                                                DateTime dateValue = (DateTime)row[col];
                                                return $"'{dateValue.ToString("yyyy-MM-dd HH:mm:ss")}'";
                                            }
                                            else
                                            {
                                                return $"'{row[col].ToString().Replace("'", "''")}'";
                                            }
                                        })
                                        .ToList();

                                    string columns = string.Join(", ", CheckedColumns);
                                    string values = string.Join(", ", ColumnValues);

                                    InsertQueries.AppendLine($"INSERT INTO {TableNameFromQuery} ({columns}) VALUES ({values});");
                                }

                                QueryGenerated = InsertQueries.ToString();
                            }
                            else
                            {
                                MessageBox.Show("No data available to generate INSERT statements.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;

                        case "SELECT":
                            QueryGenerated = $"SELECT TOP 100 {string.Join(", ", CheckedColumns)} FROM {TableNameFromQuery}";
                            break;

                        case "UPDATE":
                            if (DataTableFilled.Rows.Count > 0 && CheckedColumns.Count > 0)
                            {
                                StringBuilder UpdateQueries = new StringBuilder();

                                foreach (DataRow row in DataTableFilled.Rows)
                                {
                                    var AllColumns = row.Table.Columns
                                        .Cast<DataColumn>()
                                        .Select(c => c.ColumnName)
                                        .ToList();

                                    var ColumnValueMap = AllColumns
                                        .ToDictionary(
                                            col => col,
                                            col => {
                                                if (row[col] == DBNull.Value)
                                                {
                                                    return "NULL";
                                                }
                                                else if (row.Table.Columns[col].DataType == typeof(DateTime))
                                                {
                                                    DateTime dateValue = (DateTime)row[col];
                                                    return $"'{dateValue.ToString("yyyy-MM-dd HH:mm:ss")}'";
                                                }
                                                else if (row.Table.Columns[col].DataType == typeof(bool))
                                                {
                                                    return $"'{row[col].ToString()}'";
                                                }
                                                else
                                                {
                                                    return $"'{row[col].ToString().Replace("'", "''")}'";
                                                }
                                            }
                                        );

                                    var SetColumns = CheckedColumns
                                        .Select(col => $"{col} = {ColumnValueMap[col]}")
                                        .ToList();

                                    var WhereConditions = AllColumns
                                        .Select(col => {
                                            if (ColumnValueMap[col] == "NULL")
                                            {
                                                return $"{col} IS NULL";
                                            }
                                            return $"{col} = {ColumnValueMap[col]}";
                                        })
                                        .ToList();

                                    UpdateQueries.AppendLine($"UPDATE {TableNameFromQuery} SET {string.Join(", ", SetColumns)} WHERE {string.Join(" AND ", WhereConditions)};");
                                }

                                QueryGenerated = UpdateQueries.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Cannot generate UPDATE statements. Ensure data and columns are selected.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;

                        case "DELETE":
                            if (DataTableFilled.Rows.Count > 0 && CheckedColumns.Count > 0)
                            {
                                StringBuilder DeleteQueries = new StringBuilder();

                                foreach (DataRow row in DataTableFilled.Rows)
                                {
                                    var AllColumns = row.Table.Columns
                                        .Cast<DataColumn>()
                                        .Select(c => c.ColumnName)
                                        .ToList();

                                    var ColumnValueMap = AllColumns
                                        .ToDictionary(
                                            col => col,
                                            col => {
                                                if (row[col] == DBNull.Value)
                                                {
                                                    return "NULL";
                                                }
                                                else if (row.Table.Columns[col].DataType == typeof(DateTime))
                                                {
                                                    DateTime dateValue = (DateTime)row[col];
                                                    return $"'{dateValue.ToString("yyyy-MM-dd HH:mm:ss")}'";
                                                }
                                                else if (row.Table.Columns[col].DataType == typeof(bool))
                                                {
                                                    return $"'{row[col].ToString()}'";
                                                }
                                                else
                                                {
                                                    return $"'{row[col].ToString().Replace("'", "''")}'";
                                                }
                                            }
                                        );

                                    var WhereConditions = AllColumns
                                        .Select(col => {
                                            if (ColumnValueMap[col] == "NULL")
                                            {
                                                return $"{col} IS NULL";
                                            }
                                            return $"{col} = {ColumnValueMap[col]}";
                                        })
                                        .ToList();

                                    DeleteQueries.AppendLine($"DELETE FROM {TableNameFromQuery} WHERE {string.Join(" AND ", WhereConditions)};");
                                }

                                QueryGenerated = DeleteQueries.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Cannot generate DELETE statements. Ensure data and columns are selected.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;

                        default:
                            MessageBox.Show("Unsupported query type selected.", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    Label LabelQueryResult = new Label
                    {
                        Text = "Generated Query:",
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    TextBox QueryResultTextBox = new TextBox
                    {
                        Location = new Point(LabelQueryResult.Left, LabelQueryResult.Bottom + 5),
                        Width = 450,
                        Height = 300,
                        Multiline = true,
                        ScrollBars = ScrollBars.Both,
                        ReadOnly = true,
                        Text = QueryGenerated
                    };

                    Button ButtonCopy = new Button
                    {
                        Text = "Copy",
                        Location = new Point(QueryResultTextBox.Left, QueryResultTextBox.Bottom + 10),
                        Size = new Size(75, 30)
                    };
                    ButtonCopy.Click += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(QueryResultTextBox.Text))
                        {
                            Clipboard.SetText(QueryResultTextBox.Text);
                            MessageBox.Show("Query copied to clipboard!", "Copy Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    };

                    Button ButtonClose = new Button
                    {
                        Text = "Close",
                        Location = new Point(ButtonCopy.Right + 10, ButtonCopy.Top),
                        Size = new Size(75, 30)
                    };

                    Form FormQueryResult = new Form
                    {
                        Text = "Query Result",
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false,
                        MinimizeBox = false,
                        StartPosition = FormStartPosition.CenterScreen,
                        AcceptButton = ButtonCopy,
                        CancelButton = ButtonClose,
                        ClientSize = new Size(470, 450)
                    };

                    ButtonClose.Click += (sender, e) => FormQueryResult.Close();

                    FormQueryResult.Controls.AddRange(new Control[]
                    {
                        LabelQueryResult,
                        QueryResultTextBox,
                        ButtonCopy,
                        ButtonClose
                    });

                    if (QueryGenerated != null)
                    {
                        FormQueryResult.Show();
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }

        public string GetTableNameFromQuery(string QueryText)
        {
            int FromIndex = QueryText.Trim().IndexOf(" FROM ", StringComparison.OrdinalIgnoreCase);

            if (FromIndex != -1)
            {
                string AfterFrom = QueryText.Trim().Substring(FromIndex + 6).Trim();
                string TableName = AfterFrom.Split(new[] { ' ', '\t', '\n', '\r' })[0];

                return TableName;
            }
            return null;
        }
    }
}
