using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CZU_APPLICATION
{
    internal class Database
    {
        public static void insert(string command)
        {
            string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(path);
            SqlDataAdapter dataAdapter;
            SqlCommand cmd;
            dataAdapter = new SqlDataAdapter();
            connection.Open();
            cmd = new SqlCommand(command, connection);
            dataAdapter.InsertCommand = cmd;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            dataAdapter.Dispose();
            connection.Close();
        }
      
    }
}
