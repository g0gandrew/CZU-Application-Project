using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CZU_APPLICATION
{
    public partial class CZUUserDetails : Form
    {

        private string _studentID { get; set; }
        private string _teacherID { get; set; }
        private List<Label> _labels = new List<Label>();

        public CZUUserDetails(string t_studentID, string t_teacherID)
        {
            // Inserting student ID
            _studentID = t_studentID;
            //

            // Inserting teacher ID
            _teacherID = t_teacherID;
            //

            InitializeComponent();
        }

        private void initializePanel()
        {
            // Creating a list of contros for further operations
            _labels.Add(studentID);
            _labels.Add(firstName);
            _labels.Add(lastName);
            _labels.Add(sex);
            _labels.Add(birthday);
            _labels.Add(finalGrade);
            //
        }
        private void getAndSetData(string t_studentID, ref List <Label> t_labels, string t_teacherID)
        {
            // Variables
            string path = "SERVER=localhost; PORT=3306;DATABASE=czuapp;UID=root;PASSWORD=Andrei123!?";
            string query = $"select id, firstName, lastName, sex, birthDate from student where id = {t_studentID};";
            //

            // Setting up MYSQL CONNECTION
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = path;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            MySqlDataReader dataReader;
            connection.Open();
            //

            cmd.CommandText = query;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                for(int i = 0; i < (t_labels.Count - 1); ++i)
                   t_labels[i].Text = dataReader.GetString(i); 
            }
            dataReader.Close();

            // Getting the grades of student and displaying the final grade
            cmd.CommandText = $"select grade from grade where studentID = {t_studentID} && courseID = (select id from course where teacherID = {t_teacherID})";
            dataReader = cmd.ExecuteReader();
            int count = 0, grade = 0;
            while (dataReader.Read())
            {
                ++count;
                grade += Convert.ToInt32(dataReader.GetString(0));
            }
            dataReader.Close();
            //

            // Adding left available data into labels.
            if (count != 0)
            {
                int finalGrade = grade / count;
                // If the grade is greater then 4, set its color green
                if(finalGrade > 4)
                    t_labels[(t_labels.Count - 1)].ForeColor = Color.Green;
                else
                    t_labels[(t_labels.Count - 1)].ForeColor = Color.Red;
                t_labels[(t_labels.Count - 1)].Text = Convert.ToString(finalGrade);
            }
            //

            // Solving the datetime bug from mysql
            t_labels[4].Text = t_labels[4].Text.Substring(0, (t_labels[4].Text.LastIndexOf('/')) + 5);
            //

            // Closing connection
            connection.Close();
            //
        
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Exit button
            this.Close();
            //
        }
        private void CZUUserDetails_Load(object sender, EventArgs e)
        {
            // Creating the list of GUI elements
            initializePanel();
            //
         
            // Gets data of student, and fills controls with it
            getAndSetData(_studentID, ref _labels, _teacherID);
            //
        }
    }
}
