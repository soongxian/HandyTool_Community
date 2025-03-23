using HandyTool.Tabs.Home;
using HandyTool.Tabs.SqlAssist;
using HandyTool.Tabs.SqlSeeker;

namespace HandyTool
{
    partial class ContainerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ContainerSplit = new SplitContainer();
            ContainerTabControl = new TabControl();
            TableLayoutForPanel2 = new TableLayoutPanel();
            ListServer = new ListBox();
            TableLayoutButton = new TableLayoutPanel();
            BtnInsertServer = new Button();
            BtnUpdateServer = new Button();
            BtnDeleteServer = new Button();
            TableLayoutServerDisplay = new TableLayoutPanel();
            LabelServerTitle = new Label();
            LabelServerSelected = new Label();
            ((System.ComponentModel.ISupportInitialize)ContainerSplit).BeginInit();
            ContainerSplit.Panel1.SuspendLayout();
            ContainerSplit.Panel2.SuspendLayout();
            ContainerSplit.SuspendLayout();
            ContainerTabControl.SuspendLayout();
            TableLayoutForPanel2.SuspendLayout();
            TableLayoutButton.SuspendLayout();
            TableLayoutServerDisplay.SuspendLayout();
            SuspendLayout();
            // 
            // ContainerSplit
            // 
            ContainerSplit.Dock = DockStyle.Fill;
            ContainerSplit.FixedPanel = FixedPanel.Panel2;
            ContainerSplit.Location = new Point(0, 0);
            ContainerSplit.Name = "ContainerSplit";
            // 
            // ContainerSplit.Panel1
            // 
            ContainerSplit.Panel1.Controls.Add(ContainerTabControl);
            // 
            // ContainerSplit.Panel2
            // 
            ContainerSplit.Panel2.Controls.Add(TableLayoutForPanel2);
            ContainerSplit.Size = new Size(1200, 650);
            ContainerSplit.SplitterDistance = 975;
            ContainerSplit.TabIndex = 0;
            // 
            // ContainerTabControl
            // 
            ContainerTabControl.Dock = DockStyle.Fill;
            ContainerTabControl.Location = new Point(0, 0);
            ContainerTabControl.Name = "ContainerTabControl";
            ContainerTabControl.SelectedIndex = 0;
            ContainerTabControl.Size = new Size(975, 650);
            ContainerTabControl.TabIndex = 0;
            //
            //Tabs
            // 
            TabPage HomeTab = new TabPage("Home") { Controls = { new HomePage() } };
            ContainerTabControl.Controls.Add(HomeTab);
            TabPage SqlAssistTab = new TabPage("Sql Assist") { Controls = { new SqlAssistPage() } };
            ContainerTabControl.Controls.Add(SqlAssistTab);
            TabPage SqlSeekerTab = new TabPage("Sql Seeker") { Controls = { new SqlSeekerPage(this) } };
            ContainerTabControl.Controls.Add(SqlSeekerTab);
            // 
            // TableLayoutForPanel2
            // 
            TableLayoutForPanel2.ColumnCount = 1;
            TableLayoutForPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutForPanel2.Controls.Add(ListServer, 0, 1);
            TableLayoutForPanel2.Controls.Add(TableLayoutButton, 0, 2);
            TableLayoutForPanel2.Controls.Add(TableLayoutServerDisplay, 0, 0);
            TableLayoutForPanel2.Dock = DockStyle.Fill;
            TableLayoutForPanel2.Location = new Point(0, 0);
            TableLayoutForPanel2.Margin = new Padding(0);
            TableLayoutForPanel2.Name = "TableLayoutForPanel2";
            TableLayoutForPanel2.RowCount = 3;
            TableLayoutForPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 3.583062F));
            TableLayoutForPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 96.41694F));
            TableLayoutForPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            TableLayoutForPanel2.Size = new Size(221, 650);
            TableLayoutForPanel2.TabIndex = 0;
            // 
            // ListServer
            // 
            ListServer.Dock = DockStyle.Fill;
            ListServer.FormattingEnabled = true;
            ListServer.ItemHeight = 15;
            ListServer.Location = new Point(3, 27);
            ListServer.Name = "ListServer";
            ListServer.Size = new Size(215, 584);
            ListServer.TabIndex = 0;
            // 
            // TableLayoutButton
            // 
            TableLayoutButton.ColumnCount = 5;
            TableLayoutButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            TableLayoutButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            TableLayoutButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            TableLayoutButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            TableLayoutButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            TableLayoutButton.Controls.Add(BtnInsertServer, 0, 0);
            TableLayoutButton.Controls.Add(BtnUpdateServer, 2, 0);
            TableLayoutButton.Controls.Add(BtnDeleteServer, 4, 0);
            TableLayoutButton.Dock = DockStyle.Fill;
            TableLayoutButton.Location = new Point(3, 617);
            TableLayoutButton.Name = "TableLayoutButton";
            TableLayoutButton.RowCount = 1;
            TableLayoutButton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutButton.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TableLayoutButton.Size = new Size(215, 30);
            TableLayoutButton.TabIndex = 1;
            // 
            // BtnInsertServer
            // 
            BtnInsertServer.Location = new Point(3, 3);
            BtnInsertServer.Name = "BtnInsertServer";
            BtnInsertServer.Size = new Size(54, 21);
            BtnInsertServer.TabIndex = 2;
            BtnInsertServer.Text = "Insert";
            BtnInsertServer.UseVisualStyleBackColor = true;
            BtnInsertServer.Click += BtnInsertServer_Click;
            // 
            // BtnUpdateServer
            // 
            BtnUpdateServer.Location = new Point(77, 3);
            BtnUpdateServer.Name = "BtnUpdateServer";
            BtnUpdateServer.Size = new Size(58, 21);
            BtnUpdateServer.TabIndex = 1;
            BtnUpdateServer.Text = "Update";
            BtnUpdateServer.UseVisualStyleBackColor = true;
            BtnUpdateServer.Click += BtnUpdateServer_Click;
            // 
            // BtnDeleteServer
            // 
            BtnDeleteServer.Location = new Point(151, 3);
            BtnDeleteServer.Name = "BtnDeleteServer";
            BtnDeleteServer.Size = new Size(61, 21);
            BtnDeleteServer.TabIndex = 3;
            BtnDeleteServer.Text = "Delete";
            BtnDeleteServer.UseVisualStyleBackColor = true;
            BtnDeleteServer.Click += BtnDeleteServer_Click;
            // 
            // TableLayoutServerDisplay
            // 
            TableLayoutServerDisplay.ColumnCount = 2;
            TableLayoutServerDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutServerDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 163F));
            TableLayoutServerDisplay.Controls.Add(LabelServerTitle, 0, 0);
            TableLayoutServerDisplay.Controls.Add(LabelServerSelected, 1, 0);
            TableLayoutServerDisplay.Dock = DockStyle.Fill;
            TableLayoutServerDisplay.Location = new Point(3, 3);
            TableLayoutServerDisplay.Name = "TableLayoutServerDisplay";
            TableLayoutServerDisplay.RowCount = 1;
            TableLayoutServerDisplay.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TableLayoutServerDisplay.Size = new Size(215, 16);
            TableLayoutServerDisplay.TabIndex = 2;
            // 
            // LabelServerTitle
            // 
            LabelServerTitle.AutoSize = true;
            LabelServerTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LabelServerTitle.Location = new Point(0, 0);
            LabelServerTitle.Margin = new Padding(0);
            LabelServerTitle.Name = "LabelServerTitle";
            LabelServerTitle.Size = new Size(48, 15);
            LabelServerTitle.TabIndex = 0;
            LabelServerTitle.Text = "Server:";
            // 
            // LabelServerSelected
            // 
            LabelServerSelected.AutoSize = true;
            LabelServerSelected.Dock = DockStyle.Fill;
            LabelServerSelected.Location = new Point(55, 0);
            LabelServerSelected.Name = "LabelServerSelected";
            LabelServerSelected.Size = new Size(157, 16);
            LabelServerSelected.TabIndex = 1;
            LabelServerSelected.Text = "-";
            // 
            // ContainerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 650);
            Controls.Add(ContainerSplit);
            Name = "HandyToolContainer";
            Text = "HandyTool";
            ContainerSplit.Panel1.ResumeLayout(false);
            ContainerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ContainerSplit).EndInit();
            ContainerSplit.ResumeLayout(false);
            ContainerTabControl.ResumeLayout(false);
            TableLayoutForPanel2.ResumeLayout(false);
            TableLayoutButton.ResumeLayout(false);
            TableLayoutServerDisplay.ResumeLayout(false);
            TableLayoutServerDisplay.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer ContainerSplit;
        private TabControl ContainerTabControl;
        private TableLayoutPanel TableLayoutForPanel2;
        private ListBox ListServer;
        private TableLayoutPanel TableLayoutButton;
        private Button BtnInsertServer;
        private Button BtnUpdateServer;
        private Button BtnDeleteServer;
        private TabPage HomeTab;
        private TabPage SqlAssistTab;
        private TabPage SqlSeekerTab;
        private TableLayoutPanel TableLayoutServerDisplay;
        private Label LabelServerTitle;
        private Label LabelServerSelected;
    }
}