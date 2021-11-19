using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CZU_APPLICATION
{
    static class Statistics
    {
        public static int update(ref Label t_a, string t_command, string t_searchedKey)
        {
            int count = 0;
            t_command += $"'{t_searchedKey}'";
            string path = "SERVER=localhost; PORT=3306;DATABASE=czu_app;UID=root;PASSWORD=Andrei123!?";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = path;
            MySqlCommand cmd = new MySqlCommand(t_command, connection);
            MySqlDataReader dataReader;
            connection.Open();
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) // counting for statistics 
            {
                if ((string)dataReader.GetValue(0) == t_searchedKey)
                    ++count;
            }
            dataReader.Close();
            connection.Close();
            t_a.Text = $"{count}";
            return count;
        }

        public static void updateConnectedStudents(params Panel[] t_studentPanel)
        {
            /// Setting up MYSQL CONNECTION (1)
            string path = "SERVER=localhost; PORT=3306;DATABASE=czu_app;UID=root;PASSWORD=Andrei123!?";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            cmd.CommandText = "select connected from students;";
            dataReader = cmd.ExecuteReader();
            ///
            int i = 0;
            while(dataReader.Read())
            {
                if (dataReader.GetString(0) == "on" && i < 6)
                {

                    t_studentPanel[i].Enabled = false;
                    t_studentPanel[i++].Visible = false;
                }
                if (i == 5)
                    break;
            }
            for (int z = i; z < 6; ++z) // When there are less than 6 connected users, from the remained number, set panel
            {
                t_studentPanel[z].Enabled = true;
                t_studentPanel[z].Visible = true;
            }

            dataReader.Close();
            connection.Close();
        }

        public static void updateStudentPanel(ref GroupBox t_studentGB, ref Button t_studentImage, ref PictureBox t_studentConnected, ref Label t_label0, ref Label t_label1, ref Label t_label2, ref Label t_label3)
        {
            string studentID = "";
            /// Setting up MYSQL CONNECTION (1)
            string path = "SERVER=localhost; PORT=3306;DATABASE=czu_app;UID=root;PASSWORD=Andrei123!?";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            ///

            // Command list
            List <string> command = new List<string>();
            //

            // Student Name, studentGB Color related to sex, Student Image, Student Connected Status
            command.Add("select studentID, firstName, lastname, sex, connected from students;");
            //

            // Command 1 - First command, for gatthering the studentID + others
            cmd.CommandText = command[0];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) // --> One time operation
            {
                studentID = dataReader.GetString(0); // getting the student name 
                t_label0.Text = dataReader.GetString(1) + " " + dataReader.GetString(2); // concatinating for obtaining a full name to be displayed
                string studentConnectedStatus = dataReader.GetString(4);
                // Setting groupbox color related to sex
                if (dataReader.GetString(3) == "F")
                    t_studentGB.BackColor = System.Drawing.Color.Violet;
                else if (dataReader.GetString(3) == "M")
                    t_studentGB.BackColor = System.Drawing.Color.DodgerBlue;
                else
                { // Need to implement custom SEX} 
                }
                //
                // Changing studentConnected image status
                // Need to be implemented, linked with image
                //

                break;
            }
            dataReader.Close();

            // Student --> Questions
            command.Add($"select count(questionID) from questions where studentID = {studentID};");
            cmd.CommandText = command[1];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                t_label1.Text = dataReader.GetString(0);
            }
            dataReader.Close();
            //

            // Student --> Meetings
            command.Add($"select count(meetingID) from StudentsMeetings where studentID = {studentID};");
            cmd.CommandText = command[2];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                t_label2.Text = dataReader.GetString(0);
            }
            dataReader.Close();
            //

            // Student --> Assignments
            command.Add($"select count(assignmentID) from StudentsAssignments where studentID = {studentID};");
            cmd.CommandText = command[3];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                t_label3.Text = dataReader.GetString(0);
            }
            dataReader.Close();
            //

            // Updating Connected Users Panels

            // 
           
            
            
            // Closing MYSQL Connection, and DataReader
              connection.Close();
           //

            }
        }
    }
