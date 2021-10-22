using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;


namespace CZU_APPLICATION
{
    public partial class CZURegister : Form
    {
        public CZURegister()
        {
            InitializeComponent();
        }
        // Global Variables
        string sex_value, birthdate;

        //
        private void one_gender_selection(CheckBox maleCheck, CheckBox femaleCheck, CheckBox unspecified)
        {
            if (maleCheck.Checked)
                sex_value = "male";
            if (femaleCheck.Checked)
                sex_value = "female";
            else
                sex_value = "unspecified";
            while (maleCheck.Checked && femaleCheck.Checked || maleCheck.Checked && unspecifiedCheck.Checked || femaleCheck.Checked && unspecifiedCheck.Checked)
            {
                maleCheck.Checked = false;
                femaleCheck.Checked = false;
                unspecifiedCheck.Checked = false;
                MessageBox.Show("Select just one gender");
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

           // registration(inUsername, inPassword, inPinCode, inEmail, inPhoneNumber, inRegKey, );
        }
        private void registration(string  a, string b, string c, string d, string e, string f, string g, string h) 
        {
            string path = @"Data Source=DESKTOP-3GAOIRP;Initial Catalog=czu_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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

        /*private bool details_filled(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            while(b.Count() < 8)
                MessageBox.Show("Your password must have minimum 8 characters!");

            while (a.Count() < 5)
                MessageBox.Show("Your username must have minimum 5 characters!");
         
        }*/ // ----> A method to verify the text boxes if they're filled in the right way
 
        private void register_button_Click(object sender, EventArgs e)
        {
            birthdate = birthdate_control.Value.ToString();
            one_gender_selection(maleCheck, femaleCheck, unspecifiedCheck);
            registration(inUsername.Text, inPassword.Text, inPinCode.Text, inEmail.Text, inPhoneNumber.Text, inRegKey.Text, sex_value, birthdate);
        }

    }
}
