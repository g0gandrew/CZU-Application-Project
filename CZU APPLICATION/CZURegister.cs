using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace CZU_APPLICATION
{
    public partial class CZURegister : Form
    {
        public  CZURegister()
        {
            InitializeComponent();
        }
        // Global Variables
        string sex_value, birthdate;
        string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //
        
        private void registration(string  a, string b, string c, string d, string e, string f, string g, string h) 
        {
            SqlConnection connection = new SqlConnection(path);
            string nonquery = $"insert into users(name, password, pin, email, phone_number, registration_key, sex, birth_date) values('{a}', '{b}', '{c}', '{d}', '{e}', '{f}', '{g}', '{h}')";
            SqlCommand cmd = new SqlCommand(nonquery, connection);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.InsertCommand = cmd;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

 
        private void register_button_Click(object sender, EventArgs e)
        {
            birthdate = birthdate_control.Value.ToString();
            Security.gender(maleCheck, femaleCheck, unspecifiedCheck, sex_value);
            registration(inUsername.Text, inPassword.Text, inPinCode.Text, inEmail.Text, inPhoneNumber.Text, inRegKey.Text, sex_value, birthdate);
        }

    }
}
