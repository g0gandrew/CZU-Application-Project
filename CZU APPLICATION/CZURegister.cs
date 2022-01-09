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

        // Properties
        private bool guiInitialised { get; set; } = false;
        //

        public CZURegister()
        {
            InitializeComponent();
        }

        // Creates a list of the controls used, for further operations
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
        //


        private void register_button_Click(object sender, EventArgs e)
        {
            // One time operation for creating the list of GUI controls for further operations
            if (guiInitialised == false)
            {
                textBoxesInitialization(); // Creating the list 
                guiInitialised = true;
            }
            //

            // Variables
            string birthDate, sexValue = null;
            //

            birthDate = birthDateControl.Value.Date.ToString("yyyy.MM.dd");

            // Verifying if the data introduced in controls are valid for registration process
            bool formatValid = Security.registrationFormatVerifier(ref textBoxes, ref selectSex, ref sexValue);
            //

            if (formatValid == true)
            {
                // Verifying if the registration was sucessfull
                bool sucesfullReg = Authentication.registration(inUsername.Text, inFirstName.Text, inLastName.Text, inPassword.Text, inAuthKey.Text, inEmail.Text, inPhoneNumber.Text, sexValue, birthDate, inRegKey.Text);
                //

                if (sucesfullReg == true) // If registration was sucessfull
                {
                    MessageBox.Show("Your account has been created, you can log in!");
                    this.Close();
                }
            }
            }
    }
}
