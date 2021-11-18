using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CZU_APPLICATION
{
    public partial class CZURegister : Form
    {
        public  CZURegister()
        {
            InitializeComponent();
        }
        // Global Variables
        string sexValue, birthdate;
        string path = "SERVER=localhost; PORT=3306;DATABASE=czu_app;UID=root;PASSWORD=Andrei123!?";
        //

        private void registration(string  t_name, string t_password, string t_pin, string t_email, string t_phoneNumber, string t_registrationKey, string t_sex, string t_birthdate) 
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = path;
            string nonquery = $"insert into users(name, password, pin, email, phoneNumber, registrationKey, sex, birthDate) values('{t_name}', '{t_password}', '{t_pin}', '{t_email}', '{t_phoneNumber}', '{t_registrationKey}', '{t_sex}', '{t_birthdate}')";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(nonquery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            this.Close();

        }


        private void register_button_Click(object sender, EventArgs e)
        {
            birthdate = birthdate_control.Value.ToString();
            Security.gender(maleCheck, femaleCheck, unspecifiedCheck, sexValue);
            registration(inUsername.Text, inPassword.Text, inPinCode.Text, inEmail.Text, inPhoneNumber.Text, inRegKey.Text, sexValue, birthdate);
        }

    }
}
