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
    }
 }
