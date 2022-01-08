using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CZU_APPLICATION
{
    internal static class Authentication
    {

        private static string _path { get; } = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";

        // Registration
        public static bool registration(string t_username, string t_firstName, string t_lastName, string t_password, string t_authKey, string t_email, string t_phoneNumber, string t_sex, string t_birthDate, string t_regKey)
        {
            // Pseudo assign
            string nonquery = null;
            string registrationType = null;
            //

            registrationType = Database.registrationToken(t_regKey); // Getting token type (teacher or student), if it is valid.
            switch (registrationType)
            {
                case "teacher":
                {
                    // OPENING MYSQL CONNECTION
                    MySqlConnection connection = new MySqlConnection();
                    connection.ConnectionString = _path;
                    connection.Open();
                    //
                    nonquery = $"insert into teacher(username, firstName, phoneNumber, lastName, password, authKey, email, sex, birthDate) values('{t_username}', '{t_firstName}', {t_phoneNumber}, '{t_lastName}', '{t_password}', '{t_authKey}', '{t_email}', '{t_sex}', '{t_birthDate}')";
                    MySqlCommand cmd = new MySqlCommand(nonquery, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }

                case "student":
                {
                    // Variables
                    string studyingYear = null, classID = null;
                    //

                    // Getting data for updating student studying year and classID related to registration token 

                    // Opening MYSQL connection
                    MySqlConnection connection = new MySqlConnection();
                    connection.ConnectionString = _path;
                    MySqlCommand cmd = new MySqlCommand($"select classID from StudentRegKey where regKey = '{t_regKey}'", connection);
                    MySqlDataReader dataReader;
                    connection.Open();
                    //

                    // Getting classID
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        classID = dataReader.GetString(0);
                    }
                    dataReader.Close();
                    //

                    // Getting studying year
                    cmd.CommandText = $"select year from class where ID = '{classID}'";
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        studyingYear = dataReader.GetString(0);
                    }
                    dataReader.Close();
                    //

                    // Inserting the data into database
                    nonquery = $"insert into student(username, firstName, lastName, studyingYear, classID, password, authKey, email, phoneNumber, sex, birthDate) values('{t_username}', '{t_firstName}', '{t_lastName}', {studyingYear}, {classID}, '{t_password}', '{t_authKey}', '{t_email}', {t_phoneNumber}, '{t_sex}', '{t_birthDate}')";
                    cmd.CommandText = nonquery;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    //
                    return true;
                }
                default:
                {
                    MessageBox.Show("Registration Token is invalid");
                    return false;
                }
            }

        }
        //

        // Login
        public static void login(TextBox t_inUsername, TextBox t_inPassword, TextBox t_inAuthKey, ref int t_count, CZULogin Login)
        {
            // Opening SQL connection
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _path;
            MySqlCommand query = new MySqlCommand($"select id, username, password, authKey from student", connection);
            MySqlDataReader dataReader;
            connection.Open();
            dataReader = query.ExecuteReader();
            //

            // Variables
            bool loggedIn = false;
            //

            // Student Table Data Verifying
            while (dataReader.Read())
            {
                if (t_inUsername.Text == (string)dataReader.GetValue(1) && t_inPassword.Text == (string)dataReader.GetValue(2) && t_inAuthKey.Text == (string)dataReader.GetValue(3))
                {
                    CZUMain main = new CZUMain(); // Creating a new object (form) of the CZU Main class.
                    main.connectedUser = $"{dataReader.GetValue(1)}"; // Updating the 'Main' form control which displays the username of connected user
                    main.connectedUserType = "student";
                    string command = $"update student set connected = 'on' where id = {dataReader.GetValue(0)}";
                    dataReader.Close();
                    MySqlCommand nonquery = new MySqlCommand(command, connection);
                    nonquery.ExecuteNonQuery();
                    loggedIn = true;
                    MessageBox.Show("Succesfully logged in");
                    Login.Hide();
                    main.Show();
                    connection.Close();
                    // Closing SQL connection
                    break;
                }
            }
            // 
            if (!loggedIn)
            {
                // Teacher Table Data Verifying
                dataReader.Close();
                query.CommandText = $"select id, username, password, authKey from teacher";
                dataReader = query.ExecuteReader();
                while (dataReader.Read())
                {
                    if (t_inUsername.Text == (string)dataReader.GetValue(1) && t_inPassword.Text == (string)dataReader.GetValue(2) && t_inAuthKey.Text == (string)dataReader.GetValue(3))
                    {
                        CZUMain main = new CZUMain(); // Creating a new object (form) of the CZU Main class.
                        main.connectedUser = $"{dataReader.GetValue(1)}"; // Updating the 'Main' form control which displays the username of connected user
                        main.connectedUserType = "teacher";
                        string command = $"update teacher set connected = 'on' where id = {dataReader.GetValue(0)}";
                        dataReader.Close();
                        MySqlCommand nonquery = new MySqlCommand(command, connection);
                        nonquery.ExecuteNonQuery();
                        loggedIn = true;
                        MessageBox.Show("Succesfully logged in");
                        Login.Hide();
                        main.Show();
                        connection.Close();
                        // Closing SQL connection
                        break;
                    }
                }
            }
            //

            // Too Many Attempts Security Feature (It verifies and close the application for user that have inserted false login details more than 3 times)
            if (!loggedIn)
            {
                t_count++;
                if (t_count != 3)
                {
                    MessageBox.Show($"Incorrect credentials");
                    t_inUsername.Clear();
                    t_inPassword.Clear();
                    t_inAuthKey.Clear();
                }
                else
                {
                    MessageBox.Show("You failed attempting to enter your connection informations too many times");
                    Login.Close();
                }
            }
            else
            {
                connection.Close();
            }
            //
        }
        // 




    }
}
