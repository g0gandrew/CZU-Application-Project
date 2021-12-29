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

        // Creating a list for TextBoxes
        List <TextBox> textBoxes = new List <TextBox> ();   
        //
        public  CZURegister()
        {
            InitializeComponent();
        }

        private void textBoxesInitialization()
        {
            textBoxes.Add(inUsername);
            textBoxes.Add(inPassword);
            textBoxes.Add(inEmail);
            textBoxes.Add(inPhoneNumber);
            textBoxes.Add(inAuthKey);
            textBoxes.Add(inFirstName);
            textBoxes.Add(inLastName);
        }
        private void register_button_Click(object sender, EventArgs e)
        {
            textBoxesInitialization();
            string birthDate, sexValue = null;
            birthDate = birthDateControl.Value.Date.ToString("yyyy.MM.dd");
            bool formatValid = Security.registrationFormatVerifier(ref textBoxes, ref selectSex);
            if(formatValid)
                Authentication.registration(inUsername.Text, inFirstName.Text, inLastName.Text, inPassword.Text, inAuthKey.Text, inEmail.Text, inPhoneNumber.Text, sexValue, birthDate, inRegKey.Text);
        }
    }
}
