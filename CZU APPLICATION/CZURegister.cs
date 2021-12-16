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
    

        private void register_button_Click(object sender, EventArgs e)
        {
            string birthDate, sexValue = null;
            birthDate = birthDateControl.Value.Date.ToString("yyyy/MM/dd");
            Security.gender(maleCheck, femaleCheck, unspecifiedCheck, ref sexValue);
            Authentication.registration(inUsername.Text, inFirstName.Text, inLastName.Text, inPassword.Text, inAuthKey.Text, inEmail.Text, inPhoneNumber.Text, sexValue, birthDate, inRegKey.Text);
        }
    }
}
