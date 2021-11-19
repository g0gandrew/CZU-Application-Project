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
            Statistics.update(ref statisticsUsers, _command, "on");
        }   


        private void studentsButton_Click(object sender, EventArgs e)
        {
            Statistics.updateStudentPanel(ref studentGB1, ref studentImage1, ref studentConnected1, ref studentName1, ref studentQuestion1, ref studentAssignment1, ref studentMeeting1); // Need 6 here
            Statistics.updateConnectedStudents(studentPanel1, studentPanel2, studentPanel3, studentPanel4, studentPanel5, studentPanel6);
            studentTabState(true);

        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            studentTabState(false);

        }

        private void meetingsButton_Click(object sender, EventArgs e)
        {
            studentTabState(false);

        }

        private void questionsButton_Click(object sender, EventArgs e)
        {
            studentTabState(false);

        }

        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            studentTabState(false);

        }


        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string command = $"update users set connected = 'off' where name = '{_connectedUser}'";
            Database.insert(command);

        }

        private void studentImage1_Click(object sender, EventArgs e)
        {
            CZUUserDetails userDetails = new CZUUserDetails();
            userDetails.Show();
        }

        private void studentConnected3_Click(object sender, EventArgs e)
        {

        }

        private void studentImage1_Click_1(object sender, EventArgs e)
        {
            CZUUserDetails studentDetails = new CZUUserDetails();
            studentDetails.Show();
           
        }

        private void studentImage2_Click(object sender, EventArgs e)
        {
            CZUUserDetails studentDetails = new CZUUserDetails();
            studentDetails.Show();
        }

        private void studentImage3_Click(object sender, EventArgs e)
        {
            CZUUserDetails studentDetails = new CZUUserDetails();
            studentDetails.Show();
        }

        private void studentImage4_Click(object sender, EventArgs e)
        {
            CZUUserDetails studentDetails = new CZUUserDetails();
            studentDetails.Show();

        }

        private void studentImage5_Click(object sender, EventArgs e)
        {
            CZUUserDetails studentDetails = new CZUUserDetails();
            studentDetails.Show();
        }

        private void studentImage6_Click(object sender, EventArgs e)
        {
            CZUUserDetails studentDetails = new CZUUserDetails();
            studentDetails.Show();
        }

        private void studentTabState(Boolean mode)
        {
            studentsPanel.Enabled = mode;
            studentsPanel.Visible = mode;
        }


    }
}
