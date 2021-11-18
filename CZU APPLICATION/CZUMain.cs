using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    public partial class CZUMain : Form
    {
        private string _connectedUser, _command;
        public string connectedUser
        {
            get { return _connectedUser; }
            set {  _connectedUser = value; }
        }
        public CZUMain()
        {
            InitializeComponent();
        }
          
        private void CZUMain_Load(object sender, EventArgs e)
        {
            connectedId.Text = _connectedUser;
            _command = "select connected from users where connected =";
            Statistics.update(statisticsUsers, _command, "on");
        }



        private void studentsButton_Click(object sender, EventArgs e)
        {
            studentsPanel.Visible = true;
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            studentsPanel.Visible = false;


        }

        private void meetingsButton_Click(object sender, EventArgs e)
        {
            studentsPanel.Visible = false;

        }

        private void questionsButton_Click(object sender, EventArgs e)
        {
            studentsPanel.Visible = false;

        }

        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            studentsPanel.Visible = false;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string command = $"update users set connected = 'off' where name = '{_connectedUser}'";
            Database.insert(command);

        }
    }
}
