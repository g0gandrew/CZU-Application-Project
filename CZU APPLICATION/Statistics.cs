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
        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";

        public static void homePanelUpdateDataAsStudent(ref List <Label> t_labels, string t_classID, string t_studentID)
        {

            // Opening MYSQL Connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            // Variabels
            List<string> command = new List<string>();
            int x = 0;
            //
            // Initializing the list of commands
            command.Add($"select count(connected) from student where classID = {t_classID} && connected = 'on' && id != {t_studentID}"); // Update number of connected colleagues
            command.Add($"select count(id) from question where state = 'not answered' && studentID = '{t_studentID}'"); // Update student number of questions still not answered
            command.Add($"select count(assignmentID) from studentassignmentsolution where studentID = {t_studentID} && state = 'Not solved' && assignmentID in (select id from assignment where teacherID in (select teacherID from course where id in (select courseID from classcourse where classID = {t_classID})))"); // Update the number of assignments that student must do
            //
            foreach (string i in command)
            {
                cmd.CommandText = i;
                dataReader = cmd.ExecuteReader();
                // Getting the number of data available
                while (dataReader.Read())
                {
                    t_labels[x].Text = dataReader.GetString(0);
                }
                //
                ++x;
                dataReader.Close();
            }
            connection.Close();

        }
        public static void homePanelUpdateDataAsTeacher(ref List <Label> t_labels,  List <string> t_teachedClasses, string t_teacherID)
        {

            // Opening MYSQL Connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            if (t_teachedClasses.Count == 0) // If there are no teached classes, it means that there isn't data to be shown.
            {
                foreach (Label i in t_labels)
                {
                    i.Text = "0";
                }
            }
            else // If there is minimum one class, we can update the statistics
            {
                // Getting the number of questions a teacher has to respond
     
                for(int i = 0; i < t_labels.Count; i++)
                {
                    // Local Variables
                    int count = 0;
                    string command;
                    //
                    foreach(string x in t_teachedClasses)
                    {
                        if (i == 0)
                            command = $"select count(connected) from student where classId = {x} && connected = 'on'";
                        else if(i == 1)
                            command = $"select count(id) from question where teacherID = {t_teacherID} && state = 'not answered' && studentId in (select id from student where classId = {x})";
                        else
                            command = $"select count(assignmentID) from classassignment where classId = {x} && assignmentID in (select id from assignment where teacherID = {t_teacherID})";
                        cmd.CommandText = command;
                        dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            count += Convert.ToInt32(dataReader.GetString(0));  
                        }
                        dataReader.Close();
                    }
                    t_labels[i].Text = Convert.ToString(count);
                }
            }
            // 
        }
    }
}
