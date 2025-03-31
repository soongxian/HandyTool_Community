using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandyTool
{
    public partial class ContainerForm : Form
    {
        public ContainerForm()
        {
            InitializeComponent();
            BtnDeleteServer.Click += BtnDeleteServer_Click;
            ListServer.SelectedIndexChanged += ListServer_SelectedIndexChanged;
        }

        private void BtnInsertServer_Click(object sender, EventArgs e)
        {
            Label LabelInsert = new Label
            {
                Text = "Insert server name here:", 
                Location = new Point(10, 10),
                AutoSize = true
            };

            TextBox InsertTextBox = new TextBox
            {
                Location = new Point(LabelInsert.Left, LabelInsert.Bottom),
                Width = 250
            };

            Button ButtonInsertOk = new Button
            {
                Text = "OK",
                Location = new Point(InsertTextBox.Left, InsertTextBox.Bottom + 10),
                Size = new Size(75, 30)
            };

            Button ButtonInsertCancel = new Button
            {
                Text = "Cancel",

                Location = new Point(ButtonInsertOk.Right + 10, ButtonInsertOk.Top),
                Size = new Size(75, 30)
            };

            Form FormInsert = new Form
            {
                Text = "Insert Server",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                AcceptButton = ButtonInsertOk,
                CancelButton = ButtonInsertCancel,
                StartPosition = FormStartPosition.CenterScreen,
                ClientSize = new Size(270, 110)
            };

            ButtonInsertOk.Click += (s, ev) =>
            {
                FormInsert.DialogResult = DialogResult.OK;
                FormInsert.Close();
            };

            ButtonInsertCancel.Click += (s, ev) =>
            {
                FormInsert.Close();
            };

            FormInsert.Controls.Add(LabelInsert);
            FormInsert.Controls.Add(InsertTextBox);
            FormInsert.Controls.Add(ButtonInsertOk);
            FormInsert.Controls.Add(ButtonInsertCancel);

            FormInsert.ShowDialog();

            if (FormInsert.DialogResult == DialogResult.OK)
            {
                string ServerNameTextInput = InsertTextBox.Text;
                if (!string.IsNullOrEmpty(ServerNameTextInput))
                {
                    ListServer.Items.Add(ServerNameTextInput);
                }
            }
        }

        private void BtnUpdateServer_Click(object sender, EventArgs e)
        {
            if (ListServer.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Label LabelUpdate = new Label
            {
                Text = "Update server name:",
                Location = new Point(10, 10),
                AutoSize = true
            };

            TextBox UpdateTextBox = new TextBox
            {
                Location = new Point(LabelUpdate.Left, LabelUpdate.Bottom + 5),
                Width = 250,
                Text = ListServer.SelectedItem.ToString()
            };

            Button ButtonUpdateOk = new Button
            {
                Text = "OK",
                Location = new Point(UpdateTextBox.Left, UpdateTextBox.Bottom + 10),
                Size = new Size(75, 30)
            };

            Button ButtonUpdateCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(ButtonUpdateOk.Right + 10, ButtonUpdateOk.Top),
                Size = new Size(75, 30)
            };

            Form FormUpdate = new Form
            {
                Text = "Update Server",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                AcceptButton = ButtonUpdateOk,
                CancelButton = ButtonUpdateCancel,
                StartPosition = FormStartPosition.CenterScreen,
                ClientSize = new Size(270, 110)
            };

            ButtonUpdateOk.Click += (s, ev) =>
            {
                string updatedServerName = UpdateTextBox.Text;

                if (!string.IsNullOrEmpty(updatedServerName))
                {
                    int selectedIndex = ListServer.SelectedIndex; 
                    ListServer.Items[selectedIndex] = updatedServerName; 
                }
                FormUpdate.Close();
            };

            ButtonUpdateCancel.Click += (s, ev) =>
            {
                FormUpdate.Close();
            };

            FormUpdate.Controls.Add(LabelUpdate);     
            FormUpdate.Controls.Add(UpdateTextBox);  
            FormUpdate.Controls.Add(ButtonUpdateOk);  
            FormUpdate.Controls.Add(ButtonUpdateCancel);

            FormUpdate.ShowDialog();
        }

        private void BtnDeleteServer_Click(object sender, EventArgs e)
        {
            if (ListServer.SelectedItem != null)
            {
                ListServer.Items.Remove(ListServer.SelectedItem);
            }
        }

        private void ListServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListServer.SelectedItem != null)
            {
                LabelServerSelected.Text = ListServer.SelectedItem.ToString();
            }
            else
            {
                LabelServerSelected.Text = "-";
            }
        }

        public string GetSelectedServerName()
        {
            if (ListServer.SelectedItem != null)
            {
                return ListServer.SelectedItem.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
