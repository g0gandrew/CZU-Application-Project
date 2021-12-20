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
        // Student Panel Controls
        List<GroupBox> studentGB = new List<GroupBox>();
        List<PictureBox> studentConnected = new List<PictureBox>();
        List<Button> studentImage = new List<Button>();
        List<Label> studentName = new List<Label>();
        List<Label> studentQuestion = new List<Label>();
        List<Label> studentAssignment = new List<Label>();
        List<Label> studentMeeting = new List<Label>();
        List<Panel> studentPanel = new List<Panel>();
        List<string> teachedClassesIDs = new List<string>();
        // 
        private string _connectedUserType;
        public string connectedUserType
        {
            get
            {
                return _connectedUserType;
            }
            set
            {
                _connectedUserType = value;
            }
        }
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

        // Connected as Teacher 
        private string _teacherID;
        string teacherID
        {
            get
            {
                return _teacherID;
            }
            set
            {
                _teacherID = value;
            }
        }
        //

        public CZUMain()
        {
            InitializeComponent();
           
        }
          
        private void CZUMain_Load(object sender, EventArgs e)
        {
            connectedId.Text = _connectedUser;
            if (connectedUserType == "student")
            {
                Statistics.mainPanelConnectedColleagues(ref statisticsUsers, StudentsPanel.studentClassID(_connectedUser));
            }
            else if (connectedUserType == "teacher")
            {
                teachedClassesIDs = StudentsPanel.teachedClasses(connectedUser, out _teacherID); // getting the classes where teacher teaches
                Statistics.mainPanelConnectedStudents(ref statisticsUsers, teachedClassesIDs);
            }
        }
        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            userDisconnectsSetOffline(connectedUserType, connectedUser);
        }

        // Student and Colleagues Tab Methods and Events
        private void studentsButton_Click(object sender, EventArgs e)
        {
            if (_times++ == 0) // Creating list of GUI classes elements for student tab just one time for further operations. 
            {
                studentTabDataInitialization(); 
            }
            studentMainPanel(true);
            // Show Student Panel related to connected user type (Teacher or Student)
            if (connectedUserType == "teacher") // teacher connected
            {
                // Initializing Select Class ID List
                teachedClassesIDs = StudentsPanel.teachedClasses(connectedUser, out _teacherID); // getting the classes where teacher teaches
                if (teachedClassesIDs.Count != 0) {
                    selectClassID.DataSource = teachedClassesIDs; // inserting the list of classes where teacher teaches in ListBox for own selection.
                    StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, studentQuestion, studentAssignment, studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
                }
                else
                {
                    studentMainPanelNoData(true, "teacherNoClasses");
                }
            }
            else // student connected
            {
                // Disabling Controls used for Teacher Interface
                selectClassID.Enabled = false;
                selectClassID.Visible = false;
                label3.Enabled = false;
                label3.Visible = false;
                //
                StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName,  connectedUser);
                if(studentPanel[0].Enabled == true) // If the first panel is enabled, it means that there are no records from database matching the criteria, so, there are no colleagues.
                {
                    studentMainPanelNoData(true, "studentNoColleagues");
                }
           }
            //
        }
        private void cleanGUI()
        {
            selectClassID.Enabled = false;
            selectClassID.Visible = false;
            label3.Enabled = false;
            label3.Visible = false;
        }
        private void studentMainPanelNoData(bool t_mode, string t_case)
        {
            if (t_case == "teacherNoClasses")
            {
                studentsPanelNoData.Enabled = t_mode;
                studentsPanelNoData.Visible = t_mode;
                noDataInStudentPanelMessage.Enabled = t_mode;
                noDataInStudentPanelMessage.Visible = t_mode;
            }
            else if (t_case == "studentNoColleagues")
            {
                studentsPanelNoData.Enabled = t_mode;
                studentsPanelNoData.Visible = t_mode;
                noDataInStudentPanelMessage.Text = "      You have no colleagues";
                noDataInStudentPanelMessage.Enabled = t_mode;
                noDataInStudentPanelMessage.Visible = t_mode;
            }
            else if (t_case == "teacherNoStudents")  {
                noDataInStudentPanelMessage.Text = "     Class has no students";
                studentsPanelNoData.Enabled = t_mode; 
                studentsPanelNoData.Visible = t_mode;
                studentsPanelNoData.Location = new Point(29, 50);
                studentsPanelNoData.Visible = t_mode;
                noDataInStudentPanelMessage.Enabled = t_mode;
                noDataInStudentPanelMessage.Visible = t_mode;
            }
        }
        private void studentMainPanel(bool t_mode)
        {
            studentsMainPanel.Enabled = t_mode;
            studentsMainPanel.Visible = t_mode;
        }

        private void leftStudentList_Click(object sender, EventArgs e)
        {
            if (leftPossible && connectedUserType == "teacher")
            {
                startingFrom -= recordsOnPage + 6;
                StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, studentQuestion, studentAssignment, studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
            }
            else if (leftPossible && connectedUserType == "student")
            {
                startingFrom -= recordsOnPage + 6;
                StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, connectedUser);
            }

        }

        private void rightStudentList_Click(object sender, EventArgs e)
        {
            if (startingFrom % 6 == 0 && rightPossible == true && connectedUserType == "teacher")
                StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, studentQuestion, studentAssignment, studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
            else if (startingFrom % 6 == 0 && rightPossible == true && connectedUserType == "student") { }
                StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, connectedUser);
        }
        private void studentTabDataInitialization()
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

        private void selectClassID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (selectClassID.SelectedValue != null)
            {
                StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, studentPanel, studentGB, studentImage, studentConnected, studentName, studentQuestion, studentAssignment, studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
                if (studentPanel[0].Enabled == true)// If the first panel is enabled, it means that there are no records from database matching the criteria, so, there are no students in the class studying teacher course.
                {
                    studentMainPanelNoData(true, "teacherNoStudents");
                }
                else
                    studentMainPanelNoData(false, "teacherNoStudents");
            }
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
        //

        private void homeButton_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "student")
            {
                Statistics.mainPanelConnectedColleagues(ref statisticsUsers, StudentsPanel.studentClassID(_connectedUser));
            }
            else if (connectedUserType == "teacher")
            {
                teachedClassesIDs = StudentsPanel.teachedClasses(connectedUser, out _teacherID); // getting the classes where teacher teaches
                Statistics.mainPanelConnectedStudents(ref statisticsUsers, teachedClassesIDs);
            }
            studentMainPanel(false);
        }

        private void meetingsButton_Click(object sender, EventArgs e)
        {
            studentMainPanel(false);
        }

        private void questionsButton_Click(object sender, EventArgs e)
        {
            studentMainPanel(false);
        }

        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            studentMainPanel(false);
        }



        // General Application Methods
        private void userDisconnectsSetOffline(string t_connectedUserType, string t_connectedUser)
        {
            string command = null;
            if (connectedUserType == "student")
                command = $"update student set connected = 'off' where username = '{_connectedUser}'";
            else
                command = $"update teacher set connected = 'off' where username = '{_connectedUser}'";
            Database.insert(command);
        }
        //
       
    }
}
