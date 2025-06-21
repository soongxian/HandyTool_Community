using HandyTool.HandyTool.Presentation.Resources;

namespace HandyTool.Tabs.SqlSeeker
{
    partial class SqlSeekerPage
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
            SearchBar = new TextBox();
            CheckBoxTables = new CheckBox();
            CheckBoxStoredProcedure = new CheckBox();
            CheckBoxViews = new CheckBox();
            CheckBoxFunctions = new CheckBox();
            TableLayoutMaster = new TableLayoutPanel();
            TableLayoutTitle = new TableLayoutPanel();
            DatabaseComboBox = new ComboBox();
            RefreshButton = new Button();
            FilterResultGridView = new DataGridView();
            TableLayoutMaster.SuspendLayout();
            TableLayoutTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FilterResultGridView).BeginInit();
            SuspendLayout();
            // 
            // SearchBar
            // 
            SearchBar.Dock = DockStyle.Fill;
            SearchBar.Location = new Point(3, 2);
            SearchBar.Margin = new Padding(3, 2, 3, 2);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(284, 23);
            SearchBar.TabIndex = 0;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // CheckBoxTables
            // 
            CheckBoxTables.AutoSize = true;
            CheckBoxTables.BackColor = Color.FromArgb(192, 255, 255);
            CheckBoxTables.Checked = true;
            CheckBoxTables.CheckState = CheckState.Checked;
            CheckBoxTables.Dock = DockStyle.Fill;
            CheckBoxTables.Location = new Point(801, 2);
            CheckBoxTables.Margin = new Padding(3, 2, 3, 2);
            CheckBoxTables.Name = "CheckBoxTables";
            CheckBoxTables.Size = new Size(139, 19);
            CheckBoxTables.TabIndex = 1;
            CheckBoxTables.Text = "Tables";
            CheckBoxTables.UseVisualStyleBackColor = false;
            CheckBoxTables.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // CheckBoxStoredProcedure
            // 
            CheckBoxStoredProcedure.AutoSize = true;
            CheckBoxStoredProcedure.BackColor = Color.FromArgb(192, 255, 192);
            CheckBoxStoredProcedure.Checked = true;
            CheckBoxStoredProcedure.CheckState = CheckState.Checked;
            CheckBoxStoredProcedure.Dock = DockStyle.Fill;
            CheckBoxStoredProcedure.Location = new Point(946, 2);
            CheckBoxStoredProcedure.Margin = new Padding(3, 2, 3, 2);
            CheckBoxStoredProcedure.Name = "CheckBoxStoredProcedure";
            CheckBoxStoredProcedure.Size = new Size(212, 19);
            CheckBoxStoredProcedure.TabIndex = 2;
            CheckBoxStoredProcedure.Text = "Stored Procedure";
            CheckBoxStoredProcedure.UseVisualStyleBackColor = false;
            CheckBoxStoredProcedure.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // CheckBoxViews
            // 
            CheckBoxViews.AutoSize = true;
            CheckBoxViews.BackColor = Color.FromArgb(255, 255, 192);
            CheckBoxViews.Checked = true;
            CheckBoxViews.CheckState = CheckState.Checked;
            CheckBoxViews.Dock = DockStyle.Fill;
            CheckBoxViews.Location = new Point(1164, 2);
            CheckBoxViews.Margin = new Padding(3, 2, 3, 2);
            CheckBoxViews.Name = "CheckBoxViews";
            CheckBoxViews.Size = new Size(139, 19);
            CheckBoxViews.TabIndex = 3;
            CheckBoxViews.Text = "Views";
            CheckBoxViews.UseVisualStyleBackColor = false;
            CheckBoxViews.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // CheckBoxFunctions
            // 
            CheckBoxFunctions.AutoSize = true;
            CheckBoxFunctions.BackColor = Color.FromArgb(255, 224, 192);
            CheckBoxFunctions.Checked = true;
            CheckBoxFunctions.CheckState = CheckState.Checked;
            CheckBoxFunctions.Dock = DockStyle.Fill;
            CheckBoxFunctions.Location = new Point(1309, 2);
            CheckBoxFunctions.Margin = new Padding(3, 2, 3, 2);
            CheckBoxFunctions.Name = "CheckBoxFunctions";
            CheckBoxFunctions.Size = new Size(142, 19);
            CheckBoxFunctions.TabIndex = 4;
            CheckBoxFunctions.Text = "Functions";
            CheckBoxFunctions.UseVisualStyleBackColor = false;
            CheckBoxFunctions.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // TableLayoutMaster
            // 
            TableLayoutMaster.ColumnCount = 1;
            TableLayoutMaster.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutMaster.Controls.Add(TableLayoutTitle, 0, 0);
            TableLayoutMaster.Controls.Add(FilterResultGridView, 0, 1);
            TableLayoutMaster.Dock = DockStyle.Fill;
            TableLayoutMaster.Location = new Point(3, 3);
            TableLayoutMaster.Name = "TableLayoutMaster";
            TableLayoutMaster.RowCount = 2;
            TableLayoutMaster.RowStyles.Add(new RowStyle(SizeType.Percent, 6.060606F));
            TableLayoutMaster.RowStyles.Add(new RowStyle(SizeType.Percent, 93.93939F));
            TableLayoutMaster.Size = new Size(1460, 662);
            TableLayoutMaster.TabIndex = 6;
            // 
            // TableLayoutTitle
            // 
            TableLayoutTitle.ColumnCount = 7;
            TableLayoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            TableLayoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            TableLayoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            TableLayoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            TableLayoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            TableLayoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            TableLayoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            TableLayoutTitle.Controls.Add(SearchBar, 0, 0);
            TableLayoutTitle.Controls.Add(DatabaseComboBox, 1, 0);
            TableLayoutTitle.Controls.Add(CheckBoxFunctions, 6, 0);
            TableLayoutTitle.Controls.Add(CheckBoxViews, 5, 0);
            TableLayoutTitle.Controls.Add(CheckBoxStoredProcedure, 4, 0);
            TableLayoutTitle.Controls.Add(CheckBoxTables, 3, 0);
            TableLayoutTitle.Controls.Add(RefreshButton, 2, 0);
            TableLayoutTitle.Dock = DockStyle.Fill;
            TableLayoutTitle.Location = new Point(3, 3);
            TableLayoutTitle.Name = "TableLayoutTitle";
            TableLayoutTitle.RowCount = 1;
            TableLayoutTitle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutTitle.Size = new Size(1454, 34);
            TableLayoutTitle.TabIndex = 0;

            // 
            // DatabaseComboBox
            // 
            DatabaseComboBox.Dock = DockStyle.Fill;
            DatabaseComboBox.FormattingEnabled = true;
            DatabaseComboBox.Items.AddRange(new object[] { "All (Refresh to see Db)" });
            DatabaseComboBox.Location = new Point(293, 3);
            DatabaseComboBox.Name = "DatabaseComboBox";
            DatabaseComboBox.Size = new Size(430, 23);
            DatabaseComboBox.TabIndex = 5;
            DatabaseComboBox.SelectedIndex = 0;
            DatabaseComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // RefreshButton
            // 
            RefreshButton.Dock = DockStyle.Fill;
            RefreshButton.Font = new Font("Wingdings 3", 8F);
            RefreshButton.Location = new Point(729, 3);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(66, 23);
            RefreshButton.TabIndex = 6;
            RefreshButton.Text = "Q";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // FilterResultGridView
            // 
            FilterResultGridView.AllowUserToOrderColumns = true;
            FilterResultGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FilterResultGridView.Dock = DockStyle.Fill;
            FilterResultGridView.Location = new Point(3, 43);
            FilterResultGridView.Name = "FilterResultGridView";
            FilterResultGridView.RowHeadersWidth = 51;
            FilterResultGridView.Size = new Size(1454, 616);
            FilterResultGridView.TabIndex = 1;
            // 
            // SqlSeekerPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TableLayoutMaster);
            Name = "SqlSeekerPage";
            Size = new Size(1466, 668);
            TableLayoutMaster.ResumeLayout(false);
            TableLayoutTitle.ResumeLayout(false);
            TableLayoutTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FilterResultGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox SearchBar;
        private CheckBox CheckBoxTables;
        private CheckBox CheckBoxStoredProcedure;
        private CheckBox CheckBoxViews;
        private CheckBox CheckBoxFunctions;
        private TableLayoutPanel TableLayoutMaster;
        private TableLayoutPanel TableLayoutTitle;
        private DataGridView FilterResultGridView;
        private ComboBox DatabaseComboBox;
        private Button RefreshButton;
    }
}
