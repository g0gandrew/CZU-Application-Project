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
/*        public static bool updatePanelAsTeacher(ref List<Panel> t_assignmentPanel, ref List<Button> t_assignmentTitle, ref List<Label> t_assignmentSubmitDate, ref List<Label> t_assignmentState, string t_selectedClass, string t_teacherID, ref List<string> t_assignmentID)
        {
            // Pseudo-Assignments until proven different
            *//* t_rightPossible = false;
             t_leftPossible = false*//*
            ;
            //

            // Variables
            int loopLength; // Updating the panel by the number of students;
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
            string[] command = new string[2];
            string[] studentsIDs = new string[4];
            List<string> questionIDs = new List<string>();
            //


            /// Command 0 - Updating students connection status, image, and the displayed amount based on selected class
            command[0] = $"select title, priority, date, state, studentID, ID from question where state != 'answered' && teacherID = {t_teacherID} && studentID in (select ID from student where classID = {t_selectedClass})"; //  

            cmd.CommandText = command[0];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) // for as long it finds data, maximum 4.
            {
                if (i <= 3)
                {
                    // Inserting the ID of question in list
                    questionIDs.Add(dataReader.GetString(5));
                    //

                    // Setting up the list of students ids for further command
                    studentsIDs[i] = dataReader.GetString(4);
                    //
                    MessageBox.Show(dataReader.GetString(0) + dataReader.GetString(1) + dataReader.GetString(2) + dataReader.GetString(3) + dataReader.GetString(4));
                    // Setting up question Title
                    t_questionTitle[i].Text = dataReader.GetString(0);
                    //

                    // Setting up priority Level
                    t_questionPriorityLevel[i].Text = dataReader.GetString(1);
                    //

                    // Setting up submit date
                    t_questionSubmitDate[i].Text = dataReader.GetString(2);
                    //

                    // Setting up question state
                    t_questionState[i].Text = dataReader.GetString(3);
                    //

                    // Enabling the panel for showing the question.
                    t_questionPanel[i].Enabled = true;
                    t_questionPanel[i++].Visible = true;
                    //
                }
                else
                    break;
            }

            // Inserting the list of question IDS in list
            t_questionID = questionIDs;
            //

            // If there is any data that satisfies our conditions
            if (i != 0)
                dataAvailable = true;
            //

            tempI = i; // We'll save the amount of question records that exist in database and are valid, so, we can go further from here to display others students questions in Question panel, if it is necessarily.
            --i; // Solving the +1, because if dataReader has no more record to read, we have +1, because we expected a record to be verified.
            loopLength = i;
            for (int z = i + 1; z <= 3; ++z) // When there are less than 4 questions asked, from the remained number, update panel
            {
                t_questionPanel[z].Enabled = false;
                t_questionPanel[z].Visible = false;
            }
            dataReader.Close();
            ///

            i = 0; // restarting the value for being used further

            /// Command 1 - First command for setting Student Name
            /// 
            ////////////// HERE IS THE PROBLEM

            for (int z = 0; z <= loopLength; z++)
            {
                command[1] = $"select firstName, lastName from student where id = {studentsIDs[z]}";
                cmd.CommandText = command[1];
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    MessageBox.Show("Nume student ce a intrebat" + dataReader.GetString(0) + " " + dataReader.GetString(1));
                    t_questionStudentName[z].Text = dataReader.GetString(0) + " " + dataReader.GetString(1); // concatinating for obtaining a full name to be displayed
                }
                dataReader.Close();
            }

            ///

            //
            *//*  t_startingFrom += tempI; // We increase the start value by the users that we could display.
              t_recordsOnPage = tempI;
              if (t_startingFrom >= 7)
              {
                  t_leftPossible = true;
              }*//*
            // Closing MYSQL Connection, and DataReader
            connection.Close();
            //
            return dataAvailable;
        }
*/       
        

        public static void getAssignmentSolutionData(string t_command,  string t_state,  string t_grade) 
        {
            /// Setting up MYSQL CONNECTION (1)
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            ///
            cmd.CommandText = t_command;
            dataReader = cmd.ExecuteReader();
            while(dataReader.Read())
            {
                t_state = dataReader.GetString(0);
                t_grade = dataReader.GetString(1);
            }
            dataReader.Close();

            // Closing MYSQL connection
            connection.Close();
            //
        }

        public static bool updatePanelAsStudent(ref List<Panel> t_assignmentPanel, ref List<Button> t_assignmentTitle, ref List<Label> t_assignmentDeadline, ref List<Label> t_assignmentState, ref List <Label> t_assignmentGrade, string t_selectedCourse, string t_studentID, ref List<string> t_assignmentID, string t_classID)
        {
            // Pseudo-Assignments until proven different
            /* t_rightPossible = false;
             t_leftPossible = false*/
            //

            // Variablesh-
            int loopLength; // Updating the panel by the number of students;
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
            //

            /// Command 0 - Updating the panel with the list of assignments                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            command = $"select assignmentID from classassignment where classID = {t_classID} && assignmentID in (select id from assignment where teacherID = {teacherID})";
            cmd.CommandText = command;
            dataReader = cmd.ExecuteReader();

            // Getting the IDs of the assignments which satisfies our conditions
            while (dataReader.Read()) // for as long it finds data, maximum 4.
            {
                if (i <= 3) {
                    t_assignmentID.Add(dataReader.GetString(0));
                }
                else
                    break;
            }
            dataReader.Close();
            //

            // Getting and inserting data about assignments/
            for (int z = 0; z <= t_assignmentID.Count; z++) 
            {
                command = $"select title, deadline from assignment where id = {t_assignmentID[z]}";
                cmd.CommandText = command;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) // for as long it finds data, maximum 4.
                {
                    // Setting up question Title
                    t_assignmentTitle[z].Text = dataReader.GetString(0);
                    //


                    // Setting up deadline date
                    t_assignmentDeadline[z].Text = dataReader.GetString(1);
                    //


                    // Getting assignment state, and grade, if exists
                    getAssignmentSolutionData($"select state, grade from StudentAssignmentSolution where assignmentID = {t_assignmentID[z]} && studentID = {t_studentID}", t_assignmentState[z].Text, t_assignmentGrade[z].Text);
                    //


                    /* // Setting up assignment state
                      t_assignmentState[i].Text = dataReader.GetString(3);
                      //

                      // Setting up assignment grade
                      t_assignmentGrade[i].Text = dataReader.GetString();
                      //*/

                    // Enabling the panel for showing the question.
                    t_assignmentPanel[z].Enabled = true;
                    t_assignmentPanel[z++].Visible = true;
                    //
                }
                dataReader.Close();
            }




















            // If there is any data that satisfies our conditions
            if (i != 0)
                dataAvailable = true;
            //

            tempI = i; // We'll save the amount of question records that exist in database and are valid, so, we can go further from here to display others students questions in Question panel, if it is necessarily.
            --i; // Solving the +1, because if dataReader has no more record to read, we have +1, because we expected a record to be verified.
            loopLength = i;
            for (int z = i + 1; z <= 3; ++z) // When there are less than 4 questions asked, from the remained number, update panel
            {
                t_assignmentPanel[z].Enabled = false;
                t_assignmentPanel[z].Visible = false;
            }
            dataReader.Close();
            ///

            i = 0; // restarting the value for being used further
            //
          
            // Closing MYSQL Connection, and DataReader
            connection.Close();
            //
            return dataAvailable;
        }
    }
}
