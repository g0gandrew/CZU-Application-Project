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
    static class StudentsPanel
    {
        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";


        public static List <string> teachedClasses(string t_connectedUser, out string t_teacherID)
        {
            // Opening MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //
            // Variables
            List<string> teachedClasses = new List<string>();
            t_teacherID = null; // pseudo assign
            //

            // getting connected teacher ID
            cmd.CommandText = $"select ID from teacher where username = '{t_connectedUser}'";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
                t_teacherID = dataReader.GetString(0);
            dataReader.Close();
            //

            // getting course teached by teacher
            string teachedCourse = null; 
            cmd.CommandText = $"select id from course where teacherID = {t_teacherID}";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
                teachedCourse = dataReader.GetString(0);
            //
            dataReader.Close();
            if (teachedCourse != null)
            {
                // getting classes IDs teached by teacher
                cmd.CommandText = $"select distinct classID from classcourse where courseID = {teachedCourse}";
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    teachedClasses.Add(dataReader.GetString(0));
                }
                dataReader.Close();
            }
            connection.Close();
            //
            return teachedClasses; // returning the list of classes teached by teacher x     
        }

        public static void updatePanel(out int t_recordsOnPage, out bool t_rightPossible, out bool t_leftPossible, ref int t_startingFrom, List<Panel> t_studentPanel, List<GroupBox> t_studentGB, List<Button> t_studentImage, List<PictureBox> t_studentConnected, List<Label> t_studentName, List<Label> t_studentQuestion, List<Label> t_studentAssignment, List<Label> t_studentMeeting, string t_connectedUserType, string t_connectedUser, string t_selectedClass)
        {
            // Pseudo-Assignments until proven different
            t_rightPossible = false;
            t_leftPossible = false;
            //

            // Variables
            int loopLength; // Updating the panel by the number of students;
            string[] studentID = new string[6];
            string[] classID = new string[6];
            string connectedTeacherID = null;
            int i = 0, tempI;
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
            string[] command = new string[5];
            //

            /// Getting crucial data for further processes related to connected user type
            if (t_connectedUserType == "teacher")
            {
            }
            else
            {
                // student
            }
            ///

            /// Command 0 - Updating students connection status, image, and the displayed amount based on selected class
            if (t_connectedUserType == "teacher")
            {
                command[0] = $"select connected from student where classID = {t_selectedClass}"; //  
            }
            else
            {

            }

            cmd.CommandText = command[0];
            dataReader = cmd.ExecuteReader();
           
            while (dataReader.Read()) // for as long it finds data, maximum 6.
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
            if (t_connectedUserType == "teacher")
            {
                command[1] = $"select ID, firstName, lastname, sex, connected, classID from student where classID = {t_selectedClass}"; // need to modify it aswell       
            }
            else
            {

            }

            cmd.CommandText = command[1];
            dataReader = cmd.ExecuteReader();
            i = 0; // restarting the value for being used further
            while (dataReader.Read()) // --> One time operation
            {
                if (i <= loopLength)
                {
                    studentID[i] = dataReader.GetString(0); // getting students id 
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
                    //-
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
                if (t_connectedUserType == "teacher") 
                    command[2] = $"select count(ID) from question where studentID = {studentID[z]};";
                else
                {
                        ///
                }
                
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
                if (t_connectedUserType == "teacher")
                    command[3] =$"select count(classID) from ClassMeeting where classID = {t_selectedClass};";
                else
                {
                    // 
                }
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
                if (t_connectedUserType == "teacher")
                    command[4] = $"select count(classID) from ClassAssignment where classID = {t_selectedClass};";
                else
                {
                    // 
                }
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
