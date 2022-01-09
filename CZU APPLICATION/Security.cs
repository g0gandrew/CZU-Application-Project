using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CZU_APPLICATION
{
    internal static class Security
    {
        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";



        // Verifies if the registration data satisfies our format criteria
        public static bool registrationFormatVerifier(ref List<TextBox> textBoxes, ref CheckedListBox t_selectSex, ref string t_sexValue)
        {
            // MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection(_path);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            connection.Open();
            MySqlDataReader dataReader;
            //

            // List of errors
            List<string> errors = new List<string>();
            int count = 0;
            //

            /// Veryifing the unicity of the email and username

            // Verifing from student table
            cmd.CommandText = "select username from student;";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if(textBoxes[0].Text == dataReader.GetString(0))
                    errors.Add("Username is already taken, choose another one!");
            }
            dataReader.Close();
            //

            // Verifying from teacher table
            cmd.CommandText = "select username from teacher;";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (textBoxes[0].Text == dataReader.GetString(0))
                    errors.Add("Username is already taken, choose another one!");
            }
            dataReader.Close();
            //

            // Verifying from admin table
            cmd.CommandText = "select username from admin;";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (textBoxes[0].Text == dataReader.GetString(0))
                    errors.Add("Username is already taken, choose another one!");
            }
            dataReader.Close();
            //

            // Verifing from student table
            cmd.CommandText = "select email from student;";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (textBoxes[2].Text == dataReader.GetString(0))
                    errors.Add("Email is already taken, choose another one!");
            }
            dataReader.Close();
            //

            // Verifying from teacher table
            cmd.CommandText = "select email from teacher;";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (textBoxes[2].Text == dataReader.GetString(0))
                    errors.Add("Email is already taken, choose another one!");
            }
            dataReader.Close();
            //
          
            // Verifying from admin table
            cmd.CommandText = "select email from admin;";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (textBoxes[2].Text == dataReader.GetString(0))
                    errors.Add("Email is already taken, choose another one!");
            }
            dataReader.Close();
            //

            // CLOSING MYSQL CONNECTION
            connection.Close();
            //

            ///


      
            // Verifying the username
            if (textBoxes[0].Text.Length > 15)
            {
                errors.Add("Your username is too long, maximum 15 characters are allowed!");
                textBoxes[0].Clear();
            }
            else if (textBoxes[0].Text.Length < 5)
            {
                errors.Add("Your username is too short, minimum 5 characters are needed!");
                textBoxes[0].Clear();
            }
            //

            // Verifying the password
            if (textBoxes[1].Text.Length > 25)
            {
                errors.Add("Your password is too long, maximum 25 characters are allowed!");
                textBoxes[1].Clear();
            }
            else if (textBoxes[1].Text.Length < 8)
            {
                errors.Add("Your password is too short, minimum 8 characters are needed!");
                textBoxes[1].Clear();
            }
            //

            // Verifying the email
            if (textBoxes[2].Text.Length > 30)
            {
                errors.Add("Your email is too long, maximum 30 characters are allowed!");
                textBoxes[2].Clear();
            }
            else if (textBoxes[2].Text.Length < 3)
            {
                errors.Add("Your email is too short, minimum 3 characters are needed!");
                textBoxes[2].Clear();
            }
            //

            // Verifying the phone number
             ulong phoneNumber;
            // Trying to convert the phone number (string), into an int value, to see if it's compound only from digits.
            if (ulong.TryParse(textBoxes[3].Text.Substring(0), out phoneNumber))
            {
                if (textBoxes[3].Text.Length > 15)
                {
                    errors.Add("Your phone number is too long, maximum 15 digits are allowed!");
                    textBoxes[3].Clear();
                }
                else if (textBoxes[3].Text.Length < 8)
                {
                    errors.Add("Your phone number is too short, minimum 8 digits are needed!");
                    textBoxes[3].Clear();
                }
            }
            else // If conversion fails, it means that format is invalid, it contains characters
            {
                errors.Add("Invalid format, phone number should contain only digits!");
            }
            //

            // Verifying the Authentication Key
            if (textBoxes[4].Text.Length > 20)
            {
                errors.Add("Your Authentication key is too long, maximum 20 characters are allowed!");
                textBoxes[4].Clear();
            }
            else if (textBoxes[4].Text.Length < 10)
            {
                errors.Add("Your Authentication key is too short, minimum 10 characters are needed!");
                textBoxes[4].Clear();
            }

            //

            // Verifying the first name
            if (textBoxes[5].Text.Length > 20)
            {
                errors.Add("Your first name is too long, maximum 20 characters are allowed!");
                textBoxes[5].Clear();
            }
            else if (textBoxes[5].Text.Length < 3)
            {
                errors.Add("Your first name is too short, minimum 3 characters is needed!");
                textBoxes[5].Clear();
            }
            //

            // Verifying the last name
            if (textBoxes[6].Text.Length > 20)
            {
                errors.Add("Your last name is too long, maximum 20 characters are allowed!");
                textBoxes[6].Clear();
            }
            else if (textBoxes[6].Text.Length < 3)
            {
                errors.Add("Your last name is too short, minimum 3 characters are needed!");
                textBoxes[6].Clear();
            }
            //

            /// Verifying if there is just one gender selected

            for (int i = 0; i < t_selectSex.Items.Count; i++)
            {
                if (t_selectSex.GetItemChecked(i))
                {
                    ++count;
                }
            }
            // If there is no gender selected
            if (count == 0)
            {
                errors.Add("Select a gender!");
            }
            //

            // If there is more than one gender selected
            else if (count > 1)
            {
                errors.Add("Select just one gender!");
                t_selectSex.ClearSelected();
            }
            else if(count == 1)
            {
                string gender = t_selectSex.GetItemText(t_selectSex.SelectedItem).Substring(0,1); 
                t_sexValue = gender;
            }
            //
            ///

            // If there is an error, input format is invalid, it will return false, data won't be inserted in Database, user can repeat the process
            if (errors.Count != 0)
            {
                foreach (string error in errors)
                {
                    MessageBox.Show(error);
                }
                errors.Clear();
                return false;
            }
            //

            // Format is corect, data is inserted in database
            else
                return true;
            //
        }
        //

    }
}

