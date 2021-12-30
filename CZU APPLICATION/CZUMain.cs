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
        List<GroupBox> studentGB = new();
        List<PictureBox> studentConnected = new();
        List<Button> studentImage = new();
        List<Label> studentName = new();
        List<Label> studentQuestion = new();
        List<Label> studentAssignment = new();
        List<Label> studentMeeting = new();
        List<Panel> studentPanel = new();
        List<string> teachedClassesIDs = new List<string>();
        List<string> studiedCourses = new List<string>();
        // 

        // Home Panel Statistic Controls
        List <Label> statisticsControls = new();
        //

        // Question Panel Controls
        List <Button> questionTitle = new();
        List <GroupBox> questionGB = new();
        List <Label> questionStudentName = new();
        List <Label> questionPriorityLevel = new();
        List <Label> questionSubmitDate = new();
        List <Panel> questionPanel = new();
        List <Label> questionState = new();
        //

        // Left And Right Buttons
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


        // General Variables
        private int _times { get; set; } = 0;
        private string _command { get; set; }
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



        //

        // Question Tab
        private int _timesQuestionsTab { get; set; } = 0;
        //

        /// Connected as Student
        // Refresh Data
        private string _studentID;
        public string studentID
        {
            get
            {
                return _studentID;  
            }
            set
            {
                _studentID = value;
            }
        }

        private string _studentClassID;
        public string studentClassID
        {
            get
            {
                return _studentClassID;
            }
            set
            {
                _studentClassID = value;
            }
        }
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
        // For Question Tab
        List<string> questionID = new List<string>();
        //

        /// 

        // Refresh Data General 
        List<Panel> triggerPanel = new();
        //

        // Connected as Teacher 
        private string _teacherID;
        //

        public CZUMain()
        {
            InitializeComponent();
           
        }

        // Critical Functions for Form
        private void disableMenu(string t_message)
        {
            studentsButton.Enabled = false;
            meetingsButton.Enabled = false;
            homeButton.Enabled = false;
            assignmentsButton.Enabled = false;
            questionsButton.Enabled = false;
            MessageBox.Show(t_message);

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
                            StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                            break;
                    }
                    case "refreshcolleagues":
                    {
                        MessageBox.Show("Refresh data for student colleagues");
                            StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                            break;
                    }
                    case "refreshmeeting":
                    {
                        MessageBox.Show("Refresh data for student meetings");
                            StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                            break;
                    }
                    case "refreshassignment":
                    {
                        MessageBox.Show("Refresh data for student assignments");
                            StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
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

            // Enabling Home Panel as start and initializing some data. 
            homeMainPanelState(true);
            homeTabDataInitialization();
            //


            // Setting (GUI) username in Menu for connected user
            connectedId.Text = _connectedUser;
            //

            // Initializing the list of Trigger Panel
           // initializeTriggerPanelList(triggerPanel);
            //

            /// Critical functions related to connected User Type for data initialization
            if (connectedUserType == "student")
            {

                /*  // Initialization of latest students logs.
                  actions = StudentsTab.studentTriggerNewRefresh(_connectedUser, ref _studentLastMeeting, ref _studentLastAssignment, ref _studentLastColleague, ref _studentLastCourse);
                  refreshStudentData(actions);
                  //*/

                // Getting student for further operations
                _studentID = StudentsTab.getStudentID(_connectedUser);
                //

                // Getting student class id for further operations
                _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                //

                /// Verifying if the student is assigned to a class

                if (_studentClassID == null)  // If it is not assigned to a class
                {
                    string message = "You are not assigned to a class yet!";
                    // Disable all buttons
                    disableMenu(message);
                    //
                }
                else // If it is assigned to a class
                {
                    // Actualizing the data in statistics group for Home Panel
                    Statistics.homePanelUpdateDataAsStudent(ref statisticsControls, _studentClassID, _studentID); 
                    //
                }
                ///
            }

            else if (connectedUserType == "teacher")
            {
                // Getting teacher ID
                _teacherID = StudentsTab.getTeacherID(connectedUser);
                //

                // Getting the list of classes where teacher teaches
                teachedClassesIDs = StudentsTab.teachedClasses(connectedUser);
                //

                // Actualizing the data in statistics group for Home Panel
                Statistics.homePanelUpdateDataAsTeacher(ref statisticsControls, teachedClassesIDs, _teacherID);
                //

            }
            ///
        
        
        }
        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            userDisconnectsSetOffline(connectedUserType, connectedUser); // sets connected user status to offline.
        }
        //

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
        private void questionMainPanelState(bool t_mode)
        {
  
            questionsMainPanel.Enabled = t_mode;
            questionsMainPanel.Visible = t_mode;
        }
        private void MainPanelNoData(bool t_mode, string t_case)
        {

            noDataInPanelMessage.Enabled = false;
            noDataInPanelMessage.Visible = false;
            // Variables
            string[] casesList = new string[] { "teacherClassNoStudents", "teacherNoClasses", "studentNoColleagues", "teacherClassNoQuestions", "studentNoCourses", "studentHasNoQuestions"};
            string[] casesMessage = new string[] { "Class has no students", "You teach no classes", "You have no colleagues", "Class has no questions", "Class has no courses", "You have no questions"};
            Point[] casesMessagesLocations = new Point[6];
            //

            // Setting Messages Location for better readability and positioning.
            casesMessagesLocations[0] = new Point(400, 280);
            casesMessagesLocations[1] = new Point(400, 280);
            casesMessagesLocations[2] = new Point(400, 280);
            casesMessagesLocations[3] = new Point(400, 280);
            casesMessagesLocations[4] = new Point(400, 280);
            casesMessagesLocations[5] = new Point(400, 280);
            //


            // Verifying each case with the case from parameters list, if it exists, we'll select it.
            for(int i = 0; i < 6; ++i)
            {
                if(casesList[i] == t_case)
                {
                    MessageBox.Show("Am rulat, cazul este " + casesMessage[i]);
                    noDataInPanelMessage.Text = casesMessage[i];
                    noDataInPanelMessage.Enabled = true;
                    noDataInPanelMessage.Visible = true;
                }
            }
            //
        }
        /// 

        // Switching between lists of elements, adding question
        private void addQuestions_Click(object sender, EventArgs e)
        {
            string selectedCourse = Convert.ToString(questionsSelectClassListBox.SelectedValue);
            string teacherID = StudentsTab.getTeacherIDByCourse(selectedCourse);
            QuestionDetails addQuestion = new QuestionDetails(_studentID, teacherID); // take selected course teacher ID);
            addQuestion.Show();
        }
        private void leftStudentList_Click(object sender, EventArgs e)
        {
           // We use tempI variable declared in StudentsTab

        }

        private void rightStudentList_Click(object sender, EventArgs e)
        {
            // * The list is already initialized, because we pressed the Students Button

            // Showing the next list of student colleagues
            if (connectedUserType == "student") {
                // Verifying if there are more records available from the current Student ID
                string query = $"select id from student where id > {_startingFrom} && classID = {_studentClassID}";
                int records = 0;
                Database.recordExists(query, ref records);
                // 
                if (records > 0) // There are available records 
                    StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"&& id > {_startingFrom}");
                else
                {
                    MessageBox.Show("You have no more colleagues!");
                }
            
            }
            //
        }
        //

        // Creates lists of controls
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
        private void questionTabDataInitialization()
        {
            // Modifying GUI logic, to reuse code. 
            if (connectedUserType == "teacher")
            {
                questionsClassIDLabel.Text = "Class ID: ";
                addQuestions.Enabled = false;
                addQuestions.Visible = false;
            }
            else if(connectedUserType == "student")
            {
                questionsClassIDLabel.Text = "Courses: ";
            }
            //

            // Question Title
            questionTitle.Add(questionTitle1);
            questionTitle.Add(questionTitle2);
            questionTitle.Add(questionTitle3);
            questionTitle.Add(questionTitle4);

            // Question GroupBox
            questionGB.Add(questionGB2);
            questionGB.Add(questionGB1);
            questionGB.Add(questionGB3);
            questionGB.Add(questionGB4);

            // Question Student Name
            questionStudentName.Add(question1StudentName);
            questionStudentName.Add(question2StudentName);
            questionStudentName.Add(question3StudentName);
            questionStudentName.Add(question4StudentName);

            // Question Priority Level
            questionPriorityLevel.Add(question1PriorityLevel);
            questionPriorityLevel.Add(question2PriorityLevel);
            questionPriorityLevel.Add(question3PriorityLevel);
            questionPriorityLevel.Add(question4PriorityLevel);
            
            // Question Asked Date
            questionSubmitDate.Add(question1SubmitDate);
            questionSubmitDate.Add(question2SubmitDate);
            questionSubmitDate.Add(question3SubmitDate);
            questionSubmitDate.Add(question4SubmitDate);

            // Question Panel that covers question (depends on availability)
            questionPanel.Add(questionPanel1);
            questionPanel.Add(questionPanel2);
            questionPanel.Add(questionPanel3);
            questionPanel.Add(questionPanel4);
            
            // Question state (answered, not answered)
            questionState.Add(question1State);
            questionState.Add(question2State);
            questionState.Add(question3State);
            questionState.Add(question4State);
        }
        private void homeTabDataInitialization()
        {
            statisticsControls.Add(statisticsUsers);
            statisticsControls.Add(statisticsMeetings);
            statisticsControls.Add(statisticsQuestions);
            statisticsControls.Add(statisticsAssignments);
        }
        //

        // Select Class ListBox

        private void studentsSelectClassID_SelectedValueChanged(object sender, EventArgs e)
        {
            MainPanelNoData(true, "disableALL");
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        MessageBox.Show("AM RULAT CAZ DE STUDENTS MAIN PANEL");
                        string selectedClassValue = Convert.ToString(studentsSelectClassListBox.SelectedValue);
                        bool existsStudentsInClass = StudentsTab.updatePanelAsTeacher(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment, ref studentMeeting, selectedClassValue, _teacherID, "");
                        if (existsStudentsInClass == true)
                        {
                            MessageBox.Show("Class HAS students");
                        }
                        else
                        {
                            MessageBox.Show("Class has NO students");
                            MainPanelNoData(true, "teacherClassNoStudents");
                        }
                        break;

                    }
            }

        }
        private void questionsSelectClassListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            MainPanelNoData(true, "disableALL");
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        MessageBox.Show("AM RULAT CAZ DE QUESTIONS MAIN PANEL");

                        string selectedClassValue = Convert.ToString(questionsSelectClassListBox.SelectedValue);
                        bool existsQuestionsInClass = QuestionsTab.updatePanelAsTeacher(ref questionPanel, ref questionTitle, ref questionStudentName, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedClassValue, _teacherID, ref questionID);
                        if (existsQuestionsInClass == true)
                        {
                            MessageBox.Show("Class HAS questions");
                        }
                        else
                        {
                            MainPanelNoData(true, "teacherClassNoQuestions");
                            MessageBox.Show("Class HAS NO QUESTIONS");
                        }
                        break;
                    }
                case "student":
                    {
                        string selectedCourse = Convert.ToString(questionsSelectClassListBox.SelectedValue);
                        bool hasQuestions = QuestionsTab.updatePanelAsStudent(ref questionPanel, ref questionTitle, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedCourse, studentID, ref questionID);
                        if (hasQuestions == true)
                        {
                            MessageBox.Show("Student has questions");

                        }
                        else
                        {
                            // Message doesn't appear, need to be fixed
                            MessageBox.Show("Student has NO questions");
                            MainPanelNoData(true, "studentHasNoQuestions");
                        }
                        break;
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

        private void studentsButton_Click(object sender, EventArgs e)
        {
            // Enable Refresh Data Trigger
            // enableRefreshDataTrigger("student", triggerPanel); // TEMP DISABLED
            // 

            // Reset Left And Right buttons, by setting everything to initial state
            //



            // Disabling overlapped panels
            questionMainPanelState(false);
            homeMainPanelState(false);
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            // 


            /// Show Student Panel related to connected user type (Teacher or Student)
            if (connectedUserType == "teacher") // Teacher connected
            {

                // Getting the list of classes where teacher teaches
                teachedClassesIDs = StudentsTab.teachedClasses(connectedUser);
                //

                // Verifying if there are classes in list and update the (ListBox) List Teacher teached classes 
                bool classesExists = StudentsTab.updateTeachedClassesList(ref studentsSelectClassListBox, ref teachedClassesIDs, connectedUser); // returns true only if there is minimum one class
                //

                if (classesExists == true)
                { // if there is minimum one class teached by teacher
                    MessageBox.Show("Student Tab - Teacher has classes to teach");
                    // Getting the first Class ID
                    string selectedClass = Convert.ToString(studentsSelectClassListBox.Items[0]);
                    //

                    // Initializing the data in panel
                    StudentsTab.updatePanelAsTeacher(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment, ref studentMeeting, selectedClass, _teacherID, "");
                    //

                    // Showing the data
                    studentsMainPanelState(true);
                    //
                }
                else // if there isn't minimum one class teached by teacher
                {
                    MessageBox.Show("Student Tab - Teacher has NO classes to teach");
                    MainPanelNoData(true, "teacherNoClasses");
                }

            }
            else if (connectedUserType == "student") // Student connected 
            {

                if (_times == 0) // One Time Operations
                {
                    // Disabling Controls used for Teacher Interface
                    studentsSelectClassListBox.Enabled = false;
                    studentsSelectClassListBox.Visible = false;
                    studentsClassIDLabel.Enabled = false;
                    studentsClassIDLabel.Visible = false;
                    //
                    ++_times;
                }

                // Trying to initialize and start the GUI from student panel that shows connected colleagues. (Returns True for available data to be shown).
                bool colleaguesExists = StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _rightPossible, ref _leftPossible, ref _startingFrom, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                //

                // Getting again student class id until we make the trigger
                _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                //


                /// Verifying if there are colleagues available to be shown
                if (colleaguesExists == true)
                {
                    MessageBox.Show("Has colleagues");
                    studentsMainPanelState(true); // The Student Tab Main Panel appears, showing students colleagues.
                }
                else
                {
                    MessageBox.Show("He has NO colleagues");
                    MainPanelNoData(true, "studentNoColleagues"); // Showing the panel which says: "No connected colleagues"
                }
                ///
            }
            ///


        }
   
        private void homeButton_Click(object sender, EventArgs e)
        {
            // Disabling overlapped panels
            homeMainPanelState(true);
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            questionMainPanelState(false);
            // 

       

            if (connectedUserType == "student")
            {
                // Getting student class until create trigger
                _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                //

                // Actualizing the data in statistics group for Home Panel
                Statistics.homePanelUpdateDataAsStudent(ref statisticsControls, _studentClassID, _studentID); 
                // 
           
            }
            else if (connectedUserType == "teacher")
            {

                // Refreshing the amount of connected students
                teachedClassesIDs = StudentsTab.teachedClasses(connectedUser);
                //

                // Actualizing the data in statistics group for Home Panel
                Statistics.homePanelUpdateDataAsTeacher(ref statisticsControls, teachedClassesIDs, _teacherID);
                //               

            }
        }

        private void meetingsButton_Click(object sender, EventArgs e)
        {
            homeMainPanelState(true); // need to be replaced.
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
        }

        private void questionsButton_Click(object sender, EventArgs e)
        {

            // Reset Left And Right buttons, by setting everything to initial state
            //


            // Disabling overlapped panels
            homeMainPanelState(false); 
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            questionMainPanelState(false);
            //

            // Initializing the GUI elements for tab, just once. 
            if (_timesQuestionsTab == 0)
            {
                questionTabDataInitialization(); // set to be execute only once.
                ++_timesQuestionsTab;
            }
            //
          
            switch(connectedUserType)
            {
                case "teacher":
                    {
                       

                        bool classesExists = StudentsTab.updateTeachedClassesList(ref questionsSelectClassListBox, ref teachedClassesIDs, connectedUser); // returns true only if there is minimum one class
                        if (classesExists == true) // If exists classes
                        {
                            MessageBox.Show("Teacher - AM RULAT CAZ DE QUESTIONS MAIN PANEL");
                            string selectedClassValue = Convert.ToString(questionsSelectClassListBox.Items[0]);
                            bool existsQuestionsInClass = QuestionsTab.updatePanelAsTeacher(ref questionPanel, ref questionTitle, ref questionStudentName, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedClassValue, _teacherID, ref questionID);
                            if(existsQuestionsInClass == true)
                            {
                                questionMainPanelState(true);
                                MessageBox.Show("Class HAS questions");
                            }
                            else
                            {
                                MainPanelNoData(true, "teacherClassNoQuestions");
                                questionMainPanelState(true);
                                MessageBox.Show("Class HAS NO QUESTIONS");
                            }
                        }

                        else // If there are no classes
                        {
                            MessageBox.Show("Question Tab - No teached classes");
                            MainPanelNoData(true, "teacherNoClasses");
                        }
                        break;
                    }
                case "student":
                    {
                        // Getting again student class id until we make the trigger
                        _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                        //

                        // Getting the list of courses studied by student class
                        bool coursesExists = StudentsTab.updateStudiedCoursesList(ref questionsSelectClassListBox, _connectedUser, ref studiedCourses);
                        if(coursesExists == true)
                        {
                            MessageBox.Show(" Student - AM RULAT CAZ DE QUESTIONS MAIN PANEL, COURSES EXISTS");
                            string selectedCourse = Convert.ToString(questionsSelectClassListBox.Items[0]);
                            bool hasQuestions = QuestionsTab.updatePanelAsStudent(ref questionPanel, ref questionTitle, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedCourse, studentID, ref questionID);
                            if(hasQuestions == true)
                            {
                                MessageBox.Show("Student has questions");
                                questionMainPanelState(true);

                            }
                            else
                            {
                                // Message doesn't appear, need to be fixed
                                MessageBox.Show("Student has NO questions");
                                questionMainPanelState(true);
                                MainPanelNoData(true, "studentHasNoQuestions");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Student - AM RULAT CAZ DE QUESTIONS, MAIN PANEL, COURSES DON T EXIST");
                            MainPanelNoData(true, "studentNoCourses");
                        }
                        //

                        break;


                    }

            }
            
        }

        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            homeMainPanelState(true); // need to be replaced.
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
        }
        // 

        // Question Tab Buttons for interacting with question
        private void questionTitle1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        string questionTitle, question;
                        QuestionsTab.getQuestionDataAsTeacher(questionID[0], out questionTitle, out question);
                        QuestionDetails question1 = new QuestionDetails(questionTitle, question, questionID[0]);
                        question1.Show();
                        break;
                    }
                case "student":
                    {

                        QuestionDetails question1 = new QuestionDetails(questionID[0]); // take selected course teacher ID);
                        question1.Show();
                        break;
                    }
            }

      

        }

        private void questionTitle2_MouseClick(object sender, MouseEventArgs e)
        {
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        string questionTitle, question;
                        QuestionsTab.getQuestionDataAsTeacher(questionID[1], out questionTitle, out question);
                        QuestionDetails question2 = new QuestionDetails(questionTitle, question, questionID[1]);
                        question2.Show();
                        break;
                    }
                case "student":
                    {
                        QuestionDetails question2 = new QuestionDetails(questionID[1]); // take selected course teacher ID);
                        question2.Show();
                        break;
                    }
            }
        }

        private void questionTitle3_MouseClick(object sender, MouseEventArgs e)
        {
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        string questionTitle, question;
                        QuestionsTab.getQuestionDataAsTeacher(questionID[2], out questionTitle, out question);
                        QuestionDetails question3 = new QuestionDetails(questionTitle, question, questionID[2]);
                        question3.Show();
                        break;
                    }
                case "student":
                    {
                        QuestionDetails question3 = new QuestionDetails(questionID[2]); // take selected course teacher ID);
                        question3.Show();
                        break;
                    }
            }

        }
        private void questionTitle4_MouseClick(object sender, MouseEventArgs e)
        {
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        string questionTitle, question;
                        QuestionsTab.getQuestionDataAsTeacher(questionID[3], out questionTitle, out question);
                        QuestionDetails question4 = new QuestionDetails(questionTitle, question, questionID[3]);
                        question4.Show();
                        break;
                    }
                case "student":
                    {
                        QuestionDetails question4 = new QuestionDetails(questionID[3]); // take selected course teacher ID);
                        question4.Show();
                        break;
                    }
            }

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

