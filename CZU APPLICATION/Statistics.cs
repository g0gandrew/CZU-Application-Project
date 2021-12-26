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

        public static void update(ref Label t_a, string t_command, string t_searchedKey, ref int statisticCount)
        {
            int count = 0;
            t_command += $"'{t_searchedKey}'";
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
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
            t_a.Text = $"{count + statisticCount}";
            statisticCount = count;
        }

        public static void homePanelConnectedColleagues(ref Label t_statisticsUsers, string t_classID)
        {
            // Variables
            int statisticCount = 0;
            string command;
            command = $"select connected from student where classID = {t_classID} && connected =";
            update(ref t_statisticsUsers, command, "on", ref statisticCount);
        }
        public static void homePanelConnectedStudents(ref Label t_statisticsUsers, List <string> t_teachedClasses)
        {
            // Variables
            int statisticCount = 0;
            t_statisticsUsers.Text = "0";
            string command;
            foreach(string i in t_teachedClasses)
            {
                command = $"select connected from student where classID = {i} && connected =";
                update(ref t_statisticsUsers, command, "on", ref statisticCount);
            }
        }
        
    }
}
