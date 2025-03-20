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
            label1 = new Label();
            SearchBar = new TextBox();
            DbComponentListBox = new CheckedListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(347, 284);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Sql Seeker";
            // 
            // SearchBar
            // 
            SearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchBar.Location = new Point(6, 7);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(1355, 27);
            SearchBar.TabIndex = 0;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // DbComponentListBox
            // 
            DbComponentListBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DbComponentListBox.BackColor = SystemColors.Menu;
            DbComponentListBox.FormattingEnabled = true;
            DbComponentListBox.Items.AddRange(new object[] { "Table", "Stored Procedure", "View", "Function" });
            DbComponentListBox.Location = new Point(1367, 6);
            DbComponentListBox.Name = "DbComponentListBox";
            DbComponentListBox.Size = new Size(180, 92);
            DbComponentListBox.TabIndex = 1;
            DbComponentListBox.SelectedIndexChanged += DbComponentListBox_SelectedIndexChanged;
            // 
            // SqlSeekerPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DbComponentListBox);
            Controls.Add(SearchBar);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SqlSeekerPage";
            Padding = new Padding(3, 4, 3, 4);
            Size = new Size(1553, 574);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox SearchBar;
        private CheckedListBox DbComponentListBox;
    }
}
