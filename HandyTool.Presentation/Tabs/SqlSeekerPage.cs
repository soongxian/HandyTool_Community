using HandyTool.HandyTool.Domain.Model;
using HandyTool.HandyTool.Infrastructure;
using HandyTool.HandyTool.Presentation.Control;
using HandyTool.HandyTool.Presentation.Resources;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace HandyTool.Tabs.SqlSeeker
{
    public partial class SqlSeekerPage : UserControlMain
    {
        private readonly ContainerForm ContainerFormFromMain;
        private Timer SearchTimer;
        private string LastSearchText = string.Empty;
        SqlConnectionHelper ConnectionHelper = new SqlConnectionHelper();
        SqlConnection connect;

        public SqlSeekerPage(ContainerForm form)
        {
            InitializeComponent();
            ContainerFormFromMain = form;
            FilterResultGridView.CellFormatting += FilterResultGridView_CellFormatting;
            SearchTimer = new Timer();
            SearchTimer.Interval = 500;
            SearchTimer.Tick += SearchTimer_Tick;
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            SearchTimer.Stop();
            SearchTimer.Start();
            LastSearchText = (sender as TextBox).Text;
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            SearchTimer.Stop();
            PerformSearch(LastSearchText, ConnectionHelper);
        }

        public void LoadTableNames(SqlConnectionHelper sqlConnectionHelper)
        {
            connect = sqlConnectionHelper.InitializeSqlConnection(ContainerFormFromMain);
            try
            {
                connect.Open();
                for (int i = DatabaseComboBox.Items.Count - 1; i > 0; i--)
                {
                    DatabaseComboBox.Items.RemoveAt(i);
                }
                SqlCommand cmd = new SqlCommand(
                 @"SELECT name 
                      FROM sys.databases 
                      WHERE state_desc = 'ONLINE' 
                      AND name NOT IN ('master', 'tempdb', 'model', 'msdb')",
                 connect);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DatabaseComboBox.Items.Add(reader["name"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformSearch(string SearchText, SqlConnectionHelper sqlConnectionHelper)
        {
            connect = sqlConnectionHelper.InitializeSqlConnection(ContainerFormFromMain);
            try
            {
                List<SqlSeekerFilterModel> FilterList = new List<SqlSeekerFilterModel>();
                connect.Open();

                if (!string.IsNullOrEmpty(SearchText))
                {
                    string query = BuildDynamicSqlQuery(SearchText);

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            SqlSeekerFilterModel FilterModel = new SqlSeekerFilterModel();
                            FilterModel.ObjectType = reader["ObjectType"].ToString();
                            FilterModel.DatabaseName = reader["DatabaseName"].ToString();
                            FilterModel.SchemaName = reader["SchemaName"].ToString();
                            FilterModel.ObjectName = reader["ObjectName"].ToString();
                            FilterModel.FullObject = reader["FullObject"].ToString();
                            FilterModel.Parameters = reader["Parameters"].ToString();
                            FilterModel.Example = reader["Example"].ToString();

                            FilterList.Add(FilterModel);
                        }

                        reader.Close();
                    }

                    FilterResultGridView.DataSource = FilterList;

                    if (FilterResultGridView.Columns.Count > 0)
                    {
                        int totalWidth = FilterResultGridView.Width;

                        FilterResultGridView.Columns["ObjectType"].Width = (int)(totalWidth * 0.08);
                        FilterResultGridView.Columns["DatabaseName"].Width = (int)(totalWidth * 0.10);
                        FilterResultGridView.Columns["SchemaName"].Width = (int)(totalWidth * 0.10);
                        FilterResultGridView.Columns["ObjectName"].Width = (int)(totalWidth * 0.12);
                        FilterResultGridView.Columns["FullObject"].Width = (int)(totalWidth * 0.20);
                        FilterResultGridView.Columns["Parameters"].Width = (int)(totalWidth * 0.10);
                        FilterResultGridView.Columns["Example"].Width = (int)(totalWidth * 0.30);
                    }
                }
                else
                {
                    FilterResultGridView.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox? CheckBoxType = sender as CheckBox;

            if (CheckBoxType != null)
            {
                //string CheckBoxName = CheckBoxType.Name;
                //bool CheckBoxIsChecked = CheckBoxType.Checked;

                //switch (CheckBoxName)
                //{
                //    case "CheckBoxTables":
                //        Console.WriteLine($"Tables checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                //        break;

                //    case "CheckBoxStoredProcedure":
                //        Console.WriteLine($"Stored Procedure checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                //        break;

                //    case "CheckBoxViews":
                //        Console.WriteLine($"Views checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                //        break;

                //    case "CheckBoxFunctions":
                //        Console.WriteLine($"Functions checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                //        break;
                //}

                if (SearchBar.Text.Length > 0)
                {
                    SearchBar_TextChanged(SearchBar, EventArgs.Empty);
                }
            }
        }

        private string BuildDynamicSqlQuery(string filterText)
        {
            string tableNameFilter = "%" + filterText + "%";

            bool searchTable = CheckBoxTables.Checked;
            bool searchStoredProcedure = CheckBoxStoredProcedure.Checked;
            bool searchView = CheckBoxViews.Checked;
            bool searchFunction = CheckBoxFunctions.Checked;

            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.AppendLine("DECLARE @tableNameFilter NVARCHAR(128) = '" + tableNameFilter + "'");
            sqlBuilder.AppendLine("DECLARE @sql NVARCHAR(MAX) = ''");
            sqlBuilder.AppendLine("DECLARE @databaseName NVARCHAR(128)");
            sqlBuilder.AppendLine($"DECLARE @searchTable int = {(searchTable ? 1 : 0)}");
            sqlBuilder.AppendLine($"DECLARE @searchStoredProcedure int = {(searchStoredProcedure ? 1 : 0)}");
            sqlBuilder.AppendLine($"DECLARE @searchView int = {(searchView ? 1 : 0)}");
            sqlBuilder.AppendLine($"DECLARE @searchFunction int = {(searchFunction ? 1 : 0)}");
            if (DatabaseComboBox.SelectedIndex > 0)
            {
                sqlBuilder.AppendLine($"SET @databaseName = '" + DatabaseComboBox.Text + "'");
                sqlBuilder.AppendLine(@"
                                        IF LEN(@sql) > 0
                                            SET @sql = @sql + ' UNION ALL '
    
                                        -- Tables
                                        IF @searchTable = 1
                                            SET @sql = @sql + '
                                            SELECT 
                                                ''Table'' AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                t.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + t.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(c.name, '', '')
                                                       FROM [' + @databaseName + '].sys.columns c
                                                       WHERE c.object_id = t.object_id), '''') AS Parameters,
                                                ''SELECT TOP 100 * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + t.name AS Example
                                            FROM [' + @databaseName + '].sys.tables AS t 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON t.schema_id = s.schema_id 
                                            WHERE t.type = ''U'' AND t.name LIKE ''' + @tableNameFilter + ''' '
    
                                        -- Stored Procedures
                                        IF @searchStoredProcedure = 1
                                        BEGIN
                                            IF LEN(@sql) > 0 AND @searchTable = 1
                                                SET @sql = @sql + ' UNION ALL '
            
                                            SET @sql = @sql + '
                                            SELECT 
                                                ''Stored Procedure'' AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                p.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(params.name + '''', '', '')
                                                       FROM [' + @databaseName + '].sys.parameters params
                                                       WHERE params.object_id = p.object_id), '''') AS Parameters,
                                                CASE 
                                                    WHEN EXISTS (SELECT 1 FROM [' + @databaseName + '].sys.parameters WHERE object_id = p.object_id)
                                                    THEN ''EXEC '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name + '' '' + 
                                                        ISNULL((SELECT STRING_AGG(params.name + '' = 2508'', '', '')
                                                               FROM [' + @databaseName + '].sys.parameters params
                                                               WHERE params.object_id = p.object_id), '''')
                                                    ELSE ''EXEC '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name
                                                END AS Example
                                            FROM [' + @databaseName + '].sys.procedures AS p 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON p.schema_id = s.schema_id 
                                            WHERE p.name LIKE ''' + @tableNameFilter + ''' '
                                        END
    
                                        -- Views
                                        IF @searchView = 1
                                        BEGIN
                                            IF LEN(@sql) > 0 AND (@searchTable = 1 OR @searchStoredProcedure = 1)
                                                SET @sql = @sql + ' UNION ALL '
            
                                            SET @sql = @sql + '
                                            SELECT 
                                                ''View'' AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                v.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + v.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(c.name, '', '')
                                                       FROM [' + @databaseName + '].sys.columns c
                                                       WHERE c.object_id = v.object_id), '''') AS Parameters,
                                                ''SELECT TOP 100 * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + v.name AS Example
                                            FROM [' + @databaseName + '].sys.views AS v 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON v.schema_id = s.schema_id 
                                            WHERE v.name LIKE ''' + @tableNameFilter + ''' '
                                        END
    
                                        -- Functions
                                        IF @searchFunction = 1
                                        BEGIN
                                            IF LEN(@sql) > 0 AND (@searchTable = 1 OR @searchStoredProcedure = 1 OR @searchView = 1)
                                                SET @sql = @sql + ' UNION ALL '
            
                                            SET @sql = @sql + '
                                            SELECT 
                                                CASE f.type
                                                    WHEN ''IF'' THEN ''Inline Table-valued Function''
                                                    WHEN ''TF'' THEN ''Table-valued Function''
                                                    WHEN ''FN'' THEN ''Scalar Function''
                                                    ELSE ''Function''
                                                END AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                f.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(params.name + '' ('' + TYPE_NAME(params.user_type_id) + '')'', '', '')
                                                       FROM [' + @databaseName + '].sys.parameters params
                                                       WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') AS Parameters,
                                                CASE 
                                                    WHEN EXISTS (SELECT 1 FROM [' + @databaseName + '].sys.parameters WHERE object_id = f.object_id AND parameter_id > 0)
                                                    THEN 
                                                        CASE f.type
                                                            WHEN ''FN'' THEN ''SELECT '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''('' + 
                                                                ISNULL((SELECT STRING_AGG(''1'', '', '')
                                                                      FROM [' + @databaseName + '].sys.parameters params
                                                                      WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') + '')''
                                                            ELSE ''SELECT * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''('' + 
                                                                ISNULL((SELECT STRING_AGG(''1'', '', '')
                                                                      FROM [' + @databaseName + '].sys.parameters params
                                                                      WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') + '')''
                                                        END
                                                    ELSE 
                                                        CASE f.type
                                                            WHEN ''FN'' THEN ''SELECT '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''()''
                                                            ELSE ''SELECT * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''()''
                                                        END
                                                END AS Example
                                            FROM [' + @databaseName + '].sys.objects AS f 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON f.schema_id = s.schema_id 
                                            WHERE f.type IN (''FN'', ''IF'', ''TF'') AND f.name LIKE ''' + @tableNameFilter + ''' '
                                        END

                                    -- Add ORDER BY to the final query
                                    IF LEN(@sql) > 0
                                    BEGIN
                                        SET @sql = 'SELECT * FROM (' + @sql + ') AS AllObjects ORDER BY ObjectType, DatabaseName, SchemaName, ObjectName'
                                        EXEC sp_executesql @sql
                                    END");
                return sqlBuilder.ToString();

            }
            sqlBuilder.AppendLine(@"
                                    DECLARE db_cursor CURSOR FOR
                                        SELECT name 
                                        FROM sys.databases 
                                        WHERE state_desc = 'ONLINE' 
                                        AND name NOT IN ('master', 'tempdb', 'model', 'msdb')

                                    OPEN db_cursor
                                    FETCH NEXT FROM db_cursor INTO @databaseName

                                    WHILE @@FETCH_STATUS = 0
                                    BEGIN
                                        IF LEN(@sql) > 0
                                            SET @sql = @sql + ' UNION ALL '
    
                                        -- Tables
                                        IF @searchTable = 1
                                            SET @sql = @sql + '
                                            SELECT 
                                                ''Table'' AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                t.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + t.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(c.name, '', '')
                                                       FROM [' + @databaseName + '].sys.columns c
                                                       WHERE c.object_id = t.object_id), '''') AS Parameters,
                                                ''SELECT TOP 100 * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + t.name AS Example
                                            FROM [' + @databaseName + '].sys.tables AS t 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON t.schema_id = s.schema_id 
                                            WHERE t.type = ''U'' AND t.name LIKE ''' + @tableNameFilter + ''' '
    
                                        -- Stored Procedures
                                        IF @searchStoredProcedure = 1
                                        BEGIN
                                            IF LEN(@sql) > 0 AND @searchTable = 1
                                                SET @sql = @sql + ' UNION ALL '
            
                                            SET @sql = @sql + '
                                            SELECT 
                                                ''Stored Procedure'' AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                p.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(params.name + '''', '', '')
                                                       FROM [' + @databaseName + '].sys.parameters params
                                                       WHERE params.object_id = p.object_id), '''') AS Parameters,
                                                CASE 
                                                    WHEN EXISTS (SELECT 1 FROM [' + @databaseName + '].sys.parameters WHERE object_id = p.object_id)
                                                    THEN ''EXEC '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name + '' '' + 
                                                        ISNULL((SELECT STRING_AGG(params.name + '' = 2508'', '', '')
                                                               FROM [' + @databaseName + '].sys.parameters params
                                                               WHERE params.object_id = p.object_id), '''')
                                                    ELSE ''EXEC '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name
                                                END AS Example
                                            FROM [' + @databaseName + '].sys.procedures AS p 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON p.schema_id = s.schema_id 
                                            WHERE p.name LIKE ''' + @tableNameFilter + ''' '
                                        END
    
                                        -- Views
                                        IF @searchView = 1
                                        BEGIN
                                            IF LEN(@sql) > 0 AND (@searchTable = 1 OR @searchStoredProcedure = 1)
                                                SET @sql = @sql + ' UNION ALL '
            
                                            SET @sql = @sql + '
                                            SELECT 
                                                ''View'' AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                v.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + v.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(c.name, '', '')
                                                       FROM [' + @databaseName + '].sys.columns c
                                                       WHERE c.object_id = v.object_id), '''') AS Parameters,
                                                ''SELECT TOP 100 * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + v.name AS Example
                                            FROM [' + @databaseName + '].sys.views AS v 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON v.schema_id = s.schema_id 
                                            WHERE v.name LIKE ''' + @tableNameFilter + ''' '
                                        END
    
                                        -- Functions
                                        IF @searchFunction = 1
                                        BEGIN
                                            IF LEN(@sql) > 0 AND (@searchTable = 1 OR @searchStoredProcedure = 1 OR @searchView = 1)
                                                SET @sql = @sql + ' UNION ALL '
            
                                            SET @sql = @sql + '
                                            SELECT 
                                                CASE f.type
                                                    WHEN ''IF'' THEN ''Inline Table-valued Function''
                                                    WHEN ''TF'' THEN ''Table-valued Function''
                                                    WHEN ''FN'' THEN ''Scalar Function''
                                                    ELSE ''Function''
                                                END AS ObjectType,
                                                ''' + @databaseName + ''' AS DatabaseName, 
                                                s.name AS SchemaName, 
                                                f.name AS ObjectName, 
                                                ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name AS FullObject, 
                                                ISNULL((SELECT STRING_AGG(params.name + '' ('' + TYPE_NAME(params.user_type_id) + '')'', '', '')
                                                       FROM [' + @databaseName + '].sys.parameters params
                                                       WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') AS Parameters,
                                                CASE 
                                                    WHEN EXISTS (SELECT 1 FROM [' + @databaseName + '].sys.parameters WHERE object_id = f.object_id AND parameter_id > 0)
                                                    THEN 
                                                        CASE f.type
                                                            WHEN ''FN'' THEN ''SELECT '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''('' + 
                                                                ISNULL((SELECT STRING_AGG(''1'', '', '')
                                                                      FROM [' + @databaseName + '].sys.parameters params
                                                                      WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') + '')''
                                                            ELSE ''SELECT * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''('' + 
                                                                ISNULL((SELECT STRING_AGG(''1'', '', '')
                                                                      FROM [' + @databaseName + '].sys.parameters params
                                                                      WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') + '')''
                                                        END
                                                    ELSE 
                                                        CASE f.type
                                                            WHEN ''FN'' THEN ''SELECT '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''()''
                                                            ELSE ''SELECT * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''()''
                                                        END
                                                END AS Example
                                            FROM [' + @databaseName + '].sys.objects AS f 
                                            JOIN [' + @databaseName + '].sys.schemas AS s ON f.schema_id = s.schema_id 
                                            WHERE f.type IN (''FN'', ''IF'', ''TF'') AND f.name LIKE ''' + @tableNameFilter + ''' '
                                        END
    
                                        FETCH NEXT FROM db_cursor INTO @databaseName
                                    END

                                    CLOSE db_cursor
                                    DEALLOCATE db_cursor

                                    -- Add ORDER BY to the final query
                                    IF LEN(@sql) > 0
                                    BEGIN
                                        SET @sql = 'SELECT * FROM (' + @sql + ') AS AllObjects ORDER BY ObjectType, DatabaseName, SchemaName, ObjectName'
                                        EXEC sp_executesql @sql
                                    END");

            return sqlBuilder.ToString();
        }

        private void FilterResultGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ColorGlobal cg = new ColorGlobal();
            if (FilterResultGridView.Columns[e.ColumnIndex].Name == "ObjectType")
            {
                string objectType = e.Value?.ToString();
                Color rowColor = cg.ColorWhite;

                if (objectType != null)
                {
                    if (objectType.Contains("Function", StringComparison.OrdinalIgnoreCase))
                    {
                        rowColor = cg.ColorFunction;
                    }
                    else
                    {
                        switch (objectType)
                        {
                            case "Table":
                                rowColor = cg.ColorTable;
                                break;
                            case "Stored Procedure":
                                rowColor = cg.ColorStoredProcedure;
                                break;
                            case "View":
                                rowColor = cg.ColorView;
                                break;
                            default:
                                rowColor = cg.ColorWhite;
                                break;
                        }
                    }
                }

                foreach (DataGridViewCell cell in FilterResultGridView.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = rowColor;
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadTableNames(ConnectionHelper);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchBar.Text.Length > 0)
            {
                SearchBar_TextChanged(SearchBar, EventArgs.Empty);
            }
        }
    }
}
