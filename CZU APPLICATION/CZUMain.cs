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
        // Student Panel
        List<GroupBox> studentGB = new List<GroupBox>();
        List<PictureBox> studentConnected = new List<PictureBox>();
        List<Button> studentImage = new List<Button>();
        List<Label> studentName = new List<Label>();
        List<Label> studentQuestion = new List<Label>();
        List<Label> studentAssignment = new List<Label>();
        List<Label> studentMeeting = new List<Label>();
        List<Panel> studentPanel = new List<Panel>();
        private int _recordsOnPage = 0;
        public int recordsOnPage
        {
            get
            {
                return _recordsOnPage;
            }
            set
            {
                _recordsOnPage = value;
            }
        }
        private int _startingFrom = 0;
        public int startingFrom
        {
            get
            {
                return _startingFrom;
            }
            set
            {
                _startingFrom = value;
            }
        }
        private bool _leftPossible = false;
        public bool leftPossible
        {
            get
            {
                return _leftPossible;
            }
            set
            {
                _leftPossible = value;  
            }
        }
        private bool _rightPossible = false;
        public bool rightPossible
        {
            get
            {
                return _rightPossible;  
            }
            set
            {
                 _rightPossible = value;
            }
        }

        //
        private string _connectedUser;
        public string connectedUser
        {
            get
            {
                return _connectedUser;
            }
            set
            {
                _connectedUser = value;
            }
        }
        private string _command { get; set; }
        private int _times { get; set; } = 0;

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
            if (_times++ == 0)
            {
                studentTabDataInitialization();
            }
            studentMainPanel(true);
            Students.updatePanel(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB,  studentImage,  studentConnected,  studentName,   studentQuestion,   studentAssignment,  studentMeeting); 

        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            studentMainPanel(false);
            studentTabDataInitialization();
        }

        private void meetingsButton_Click(object sender, EventArgs e)
        {
            studentMainPanel(false);
            studentTabDataInitialization();
        }

        private void questionsButton_Click(object sender, EventArgs e)
        {
            studentMainPanel(false);
            studentTabDataInitialization();
        }

        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            studentMainPanel(false);
            studentTabDataInitialization();
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
                
        private void studentMainPanel(bool mode)
        {
            studentsMainPanel.Enabled = mode;
            studentsMainPanel.Visible = mode;

        }

        private void leftStudentList_Click(object sender, EventArgs e)
        {
            if (leftPossible)
            {
                startingFrom -= recordsOnPage + 6;
                Students.updatePanel(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, studentQuestion, studentAssignment, studentMeeting);
            }
        }

        private void rightStudentList_Click(object sender, EventArgs e)
        {
            if(startingFrom % 6 == 0 && rightPossible == true) {
                Students.updatePanel(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, studentQuestion, studentAssignment, studentMeeting);
            }

        }

        private void studentTabDataInitialization( )
        {
            studentConnected.Add(studentConnected1);
            studentConnected.Add(studentConnected2);
            studentConnected.Add(studentConnected3);
            studentConnected.Add(studentConnected4);
            studentConnected.Add(studentConnected5);
            studentConnected.Add(studentConnected6);
            studentGB.Add(studentGB1);
            studentGB.Add(studentGB2);
            studentGB.Add(studentGB3);
            studentGB.Add(studentGB4);
            studentGB.Add(studentGB5);
            studentGB.Add(studentGB6);
            studentImage.Add(studentImage1);
            studentImage.Add(studentImage2);
            studentImage.Add(studentImage3);
            studentImage.Add(studentImage4);
            studentImage.Add(studentImage5);
            studentImage.Add(studentImage6);
            studentName.Add(studentName1);
            studentName.Add(studentName2);
            studentName.Add(studentName3);
            studentName.Add(studentName4);
            studentName.Add(studentName5);
            studentName.Add(studentName6);
            studentQuestion.Add(studentQuestion1);
            studentQuestion.Add(studentQuestion2);
            studentQuestion.Add(studentQuestion3);
            studentQuestion.Add(studentQuestion4);
            studentQuestion.Add(studentQuestion5);
            studentQuestion.Add(studentQuestion6);
            studentAssignment.Add(studentAssignment1);
            studentAssignment.Add(studentAssignment2);
            studentAssignment.Add(studentAssignment3);
            studentAssignment.Add(studentAssignment4);
            studentAssignment.Add(studentAssignment5);
            studentAssignment.Add(studentAssignment6);
            studentMeeting.Add(studentMeeting1);
            studentMeeting.Add(studentMeeting2);
            studentMeeting.Add(studentMeeting3);
            studentMeeting.Add(studentMeeting4);
            studentMeeting.Add(studentMeeting5);
            studentMeeting.Add(studentMeeting6);
            studentPanel.Add(studentPanel1);
            studentPanel.Add(studentPanel2);
            studentPanel.Add(studentPanel3);
            studentPanel.Add(studentPanel4);
            studentPanel.Add(studentPanel5);
            studentPanel.Add(studentPanel6);
        }
    }
}
