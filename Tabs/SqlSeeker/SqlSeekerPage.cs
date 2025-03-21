using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandyTool.Tabs.SqlSeeker
{
    public partial class SqlSeekerPage : UserControlMain
    {
        public SqlSeekerPage()
        {
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox? CheckBoxType = sender as CheckBox;

            if (CheckBoxType != null)
            {
                string CheckBoxName = CheckBoxType.Name;
                bool CheckBoxIsChecked = CheckBoxType.Checked;

                switch (CheckBoxName)
                {
                    case "CheckBoxTables":
                        Console.WriteLine($"Tables checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                        break;

                    case "CheckBoxStoredProcedure":
                        Console.WriteLine($"Stored Procedure checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                        break;

                    case "CheckBoxViews":
                        Console.WriteLine($"Views checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                        break;

                    case "CheckBoxFunctions":
                        Console.WriteLine($"Functions checkbox is now {(CheckBoxIsChecked ? "checked" : "unchecked")}");
                        break;
                }
            }
        }

    }
}
