using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;


namespace CZU_APPLICATION
{
    static class Students
    {
        public static void updatePanel(out int t_recordsOnPage, out bool t_rightPossible, out bool t_leftPossible, ref int t_startingFrom, List<Panel> t_studentPanel, List <GroupBox> t_studentGB,  List <Button> t_studentImage, List<PictureBox> t_studentConnected, List <Label> t_studentName,  List<Label> t_studentQuestion,  List<Label> t_studentAssignment,  List<Label> t_studentMeeting)
        {
            // Pseudo-Assignments until proven different
            t_rightPossible = false;
            t_leftPossible = false;
            //

            // Variables
            int loopLength; // Updating the panel by the number of students;
            string[] studentID = new string[6];
            int i = 0, tempI;
            //

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
            string[] command = new string[5];
            //


            /// Command 0 - Updating users, connect status, that are shown, related to number of students registered
            command[0] = $"select connected from students where studentID >= {t_startingFrom + 1}";
            cmd.CommandText = command[0];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (i <= 5)
                {
                    // Setting up online/offline status
                    if (dataReader.GetString(0) == "on")
                        t_studentConnected[i].Image = Image.FromFile(@"C:\Users\Andrew\source\repos\CZU APPLICATION\Images\on.png");
                    else
                        t_studentConnected[i].Image = Image.FromFile(@"C:\Users\Andrew\source\repos\CZU APPLICATION\Images\off.png");
                    // Disabling the panel that cover Student Interface x/6
                    t_studentPanel[i].Enabled = false;
                    t_studentPanel[i++].Visible = false;
                }
                else
                    break;
            }
            tempI = i; // We'll save the amount of students records that exist in database and are valid, so, we can go further from here to display others students in student panel, if it is necessarily.
            --i; // Solving the +1, because if dataReader has no more record to read, we have +1, because we expected a record to be verified.
            loopLength = i;
            for (int z = i + 1; z <= 5; ++z) // When there are less than 6 connected users, from the remained number, update panel
            {
                t_studentPanel[z].Enabled = true;
                t_studentPanel[z].Visible = true;
            }
            dataReader.Close();
            ///


            /// Command 1 - First command, for gatthering the studentID + others
            command[1] = $"select studentID, firstName, lastname, sex, connected from students where studentID >= {t_startingFrom + 1}"; // need to modify it aswell
            cmd.CommandText = command[1];
            dataReader = cmd.ExecuteReader();
            i = 0; // restarting the value for being used further
            while (dataReader.Read()) // --> One time operation
            {
                if (i <= loopLength)
                {
                    studentID[i] = dataReader.GetString(0); // getting the student id 
                    t_studentName[i].Text = dataReader.GetString(1) + " " + dataReader.GetString(2); // concatinating for obtaining a full name to be displayed
                    string studentConnectedStatus = dataReader.GetString(4);
                    // Setting groupbox color related to sex
                    if (dataReader.GetString(3) == "F")
                        t_studentGB[i].BackColor = System.Drawing.Color.Violet;
                    else if (dataReader.GetString(3) == "M")
                        t_studentGB[i].BackColor = System.Drawing.Color.DodgerBlue;
                    else
                    { // Need to implement custom SEX} 
                    }
                    //
                    // Changing studentConnected image status
                    // Need to be implemented, linked with image
                    //
                    ++i;
                }
                else
                {
                    // Verifying if there exists one more record, so, we can utilize right button to display further students in panel.
                    // If this else runs, it means that dataReader has found a record in table, so, there exists one more record which satisfy our button condition.
                    t_rightPossible = true;
                }
            }
            dataReader.Close();
            ///
            // Command 2 - Student --> Questions
            for (int z = 0; z <= loopLength; z++)
            {
                command[2] = $"select count(questionID) from questions where studentID = {studentID[z]};";
                cmd.CommandText = command[2];
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                        t_studentQuestion[z].Text = dataReader.GetString(0);
                }
                dataReader.Close();
            }
            //

            // Command 3 - Student --> Meetings
            for (int z = 0; z <= loopLength; z++)
            {
                command[3] =$"select count(meetingID) from StudentsMeetings where studentID = {studentID[z]};";
                cmd.CommandText = command[3];
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                        t_studentAssignment[z].Text = dataReader.GetString(0);
                }
                dataReader.Close();
            }
            //
           

            // Command 4 - Student --> Assignments
            for (int z = 0; z <= loopLength; z++)
            {
                command[4] = $"select count(assignmentID) from StudentsAssignments where studentID = {studentID[z]};";
                cmd.CommandText = command[4];
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                        t_studentMeeting[z].Text = dataReader.GetString(0);
                }
                dataReader.Close();
            }
            //

            t_startingFrom += tempI; // We increase the start value by the users that we could display.
            t_recordsOnPage = tempI;
            if (t_startingFrom >= 7)
            {
                t_leftPossible = true;
            }
            // Closing MYSQL Connection, and DataReader
            connection.Close();
            //

        }
    }
}
