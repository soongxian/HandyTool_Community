using HandyTool.Global;

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
            CheckBoxTables = new CheckBox();
            CheckBoxStoredProcedure = new CheckBox();
            CheckBoxViews = new CheckBox();
            CheckBoxFunctions = new CheckBox();
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
            SearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchBar.Location = new Point(6, 7);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(1311, 27);
            SearchBar.TabIndex = 0;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // CheckBoxTables
            // 
            CheckBoxTables.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxTables.AutoSize = true;
            CheckBoxTables.BackColor = Color.FromArgb(192, 255, 255);
            CheckBoxTables.Checked = true;
            CheckBoxTables.CheckState = CheckState.Checked;
            CheckBoxTables.Location = new Point(1323, 7);
            CheckBoxTables.Name = "CheckBoxTables";
            CheckBoxTables.Size = new Size(72, 24);
            CheckBoxTables.TabIndex = 1;
            CheckBoxTables.Text = "Tables";
            CheckBoxTables.UseVisualStyleBackColor = false;
            CheckBoxTables.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // CheckBoxStoredProcedure
            // 
            CheckBoxStoredProcedure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxStoredProcedure.AutoSize = true;
            CheckBoxStoredProcedure.BackColor = Color.FromArgb(192, 255, 192);
            CheckBoxStoredProcedure.Checked = true;
            CheckBoxStoredProcedure.CheckState = CheckState.Checked;
            CheckBoxStoredProcedure.Location = new Point(1398, 7);
            CheckBoxStoredProcedure.Name = "CheckBoxStoredProcedure";
            CheckBoxStoredProcedure.Size = new Size(146, 24);
            CheckBoxStoredProcedure.TabIndex = 2;
            CheckBoxStoredProcedure.Text = "Stored Procedure";
            CheckBoxStoredProcedure.UseVisualStyleBackColor = false;
            CheckBoxStoredProcedure.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // CheckBoxViews
            // 
            CheckBoxViews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxViews.AutoSize = true;
            CheckBoxViews.BackColor = Color.FromArgb(255, 255, 192);
            CheckBoxViews.Checked = true;
            CheckBoxViews.CheckState = CheckState.Checked;
            CheckBoxViews.Location = new Point(1323, 37);
            CheckBoxViews.Name = "CheckBoxViews";
            CheckBoxViews.Size = new Size(69, 24);
            CheckBoxViews.TabIndex = 3;
            CheckBoxViews.Text = "Views";
            CheckBoxViews.UseVisualStyleBackColor = false;
            CheckBoxViews.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // CheckBoxFunctions
            // 
            CheckBoxFunctions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxFunctions.AutoSize = true;
            CheckBoxFunctions.BackColor = Color.FromArgb(255, 224, 192);
            CheckBoxFunctions.Checked = true;
            CheckBoxFunctions.CheckState = CheckState.Checked;
            CheckBoxFunctions.Location = new Point(1398, 37);
            CheckBoxFunctions.Name = "CheckBoxFunctions";
            CheckBoxFunctions.Size = new Size(93, 24);
            CheckBoxFunctions.TabIndex = 4;
            CheckBoxFunctions.Text = "Functions";
            CheckBoxFunctions.UseVisualStyleBackColor = false;
            CheckBoxFunctions.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // SqlSeekerPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CheckBoxFunctions);
            Controls.Add(CheckBoxViews);
            Controls.Add(CheckBoxStoredProcedure);
            Controls.Add(CheckBoxTables);
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
        private CheckBox CheckBoxTables;
        private CheckBox CheckBoxStoredProcedure;
        private CheckBox CheckBoxViews;
        private CheckBox CheckBoxFunctions;
    }
}
