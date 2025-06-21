namespace HandyTool.HandyTool.Presentation.InsertUpdateBox
{
    partial class InsertUpdateBox
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
            tableLayoutPanel1 = new TableLayoutPanel();
            serverLabel = new Label();
            authenticateLabel = new Label();
            loginLabel = new Label();
            passwordLabel = new Label();
            serverTextBox = new TextBox();
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            doneButton = new Button();
            cancelButton = new Button();
            authenticationCheckbox = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(serverLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(authenticateLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(loginLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(passwordLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(serverTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(loginTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(passwordTextBox, 1, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 4);
            tableLayoutPanel1.Controls.Add(authenticationCheckbox, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new Size(254, 191);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Dock = DockStyle.Fill;
            serverLabel.Location = new Point(3, 0);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(70, 38);
            serverLabel.TabIndex = 0;
            serverLabel.Text = "Server:";
            // 
            // authenticateLabel
            // 
            authenticateLabel.AutoSize = true;
            authenticateLabel.Dock = DockStyle.Fill;
            authenticateLabel.Location = new Point(3, 38);
            authenticateLabel.Name = "authenticateLabel";
            authenticateLabel.Size = new Size(70, 19);
            authenticateLabel.TabIndex = 1;
            authenticateLabel.Text = "Auth?";
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Dock = DockStyle.Fill;
            loginLabel.Location = new Point(3, 57);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(70, 38);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "Login:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Dock = DockStyle.Fill;
            passwordLabel.Location = new Point(3, 95);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(70, 38);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password: ";
            // 
            // serverTextBox
            // 
            serverTextBox.Dock = DockStyle.Fill;
            serverTextBox.Location = new Point(79, 3);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(172, 23);
            serverTextBox.TabIndex = 4;
            // 
            // loginTextBox
            // 
            loginTextBox.Dock = DockStyle.Fill;
            loginTextBox.Location = new Point(79, 60);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(172, 23);
            loginTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Dock = DockStyle.Fill;
            passwordTextBox.Location = new Point(79, 98);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(172, 23);
            passwordTextBox.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(doneButton, 0, 0);
            tableLayoutPanel2.Controls.Add(cancelButton, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(79, 136);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(172, 52);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // doneButton
            // 
            doneButton.Dock = DockStyle.Fill;
            doneButton.Location = new Point(3, 3);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(80, 46);
            doneButton.TabIndex = 0;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.Location = new Point(89, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(80, 46);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // authenticationCheckbox
            // 
            authenticationCheckbox.AutoSize = true;
            authenticationCheckbox.Dock = DockStyle.Fill;
            authenticationCheckbox.Location = new Point(79, 41);
            authenticationCheckbox.Name = "authenticationCheckbox";
            authenticationCheckbox.Size = new Size(172, 13);
            authenticationCheckbox.TabIndex = 8;
            authenticationCheckbox.UseVisualStyleBackColor = true;
            // 
            // InsertUpdateBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 191);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "InsertUpdateBox";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "InsertUpdateBox";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label serverLabel;
        private Label authenticateLabel;
        private Label loginLabel;
        private Label passwordLabel;
        private TextBox serverTextBox;
        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Button doneButton;
        private Button cancelButton;
        private CheckBox authenticationCheckbox;
    }
}