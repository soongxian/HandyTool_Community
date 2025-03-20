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
            ((System.ComponentModel.ISupportInitialize)ContainerSplit).BeginInit();
            ContainerSplit.Panel1.SuspendLayout();
            ContainerSplit.SuspendLayout();
            ContainerTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // ContainerSplit
            //
            ContainerSplit.Dock = DockStyle.Fill;
            ContainerSplit.Location = new Point(0, 0);
            ContainerSplit.Name = "ContainerSplit";
            // 
            // ContainerSplit.Panel1
            // 
            ContainerSplit.Panel1.Controls.Add(ContainerTabControl);
            ContainerSplit.Size = new Size(800, 450);
            ContainerSplit.SplitterDistance = 650;
            ContainerSplit.TabIndex = 0;
            // 
            // ContainerTabControl
            // 
            ContainerTabControl.Dock = DockStyle.Fill;
            ContainerTabControl.Location = new Point(3, 3);
            ContainerTabControl.Name = "ContainerTabControl";
            ContainerTabControl.SelectedIndex = 0;
            ContainerTabControl.Size = new Size(544, 447);
            ContainerTabControl.TabIndex = 0;
            //
            //Tabs
            //
            TabPage HomeTab = new TabPage("Home") { Controls = { new HomePage() } };
            ContainerTabControl.Controls.Add(HomeTab);
            TabPage SqlAssistTab = new TabPage("Sql Assist") { Controls = { new SqlAssistPage() } };
            ContainerTabControl.Controls.Add(SqlAssistTab);
            TabPage SqlSeekerTab = new TabPage("Sql Seeker") { Controls = { new SqlSeekerPage() } };
            ContainerTabControl.Controls.Add(SqlSeekerTab);
            // 
            // ContainerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 650);
            Controls.Add(ContainerSplit);
            Name = "HandyTool";
            Text = "HandyTool";
            ContainerSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ContainerSplit).EndInit();
            ContainerSplit.ResumeLayout(false);
            ContainerTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer ContainerSplit;
        private TabControl ContainerTabControl;
    }
}