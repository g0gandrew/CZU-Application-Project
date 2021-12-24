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

        /// Connected as Student
        // Refresh Data
        private int _studentLastCourse = 0;
        public int studentLastCourse
        {
            get
            {
                return _studentLastCourse;
            }
            set
            {
                _studentLastCourse = value; 
            }
        }

        private int _studentLastMeeting = 0;
        public int studentLastMeeting
        {
            get
            {
                return _studentLastMeeting;
            }
            set
            {
                _studentLastMeeting = value;
            }
        }

        private int _studentLastAssignment = 0;
        public int studentLastAssignment
        {
            get
            {
                  return _studentLastAssignment;
            }
            set
            {
                _studentLastAssignment = value; 
            }
        }

        private int _studentLastColleague = 0;
        public int studentLastColleague
        {
            get
            {
                return _studentLastColleague;
            }
            set
            {
               _studentLastColleague = value;
            }
        }
        List<string> actions; // List used for multiple tasks to do on refreshing data. (Stores what to refresh).
        //
        /// 

        // Refresh Data General 
        List <Panel> triggerPanel = new List<Panel>();
        //

        // Connected as Teacher 
        private string _teacherID;
        //

        public CZUMain()
        {
            InitializeComponent();
           
        }

        private void refreshStudentData(List <string> t_actions) // hard coded function
        {
            foreach (string i in t_actions)
            {
                switch (i)
                {
                    case "refreshcourse":
                    {
                        MessageBox.Show("Refresh data for student courses");
                            StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser);
                            break;
                    }
                    case "refreshcolleagues":
                    {
                        MessageBox.Show("Refresh data for student colleagues");
                        StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser);
                            break;
                    }
                    case "refreshmeeting":
                    {
                        MessageBox.Show("Refresh data for student meetings");
                        StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser);
                            break;
                    }
                    case "refreshassignment":
                    {
                        MessageBox.Show("Refresh data for student assignments");
                        StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser);
                            break;
                    }
                    default:
                        {
                            MessageBox.Show("No need to refresh - Test");
                            break;
                        }
                }
            }
        }
        private void CZUMain_Load(object sender, EventArgs e)
        {
            // Creating the GUI of Student Tab for Users shown in panel.
            studentTabDataInitialization(); 
            // 

            // Enabling Home Panel as Start
            homeMainPanelState(true);
            //

            // Setting (GUI) username in Menu for connected user
            connectedId.Text = _connectedUser;
            //

            // Initializing the list of Trigger Panel
            initializeTriggerPanelList(triggerPanel);
            //

            /// Critical functions related to connected User Type for data initialization
            if (connectedUserType == "student")
            {

                // Initialization of latest students logs.
                actions = StudentsPanel.studentTriggerNewRefresh(_connectedUser, ref _studentLastMeeting, ref _studentLastAssignment, ref _studentLastColleague, ref _studentLastCourse);
                refreshStudentData(actions);
                //

                // Introducing data in Home Panels statistics
                Statistics.homePanelConnectedColleagues(ref statisticsUsers, StudentsPanel.getStudentClassID(_connectedUser)); // Actualizing the number of connected colleagues
                // 
            }

            else if (connectedUserType == "teacher")
            {
                // Getting teacher ID
                _teacherID = StudentsPanel.getTeacherID(connectedUser);
                //

                // Getting the list of classes where teacher teaches
                teachedClassesIDs = StudentsPanel.teachedClasses(connectedUser); 
                Statistics.homePanelConnectedStudents(ref statisticsUsers, teachedClassesIDs); // Actualizing the number of connected students
                //

            }
            ///
        
        
        }
        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            userDisconnectsSetOffline(connectedUserType, connectedUser); // sets connected user status to offline.
        }


        // Student and Colleagues Tab Methods and Events
        private void studentsButton_Click(object sender, EventArgs e)
        {
            // Enable Refresh Data Trigger
            // enableRefreshDataTrigger("student", triggerPanel); // TEMP DISABLED
            // 


            // Disabling overlapped panels
            homeMainPanelState(true);
            studentsMainPanelState(false);
            studentMainPanelNoData(true, "disableAll");
            // 
            

            /// Show Student Panel related to connected user type (Teacher or Student)
            if (connectedUserType == "teacher") // Teacher connected
            {
                // Verifying if there are classes in list and update the (ListBox) List Teacher teached classes 
                bool classesExists = StudentsPanel.updateTeachedClassesList(selectClassID, ref teachedClassesIDs, connectedUser); // returns true only if there is minimum one class
                //
                if (classesExists == true) { // if there is minimum one class teached by teacher
                    MessageBox.Show("Teacher has classes to teach");
                    StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment, ref studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
                    studentsMainPanelState(true);
                }
                else // if there isn't minimum one class teached by teacher
                {
                    MessageBox.Show("Teacher has NO classes to teach");
                    studentMainPanelNoData(true, "teacherNoClasses");
                }

            }
            else if (connectedUserType == "student") // Student connected 
            {

                if (_times == 0) // One Time Operations
                {
                    // Disabling Controls used for Teacher Interface
                    selectClassID.Enabled = false;
                    selectClassID.Visible = false;
                    classIDLabel.Enabled = false;
                    classIDLabel.Visible = false;
                    //
                    ++_times;
                }

                // Trying to initialize and start the GUI from student panel that shows connected colleagues. (Returns True for available data to be shown).
                bool colleaguesExists = StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser);
                //

                /// Verifying if there are colleagues available to be shown
                if (colleaguesExists == true) 
                {
                    MessageBox.Show("Has colleagues");
                    studentsMainPanelState(true); // The Student Tab Main Panel appears, showing students colleagues.
                }
                else
                {
                    MessageBox.Show("He has NOT colleagues");
                    studentMainPanelNoData(true, "studentNoColleagues"); // Showing the panel which says: "No connected colleagues"
                }
                ///
            }
            ///


        }

        private void cleanGUI()
        {
            selectClassID.Enabled = false;
            selectClassID.Visible = false;
            classIDLabel.Enabled = false;
            classIDLabel.Visible = false;
        }
        private void studentMainPanelNoData(bool t_mode, string t_case)
        {
            MessageBox.Show("AM RULAT MESAJE NO DATA");

            if (t_case == "teacherClassNoStudents")
            {
                noDataInStudentPanelMessage.Text = "      Class has no students";
                noDataInStudentPanelMessage.Enabled = t_mode;
                noDataInStudentPanelMessage.Visible = t_mode;
                studentsPanelNoData.Enabled = t_mode;
                studentsPanelNoData.Visible = t_mode;
            }
            else
            {
                studentsPanelNoData.Enabled = !t_mode;
                studentsPanelNoData.Visible = !t_mode;
                noDataInStudentPanelMessage.Enabled = !t_mode;
                noDataInStudentPanelMessage.Visible = !t_mode;

            }

            if (t_case == "teacherNoClasses")
            {
                MessageBox.Show("Am rulat");
                studentsPanelNoData.Enabled = t_mode;
                studentsPanelNoData.Visible = t_mode;
                noDataInStudentPanelMessage.Enabled = t_mode;
                noDataInStudentPanelMessage.Visible = t_mode;
            }
            else
            {
                studentsPanelNoData.Enabled = !t_mode;
                studentsPanelNoData.Visible = !t_mode;
                noDataInStudentPanelMessage.Enabled = !t_mode;
                noDataInStudentPanelMessage.Visible = !t_mode;
            } 

           if(t_case == "studentNoColleagues")
            {
                MessageBox.Show("studentNoColleagues" + t_mode);
                studentsPanelNoData.Enabled = t_mode;
                studentsPanelNoData.Visible = t_mode;
                noDataInStudentPanelMessage.Text = "      You have no colleagues";
                noDataInStudentPanelMessage.Enabled = t_mode;
                noDataInStudentPanelMessage.Visible = t_mode;
            }
           else
            {
                studentsPanelNoData.Enabled = !t_mode;
                studentsPanelNoData.Visible = !t_mode;
                noDataInStudentPanelMessage.Enabled = !t_mode;
                noDataInStudentPanelMessage.Visible = !t_mode;
            }

        }

        /// Panels state
        private void studentsMainPanelState(bool t_mode)
        {
            studentsMainPanel.Enabled = t_mode;
            studentsMainPanel.Visible = t_mode;
        }
        private void homeMainPanelState(bool t_mode)
        {
            homeMainPanel.Enabled = t_mode;
            homeMainPanel.Visible = t_mode;
        }
        /// 
 
        // Switching between lists of elements 
        private void leftStudentList_Click(object sender, EventArgs e)
        {
            if (leftPossible && connectedUserType == "teacher")
            {
                startingFrom -= recordsOnPage + 6;
                StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment, ref studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
            }
            else if (leftPossible && connectedUserType == "student")
            {
                startingFrom -= recordsOnPage + 6;
                StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser);
            }

        }

        private void rightStudentList_Click(object sender, EventArgs e)
        {
            if (startingFrom % 6 == 0 && rightPossible == true && connectedUserType == "teacher")
                StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment, ref studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
            else if (startingFrom % 6 == 0 && rightPossible == true && connectedUserType == "student") { }
                StudentsPanel.updatePanelAsStudent(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser);
        }
        //


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
      
        // Select Class ListBox
        private void selectClassID_SelectedValueChanged(object sender, EventArgs e)
        {
    

            if (connectedUserType == "teacher")
            {
                bool existsStudentsInClass = StudentsPanel.updatePanelAsTeacher(out _recordsOnPage, out _rightPossible, out _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment, ref studentMeeting, Convert.ToString(selectClassID.SelectedValue), _teacherID);
                if (existsStudentsInClass == true)
                {
                    studentsMainPanelState(true);
                    MessageBox.Show("Class HAS students");
                }
                else
                {
                    homeMainPanelState(false);
                    studentsMainPanelState(false);
                    MessageBox.Show("Class has NO students");
                    studentMainPanelNoData(true, "teacherClassNoStudents");
                }
            }
        }
        //

        // On Panel Triggers for Refreshing Data
        private void initializeTriggerPanelList(List<Panel> t_triggerPanel) // Initializing the list of panels. (Adding them in a list)
        {
            t_triggerPanel.Add(triggerDataRefreshStudentPanel);
            // Need to add the others
        } 
        private void enableRefreshDataTrigger(string t_currentTab, List <Panel> t_triggerPanel)
        {
            MessageBox.Show("Refresh Data Trigger");
            void disableTriggers(ref Panel t_exceptThis)
            {
                foreach(Panel p in t_triggerPanel)
                {
                    if (p != t_exceptThis)
                    {
                        p.Enabled = false;
                        p.Visible = false;
                    }
                }
                t_exceptThis.Enabled = false;
                t_exceptThis.Visible = false;
            }
            switch (t_currentTab)
            {
                case "home":
                {

                    break;
                }
                case "student":
                {
                        MessageBox.Show("Refresh Data Trigger Student");
                        disableTriggers(ref triggerDataRefreshStudentPanel);
                    break;

                }
                case "assignment":
                {
                    break;

                }
                case "meeting":
                {
                    break;

                }
                case "question":
                {
                    break;

                }
            }

       

        } // Disables other trigger surfaces and enabling the right one related to active Tab.

        private void CZUMain_MouseMove(object sender, MouseEventArgs e)
        {
           /* if (triggerDataRefreshStudentPanel.Bounds.Contains(e.Location))
            {
              *//*  MessageBox.Show("Run Test  - Trigger Student Panel");
                if (_connectedUserType == "student") // verify database for any new modifications 
                {
                    // verify database for any new modifications 
                    actions = StudentsPanel.studentTriggerNewRefresh(_connectedUser, ref _studentLastMeeting, ref _studentLastAssignment, ref _studentLastColleague, ref _studentLastCourse);
                    refreshStudentData(actions);
                    //
                }
                else
                {
                    StudentsPanel.updateTeachedClassesList(selectClassID, ref teachedClassesIDs, connectedUser); // updating Teacher Teached Classes List every time he clicks
                }*//*
            }
            */
        }
        //

        // Functions for showing data related to student
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

        // Menu buttons
        private void homeButton_Click(object sender, EventArgs e)
        {
            // Disabling overlapped panels
            homeMainPanelState(true);
            studentsMainPanelState(false);
            studentMainPanelNoData(true, "disableAll");
            // 

            if (connectedUserType == "student")
            {
                Statistics.homePanelConnectedColleagues(ref statisticsUsers, StudentsPanel.getStudentClassID(_connectedUser));  // Actualizing the number of connected colleagues
            }
            else if (connectedUserType == "teacher")
            {
                teachedClassesIDs = StudentsPanel.teachedClasses(connectedUser); // Getting and initializing a list of classes where teacher teaches
                Statistics.homePanelConnectedStudents(ref statisticsUsers, teachedClassesIDs);  // Actualizing the number of connected students
            }
        }

        private void meetingsButton_Click(object sender, EventArgs e)
        {
            homeMainPanelState(true); // need to be replaced.
            studentsMainPanelState(false);
            studentMainPanelNoData(true, "disableAll");
        }

        private void questionsButton_Click(object sender, EventArgs e)
        {
            homeMainPanelState(true); // need to be replaced.
            studentsMainPanelState(false);
            studentMainPanelNoData(true, "disableAll");
        }

        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            homeMainPanelState(true); // need to be replaced.
            studentsMainPanelState(false);
            studentMainPanelNoData(true, "disableAll");
        }
        // 

        // General Application Methods
        private void userDisconnectsSetOffline(string t_connectedUserType, string t_connectedUser)
        {
            string command = null;
            if (t_connectedUserType == "student")
                command = $"update student set connected = 'off' where username = '{t_connectedUser}'";
            else
                command = $"update teacher set connected = 'off' where username = '{t_connectedUser}'";
            Database.insert(command);
        }
        //

    }
}
