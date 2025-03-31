using HandyTool.HandyTool.Presentation.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandyTool.Tabs.Home
{
    public partial class HomePage : UserControlMain
    {
        public HomePage()
        {
            InitializeComponent();
            linkLabel1.Text = "Welcome to my SQL HandyTool!\n\n" +
                              "Feel free to explore and use it however you like.\n\n" +
                              "Got ideas for improvements? You’re welcome to fork the project and make it even better!";
            linkLabel1.Links.Add(linkLabel1.Text.Length, "https://github.com/soongxian/HandyTool".Length, "https://github.com/soongxian/HandyTool");
            linkLabel1.Text += "\n\nClick here to view the project!";
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
        }
    }
}
