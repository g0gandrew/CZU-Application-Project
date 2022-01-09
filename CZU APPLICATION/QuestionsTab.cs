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
    internal static class QuestionsTab
    {
        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";

        // Main function to update Question panel as teacher
        public static bool updatePanelAsTeacher(ref List<Panel> t_questionPanel, ref List<Button> t_questionTitle, ref List<Label> t_questionStudentName, ref List<Label> t_questionPriorityLevel, ref List<Label> t_questionSubmitDate, ref List <Label> t_questionState, string t_selectedClass, string t_teacherID, ref List <string> t_questionID) 
        {
          

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
            List <string> questionIDs = new List<string>();
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
                    // Setting up question Title
                    t_questionTitle[i].Text = dataReader.GetString(0);
                    //
                    
                    // Setting up priority Level
                    t_questionPriorityLevel[i].Text = dataReader.GetString(1);
                    //

                    // Setting up submit date
                    t_questionSubmitDate[i].Text = dataReader.GetString(2);
                    //
                    
                    // Setting up question state and text color 
                    t_questionState[i].Text = dataReader.GetString(3);
                    if (t_questionState[i].Text == "not answered") // If the question doesn't have an answer, set text color to red
                        t_questionState[i].ForeColor = Color.Red;
                    else
                        t_questionState[i].ForeColor = Color.Green; // If the question has an answer, set text color to green.
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
            for (int z = 0; z <= loopLength; z++)
            {
                command[1] = $"select firstName, lastName from student where id = {studentsIDs[z]}";
                cmd.CommandText = command[1];
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    t_questionStudentName[z].Text = dataReader.GetString(0) + " " + dataReader.GetString(1); // concatinating for obtaining a full name to be displayed
                }
                dataReader.Close();
            }
            
            ///
        
            // Closing MYSQL Connection, and DataReader
            connection.Close();
            //
            return dataAvailable;
        }
        //


        // Main function to update Question panel as student
        public static bool updatePanelAsStudent(ref List<Panel> t_questionPanel, ref List<Button> t_questionTitle, ref List<Label> t_questionPriorityLevel, ref List<Label> t_questionSubmitDate, ref List<Label> t_questionState, string t_selectedCourse, string t_studentID,  ref List <string> t_questionIDs)
        {
            // Pseudo-Assignments until proven different
            /* t_rightPossible = false;
             t_leftPossible = false*/
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
            string command;
            string teacherID = StudentsTab.getTeacherIDByCourse(t_selectedCourse);
            List<string> questionIDs = new List<string>();
            //


            /// Command 0 - Updating students connection status, image, and the displayed amount based on selected class
            command = $"select title, priority, date, state, studentID, ID from question where studentID = {t_studentID} && teacherID = {teacherID}"; //  

            cmd.CommandText = command;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) // for as long it finds data, maximum 4.
            {
                if (i <= 3)
                {
                    // Inserting the ID of question in list
                    questionIDs.Add(dataReader.GetString(5));
                    //

                    // Setting up question Title
                    t_questionTitle[i].Text = dataReader.GetString(0);
                    //

                    // Setting up priority Level
                    t_questionPriorityLevel[i].Text = dataReader.GetString(1);
                    //

                    // Setting up submit date
                    t_questionSubmitDate[i].Text = dataReader.GetString(2);
                    //

                    // Setting up question state and text color
                    t_questionState[i].Text = dataReader.GetString(3);

                    if (t_questionState[i].Text == "not answered") // If the question doesn't have an answer, set text color to red
                        t_questionState[i].ForeColor = Color.Red;
                    else
                        t_questionState[i].ForeColor = Color.Green; // If the question has an answer, set text color to green.
                    //

                    // Enabling the panel for showing the question.
                    t_questionPanel[i].Enabled = true;
                    t_questionPanel[i++].Visible = true;
                    //
                }
                else
                    break;
            }
            t_questionIDs = questionIDs;
        

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
            //
            /*  t_startingFrom += tempI; // We increase the start value by the users that we could display.
              t_recordsOnPage = tempI;
              if (t_startingFrom >= 7)
              {
                  t_leftPossible = true;
              }*/
            // Closing MYSQL Connection, and DataReader
            connection.Close();
            //
            return dataAvailable;
        }
        //

        // Method used to update controls from panel related to teacher connection type
        public static void getQuestionDataAsTeacher(string t_questionID, out string t_title, out string t_question)  
        {
            /// Setting up MYSQL CONNECTION (1)
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            ///

            // Pseudo-Assign
            t_title = "";
            t_question = "";
            //

            cmd.CommandText = $"select title, description from question where id = {t_questionID}";
            dataReader = cmd.ExecuteReader();
            while(dataReader.Read())
            {
                t_title = dataReader.GetString(0);
                t_question = dataReader.GetString(1);
            }
            dataReader.Close();
            connection.Close();

        }
        //

        // Method used to update controls from panel related to student connection type
        public static void getQuestionDataAsStudent(string t_command, ref RichTextBox t_teacherAnswer,  ref RichTextBox t_studentQuestion)
        {
            //  MYSQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand(t_command, connection);
            MySqlDataReader dataReader;
            connection.Open();
            //

            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                t_teacherAnswer.Text = dataReader.GetString(0);
                t_studentQuestion.Text = dataReader.GetString(1);
            }
            dataReader.Close();

            // Closing MYSQL CONNECTION
            connection.Close();
            //

        }
        //

    }
}

