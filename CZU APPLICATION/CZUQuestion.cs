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
    public partial class QuestionDetails : Form
    {
        public QuestionDetails()
        {
            InitializeComponent();
        }

        private string _questionID { get; set; }
        private string _connectedUserType { get; set; }
        private string _studentID { get; set; }
        private string _selectedCourse { get; set; }
        private string _teacherID { get; set; }
        public QuestionDetails(string t_studentID, string t_teacherID) // Constructor for student
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
        }
        public QuestionDetails(string t_Title, string t_question, string t_questionID) // Constructor for teacher
        {
            InitializeComponent();
            // Setting up question title
            questionTitleLabel.Text = t_Title;
            //

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




        // Critical Functions
        private void QuestionDetails_Load(object sender, EventArgs e)
        {
            enableGB(true, _connectedUserType);
        }
        //

        // Enabling GUI elements
        private void enableGB(bool t_mode, string t_connectedUserType)
        {
            switch (t_connectedUserType)
            {
                case "teacher": {
                        // Enabling GB
                        questionDetailsMainGB.Enabled = t_mode;
                        questionDetailsMainGB.Visible = t_mode;
                        break;
                }
                case "student":
                    {
                        // Enabling GB
                        submitResponse.Text = "Ask";
                        questionDetailsMainGB2.Enabled = t_mode;
                        questionDetailsMainGB2.Visible = t_mode;
                        questionTitleLabel.Enabled = false;
                        questionTitleLabel.Visible = false;
                        break;
                    }
            }
        }
        //

        // Buttons
        private void submitResponse_Click(object sender, EventArgs e)
        {
            switch (_connectedUserType) {
                case "teacher": {
                        if (teacherAnswer.Text.Length <= 1000)
                        {
                            Database.insert($"update question set answer = '{teacherAnswer.Text}', state = 'answered' where ID = {_questionID}");
                        }
                        else
                        {
                            MessageBox.Show("Your response is too long, it shouldn't exceed 1000 charffacters!");
                        }
                        break;
                    }
                case "student": {
                        if (studentQuestion.Text.Length <= 1000)
                        {
                           Database.insert($"insert into question(studentID, teacherID, description, priority, title) values({_studentID}, {_teacherID}, '{question.Text}', '{Convert.ToString(priority.SelectedValue)}', '{questionTitle.Text}')");

                        }
                        else
                        {
                            MessageBox.Show("Your response is too long, it shouldn't exceed 1000 charffacters!");
                        }


                        break;
                    }
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //

    }
}
