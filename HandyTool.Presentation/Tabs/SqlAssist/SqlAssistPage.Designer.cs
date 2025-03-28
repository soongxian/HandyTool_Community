namespace HandyTool.Tabs.SqlAssist
{
    partial class SqlAssistPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TableLayoutPanelMain = new TableLayoutPanel();
            TextBoxQuery = new TextBox();
            TableLayoutPanelButton = new TableLayoutPanel();
            BtnShowQuery = new Button();
            BtnGenerateQuery = new Button();
            ComboBoxGenerateType = new ComboBox();
            DataGridViewDisplayQuery = new DataGridView();
            CheckedListBoxQueryParam = new CheckedListBox();
            TableLayoutPanelMain.SuspendLayout();
            TableLayoutPanelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewDisplayQuery).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanelMain
            // 
            TableLayoutPanelMain.ColumnCount = 2;
            TableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.26316F));
            TableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.7368412F));
            TableLayoutPanelMain.Controls.Add(TextBoxQuery, 0, 0);
            TableLayoutPanelMain.Controls.Add(TableLayoutPanelButton, 1, 0);
            TableLayoutPanelMain.Controls.Add(DataGridViewDisplayQuery, 0, 1);
            TableLayoutPanelMain.Controls.Add(CheckedListBoxQueryParam, 1, 1);
            TableLayoutPanelMain.Dock = DockStyle.Fill;
            TableLayoutPanelMain.Location = new Point(3, 4);
            TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            TableLayoutPanelMain.RowCount = 2;
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 24.00835F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 75.9916458F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutPanelMain.Size = new Size(1336, 451);
            TableLayoutPanelMain.TabIndex = 0;
            // 
            // TextBoxQuery
            // 
            TextBoxQuery.Dock = DockStyle.Fill;
            TextBoxQuery.Location = new Point(3, 3);
            TextBoxQuery.Multiline = true;
            TextBoxQuery.Name = "TextBoxQuery";
            TextBoxQuery.Size = new Size(1066, 102);
            TextBoxQuery.TabIndex = 0;
            // 
            // TableLayoutPanelButton
            // 
            TableLayoutPanelButton.ColumnCount = 1;
            TableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanelButton.Controls.Add(BtnShowQuery, 0, 0);
            TableLayoutPanelButton.Controls.Add(BtnGenerateQuery, 0, 1);
            TableLayoutPanelButton.Controls.Add(ComboBoxGenerateType, 0, 2);
            TableLayoutPanelButton.Dock = DockStyle.Fill;
            TableLayoutPanelButton.Location = new Point(1075, 3);
            TableLayoutPanelButton.Name = "TableLayoutPanelButton";
            TableLayoutPanelButton.RowCount = 3;
            TableLayoutPanelButton.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            TableLayoutPanelButton.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            TableLayoutPanelButton.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            TableLayoutPanelButton.Size = new Size(258, 102);
            TableLayoutPanelButton.TabIndex = 1;
            // 
            // BtnShowQuery
            // 
            BtnShowQuery.Dock = DockStyle.Fill;
            BtnShowQuery.Location = new Point(3, 3);
            BtnShowQuery.Name = "BtnShowQuery";
            BtnShowQuery.Size = new Size(252, 26);
            BtnShowQuery.TabIndex = 0;
            BtnShowQuery.Text = "Show Query";
            BtnShowQuery.UseVisualStyleBackColor = true;
            BtnShowQuery.Click += BtnShowQuery_Click;
            // 
            // BtnGenerateQuery
            // 
            BtnGenerateQuery.Dock = DockStyle.Fill;
            BtnGenerateQuery.Location = new Point(3, 36);
            BtnGenerateQuery.Name = "BtnGenerateQuery";
            BtnGenerateQuery.Size = new Size(252, 26);
            BtnGenerateQuery.TabIndex = 1;
            BtnGenerateQuery.Text = "Generate Query";
            BtnGenerateQuery.UseVisualStyleBackColor = true;
            BtnGenerateQuery.Click += BtnGenerateQuery_Click;
            // 
            // ComboBoxGenerateType
            // 
            ComboBoxGenerateType.DisplayMember = "Update";
            ComboBoxGenerateType.FormattingEnabled = true;
            ComboBoxGenerateType.Items.AddRange(new object[] { "INSERT", "SELECT", "UPDATE", "DELETE" });
            ComboBoxGenerateType.SelectedIndex = 0;
            ComboBoxGenerateType.Name = "ComboBoxGenerateType";
            ComboBoxGenerateType.Size = new Size(252, 28);
            ComboBoxGenerateType.TabIndex = 2;
            // 
            // DataGridViewDisplayQuery
            // 
            DataGridViewDisplayQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewDisplayQuery.Dock = DockStyle.Fill;
            DataGridViewDisplayQuery.Location = new Point(3, 111);
            DataGridViewDisplayQuery.Name = "DataGridViewDisplayQuery";
            DataGridViewDisplayQuery.ReadOnly = true;
            DataGridViewDisplayQuery.RowHeadersWidth = 51;
            DataGridViewDisplayQuery.Size = new Size(1066, 337);
            DataGridViewDisplayQuery.TabIndex = 2;
            // 
            // CheckedListBoxQueryParam
            // 
            CheckedListBoxQueryParam.CheckOnClick = true;
            CheckedListBoxQueryParam.Dock = DockStyle.Fill;
            CheckedListBoxQueryParam.FormattingEnabled = true;
            CheckedListBoxQueryParam.Location = new Point(1075, 111);
            CheckedListBoxQueryParam.Name = "CheckedListBoxQueryParam";
            CheckedListBoxQueryParam.Size = new Size(258, 337);
            CheckedListBoxQueryParam.TabIndex = 3;
            CheckedListBoxQueryParam.CheckOnClick = true;
            // 
            // SqlAssistPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TableLayoutPanelMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SqlAssistPage";
            Padding = new Padding(3, 4, 3, 4);
            Size = new Size(1342, 459);
            TableLayoutPanelMain.ResumeLayout(false);
            TableLayoutPanelMain.PerformLayout();
            TableLayoutPanelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridViewDisplayQuery).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanelMain;
        private TextBox TextBoxQuery;
        private TableLayoutPanel TableLayoutPanelButton;
        private Button BtnShowQuery;
        private Button BtnGenerateQuery;
        private ComboBox ComboBoxGenerateType;
        private DataGridView DataGridViewDisplayQuery;
        private CheckedListBox CheckedListBoxQueryParam;
    }
}
