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
        List<Panel> studentPanel = new();
        List <string> _teachedClassesIDs = new();
        List <string> _studiedCourses = new();
        // 


        // Home Panel Statistic Controls
        List <Label> statisticsControls = new();
        //

        // Question Panel Controls
        List <Button> questionTitle = new();
        List <Label> questionStudentName = new();
        List <GroupBox> questionGB = new();
        List <Label> questionPriorityLevel = new();
        List <Label> questionSubmitDate = new();
        List <Panel> questionPanel = new();
        List <Label> questionState = new();
        //

        // Assignment Panel Controls
        List<Panel> assignmentPanel = new();
        List<Button> assignmentTitle = new();
        List<Label> assignmentDeadline = new();
        List<Label> assignmentState = new();
        List<Label> assignmentGrade = new();
        List<GroupBox> assignmentGB = new();
        //

        // Left And Right Buttons
        private int _startAt = 0;
        public int startAt
        {
            get
            {
                return _startAt;
            }
            set
            {
                _startAt = value;
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
        private int _lastID = 0;
        public int lastID
        {
            get
            {
                return _lastID;
            }
            set
            {
                _lastID = value;
            }
        }

        //


        // General Variables
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

        // Tabs state
        private bool _QuestionsTabInitialized { get; set; } = false;
        private bool _StudentsTabInitialized { get; set; } = false;
        private bool _AssignmentsTabInitialized { get; set; } = false;
        private string _assignmentTeacherInterfaceMode { get; set; }
        //

        /// Connected as Student
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
       /// 


        // List of main elements IDS
        List<string> _questionID = new List<string>();

        List<string> _assignmentID = new List<string>();

        List<string> _studentIDS = new List<string>();  
        //
        /// 


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
            // Disabling the application buttons
            studentsButton.Enabled = false;
            gradesButton.Enabled = false;
            homeButton.Enabled = false;
            assignmentsButton.Enabled = false;
            questionsButton.Enabled = false;
            //
            MessageBox.Show(t_message);

        }
        private void CZUMain_Load(object sender, EventArgs e)
        {

            // 
            MainPanelNoData(true, "disableALL");
            //

            // Enabling Home Panel as start and initializing some data. 
            homeMainPanelState(true);
            homeTabGUIInitialization();
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
                    // Actualizing the data in statistics group box for Home Panel
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

                // Disabling Grades button (It is used just by the student)
                gradesButton.Enabled = false;
                //

                // Getting the list of classes where teacher teaches
                _teachedClassesIDs = StudentsTab.teachedClasses(connectedUser);
                //

                // Actualizing the data in statistics group for Home Panel
                Statistics.homePanelUpdateDataAsTeacher(ref statisticsControls, _teachedClassesIDs, _teacherID);
                //

            }
            ///
        
        
        }
        private void CZUMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // If the user closes the application
            userDisconnectsSetOffline(connectedUserType, connectedUser); // Sets connected user status to offline.
            //
        }
        private void MainPanelNoData(bool t_mode, string t_case)
        {
            // Pseudo disabling message, until proven different
            noDataInPanel.Visible = false;
            noDataInPanel.Enabled = false;
            noDataInPanelMessage.Enabled = false;
            noDataInPanelMessage.Visible = false;
            //


            // Variables
            string[] casesList = new string[] { "teacherClassNoStudents", "teacherNoClasses", "studentNoColleagues", "teacherClassNoQuestions", "studentNoCourses", "studentHasNoQuestions", "studentHasNoAssignments", "classHasNoAssignments", "assignmentHasNoSolutions"};
            string[] casesMessage = new string[] { "Class has no students", "You teach no classes", "You have no colleagues", "Class has no questions", "Class has no courses", "You have no questions", "You have no assignments", "Class has no assignments", "No solutions available"};
            //

            // Verifying each case with the case from parameters list, if it exists, we'll select it.
            for(int i = 0; i < 9; ++i)
            {
                if(casesList[i] == t_case)
                {
                    noDataInPanelMessage.Text = casesMessage[i];
                    noDataInPanelMessage.Enabled = true;
                    noDataInPanelMessage.Visible = true;
                    noDataInPanel.Enabled = true;
                    noDataInPanel.Visible = true;
                }
            }
            //
        }
        private void assignmentInterfaceMode(string t_interfaceMode)
        {
            switch(t_interfaceMode)
            {
                case "teacherManagesAssignments":
                    {
                        foreach (Control c in assignmentGB)
                        {
                            c.Enabled = true;
                            c.Visible = true;
                        }
                        foreach (GroupBox g in assignmentGB)
                        {
                            g.BackColor = Color.Transparent;
                        }

                        break;
                    }
                case "studentAssignmentSolution":
                    {
                        // Disabling some controls that aren't used in this interface mode
                        addAssignment.Enabled = false;
                        addAssignment.Visible = false;
                        //

                        foreach (Control c in assignmentGB)
                        {
                            bool disableIt = true;
                            for (int i = 1; i <= 4; ++i)
                            {
                                if (c.Name == $"assignment{i}GB")
                                {
                                    disableIt = false;
                                }
                            }
                            if(disableIt)
                            {
                                c.Enabled = false;
                                c.Visible = false;
                            }

                        }
                        foreach(GroupBox g in assignmentGB)
                        {
                            g.BackColor = Color.Red;
                        }
                        break;
                    }
            }
        }
        //

        /// Panels state
        private void assignmentsMainPanelState(bool t_mode)
        {
            if(_connectedUserType == "student")
            {
                // Disabling add assignment button (it is for teacher)
                addAssignment.Enabled = false;
                addAssignment.Visible = false;
                //

                // Modify 'Select Class ID' control name to reuse code
                assignmentSelectClassID.Text = "Course:";
                //

                // Disabling some controls used for teacher interface
                assignmentName.Enabled = false;
                assignmentName.Visible = false;
                selectAssignmentNameListBox.Enabled = false;
                selectAssignmentNameListBox.Visible = false;
                //
            }
            // Changing panel state, related to the parameter (ON/OFF)
            assignmentsMainPanel.Enabled = t_mode;
            assignmentsMainPanel.Visible = t_mode;
            //

        }
        private void studentsMainPanelState(bool t_mode)
        {
            // Changing panel state, related to the parameter (ON/OFF)
            studentsMainPanel.Enabled = t_mode;
            studentsMainPanel.Visible = t_mode;
            //
        }
        private void homeMainPanelState(bool t_mode)
        {
            // Changing panel state, related to the parameter (ON/OFF)
            homeMainPanel.Enabled = t_mode;
            homeMainPanel.Visible = t_mode;
            //
        }
        private void questionMainPanelState(bool t_mode)
        {
            // Changing panel state, related to the parameter (ON/OFF)
            questionsMainPanel.Enabled = t_mode;
            questionsMainPanel.Visible = t_mode;
            //
        }
        private void gradesMainPanelState(bool t_mode)
        {
            // Changing panel state, related to the parameter (ON/OFF)
            gradesMainPanel.Enabled = t_mode;
            gradesMainPanel.Visible = t_mode;
            //
        }
        //

        /// 

        // Switching between lists of elements, adding question
        private void addQuestions_Click(object sender, EventArgs e)
        {
            // Gets the course name from the 'Select Course' listbox
            string selectedCourse = Convert.ToString(questionsSelectClassListBox.SelectedValue);
            //
            
            // Gets teacherID by course name
            string teacherID = StudentsTab.getTeacherIDByCourse(selectedCourse);
            //

            // Create a new object of QuestionDetails
            CZUQuestion addQuestion = new CZUQuestion(_studentID, teacherID); 
            //

            // Shows the form
            addQuestion.Show();
            //
        }
        private void leftStudentList_Click(object sender, EventArgs e)
        {

            // Showing the previous list of colleagues 
            if (connectedUserType == "student")
            {
                // Variables
                int output = 0;
                string query;
                int records, startFromId = 0;
                //


                /* Verifying, if, from this list of records, if we take out all its elements + 1, there exists a record.
                 If there exists a record, it means that there is a full list available. If not, there is no more data available.
                 Because, from the begging, the list is populated with six elements. (Take a look at button algorithm from files.
                */

                // From the last id, verfiy the previous explanation, and get the record ID
                query = $"select id from student where id < {_lastID} && classID = {_studentClassID} && id <> {_studentID} order by id desc limit {_recordsOnPage}";
                Database.getData(query, ref output);
                //
                
                // From the record we have, verify if there are 5 more available, to populate the list, if not, do nothing.
                query = $"select id from student where id < {output} && classID = {_studentClassID} && id <> {_studentID} order by id desc limit 5";
                records = Database.getDataAndNoOfRecords(query, 1, ref startFromId);
                //
        
                if (records == 5) // FULL LIST
                {
                    // Activate right button
                    studentsRightList.Enabled = true;
                    //

                    // Repopulate the list
                    StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"&& id >= {startFromId} limit 6");
                    //
                }
                else // No elements in list
                {
                    studentsLeftList.Enabled = false;
                }
            }
            else if(connectedUserType == "teacher")
            {
                // Variables
                int output = 0;
                string query;
                int records, startFromId = 0;
                string selectedClassValue = Convert.ToString(studentsSelectClassListBox.SelectedValue);
                //

                /* Verifying, if, from this list of records, if we take out all its elements + 1, there exists a record.
                 If there exists a record, it means that there is a full list available. If not, there is no more data available.
                 Because, from the begging, the list is populated with six elements. (Take a look at button algorithm from files.
                */
                // From the last id, verfiy the previous explanation, and get the record ID
                query = $"select id from student where id < {_lastID} && classID = {selectedClassValue} order by id desc limit {_recordsOnPage}";
                Database.getData(query, ref output);
                //

                // From the record we have, verify if there are 5 more available, to populate the list, if not, do nothing.
                query = $"select id from student where id < {output} && classID = {selectedClassValue} order by id desc limit 5";
                records = Database.getDataAndNoOfRecords(query, 1, ref startFromId);
                //

                if (records == 5) // FULL LIST
                {
                    // Activate right button
                    studentsRightList.Enabled = true;
                    //

                    // Repopulate the list
                    StudentsTab.updatePanelAsTeacher(ref _recordsOnPage, ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment,   selectedClassValue, _teacherID, $"&& id >= {startFromId} limit 6", ref _studentIDS);
                    //
                }
                else // No elements in list
                {
                    studentsLeftList.Enabled = false;
                }
            }

        }
        private void rightStudentList_Click(object sender, EventArgs e)
        {
            // * The list is already initialized, because we pressed the Students Button
            // Showing the next list of colleagues
            if (connectedUserType == "student") {

                // Variables
                int records = 0;
                //

                // Verifying if there are more records available from the current Student ID
                string query = $"select id from student where id > {_lastID} && classID = {_studentClassID} && id <> {_studentID} limit 6";
                Database.recordExists(query, ref records);
                //

                if (records > 0) // There are available records 
                {  
                    StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"&& id > {_lastID}");
                    // * Because there are available records, it means that we can swipe to the next list, and, we can also go back
                    
                    // Because of that, we activate left button
                    studentsLeftList.Enabled = true;
                    //
                }
                else
                {
                    // IF there are no more records, deactivate right button
                    studentsRightList.Enabled = false;
                    //
                }
            }
            //

            else if(connectedUserType == "teacher")
            {
                // Variables
                int records = 0;
                //

                // Getting the value of current class selection
                string selectedClassValue = Convert.ToString(studentsSelectClassListBox.SelectedValue);
                //

                // Verifying if there are more records available from the current Student ID
                string query = $"select id from student where classID = {selectedClassValue} && id > {_lastID} limit 6";
                Database.recordExists(query, ref records);
                //

                if (records > 0) // There are available records 
                {  
                    StudentsTab.updatePanelAsTeacher(ref _recordsOnPage, ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment,   selectedClassValue, _teacherID, $"&& id > {_lastID} limit 6", ref _studentIDS);
                    // * Because there are available records, it means that we can swipe to the next list, and, we can also go back
                    
                    // Because there are more available records, we activate left button
                    studentsLeftList.Enabled = true;
                    //
                }
                else
                {
                    // IF there are no more records, deactivate right button
                    studentsRightList.Enabled = false;
                    //
                }
            }
        }
        //

        // Creates lists of controls
        private void studentTabGUInitialization(string t_connectedUserType)
        {
            // Student Connection State (ON/OFF)
            studentConnected.Add(studentConnected1);
            studentConnected.Add(studentConnected2);
            studentConnected.Add(studentConnected3);
            studentConnected.Add(studentConnected4);
            studentConnected.Add(studentConnected5);
            studentConnected.Add(studentConnected6);
            //

            // Student GB
            studentGB.Add(studentGB1);
            studentGB.Add(studentGB2);
            studentGB.Add(studentGB3);
            studentGB.Add(studentGB4);
            studentGB.Add(studentGB5);
            studentGB.Add(studentGB6);
            //

            // Student Image
            studentImage.Add(studentImage1);
            studentImage.Add(studentImage2);
            studentImage.Add(studentImage3);
            studentImage.Add(studentImage4);
            studentImage.Add(studentImage5);
            studentImage.Add(studentImage6);
            //

            // Student Name
            studentName.Add(studentName0);
            studentName.Add(studentName1);
            studentName.Add(studentName2);
            studentName.Add(studentName3);
            studentName.Add(studentName4);
            studentName.Add(studentName5);
            //

            // If the connected user type is teacher, add some extra controls
            if (t_connectedUserType == "teacher")
            {
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
            }
            // 

            // If the connected user type is student, disable controls that are used for teacher connection type
            else if(t_connectedUserType == "student")
            {
                // Disabling controls used for teacher interface
                for(int i = 0; i < 6; ++i)
                    foreach(Control ctr in studentGB[i].Controls)
                        if (ctr.Name != $"studentName{i}")
                        {
                            ctr.Enabled = false;
                            ctr.Visible = false;
                        }
                //

                // Disabling Controls used for Teacher Interface
                studentsSelectClassListBox.Enabled = false;
                studentsSelectClassListBox.Visible = false;
                studentsClassIDLabel.Enabled = false;
                studentsClassIDLabel.Visible = false;
                //
            }

            // Student Panel
            studentPanel.Add(studentPanel1);
            studentPanel.Add(studentPanel2);
            studentPanel.Add(studentPanel3);
            studentPanel.Add(studentPanel4);
            studentPanel.Add(studentPanel5);
            studentPanel.Add(studentPanel6);
            //
        }
        private void questionTabGUIInitialization(string t_connectedUserType)
        {
            // Question Student Name
            questionGB.Add(questionGB0);
            questionGB.Add(questionGB1);
            questionGB.Add(questionGB2);
            questionGB.Add(questionGB3);
            //


            // Modifying GUI logic, to reuse code. 
            if (t_connectedUserType == "teacher")
            {
                questionsClassIDLabel.Text = "Class ID: ";
                addQuestions.Enabled = false;
                addQuestions.Visible = false;
              
            }
            else if(t_connectedUserType == "student")
            {
                // Changing front text of 'Select Class Id --> List Box' to reuse the control for student interface
                questionsClassIDLabel.Text = "Courses: ";
                //

                // Disabling 'Student Name' controls
                for (int i = 0; i < 4; ++i)
                {
                    foreach (Control c in questionGB[i].Controls)
                    {
                        // Disabling the controls that aren't used for question tab on "student" type of connection
                        if ((c.Name == $"question{i}StudentName" || c.Text == "Student Name:")) 
                        {
                            c.Enabled = false;
                            c.Visible = false;
                        }
                        //  

                        else // Modifying other controls position in GroupBox for better Design and code reusability
                        {
                            // Creating an object of Point Class
                            Point controlLocation = new Point();
                            // 

                            // Assigning the instance of Point Class our control location
                            controlLocation = c.Location;
                            //
                            
                            // Modifiyng the vertical location of controls, with -18 pixels, to modify the Design of GroupBox.
                            controlLocation.Y -= 18;
                            c.Location = new Point(controlLocation.X, controlLocation.Y);
                            //
                        }
                    }
                }
            }
            // Question Student Name
            questionStudentName.Add(question0StudentName);
            questionStudentName.Add(question1StudentName);
            questionStudentName.Add(question2StudentName);
            questionStudentName.Add(question3StudentName);
            //

            // Question Title
            questionTitle.Add(questionTitle1);
            questionTitle.Add(questionTitle2);
            questionTitle.Add(questionTitle3);
            questionTitle.Add(questionTitle4);
            //
            
            // Question Priority Level
            questionPriorityLevel.Add(question1PriorityLevel);
            questionPriorityLevel.Add(question2PriorityLevel);
            questionPriorityLevel.Add(question3PriorityLevel);
            questionPriorityLevel.Add(question4PriorityLevel);
            //

            // Question Asked Date
            questionSubmitDate.Add(question1SubmitDate);
            questionSubmitDate.Add(question2SubmitDate);
            questionSubmitDate.Add(question3SubmitDate);
            questionSubmitDate.Add(question4SubmitDate);
            //

            // Question Panel that covers question (depends on availability)
            questionPanel.Add(questionPanel1);
            questionPanel.Add(questionPanel2);
            questionPanel.Add(questionPanel3);
            questionPanel.Add(questionPanel4);
            //

            // Question state (answered, not answered)
            questionState.Add(question1State);
            questionState.Add(question2State);
            questionState.Add(question3State);
            questionState.Add(question4State);
            //
        }
        private void homeTabGUIInitialization()
        {
            // List of controls that display related data
            statisticsControls.Add(statisticsUsers);
            statisticsControls.Add(statisticsQuestions);
            statisticsControls.Add(statisticsAssignments);
            //
        }
        private void assignmentTabGUIInitialization(string t_connectedUserType)
        {
            if(connectedUserType == "student")
            {
                // Disabling Controls for interface choice
                teacherAssignments.Enabled = false;
                teacherAssignments.Visible = false;
                studentsAssignments.Enabled = false;
                studentsAssignments.Visible = false;
                //

            }
           
            // Panel
            assignmentPanel.Add(assignment1Panel);
            assignmentPanel.Add(assignment2Panel);
            assignmentPanel.Add(assignment3Panel);
            assignmentPanel.Add(assignment4Panel);
            //

            // Title
            assignmentTitle.Add(assignment1Button);
            assignmentTitle.Add(assignment2Button);
            assignmentTitle.Add(assignment3Button);
            assignmentTitle.Add(assignment4Button);
            //

            // Deadline
            assignmentDeadline.Add(assignment1DeadLine);
            assignmentDeadline.Add(assignment2Deadline);
            assignmentDeadline.Add(assignment3Deadline);
            assignmentDeadline.Add(assignment4Deadline);
            //

            // State
            assignmentState.Add(assignment1State);
            assignmentState.Add(assignment2State);
            assignmentState.Add(assignment3State);
            assignmentState.Add(assignment4State);
            //

            // Grade
            assignmentGrade.Add(assignment1Grade);
            assignmentGrade.Add(assignment2Grade);
            assignmentGrade.Add(assignment3Grade);
            assignmentGrade.Add(assignment4Grade);
            //

            // GroupBox
            assignmentGB.Add(assignment1GB);
            assignmentGB.Add(assignment2GB);
            assignmentGB.Add(assignment3GB);
            assignmentGB.Add(assignment4GB);
            //

        }
        //

        // Select Class ListBox

        private void studentsSelectClassID_SelectedValueChanged(object sender, EventArgs e)
        {
            // Enabling right button 
            studentsRightList.Enabled = true;
            //

            // Disabling the no data text, if exists
            MainPanelNoData(true, "disableALL");
            //


            switch (connectedUserType)
            {
                case "teacher":
                    {
                        // Getting the class ID that was selected from 'Select Class ID' listbox
                        string selectedClassValue = Convert.ToString(studentsSelectClassListBox.SelectedValue);
                        //

                        // Verifying if there are students in the class selected from listbox
                        bool existsStudentsInClass = StudentsTab.updatePanelAsTeacher(ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment,   selectedClassValue, _teacherID, "", ref _studentIDS);
                        //

                        if (!existsStudentsInClass) // If there are no students in class
                            // Displaying the text 'Class has no students'
                            MainPanelNoData(true, "teacherClassNoStudents");
                            //
                        break;
                    }
            }
        }
        private void questionsSelectClassListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // Disabling the no data text, if exists
            MainPanelNoData(true, "disableALL");
            //

            switch (connectedUserType)
            {
                case "teacher":
                    {
                        // Getting the class ID that was selected from 'Select Class ID' listbox
                        string selectedClassValue = Convert.ToString(questionsSelectClassListBox.SelectedValue);
                        //

                        // Verifying if there are questions in the class selected from listbox
                        bool existsQuestionsInClass = QuestionsTab.updatePanelAsTeacher(ref questionPanel, ref questionTitle, ref questionStudentName, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedClassValue, _teacherID, ref _questionID);
                       //

                        if (!existsQuestionsInClass) // If there are no questions in the class that was selected
                            MainPanelNoData(true, "teacherClassNoQuestions"); // Display the message 'Class has no questions'
                
                        break;
                    }
                case "student":
                    {
                        // Getting the course name that was selected from 'Select Course' listbox
                        string selectedCourse = Convert.ToString(questionsSelectClassListBox.SelectedValue);
                        //

                        // Verifying if there student has questions for the selected class
                        bool hasQuestions = QuestionsTab.updatePanelAsStudent(ref questionPanel, ref questionTitle, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedCourse, studentID, ref _questionID);
                        //

                        if (!hasQuestions) // If the student has no questions
                            MainPanelNoData(true, "studentHasNoQuestions");
                        break;
                    }
            }
        }
        private void assignmentSelectClassIDListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        // Disabling 
                        MainPanelNoData(true, "disableALL");
                        //

                        // Variables
                        string selectedAssignment;
                        //

                        // Selected class
                        string selectedClass = Convert.ToString(assignmentSelectClassIDListBox.SelectedValue);
                        //

                        // Selected assignment
                        if (selectAssignmentNameListBox.SelectedValue != "No Assignments")
                        {
                            selectedAssignment = Convert.ToString(selectAssignmentNameListBox.SelectedValue);
                        }
                        else
                            selectedAssignment = "No Assignments";
                        //

                        // Calling the method that shows the assignments that are satisfing our above conditions
                        if (selectedAssignment != "No Assignments") // If there exists minimum one assignment  
                        {
                            bool availableSolutions = AssignmentsTab.updatePanelAsTeacher(ref assignmentPanel, ref assignmentTitle, ref _studentIDS, selectedClass, selectedAssignment);
                            if (!availableSolutions)
                                MainPanelNoData(true, "assignmentHasNoSolutions");
                        }
                        else
                        {
                            AssignmentsTab.updatePanelAsTeacher(ref assignmentPanel, ref assignmentTitle, ref _studentIDS, selectedClass, "0"); // Pseudo assign just to disable panels
                            MainPanelNoData(true, "classHasNoAssignments");
                        }
                        //

                        break;
                    }
                case "student":
                    {
                        // Disabling 
                        MainPanelNoData(true, "disableALL");
                        //

                        // Verifying if there are assignments for the course selected from listbox
                        string selectedCourse = Convert.ToString(assignmentSelectClassIDListBox.SelectedValue);
                        //

                        // If student has assignments
                        bool hasAssignments = AssignmentsTab.updatePanelAsStudent(ref assignmentPanel, ref assignmentTitle, ref assignmentDeadline, ref assignmentState, ref assignmentGrade, selectedCourse, _studentID, ref _assignmentID, _studentClassID);
                        //

                        if (hasAssignments == true)
                        {
                            //
                        }
                        else
                        {
                            MainPanelNoData(true, "studentHasNoAssignments");
                        }
                        break;
                    }
            }
        }
        private void gradesSelectCourse_SelectedValueChanged(object sender, EventArgs e)
        {
            // Getting the course id that was selected from 'Select Course' listbox
            string selectedCourse = StudentsTab.getCourseIDbyName(Convert.ToString(gradesSelectCourse.SelectedValue));
            //

            // Query that will get data for DataGridView where student grades will appear
            string query = $"select assignmentTitle as 'Assignment Title', grade as 'Your Grade' from grade where studentId = {_studentID} && courseID = {selectedCourse}";
            //

            // Filling the DataGridView with data related to the student grades
            StudentsTab.studentGradesData(query, ref studentGrades);
            //

            // Variables
            int finalGrade = 0, count = 0; // (Used for counting how many grades student has)
            //

            // Sum all grades of student
            for (int i = 0; i < studentGrades.Rows.Count; ++i)
            {
                ++count;
                finalGrade += Convert.ToInt32(studentGrades.Rows[i].Cells[1].Value);
            }
            //

            // If there is minimum one grade
            if (count != 0)
            {
                // Applying the formula to calculate final grade
                finalGrade /= count;
                //

                // If the grade is greater then 4, set its color green
                if(finalGrade > 4)
                    gradesSituation.ForeColor = Color.Green;
                else
                    gradesSituation.ForeColor = Color.Red;
                //
            }
            //
            
            else // It means that the grade is 0
                gradesSituation.ForeColor = Color.Red;

            // Inserting the value in the control that shows the value
            gradesSituation.Text = Convert.ToString(finalGrade);
            //
        }
        private void selectAssignmentNameListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // Disabling 
            MainPanelNoData(true, "disableALL");
            //

            // Variables
            string selectedAssignment;
            //

            // Selected class
            string selectedClass = Convert.ToString(assignmentSelectClassIDListBox.SelectedValue);
            //

            // Selected assignment
            if (selectAssignmentNameListBox.SelectedValue != "No Assignments")
                selectedAssignment = Convert.ToString(selectAssignmentNameListBox.SelectedValue);
            else
                selectedAssignment = "No Assignments";
            //

            // Calling the method that shows the assignments that are satisfing our above conditions
            if (selectedAssignment != "No Assignments") // If there exists minimum one assignment  
            {
                bool availableSolutions = AssignmentsTab.updatePanelAsTeacher(ref assignmentPanel, ref assignmentTitle, ref _studentIDS, selectedClass, selectedAssignment);
                if (!availableSolutions)
                    MainPanelNoData(true, "assignmentHasNoSolutions");

            }
            else
            {
                AssignmentsTab.updatePanelAsTeacher(ref assignmentPanel, ref assignmentTitle, ref _studentIDS, selectedClass, "0"); // Pseudo assign just to disable panels
                MainPanelNoData(true, "classHasNoAssignments");
            }
            //
        }
        //

      

        // Functions for showing data related to student

        private void studentImage1_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                // Creates a new object of CZUUserDetails class
                CZUUserDetails studentDetails1 = new CZUUserDetails(_studentIDS[0], _teacherID);
                //
                
                // Shows the form
                studentDetails1.Show();
                //
            }
        }
        private void studentImage2_Click(object sender, EventArgs e)
        {            
            if (connectedUserType == "teacher")
            {
                // Creates a new object of CZUUserDetails class
                CZUUserDetails studentDetails2 = new CZUUserDetails(_studentIDS[1], _teacherID);
                //
             
                // Shows the form
                studentDetails2.Show();
                //
            }
        }

        private void studentImage3_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                // Creates a new object of CZUUserDetails class
                CZUUserDetails studentDetails3 = new CZUUserDetails(_studentIDS[2], _teacherID);
                //

                // Shows the form
                studentDetails3.Show();
                //
            }
        }

        private void studentImage4_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                // Creates a new object of CZUUserDetails class
                CZUUserDetails studentDetails4 = new CZUUserDetails(_studentIDS[3], _teacherID);
                //

                // Shows the form
                studentDetails4.Show();
                //

            }

        }

        private void studentImage5_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                // Creates a new object of CZUUserDetails class
                CZUUserDetails studentDetails5 = new CZUUserDetails(_studentIDS[4], _teacherID);
                //

                // Shows the form
                studentDetails5.Show();
                //
            }
        }

        private void studentImage6_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                // Creates a new object of CZUUserDetails class
                CZUUserDetails studentDetails6 = new CZUUserDetails(_studentIDS[5], _teacherID);
                //

                // Shows the form
                studentDetails6.Show();
                //
            }
        }
        //

        /// Menu buttons
        private void studentsButton_Click(object sender, EventArgs e)
        {
            // Enable Refresh Data Trigger
            // enableRefreshDataTrigger("student", triggerPanel); // TEMP DISABLED
            // 

            // Initializing the GUI elements for tab, just once. 
            if (_StudentsTabInitialized == false)
            {
                studentTabGUInitialization(connectedUserType);
                _StudentsTabInitialized = true;
            }
            //


            // Reset Left And Right buttons, by setting everything to initial state
            //

            // Enabling right button
            studentsRightList.Enabled = true;
            //

            // Disabling overlapped panels
            assignmentsMainPanelState(false);
            questionMainPanelState(false);
            homeMainPanelState(false);
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            // 


            /// Show Student Panel related to connected user type (Teacher or Student)
            if (connectedUserType == "teacher") // Teacher connected
            {

                // Getting the list of classes where teacher teaches
                _teachedClassesIDs = StudentsTab.teachedClasses(connectedUser);
                //

                // Verifying if there are classes in list and update the (ListBox) List Teacher teached classes 
                bool classesExists = StudentsTab.updateTeachedClassesList(ref studentsSelectClassListBox, ref _teachedClassesIDs, connectedUser); // returns true only if there is minimum one class
                //

                if (classesExists == true)  // If there is minimum one class teached by teacher
                {
                    // Getting the first Class ID
                    string selectedClass = Convert.ToString(studentsSelectClassListBox.Items[0]);
                    //


                    // Initializing the data in panel and verifying if there are any students in class
                    bool existsStudentsInClass = StudentsTab.updatePanelAsTeacher(ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment,  selectedClass, _teacherID, "", ref _studentIDS);
                    //
              
                    // If there are no students in class, display a message 
                    if (!existsStudentsInClass)
                    {
                        MainPanelNoData(true, "teacherClassNoStudents");
                    }
                    //

                    // Showing the data available
                    studentsMainPanelState(true);
                    //


                }
                else // if there isn't minimum one class teached by teacher
                {
                    MainPanelNoData(true, "teacherNoClasses");
                }

            }
            else if (connectedUserType == "student") // Student connected 
            {
                // Disabling overlapped panels
                gradesMainPanelState(false);
                //

                // Trying to initialize and start the GUI from student panel that shows connected colleagues. (Returns True for available data to be shown).
                bool colleaguesExists = StudentsTab.updatePanelAsStudent( ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                //

                // Getting again student class id until we make the trigger
                _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                //


                /// Verifying if there are colleagues available to be shown
                if (colleaguesExists == true)
                {
                    studentsMainPanelState(true); // The Student Tab Main Panel appears, showing students colleagues.
                }
                else
                {
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
            assignmentsMainPanelState(false);
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            questionMainPanelState(false);
            // 



            if (connectedUserType == "student")
            {

                // Disabling overlapped panels
                gradesMainPanelState(false);
                //

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
                _teachedClassesIDs = StudentsTab.teachedClasses(connectedUser);
                //

                // Actualizing the data in statistics group for Home Panel
                Statistics.homePanelUpdateDataAsTeacher(ref statisticsControls, _teachedClassesIDs, _teacherID);
                //               

            }
        }
        private void questionsButton_Click(object sender, EventArgs e)
        {

            // Reset Left And Right buttons, by setting everything to initial state
            //


            // Disabling overlapped panels
            homeMainPanelState(false);
            gradesMainPanelState(false);
            assignmentsMainPanelState(false);
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            //

            // Initializing the GUI elements for tab, just once. 
            if (_QuestionsTabInitialized == false)
            {
                questionTabGUIInitialization(connectedUserType); 
                _QuestionsTabInitialized = true;
            }
            //
          
            switch(connectedUserType)
            {
                case "teacher":
                    {
                        // Verifying and updating the list of teached classes
                        bool classesExists = StudentsTab.updateTeachedClassesList(ref questionsSelectClassListBox, ref _teachedClassesIDs, connectedUser); // returns true only if there is minimum one class
                        // 

                        if (classesExists == true) // If teacher teaches any class
                        {

                            // Gets the first class id from the 'Select Class Listbox'
                            string selectedClassValue = Convert.ToString(questionsSelectClassListBox.Items[0]);
                            //

                            // Trying to initialize and start the GUI from question panel that shows students questions. (Returns True for available data to be shown).
                            bool existsQuestionsInClass = QuestionsTab.updatePanelAsTeacher(ref questionPanel, ref questionTitle, ref questionStudentName, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedClassValue, _teacherID, ref _questionID);
                            //

                            // If there are questions in class
                            if (existsQuestionsInClass == true)
                                questionMainPanelState(true);
                            else
                            {
                                questionMainPanelState(true);
                                MainPanelNoData(true, "teacherClassNoQuestions");
                            }
                            //
                        }

                        else // If there are no classes
                            MainPanelNoData(true, "teacherNoClasses");
                        break;
                    }
                case "student":
                    {
                        // Disabling overlapped panels
                        gradesMainPanelState(false);
                        //

                        // Getting again student class id until we make the trigger
                        _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                        //

                        // Getting the list of courses studied by student class
                        bool coursesExists = StudentsTab.updateStudiedCoursesList(ref questionsSelectClassListBox, _connectedUser,  ref _studiedCourses);
                        //

                        if(coursesExists == true) // If there is minimum one course that is teached at student class
                        {
                            // Gets the first course name from the 'Select Course Name' listbox
                            string selectedCourse = Convert.ToString(questionsSelectClassListBox.Items[0]);
                            //

                            // Trying to initialize and start the GUI from question panel that shows student questions. (Returns True for available data to be shown).
                            bool hasQuestions = QuestionsTab.updatePanelAsStudent(ref questionPanel, ref questionTitle, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedCourse, studentID, ref _questionID);
                            //

                            if(hasQuestions == true) // If student has minimum one question
                                questionMainPanelState(true);
                            else
                            {
                                questionMainPanelState(true);
                                MainPanelNoData(true, "studentHasNoQuestions");
                            }
                        }
                        else // If there are no courses teached at student class
                            MainPanelNoData(true, "studentNoCourses");
                        break;
                    }
            }
            
        }
        // Assignment Button
        private void assignmentsButton_Click(object sender, EventArgs e)
        {
            // Disabling overlapped panels
            homeMainPanelState(false);
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            questionMainPanelState(false);
            gradesMainPanelState(false);
            assignmentsMainPanelState(false);
            //


            // Initializing the GUI elements for tab, just once. 
            if (_AssignmentsTabInitialized == false)
            {
                assignmentTabGUIInitialization(connectedUserType);
                _AssignmentsTabInitialized = true;
            }
            //
            switch (connectedUserType)
            {

                case "student":
                    {
                        // Disabling overlapped panels
                        gradesMainPanelState(false);
                        //

                        // Getting student class id for further operations
                        _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                        //

                        // Getting the list of courses studied by student class
                        bool coursesExists = StudentsTab.updateStudiedCoursesList(ref assignmentSelectClassIDListBox, _connectedUser, ref _studiedCourses);
                        //

                        if (coursesExists == true)
                        {
                            string selectedCourse = Convert.ToString(assignmentSelectClassIDListBox.Items[0]);
                            bool hasAssignments = AssignmentsTab.updatePanelAsStudent(ref assignmentPanel, ref assignmentTitle, ref assignmentDeadline, ref assignmentState, ref assignmentGrade, selectedCourse, _studentID, ref _assignmentID, _studentClassID);
                            if (hasAssignments == true)
                            {
                                assignmentsMainPanelState(true);
                            }
                            else
                            {
                                assignmentsMainPanelState(true);
                                MainPanelNoData(true, "studentHasNoAssignments");
                            }
                        }
                        else
                        {
                            MainPanelNoData(true, "studentNoCourses");
                        }
                        break;
                    }
                case "teacher":
                    {
                        // Verifying and updating the list of teached classes
                        bool classesExists = StudentsTab.updateTeachedClassesList(ref assignmentSelectClassIDListBox, ref _teachedClassesIDs, connectedUser); // returns true only if there is minimum one class
                        // 

                        if (classesExists) {
                            assignmentInterfaceButtonsState(true);
                            assignmentsMainPanelState(true);
                        }
                        else
                            MainPanelNoData(true, "teacherNoClasses");

                        break;
                    }
            }


        }
        private void assignmentInterfaceButtonsState(bool t_mode)
        {
            // Deactivating interface choice buttons
            teacherAssignments.Enabled = t_mode;
            teacherAssignments.Visible = t_mode;
            studentsAssignments.Enabled = t_mode;
            studentsAssignments.Visible = t_mode;
            //
        }
        private void teacherAssignments_Click(object sender, EventArgs e) // Display teacher interface for managing assignments
        {

            // Not done
        }
        private void studentsAssignments_Click(object sender, EventArgs e) // Display students assignments related to the selected class
        {

            // Disabling 
            MainPanelNoData(true, "disableALL");
            //

            // Deactivating the buttons for interface mode choice as teacher on Assignment Tab
            assignmentInterfaceButtonsState(false);
            //

            // Setting up the interface mode for further operations
            _assignmentTeacherInterfaceMode = "studentAssignmentSolution";
            //


            // Modify shown elements in page GUI
            assignmentInterfaceMode(_assignmentTeacherInterfaceMode);
            //


            /// Running the functions that updates Assignments Panel related to the made choice (Show students assignment or manage assignments)

            // Selected class
            string selectedClass = Convert.ToString(assignmentSelectClassIDListBox.Items[0]);
            //

            // Updating the list of assignments related to the selected class
            AssignmentsTab.classAssignments(selectedClass, ref selectAssignmentNameListBox, _teacherID);
            //

            // Selected assignment
            string selectedAssignment = Convert.ToString(selectAssignmentNameListBox.Items[0]);
            //
            
            
            // Calling the method that shows the assignments that are satisfing our above conditions
            if (selectedAssignment != "No Assignments") // If there exists minimum one assignment  
            {
                bool availableSolutions =  AssignmentsTab.updatePanelAsTeacher(ref assignmentPanel, ref assignmentTitle, ref _studentIDS, selectedClass, selectedAssignment);
                if (!availableSolutions)
                    MainPanelNoData(true, "assignmentHasNoSolutions");

            }
            else
            {
                AssignmentsTab.updatePanelAsTeacher(ref assignmentPanel, ref assignmentTitle, ref _studentIDS, selectedClass, "0"); // Pseudo assign just to disable panels
                MainPanelNoData(true, "classHasNoAssignments");
            }
            //
            ///

        }
        //
        private void gradesButton_Click(object sender, EventArgs e)
        {
            // Disabling overlapped panels
            homeMainPanelState(false);
            assignmentsMainPanelState(false);
            studentsMainPanelState(false);
            MainPanelNoData(true, "disableAll");
            questionMainPanelState(false);
            gradesMainPanelState(false);
            //

            // Getting again student class id until we make the trigger
            _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
            //

            // Getting the list of courses studied by student class
            bool coursesExists = StudentsTab.updateStudiedCoursesList(ref gradesSelectCourse, _connectedUser, ref _studiedCourses);
            //

            if (coursesExists == true) // If there is minimum one course teached at class
            {
                // Activating the controls from grades Main Panel
                gradesMainPanelState(true);
                //
                
                // Select the first course from list
                string selectedCourse = StudentsTab.getCourseIDbyName(Convert.ToString(gradesSelectCourse.Items[0]));
                //

                // Display the grades that exist
                StudentsTab.studentGradesData($"select assignmentTitle as 'Assignment Title', grade as 'Your Grade' from grade where studentId = {_studentID} && courseID = {selectedCourse}", ref studentGrades);
                //


                /// Displaying the student final grade

                // Variables
                int finalGrade = 0, count = 0;
                //

                // Getting the grades and count how many exists
                for(int i = 0; i < studentGrades.Rows.Count; ++i)
                {
                    ++count;
                    finalGrade += Convert.ToInt32(studentGrades.Rows[i].Cells[1].Value);
                }
                //

                if (count != 0) // If there is minimum one grade found
                {
                    // Formula for final grade
                    finalGrade /= count;
                    //

                    // If the grade is greater then 4, set its color green, if not, red
                    if (finalGrade > 4)
                        gradesSituation.ForeColor = Color.Green;
                    else
                        gradesSituation.ForeColor = Color.Red;
                    //
                }

                else // If there are no grades found, change text color to Red
                    gradesSituation.ForeColor = Color.Red;

                // Inserting the final grade into control property
                gradesSituation.Text = Convert.ToString(finalGrade);
                //

                ///
            }
            else // If there are no courses available
                MainPanelNoData(true, "studentNoCourses"); // Display message 'Class has no courses'
        }

        /// 

        // Question Tab Buttons for interacting with question
        private void questionTitle1_MouseClick(object sender, MouseEventArgs e)
        {

            switch (connectedUserType)
            {
                case "teacher":
                    {
                        // Variables
                        string questionTitle, question;
                        //

                        // Getting question 1 data
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[0], out questionTitle, out question);
                        //
                        
                        // Creates a new object of the QuestionDetails class
                        CZUQuestion question1 = new CZUQuestion(questionTitle, question, _questionID[0]);
                        //
                        
                        // Shows the form
                        question1.Show();
                        //

                        break;
                    }
                case "student":
                    {

                        CZUQuestion question1 = new CZUQuestion(_questionID[0]); // take selected course teacher ID);
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
                        // Variables
                        string questionTitle, question;
                        //

                        // Getting question 2 data
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[1], out questionTitle, out question);
                        //

                        // Creates a new object of the QuestionDetails class
                        CZUQuestion question2 = new CZUQuestion(questionTitle, question, _questionID[1]);
                        //

                        // Shows the form
                        question2.Show();
                        //

                        break;
                    }
                case "student":
                    {
                        // Creates a new object of the QuestionDetails class
                        CZUQuestion question2 = new CZUQuestion(_questionID[1]);
                        //
                        
                        // Shows the form
                        question2.Show();
                        //
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
                        // Variables
                        string questionTitle, question;
                        //

                        // Getting question 3 data
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[2], out questionTitle, out question);
                        //

                        // Creates a new object of the QuestionDetails class
                        CZUQuestion question3 = new CZUQuestion(questionTitle, question, _questionID[2]);
                        //

                        // Shows the form
                        question3.Show();
                        //

                        break;
                    }
                case "student":
                    {

                        // Creates a new object of the QuestionDetails class
                        CZUQuestion question3 = new CZUQuestion(_questionID[2]); 
                        //

                        // Shows the form
                        question3.Show();
                        //

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
                        // Variables
                        string questionTitle, question;
                        //

                        // Getting question 4 data
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[3], out questionTitle, out question);
                        //

                        // Creates a new object of the QuestionDetails class
                        CZUQuestion question4 = new CZUQuestion(questionTitle, question, _questionID[3]);
                        //

                        // Shows the form
                        question4.Show();
                        //

                        break;
                    }
                case "student":
                    {
                        // Creates a new object of the QuestionDetails class
                        CZUQuestion question4 = new CZUQuestion(_questionID[3]); // take selected course teacher ID);
                        //

                        // Shows the form
                        question4.Show();
                        //

                        break;
                    }
            }

        }
        //

        // Assignment Tab Buttons for interacting with assignments
        private void assignment1Button_Click(object sender, EventArgs e)
        {
            switch (connectedUserType)
            {
                case "student":
                    {
                        // Variables
                        string assignmentState = null;
                        //

                        // Getting the solution state
                        AssignmentsTab.studentAssignmentSolutionState(_assignmentID[0], _studentID, ref assignmentState);
                        //
                        CZUAssignment assignment1 = new CZUAssignment(_assignmentID[0], _studentID, "studentAddsSolution");
                        assignment1.Show();
                        break;
                    }
                case "teacher":
                    {
                       
                            string selectedAssignment = Convert.ToString(selectAssignmentNameListBox.SelectedValue);
                            CZUAssignment assignment1 = new CZUAssignment(selectedAssignment, _studentIDS[0], "teacherGradesSolution");
                            assignment1.Show();
                            break;
                    }
            }
        }

        private void assignment2Button_Click(object sender, EventArgs e)
        {
            switch (connectedUserType)
            {
                case "student":
                    {
                        // Variables
                        string assignmentState = null;
                        //

                        // Getting the solution state
                        AssignmentsTab.studentAssignmentSolutionState(_assignmentID[1], _studentID, ref assignmentState);
                        //
                        CZUAssignment assignment2 = new CZUAssignment(_assignmentID[1], _studentID, "studentAddsSolution");
                        assignment2.Show();
                        break;
                    }
                case "teacher":
                    {
                        string selectedAssignment = Convert.ToString(selectAssignmentNameListBox.SelectedValue);
                        CZUAssignment assignment2 = new CZUAssignment(selectedAssignment, _studentIDS[1], "teacherGradesSolution");
                        assignment2.Show();
                        break;
                    }
            }
        }

        private void assignment3Button_Click(object sender, EventArgs e)
        {
            switch (connectedUserType)
            {
                case "student":
                    {
                        // Variables
                        string assignmentState = null;
                        //

                        // Getting the solution state
                        AssignmentsTab.studentAssignmentSolutionState(_assignmentID[2], _studentID, ref assignmentState);
                        //
                        CZUAssignment assignment3 = new CZUAssignment(_assignmentID[2], _studentID, "studentAddsSolution");
                        assignment3.Show();
                        break;
                    }
                case "teacher":
                    {
                        string selectedAssignment = Convert.ToString(selectAssignmentNameListBox.SelectedValue);
                        CZUAssignment assignment3 = new CZUAssignment(selectedAssignment, _studentIDS[2], "teacherGradesSolution");
                        assignment3.Show();
                        break;
                    }
            }
        }

        private void assignment4Button_Click(object sender, EventArgs e)
        {
            switch (connectedUserType)
            {
                case "student":
                    {
                        // Variables
                        string assignmentState = null;
                        //

                        // Getting the solution state
                        AssignmentsTab.studentAssignmentSolutionState(_assignmentID[3], _studentID, ref assignmentState);
                        //
                        CZUAssignment assignment4 = new CZUAssignment(_assignmentID[3], _studentID, "studentAddsSolution");
                        assignment4.Show();
                        break;
                    }
                case "teacher":
                    {
                        string selectedAssignment = Convert.ToString(selectAssignmentNameListBox.SelectedValue);
                        CZUAssignment assignment4 = new CZUAssignment(selectedAssignment, _studentIDS[3], "teacherGradesSolution");
                        assignment4.Show();
                        break;
                    }
            }
        }
        //



        // General Application Methods
        private void userDisconnectsSetOffline(string t_connectedUserType, string t_connectedUser) // This method sets the user status as disconnected
        {
            // Variables
            string command = null;
            //

            if (t_connectedUserType == "student")
                command = $"update student set connected = 'off' where username = '{t_connectedUser}'";
            else
                command = $"update teacher set connected = 'off' where username = '{t_connectedUser}'";
            Database.insert(command);
        }

    }
}

