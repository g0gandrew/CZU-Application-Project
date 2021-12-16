using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CZU_APPLICATION
{
    internal class Security
    {
        public static void gender(CheckBox t_maleCheck, CheckBox t_femaleCheck, CheckBox t_unspecifiedCheck, ref string t_sexValue)
        {
            if (t_maleCheck.Checked)
                t_sexValue = "M";
            if (t_femaleCheck.Checked)
                t_sexValue = "F";
            else
                t_sexValue = "C";
            while (t_maleCheck.Checked && t_femaleCheck.Checked || t_maleCheck.Checked && t_unspecifiedCheck.Checked || t_femaleCheck.Checked && t_unspecifiedCheck.Checked)
            {
                t_maleCheck.Checked = false;
                t_femaleCheck.Checked = false;
                t_unspecifiedCheck.Checked = false;
                MessageBox.Show("Select just one gender");
            }
        }
    }
}

