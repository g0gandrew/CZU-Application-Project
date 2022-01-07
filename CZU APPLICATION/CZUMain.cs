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

        // Tabs state
        private bool _QuestionsTabInitialized { get; set; } = false;
        private bool _StudentsTabInitialized { get; set; } = false;
        private bool _AssignmentsTabInitialized { get; set; } = false;
        private bool _GradesTabInitialized { get; set; } = false;
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
        List<string> _questionID = new List<string>();

        List<string> _assignmentID = new List<string>();

        List<string> _studentIDS = new List<string>();  
    
        //

        /// 

        // Refresh  General Data
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
            gradesButton.Enabled = false;
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
                            StudentsTab.updatePanelAsStudent( ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                            break;
                    }
                    case "refreshcolleagues":
                    {
                        MessageBox.Show("Refresh data for student colleagues");
                            StudentsTab.updatePanelAsStudent( ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                            break;
                    }
                    case "refreshmeeting":
                    {
                        MessageBox.Show("Refresh data for student meetings");
                            StudentsTab.updatePanelAsStudent( ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
                            break;
                    }
                    case "refreshassignment":
                    {
                        MessageBox.Show("Refresh data for student assignments");
                            StudentsTab.updatePanelAsStudent( ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
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

                // Disabling Grades button
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
            userDisconnectsSetOffline(connectedUserType, connectedUser); // sets connected user status to offline.
        }
        //

        // Cleaning useless data
        
        //

        /// Panels state
        private void assignmentsMainPanelState(bool t_mode)
        {
            if(_connectedUserType == "student")
            {
                // Disabling add assignment button (it is for teacher)
                addAssignment.Enabled = false;
                addAssignment.Visible = false;
                // Modify control name to reuse code
                assignmentSelectClassID.Text = "Course:";
            }
            assignmentsMainPanel.Enabled = t_mode;
            assignmentsMainPanel.Visible = t_mode;
        }
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
        private void gradesMainPanelState(bool t_mode)
        {
            gradesMainPanel.Enabled = t_mode;
            gradesMainPanel.Visible = t_mode;
        }

        private void MainPanelNoData(bool t_mode, string t_case)
        {

            noDataInPanelMessage.Enabled = false;
            noDataInPanelMessage.Visible = false;
            // Variables
            string[] casesList = new string[] { "teacherClassNoStudents", "teacherNoClasses", "studentNoColleagues", "teacherClassNoQuestions", "studentNoCourses", "studentHasNoQuestions", "studentHasNoAssignments"};
            string[] casesMessage = new string[] { "Class has no students", "You teach no classes", "You have no colleagues", "Class has no questions", "Class has no courses", "You have no questions", "You have no assignments"};
            Point[] casesMessagesLocations = new Point[7];
            //

            // Setting Messages Location for better readability and positioning.
            casesMessagesLocations[0] = new Point(400, 280);
            casesMessagesLocations[1] = new Point(400, 280);
            casesMessagesLocations[2] = new Point(400, 280);
            casesMessagesLocations[3] = new Point(400, 280);
            casesMessagesLocations[4] = new Point(400, 280);
            casesMessagesLocations[5] = new Point(400, 280);
            casesMessagesLocations[6] = new Point(400, 280);
            //


            // Verifying each case with the case from parameters list, if it exists, we'll select it.
            for(int i = 0; i < 7; ++i)
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

            // Showing the previous list of colleagues 
            if (connectedUserType == "student")
            {
                int output = 0;
                string query;
                int records, startFromId = 0;

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

                if (records > 0)
                {  // There are available records 
                    StudentsTab.updatePanelAsStudent(ref _recordsOnPage, ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"&& id > {_lastID}");
                    // Because there are available records, it means that we can swipe to the next list, and, we can also go back
                    // Because of that, we activate left button
                    studentsLeftList.Enabled = true;
                }
                else
                {
                    studentsRightList.Enabled = false;
                }
            }
            //

            else if(connectedUserType == "teacher")
            {
                // Variables
                int records = 0;
                //
                string selectedClassValue = Convert.ToString(studentsSelectClassListBox.SelectedValue);
                // Verifying if there are more records available from the current Student ID
                string query = $"select id from student where classID = {selectedClassValue} && id > {_lastID} limit 6";
                Database.recordExists(query, ref records);
                //
                if (records > 0)
                {  // There are available records 
                    StudentsTab.updatePanelAsTeacher(ref _recordsOnPage, ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment,   selectedClassValue, _teacherID, $"&& id > {_lastID} limit 6", ref _studentIDS);
                    // Because there are available records, it means that we can swipe to the next list, and, we can also go back
                    // Because of that, we activate left button
                    studentsLeftList.Enabled = true;
                }
                else
                {
                    studentsRightList.Enabled = false;
                }
            }
        }
        //

        // Creates lists of controls
        private void studentTabGUInitialization(string t_connectedUserType)
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
            studentName.Add(studentName0);
            studentName.Add(studentName1);
            studentName.Add(studentName2);
            studentName.Add(studentName3);
            studentName.Add(studentName4);
            studentName.Add(studentName5);
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
            else if(t_connectedUserType == "student")
            {
                for(int i = 0; i < 6; ++i)
                    foreach(Control ctr in studentGB[i].Controls)
                        if (ctr.Name != $"studentName{i}")
                        {
                            ctr.Enabled = false;
                            ctr.Visible = false;
                        }
            }
            studentPanel.Add(studentPanel1);
            studentPanel.Add(studentPanel2);
            studentPanel.Add(studentPanel3);
            studentPanel.Add(studentPanel4);
            studentPanel.Add(studentPanel5);
            studentPanel.Add(studentPanel6);
        }
        private void questionTabGUIInitialization()
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
        private void homeTabGUIInitialization()
        {
            statisticsControls.Add(statisticsUsers);
            statisticsControls.Add(statisticsQuestions);
            statisticsControls.Add(statisticsAssignments);
        }
        private void assignmentTabGUIInitialization()
        {

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
        }
        //

        // Select Class ListBox

        private void studentsSelectClassID_SelectedValueChanged(object sender, EventArgs e)
        {
            // Enabling right button 
            studentsRightList.Enabled = true;
            //

            MainPanelNoData(true, "disableALL");
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        MessageBox.Show("AM RULAT CAZ DE STUDENTS MAIN PANEL");
                        string selectedClassValue = Convert.ToString(studentsSelectClassListBox.SelectedValue);
                        bool existsStudentsInClass = StudentsTab.updatePanelAsTeacher(ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment,   selectedClassValue, _teacherID, "", ref _studentIDS);
                        if (existsStudentsInClass == true)
                        {
                            MessageBox.Show("Class HAS students");
                        }
                        else
                        {
                            MessageBox.Show("Class has NO students");
                            MainPanelNoData(true, "disableALL");
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
                        bool existsQuestionsInClass = QuestionsTab.updatePanelAsTeacher(ref questionPanel, ref questionTitle, ref questionStudentName, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedClassValue, _teacherID, ref _questionID);
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
                        bool hasQuestions = QuestionsTab.updatePanelAsStudent(ref questionPanel, ref questionTitle, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedCourse, studentID, ref _questionID);
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
        private void assignmentSelectClassIDListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            MainPanelNoData(true, "disableALL");
            switch (connectedUserType)
            {
                case "teacher":
                    {
                        break;
                    }
                case "student":
                    {
                        MessageBox.Show(" student - AM RULAT CAZ DE ASSIGNMENT MAIN PANEL, ASSIGNMENTS EXISTS");
                        string selectedCourse = Convert.ToString(assignmentSelectClassIDListBox.SelectedValue);
                        bool hasAssignments = AssignmentsTab.updatePanelAsStudent(ref assignmentPanel, ref assignmentTitle, ref assignmentDeadline, ref assignmentState, ref assignmentGrade, selectedCourse, _studentID, ref _assignmentID, _studentClassID);
                        if (hasAssignments == true)
                        {
                            MessageBox.Show("Student has assignments");

                        }
                        else
                        {
                            // Message doesn't appear, need to be fixed
                            MessageBox.Show("Student has NO assignments");
                            MainPanelNoData(true, "studentHasNoAssignments");
                        }
                        break;
                    }
            }
        }
        private void gradesSelectCourse_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedCourse = StudentsTab.getCourseIDbyName(Convert.ToString(gradesSelectCourse.SelectedValue));
            StudentsTab.studentGradesData($"select assignmentTitle as 'Assignment Title', grade as 'Your Grade' from grade where studentId = {_studentID} && courseID = {selectedCourse}", ref studentGrades);

            // Displaying the student final grade
            int finalGrade = 0, count = 0;
            for (int i = 0; i < studentGrades.Rows.Count; ++i)
            {
                ++count;
                finalGrade += Convert.ToInt32(studentGrades.Rows[i].Cells[1].Value);
            }
            if (count != 0)
            {
                finalGrade /= count;
                // If the grade is greater then 4, set its color green
                if(finalGrade > 4)
                    gradesSituation.ForeColor = Color.Green;
                else
                    gradesSituation.ForeColor = Color.Red;

                //
            }
            else
            {
                gradesSituation.ForeColor = Color.Red;
            }
            gradesSituation.Text = Convert.ToString(finalGrade);
            //
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
                    StudentsPanel.updateTeachedClassesList(selectClassID, _teachedClassesIDs, connectedUser); // updating Teacher Teached Classes List every time he clicks
                }*//*
            }
            */
        }
        //

        // Functions for showing data related to student

        private void studentImage1_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                CZUUserDetails studentDetails1 = new CZUUserDetails(_studentIDS[0], _teacherID);
                studentDetails1.Show();
            }
        }
        private void studentImage2_Click(object sender, EventArgs e)
        {            
            if (connectedUserType == "teacher")
            {
                CZUUserDetails studentDetails2 = new CZUUserDetails(_studentIDS[1], _teacherID);
            studentDetails2.Show();
            }
        }

        private void studentImage3_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                CZUUserDetails studentDetails3 = new CZUUserDetails(_studentIDS[2], _teacherID);
                studentDetails3.Show();
            }
        }

        private void studentImage4_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                CZUUserDetails studentDetails4 = new CZUUserDetails(_studentIDS[3], _teacherID);
                studentDetails4.Show();
            }

        }

        private void studentImage5_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                CZUUserDetails studentDetails5 = new CZUUserDetails(_studentIDS[4], _teacherID);
                studentDetails5.Show();
            }
        }

        private void studentImage6_Click(object sender, EventArgs e)
        {
            if (connectedUserType == "teacher")
            {
                CZUUserDetails studentDetails6 = new CZUUserDetails(_studentIDS[5], _teacherID);
                studentDetails6.Show();
            }
        }
        //

        // Menu buttons

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

                if (classesExists == true)
                { // if there is minimum one class teached by teacher
                    MessageBox.Show("Student Tab - Teacher has classes to teach");
                    // Getting the first Class ID
                    string selectedClass = Convert.ToString(studentsSelectClassListBox.Items[0]);
                    //

                    // Initializing the data in panel
                    StudentsTab.updatePanelAsTeacher(ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, ref studentQuestion, ref studentAssignment,  selectedClass, _teacherID, "", ref _studentIDS);
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
                // Disabling overlapped panels
                gradesMainPanelState(false);
                //

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
                bool colleaguesExists = StudentsTab.updatePanelAsStudent( ref _recordsOnPage,  ref _lastID, ref studentPanel, ref studentGB, ref studentImage, ref studentConnected, ref studentName, connectedUser, $"");
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
            questionMainPanelState(false);
            //

            // Initializing the GUI elements for tab, just once. 
            if (_QuestionsTabInitialized == false)
            {
                questionTabGUIInitialization(); // set to be execute only once.
                _QuestionsTabInitialized = true;
            }
            //
          
            switch(connectedUserType)
            {
                case "teacher":
                    {
                        bool classesExists = StudentsTab.updateTeachedClassesList(ref questionsSelectClassListBox, ref _teachedClassesIDs, connectedUser); // returns true only if there is minimum one class
                        if (classesExists == true) // If exists classes
                        {
                            MessageBox.Show("Teacher - AM RULAT CAZ DE QUESTIONS MAIN PANEL");
                            string selectedClassValue = Convert.ToString(questionsSelectClassListBox.Items[0]);
                            bool existsQuestionsInClass = QuestionsTab.updatePanelAsTeacher(ref questionPanel, ref questionTitle, ref questionStudentName, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedClassValue, _teacherID, ref _questionID);
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
                        // Disabling overlapped panels
                        gradesMainPanelState(false);
                        //

                        // Getting again student class id until we make the trigger
                        _studentClassID = StudentsTab.getStudentClassID(_connectedUser);
                        //

                        // Getting the list of courses studied by student class
                        bool coursesExists = StudentsTab.updateStudiedCoursesList(ref questionsSelectClassListBox, _connectedUser,  ref _studiedCourses);
                        if(coursesExists == true)
                        {
                            MessageBox.Show(" Student - AM RULAT CAZ DE QUESTIONS MAIN PANEL, COURSES EXISTS");
                            string selectedCourse = Convert.ToString(questionsSelectClassListBox.Items[0]);
                            bool hasQuestions = QuestionsTab.updatePanelAsStudent(ref questionPanel, ref questionTitle, ref questionPriorityLevel, ref questionSubmitDate, ref questionState, selectedCourse, studentID, ref _questionID);
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
                assignmentTabGUIInitialization();
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
                            MessageBox.Show(" student - AM RULAT CAZ DE ASSIGNMENT MAIN PANEL, ASSIGNMENTS EXISTS");
                            string selectedCourse = Convert.ToString(assignmentSelectClassIDListBox.Items[0]);
                            bool hasAssignments = AssignmentsTab.updatePanelAsStudent(ref assignmentPanel, ref assignmentTitle, ref assignmentDeadline, ref assignmentState, ref assignmentGrade, selectedCourse, _studentID, ref _assignmentID, _studentClassID);
                            if (hasAssignments == true)
                            {
                                MessageBox.Show("Student has assignments");
                                assignmentsMainPanelState(true);

                            }
                            else
                            {
                                // Message doesn't appear, need to be fixed
                                MessageBox.Show("Student has NO assignments");
                                assignmentsMainPanelState(true);
                                MainPanelNoData(true, "studentHasNoAssignments");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Student - AM RULAT CAZ DE ASSIGNMENT, MAIN PANEL, COURSES DON T EXIST");
                            MainPanelNoData(true, "studentNoCourses");
                        }



                        break;
                    }
                case "teacher":
                    {
                        break;

                    }
            }


        }
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

            if (coursesExists == true)
            {
                gradesMainPanelState(true);
                MessageBox.Show(" Student - AM RULAT CAZ DE Grades MAIN PANEL, COURSES EXISTS");
                string selectedCourse = StudentsTab.getCourseIDbyName(Convert.ToString(gradesSelectCourse.Items[0]));
                StudentsTab.studentGradesData($"select assignmentTitle as 'Assignment Title', grade as 'Your Grade' from grade where studentId = {_studentID} && courseID = {selectedCourse}", ref studentGrades);

                // Displaying the student final grade
                int finalGrade = 0, count = 0;
                for(int i = 0; i < studentGrades.Rows.Count; ++i)
                {
                    ++count;
                    finalGrade += Convert.ToInt32(studentGrades.Rows[i].Cells[1].Value);
                }
                MessageBox.Show($"Final grade = {finalGrade}, count = {count}");
                if (count != 0)
                {
                    finalGrade /= count;
                    // If the grade is greater then 4, set its color green
                    if (finalGrade > 4)
                        gradesSituation.ForeColor = Color.Green;
                    else
                        gradesSituation.ForeColor = Color.Red;

                    //
                }
                else
                    gradesSituation.ForeColor = Color.Red;
                gradesSituation.Text = Convert.ToString(finalGrade);
                //

            }
            else
            {
                MessageBox.Show(" Student - AM RULAT CAZ DE Grades MAIN PANEL, COURSES DON T EXIST");
                MainPanelNoData(true, "studentNoCourses");
            }
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
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[0], out questionTitle, out question);
                        QuestionDetails question1 = new QuestionDetails(questionTitle, question, _questionID[0]);
                        question1.Show();
                        break;
                    }
                case "student":
                    {

                        QuestionDetails question1 = new QuestionDetails(_questionID[0]); // take selected course teacher ID);
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
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[1], out questionTitle, out question);
                        QuestionDetails question2 = new QuestionDetails(questionTitle, question, _questionID[1]);
                        question2.Show();
                        break;
                    }
                case "student":
                    {
                        QuestionDetails question2 = new QuestionDetails(_questionID[1]); // take selected course teacher ID);
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
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[2], out questionTitle, out question);
                        QuestionDetails question3 = new QuestionDetails(questionTitle, question, _questionID[2]);
                        question3.Show();
                        break;
                    }
                case "student":
                    {
                        QuestionDetails question3 = new QuestionDetails(_questionID[2]); // take selected course teacher ID);
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
                        QuestionsTab.getQuestionDataAsTeacher(_questionID[3], out questionTitle, out question);
                        QuestionDetails question4 = new QuestionDetails(questionTitle, question, _questionID[3]);
                        question4.Show();
                        break;
                    }
                case "student":
                    {
                        QuestionDetails question4 = new QuestionDetails(_questionID[3]); // take selected course teacher ID);
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

