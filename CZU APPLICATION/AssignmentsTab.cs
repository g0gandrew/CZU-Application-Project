using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZU_APPLICATION
{
    internal static class AssignmentsTab
    {
        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";
        
        // Gets the information about the student assignment solution
        public static void getAssignmentSolutionData(string t_command,  ref string t_state,  ref string t_grade, ref DateTime t_solutionSubmitDate) 
        {
            // Opening MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = t_command;
            dataReader = cmd.ExecuteReader();
            while(dataReader.Read())
            {
                t_state = dataReader.GetString(0);
                t_grade = dataReader.GetString(1);
                t_solutionSubmitDate = Convert.ToDateTime(dataReader.GetString(2));
            }
            dataReader.Close();

            // Closing MYSQL connection
            connection.Close();
            //
        }
        //

        // Gets student solution state
        public static void studentAssignmentSolutionState(string t_assignmentID, string t_studentID, ref string t_assignmentState)
        {
            // Opening MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //
            cmd.CommandText = $"select state from studentassignmentsolution where assignmentID = {t_assignmentID} && studentID = {t_studentID}";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                t_assignmentState = dataReader.GetString(0);
            }
            dataReader.Close();

            // Closing MYSQL connection
            connection.Close();
        }
        //

        // Gets assignment state
        public static void assignmentText(string t_assignmentID, ref string t_output)
        {
            // Opening MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = $"select description from assignment where id = {t_assignmentID}";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                t_output = dataReader.GetString(0);
            
            }
            dataReader.Close();

            // Closing MYSQL connection
            connection.Close();
            //
        }
        //

        // Gets student assignment solution
        public static void studentAssignmentSolution(string t_assignmentID, string t_studentID, ref string t_output)
        {
            // Opening MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = $"select solution from studentassignmentsolution where assignmentID = {t_assignmentID} && studentID = {t_studentID}";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                t_output = dataReader.GetString(0);

            }
            dataReader.Close();

            // Closing MYSQL connection
            connection.Close();
            //
        }
        //

        // Gets and fills the list of assignment that is assigned to a particular class
        public static void classAssignments(string t_classID, ref ListBox t_classAssignmentsListBox, string t_teacherID)
        {

            // Opening MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            // List of assignments assigned to class
            List<string> assignedAssignments = new List<string>();
            //


            // Getting the assignments assigned to a specified class
            cmd.CommandText = $"select distinct assignmentID from classassignment where classID = {t_classID} && assignmentID in (select id from assignment where teacherID = {t_teacherID})";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                assignedAssignments.Add(Convert.ToString(dataReader.GetString(0)));
            }
            dataReader.Close();
            //


            // Filling up the Listbox with Assignments given to class
            if (assignedAssignments.Count > 0)
                t_classAssignmentsListBox.DataSource = assignedAssignments;
            else {
                assignedAssignments.Add("No Assignments");
                t_classAssignmentsListBox.DataSource = assignedAssignments;
            }
            //


                // Closing MYSQL CONNECTION
            connection.Close();
            //
        }
        //


        // The Main function for updating 'Assignment' tab with related information to connected student (his assignments), and initializing others fields with vital information for further operations 
        public static bool updatePanelAsStudent(ref List<Panel> t_assignmentPanel, ref List<Button> t_assignmentTitle, ref List<Label> t_assignmentDeadline, ref List<Label> t_assignmentState, ref List <Label> t_assignmentGrade, string t_selectedCourse, string t_studentID,  ref List<string> t_assignmentID, string t_classID)
        {
            // Variables
            int i = 0, tempI;
            bool dataAvailable = false;
            //

            /// Setting up MYSQL CONNECTION (1)
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            ///

            // Commands list
            string command;
            string teacherID = StudentsTab.getTeacherIDByCourse(t_selectedCourse); // Getting the teacher id for the selected course                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            List<string> assignmentsIds = new();
            //

            /// Command 0 - Updating the panel with the list of assignments                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            command = $"select assignmentID from studentassignmentsolution where studentID = {t_studentID} && assignmentID in (select id from assignment where teacherID = {teacherID})";
            cmd.CommandText = command;
            dataReader = cmd.ExecuteReader();

            // Getting the IDs of the assignments which satisfies our conditions
            while (dataReader.Read()) // for as long it finds data, maximum 4.
            {
                if (i <= 3) {
                    assignmentsIds.Add(dataReader.GetString(0));
                    ++i;
                }
                else
                    break;
            }
            dataReader.Close();
            //


            // Assigning the list of assignments
            t_assignmentID = assignmentsIds;
            //


            // Getting and inserting data about assignments/
            for (int z = 0; z < t_assignmentID.Count; z++) 
            {
                command = $"select title, deadline from assignment where id = {t_assignmentID[z]}";
                cmd.CommandText = command;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) // for as long it finds data, maximum 4.
                {
                    // Setting up assignment Title
                    t_assignmentTitle[z].Text = dataReader.GetString(0);
                    //


                    // Setting up Deadline date
                    t_assignmentDeadline[z].Text = dataReader.GetString(1);

                    /// Verifying if the assignment haven't passed the deadline

                    DateTime deadlineDate = Convert.ToDateTime(dataReader.GetString(1));
                    DateTime assignmentSolutionDate = new();
                    string assignmentState = null, assignmentGrade = null;


                    // Getting assignment state, and grade, submitdate, if exists
                    getAssignmentSolutionData($"select state, grade, solutiondate from StudentAssignmentSolution where assignmentID = {t_assignmentID[z]} && studentID = {t_studentID}", ref assignmentState, ref assignmentGrade, ref assignmentSolutionDate);
                    //
                    
                    // If the deadline is passed, set deadline date with red and deactivate button.
                    if (deadlineDate < assignmentSolutionDate)
                    {
                        // Deactivating the button for submiting assignment
                        t_assignmentTitle[z].Enabled = false;
                        //

                        // Changing deadline color to red
                        t_assignmentDeadline[z].ForeColor = Color.Red;
                        //

                        // Modiyfing displayed text, grade
                        t_assignmentState[z].Text = "Deadline Missed";
                        //

                        // Displaying the grade 
                        t_assignmentGrade[z].Text = assignmentGrade;
                        //
                    }
                    // If the deadline isn't passed, verify the scenarios, and do so related to the valid one
                    else 
                    {
                        // Changing deadline color to green
                        t_assignmentDeadline[z].ForeColor = Color.Green;
                        //

                        // Setting up the state of the assignment
                        t_assignmentState[z].Text = assignmentState;
                        //

                        // If the assignment state appears as 'solved' (Automatically setted when student submit the solution) 
                        if (assignmentState == "Solved")
                        {
                            t_assignmentTitle[z].Enabled = false; // We deactivate the button
                            t_assignmentGrade[z].Text = "Not graded yet";
                        }
                        //

                        // If the assignment state appears as 'graded' (Automatically setted when the teacher have graded student assignment)
                        else if (assignmentState == "Graded")
                        {
                            t_assignmentTitle[z].Enabled = false; // We deactivate the button
                            t_assignmentGrade[z].Text = assignmentGrade; // We display the grade.

                        }
                        //

                        // If the assignmment state appears as 'Not Solved' (Student hasn't submit a solution to assignment yet)
                        else if(assignmentState == "Not solved")
                        {
                            t_assignmentTitle[z].Enabled = true; // We deactivate the button
                            t_assignmentGrade[z].Text = "Not graded yet"; // We display the grade.
                        }
                        //
                        // Enabling the panel for showing the assignment.
                        t_assignmentPanel[z].Enabled = true;
                        t_assignmentPanel[z].Visible = true;
                        //
                    }
                    //

                }
                dataReader.Close();
            }



            // If there is any data that satisfies our conditions
            if (i != 0)
                dataAvailable = true;
            //

            tempI = i; // We'll save the amount of question records that exist in database and are valid, so, we can go further from here to display others students assignment in Assignment panel, if it is necessarily.
            --i; // Solving the +1, because if dataReader has no more record to read, we have +1, because we expected a record to be verified.
            for (int z = i + 1; z <= 3; ++z) // When there are less than 4 questions asked, from the remained number, update panel
            {
                t_assignmentPanel[z].Enabled = false;
                t_assignmentPanel[z].Visible = false;
            }
            dataReader.Close();
            ///

          
            // Closing MYSQL Connection
            connection.Close();
            //
            return dataAvailable;
        }
        //


        // The Main function for updating 'Assignment' tab with related information to connected teacher, and initializing others fields with vital information for further operations 
        public static bool updatePanelAsTeacher(ref List<Panel> t_assignmentPanel, ref List<Button> t_assignmentTitle,  ref List<string> t_studentIDs, string t_selectedClassID, string t_selectedAssignment)
        {
            // Variables
            int i = 0, tempI;
            bool dataAvailable = false;
            //

            /// Setting up MYSQL CONNECTION (1)
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            ///

            // Commands list
            string command;
            List<string> studentID = new();
            //

            /// Command 0 - Updating the panel with the list of assignments                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            command = $"select studentID from studentassignmentsolution where assignmentID = {t_selectedAssignment} && studentID in (select id from student where classID = {t_selectedClassID}) && state = 'Solved'";
            cmd.CommandText = command;
            dataReader = cmd.ExecuteReader();

            // Getting the IDs of the assignments which satisfies our conditions
            while (dataReader.Read()) // for as long it finds data, maximum 4.
            {
                if (i <= 3)
                {
                    studentID.Add(dataReader.GetString(0));

                    // Enabling the panel for showing the assignment.
                    t_assignmentPanel[i].Enabled = true;
                    t_assignmentPanel[i++].Visible = true;
                    //
                }
                else
                    break;
            }
            dataReader.Close();
            //

            // Inserting the list of student IDS
                t_studentIDs = studentID;
            //

            // Getting and inserting students name
            for (int z = 0; z < studentID.Count; z++)
            {
                command = $"select firstName, lastName from student where id = {studentID[z]}";
                cmd.CommandText = command;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) // for as long it finds data, maximum 4.
                {

                    // Reusing the control to display student name
                    t_assignmentTitle[z].Text = dataReader.GetString(1) + " " + dataReader.GetString(0); 
                    //
                }
                dataReader.Close();
            }
            //


            // If there is any data that satisfies our conditions
            if (i != 0)
                dataAvailable = true;
            //

            --i; // Solving the +1, because if dataReader has no more record to read, we have +1, because we expected a record to be verified.
            for (int z = i + 1; z <= 3; ++z) // When there are less than 4 questions asked, from the remained number, update panel
            {
                t_assignmentPanel[z].Enabled = false;
                t_assignmentPanel[z].Visible = false;
            }
            dataReader.Close();
            ///


            // Closing MYSQL Connection
            connection.Close();
            //
            return dataAvailable;
        }
        //

    }
}
