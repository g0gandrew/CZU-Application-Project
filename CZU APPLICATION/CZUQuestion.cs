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
    public partial class CZUQuestion : Form
    {
        public CZUQuestion()
        {
            InitializeComponent();
        }

        private string _questionID { get; set; }
        private string _connectedUserType { get; set; }
        private string _studentID { get; set; }
        private string _teacherID { get; set; }
        private string _interfaceMode { get; set; }
        public CZUQuestion(string t_questionID) // Constructor for student, to initlialize the data for showing question.
        {
            InitializeComponent();
            _connectedUserType = "student";

            // Inserting studentID for further operations
            _questionID = t_questionID;
            //

            // Choosing the GUI to be shown, related to operation
            _interfaceMode = "showquestion";
            //


        }
        public CZUQuestion(string t_studentID, string t_teacherID) // Constructor for student
        {
            InitializeComponent();
            // Inserting studentID for further operations
            _studentID = t_studentID;
            //


            // Inserting teacherID for further operations
            _teacherID = t_teacherID;
            //

            // Setting up connection type (Student or Teacher) 
            _connectedUserType = "student";
            //

            // Setting up the connection
        }
        public CZUQuestion(string t_Title, string t_question, string t_questionID) // Constructor for teacher
        {
            InitializeComponent();

            // Filling up question rich text box with the question
            studentQuestion.Text = t_question;
            //

            // Setting up question ID for further operatiosn
            _questionID = t_questionID;
            //

            // Setting up connection type (Student or Teacher) 
            _connectedUserType = "teacher";
            //
        }




        /// Critical Functions
        private void QuestionDetails_Load(object sender, EventArgs e)
        {

            // Turning on the GUI interface related to the connected user type (teacher or student)
            enableGB(_connectedUserType);
            //

            // If student wants to see the question details
            if (_interfaceMode == "showquestion")
            {
                // Getting the data to update GUI Elements
                QuestionsTab.getQuestionDataAsStudent($"select answer, description from question where id = {_questionID}", ref teacherAnswer1, ref studentQuestion1);
                //
            }
            //
        }
        ///

        // Enabling GUI elements
        private void enableGB(string t_connectedUserType)
        {
            switch (t_connectedUserType)
            {
                case "teacher": {
                        // Enabling Teacher GB
                        answerToQuestion.Enabled = true;
                        answerToQuestion.Visible = true;
                        submit.Text = "Submit";
                        break;
                        //
                }
                case "student":
                    {
                        if (_interfaceMode != "showquestion") 
                        {

                            // Ask a question interface will appear
                            displayAddQuestion.Enabled = true;
                            displayAddQuestion.Visible = true;
                            submit.Text = "Ask";
                            //
                        }
                        else // Show question answer will appear
                        {
                            showQuestion.Enabled = true;
                            showQuestion.Visible = true;
                            submit.Text = "Exit";
                            exit.Text = "Delete Question";
                        }
                        break;
                    }
            }
        }
        //

        // Buttons
        private void submitResponse_Click(object sender, EventArgs e)
        {
            switch (_connectedUserType) {
                case "teacher": { // If teacher is connected (The teacher constructor was called)
                        if (teacherAnswer.Text.Length <= 1000)
                        {
                           Database.insert($"update question set answer = '{teacherAnswer.Text}', state = 'answered' where ID = {_questionID}");
                        }
                        else
                        {
                            MessageBox.Show("Your response is too long, it shouldn't exceed 1000 characters!");
                        }
                        this.Close();
                        break;
                    }
                case "student": {
                        if (_interfaceMode != "showquestion") // If student chosed to add a question (The student constructor was called, the one which initialize the GUI for displaying question details).
                        {
                            // Verifying if there minimum one priority mode was selected
                            bool prioritySelected = questionPriority.SelectedIndex > -1;
                            //
                            if(questionTitle.Text.Length < 5)
                            {
                                MessageBox.Show("Your question title is too short, minimum 5 characters needed!");
                            }
                            else if(questionTitle.Text.Length > 170)
                            {
                                MessageBox.Show("Your question title is too long, maximum 170 characters are allowed!");
                            }
                            else if(question.Text.Length < 10)
                            {
                                MessageBox.Show("Your question is too short, minimum 10 characters are needed!");
                            }
                            else if (question.Text.Length <= 1000)
                            {
                                if (!prioritySelected)
                                    MessageBox.Show("Select a priority mode before asking the question!");
                                else
                                {
                                    MessageBox.Show("Your question was added!");
                                    Database.insert($"insert into question(studentID, teacherID, description, priority, title) values({_studentID}, {_teacherID}, '{question.Text}', '{questionPriority.SelectedItem.ToString()}', '{questionTitle.Text}')");
                                    this.Close();
                                }
                            }
                        }
                        else // If student haven't chosed to add a question, this button will serve for quiting the form.
                        {
                            this.Close();

                        }
                        break;
                    }
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            if (_interfaceMode == "showquestion") // Button will serve as "Delete question for Showing Question Interface"
            {
                // The question will be deleted from database
                Database.insert($"delete from question where id = {_questionID};");
                MessageBox.Show("Your question was deleted!");
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        //

    }
}
