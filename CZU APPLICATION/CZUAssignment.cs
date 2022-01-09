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
    public partial class CZUAssignment : Form
    {

        private string _assignmentID { get; set; }
        private string _studentID { get; set; }
        private string _interfaceMode { get; set; }
        public CZUAssignment()
        {
            InitializeComponent();
        }
        public CZUAssignment(string t_assignmentID, string t_studentID, string t_interfaceMode) // For student, to add the assignment solution
        {
            InitializeComponent();

            // Initializing the main variables
            _assignmentID = t_assignmentID;
            _studentID = t_studentID;
            //

            // Setting up interface mode
            _interfaceMode = t_interfaceMode;
            //

            // Enabling the GUI Interface
            switch(_interfaceMode)
            {
                case "teacherGradesSolution":
                    {
                        // Enabling the GUI Interface
                        studentAssignmentSolution.Enabled = true;
                        studentAssignmentSolution.Visible = true;
                        //
                        break;
                    }
                case "studentAddsSolution":
                    {
                        // Enabling the GUI Interface
                        addAssignmentSolution.Enabled = true;
                        addAssignmentSolution.Visible = true;
                        //
                        break;
                    }
                case "teacherAddsAssignment":
                    {
                        addAssignment.Enabled = true;
                        addAssignment.Visible = true;
                        break;
                    }
            }
        }

        private void CZUAssignment_Load(object sender, EventArgs e)
        {
            switch (_interfaceMode) // The interface will be shown upon the called constructor, every constructor has a scope. (Adding assignment as teacher, displaying assignment, and so on)
            {
                case "studentAddsSolution":
                    {
                        // Variables
                        string assignmentDescription = null;
                        //

                        // Getting assignment description
                        AssignmentsTab.assignmentText(_assignmentID, ref assignmentDescription);
                        //

                        // Inserting the assignment description in the control that shows it  
                        assignment.Text = assignmentDescription;
                        //
                        break;
                    }
                case "teacherAddsAssignment":
                    {
                        // Not done
                        break;
                    }
                case "teacherGradesSolution":
                    {
                        // Variables
                        string assignmentDescription = null, studentAssignmentSolution = null;
                        //

                        // Getting assignment description
                        AssignmentsTab.assignmentText(_assignmentID, ref assignmentDescription);
                        //

                        // Inserting the assignment description in the control that shows it  
                        assignmentDescription1.Text = assignmentDescription;
                        //

                        // Getting student assignment solution description
                        AssignmentsTab.studentAssignmentSolution(_assignmentID, _studentID, ref studentAssignmentSolution);
                        //

                        // Inserting the student solution description in the control that shows it  
                        studentSolution.Text = studentAssignmentSolution;
                        //


                        break;
                    }

            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            switch(_interfaceMode) // The interface will be shown upon the called constructor, every constructor has a scope. (Adding assignment as teacher, displaying assignment, and so on)
            {
                case "studentAddsSolution":
                    {
                        if (solution.Text.Length > 25)
                        {
                            // Variables
                            DateTime dateTime = DateTime.Now; // Getting the current time
                            string currentDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss"); // Inserting the current time into a variable, for inserting it in DB 
                            //

                            // DB Non query
                            string nonquery = $"update studentassignmentsolution set solution = '{solution.Text}', state = 'Solved', solutionDate = '{currentDateTime}' where studentID = {_studentID} && assignmentID = {_assignmentID};";
                            //
                            
                            // Updating the data in DB
                            Database.insert(nonquery);
                            //

                            // Displaying a message
                            MessageBox.Show("Your solution was added!");
                            //
                            
                            // Closing the form
                            this.Close();
                            //
                        }
                        else
                            MessageBox.Show("Your solution must have minimum 25 characters!");
                        break;
                    }
                case "teacherAddsAssignment":
                    {
                        // not done
                        break;
                    }
                case "teacherGradesSolution":
                    {
                        if(gradeOfSolution.SelectedIndex > -1) // If a grade was selected
                        {
                            string grade = Convert.ToString(gradeOfSolution.SelectedItem);
                            string nonquery = $"update studentassignmentsolution set grade = {grade}, state = 'Graded' where assignmentID = {_assignmentID} && studentID = {_studentID}";
                            Database.insert(nonquery);
                            MessageBox.Show("Assignment was graded!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Select a grade!");
                        }
                        break;
                    }

            }
        }

        private void exitAssignment_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
