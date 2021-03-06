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
    static class StudentsTab
    {
        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";
        // Gets student class Id 
        public static string getStudentClassID(string t_connectedUser)
        {
            // Pseudo Assign in case of data not found
            string t_classID = null;
            //

            // OPENING MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //
            
            cmd.CommandText = $"select classID from student where username = '{t_connectedUser}'";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                    t_classID = dataReader.GetString(0);
                else
                    return null;
            }
      
            return t_classID;
        }
        //

        // Gets course id by name
        public static string getCourseIDbyName(string t_courseName)
        {
            // Pseudo Assign in case of data not found
            string courseID = null;
            //

            // Opening MYSQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = $"select id from course where name = '{t_courseName}'";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                courseID = dataReader.GetString(0);
            }
            return courseID;
        }
        //

        // Fills DataGridView from Grades tab with student grades
        public static void studentGradesData(string t_command, ref DataGridView t_studentGrades)
        {
            // Opening MYSQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = t_command;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            connection.Open();
            //
            dataAdapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            dataAdapter.Fill(table); 
            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            t_studentGrades.DataSource = bSource;
            connection.Close();
        }
        //
        
        // Gets teacher id
        public static string getTeacherID(string t_connectedUser)
        {
            // Pseudo Assign in case of data not found
            string teacherID = null;
            //
            // Opening MYSQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = $"select id from teacher where username = '{t_connectedUser}'";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                teacherID = dataReader.GetString(0);
            }
            return teacherID;
        }
        //
        
        // Gets teacher id using the course name
        public static string getTeacherIDByCourse(string t_courseName)
        {
            // Pseudo Assign in case of data not found
            string teacherID = null;
            //

            // Opening MYSQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = $"select teacherID from course where name = '{t_courseName}'";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                teacherID = dataReader.GetString(0);
            }
            dataReader.Close();
            return teacherID;
            connection.Close();
        }
        //

        // Gets student id
        public static string getStudentID(string t_connectedUser)
        {
            // Pseudo Assign in case of data not found
            string studentID = null;
            //

            // OPENING MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = $"select id from student where username = '{t_connectedUser}'";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                studentID = dataReader.GetString(0);
            }
            return studentID;
        }
        //

        // Returns a list of the classes that are teached by the connected teacher
        public static List<string> teachedClasses(string t_connectedUser)
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
            string teacherID; 
            //

            // getting connected teacher ID
            teacherID = getTeacherID(t_connectedUser);
            //

            // getting course teached by teacher
            string teachedCourse = null;
            cmd.CommandText = $"select id from course where teacherID = {teacherID}";
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
        //

        // Returns a list of the courses that are studied by the connected student
        public static List <string> studiedCourses(string t_connectedUser)
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
            List<string> studiedCourses = new List<string>();
            List<string> studiedCoursesIDs = new List<string>();
            string classID;
            //

            // Getting student class ID
            classID = getStudentClassID(t_connectedUser);
            //

            // Getting course/s teached at class
            string teachedCourse = null;
            cmd.CommandText = $"select courseID from classcourse where classID = {classID}";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
                studiedCoursesIDs.Add(dataReader.GetString(0));
            //
            dataReader.Close();

            if (studiedCoursesIDs.Count > 0)
            {
                // Getting courses name studied by student
                foreach(string courseID in studiedCoursesIDs)
                {
                    cmd.CommandText = $"select name from course where ID = {courseID}";
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        studiedCourses.Add(dataReader.GetString(0));
                    }
                    dataReader.Close();
                }
                //
            }
            connection.Close();
            //
            return studiedCourses; // returning the list of classes teached by teacher x     
        }
        //

        // The Main function for updating 'Students' tab with related information to connected student (his colleagues), and initializing others fields with vital information for further operations 
        public static bool updatePanelAsStudent(ref int t_recordsOnPage, ref int t_lastID, ref List<Panel> t_studentPanel, ref List<GroupBox> t_studentGB, ref List<Button> t_studentImage, ref List<PictureBox> t_studentConnected, ref List<Label> t_studentName, string t_connectedUser, string t_extraConstraint)
        {
            // Variables
            int loopLength; // Updating the panel by the number of students;
            int i = 0, tempI;
            bool dataAvailable = false;
            int lastStudentID = 0;
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
            string classID = getStudentClassID(t_connectedUser);
            //

            /// Command 0 - Updating students connection status, image, and the displayed users in main panel amount based on students colleagues
            command[0] = $"select connected, id from student where classID = {classID} && username != '{t_connectedUser}' {t_extraConstraint}";
            cmd.CommandText = command[0];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) // For as long it finds data, maximum 6.
            {
                if (i <= 5)
                {
                    // Getting the last student ID
                    lastStudentID = dataReader.GetInt32(1);
                    //

                    // Setting up online/offline status
                    if (dataReader.GetString(0) == "on")
                        t_studentConnected[i].Image = Properties.Resources.on;
                    else
                        t_studentConnected[i].Image = Properties.Resources.off;
                    // // Enabling the panel with data
                    t_studentPanel[i].Enabled = true;
                    t_studentPanel[i++].Visible = true;
                }
                else
                    break;
            }
            dataReader.Close();
            ///


            // If there is any data to be shown
            if (i != 0)
                dataAvailable = true;
            //

            // Statements to modify data use  
            tempI = i; // We'll save the amount of students records that exist in database and are valid, so, we can go further from here to display others students in student panel, if it is necessarily.
            --i; // Solving the +1, because if dataReader has no more record to read, we have +1, because we expected a record to be verified.
            loopLength = i;
            //

            // When there are less than 6 connected users, from the remained number, update panel
            for (int z = i + 1; z <= 5; ++z)
            {
                t_studentPanel[z].Enabled = false;
                t_studentPanel[z].Visible = false;
            }
            //

           
            /// Command 1 - First command, 
            command[1] = $"select firstName, lastname, sex, id from student where classID = {classID} && username != '{t_connectedUser}' {t_extraConstraint}"; // need to modify it aswell       
            cmd.CommandText = command[1];
            dataReader = cmd.ExecuteReader();
            i = 0; // Restarting the value for being used further
            while (dataReader.Read()) // --> One time operation
            {
                if (i <= loopLength)
                {
                    t_studentName[i].Text = dataReader.GetString(0) + " " + dataReader.GetString(1); // concatinating for obtaining a full name to be displayed
                    // Setting groupbox color related to sex
                    if (dataReader.GetString(2) == "F")
                        t_studentGB[i].BackColor = System.Drawing.Color.Violet;
                    else if (dataReader.GetString(2) == "M")
                        t_studentGB[i].BackColor = System.Drawing.Color.DodgerBlue;
                    else
                    {
                        t_studentGB[i].BackColor = System.Drawing.Color.MediumSlateBlue;
                    }

                    ++i;
                }
            }
            dataReader.Close();
            ///

            /// Left And Right Button
            t_lastID = lastStudentID; // We save the record from database last ID.
            t_recordsOnPage = tempI; // We save the amount of records available to be shown in Panel - We set -1,  because we saved in tempI maximum 5, because of indexing from 0 in the previous statements
            ///                    

            // Closing MYSQL Connection
            connection.Close();
            //

            return dataAvailable;
        }
        //

        // The Main function for updating 'Students' tab with related information to connected teacher (the students that are part of the class where teacher teaches), and initializing others field with vital information (Initializes a list of students ids for further operations)
        public static bool updatePanelAsTeacher(ref int t_recordsOnPage, ref int t_lastID, ref List<Panel> t_studentPanel, ref List<GroupBox> t_studentGB, ref List<Button> t_studentImage, ref List<PictureBox> t_studentConnected, ref List<Label> t_studentName, ref List<Label> t_studentQuestion, ref List<Label> t_studentAssignment,  string t_selectedClass, string t_teacherID, string t_extraConstraint, ref List <string> t_studentIDS)
        {
            // Variables
            int loopLength; // Updating the panel by the number of students;
            string[] studentsIDs = new string[6];
            int i = 0, tempI;
            bool dataAvailable = false;
            int lastStudentID = 0;
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
            string[] command = new string[4];
            List<string> studentIDs = new List<string>();
            //


            /// Command 0 - Updating students connection status, image, and the displayed amount based on selected class
            command[0] = $"select connected, id  from student where classID = {t_selectedClass} {t_extraConstraint}"; //  

            cmd.CommandText = command[0];
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) // for as long it finds data, maximum 6.
            {
                if (i <= 5)
                {
                    // Getting the last student ID
                    lastStudentID = dataReader.GetInt32(1);
                    //

                    // Filling up the list of student IDS
                    studentIDs.Add(dataReader.GetString(1));
                    //

                    // Setting up online/offline status
                    if (dataReader.GetString(0) == "on") {
                        t_studentConnected[i].Image = Properties.Resources.on;
                    }
                    else
                        t_studentConnected[i].Image = Properties.Resources.off;
                    // Enabling the panel with data
                    t_studentPanel[i].Enabled = true;
                    t_studentPanel[i++].Visible = true;
                }
                else
                    break;
            }

            if (i != 0)
                dataAvailable = true;
            --i; // Solving the +1, because if dataReader has no more record to read, we have +1, because we expected a record to be verified.
            tempI = i; // We'll save the amount of students records that exist in database and are valid, so, we can go further from here to display others students in student panel, if it is necessarily.
            loopLength = i;
            for (int z = i + 1; z <= 5; ++z) // When there are less than 6 connected users, from the remained number, update panel
            {
                t_studentPanel[z].Enabled = false;
                t_studentPanel[z].Visible = false;
            }
            dataReader.Close();
            ///

            // Filling up the list of student IDS
            t_studentIDS = studentIDs;
            //


            /// Command 1 - First command, for gatthering the studentID + others
            command[1] = $"select ID, firstName, lastname, sex, connected, classID, id from student where classID = {t_selectedClass} {t_extraConstraint}"; // need to modify it aswell       
            cmd.CommandText = command[1];
            dataReader = cmd.ExecuteReader();
            i = 0; // restarting the value for being used further
            while (dataReader.Read()) // --> One time operation
            {
                if (i <= loopLength)
                {
                    studentsIDs[i] = dataReader.GetString(0); // getting students id 
                    t_studentName[i].Text = dataReader.GetString(1) + " " + dataReader.GetString(2); // concatinating for obtaining a full name to be displayed
                    // Setting groupbox color related to sex
                    if (dataReader.GetString(3) == "F")
                        t_studentGB[i].BackColor = System.Drawing.Color.Violet;
                    else if (dataReader.GetString(3) == "M")
                        t_studentGB[i].BackColor = System.Drawing.Color.DodgerBlue;
                    else
                    {
                        t_studentGB[i].BackColor = System.Drawing.Color.MediumSlateBlue;

                    }
                    ++i;
                }           
            }
            dataReader.Close();

              /// Left And Right Button
            t_lastID = lastStudentID; // We save the record from database last ID.
            t_recordsOnPage = tempI; // We save the amount of records available to be shown in Panel - We set -1,  because we saved in tempI maximum 5, because of indexing from 0 in the previous statements
            ///   



            // Command 2 - Student --> Questions
            for (int z = 0; z <= loopLength; z++)
            {
                command[2] = $"select count(ID) from question where studentID = {studentsIDs[z]} && teacherID = {t_teacherID} && state = 'not answered';";
                cmd.CommandText = command[2];
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    t_studentQuestion[z].Text = dataReader.GetString(0);
                }
                dataReader.Close();
            }
            //


            // Command 3 - Student --> Assignments
            for (int z = 0; z <= loopLength; z++)
            {
                command[3] = $"select count(assignmentID) from studentassignmentsolution where studentID = {studentsIDs[z]} && state = 'Solved' && assignmentID in (select id from assignment where teacherID = {t_teacherID})"; // Update the number of assignments that student must do
                cmd.CommandText = command[3];
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    t_studentAssignment[z].Text = dataReader.GetString(0);
                }
                dataReader.Close();
            }
      
            // Closing MYSQL Connection, and DataReader
            connection.Close();
            //
            return dataAvailable;
        }
        //

        // This method verify if the teacher teach any class, and, fills the 'Select Class ID' list box with the found information
        public static bool updateTeachedClassesList(ref ListBox t_teachedClassesControl, ref List<string> t_teachedClasses, string t_connectedUser)
        {
            // Fills the list of teached classes with related information
            t_teachedClasses = teachedClasses(t_connectedUser);
            //
            
            // Updating the 'Select Class ID' list with the found information
            t_teachedClassesControl.DataSource = t_teachedClasses;
            //

            // If there are teached classes in list
            if (t_teachedClasses.Count != 0) 
            {
                return true;
            }
            // If there aren't teached classes in the list
            return false; 
        }
        // 

        // This method verify if the student class has any course to study, and, fills the 'Select Course' list box with the found information
        public static bool updateStudiedCoursesList(ref ListBox t_list, string t_connectedUser, ref List <string> t_studiedCourses)
        {
            // Fills the list of studied courses with related information
            t_studiedCourses = studiedCourses(t_connectedUser);
            //


            // Updating the 'Select Course' list with the found information
            t_list.DataSource = t_studiedCourses;
            //

            // If there are studied courses in list
            if(t_studiedCourses.Count != 0)
            {
                return true;
            }
            // If there aren't studied courses in list
            return false;
        }
        //
    }
}