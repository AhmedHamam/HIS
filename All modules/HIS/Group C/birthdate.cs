using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class birthdate : Form
    {
        تسجيل_بيانات__مريض y;
        public birthdate()
        {
            InitializeComponent();
        }


        public birthdate(تسجيل_بيانات__مريض x)
        {
            InitializeComponent();
            y = x;
        }
        private void birthdate_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int years = DateTime.Now.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.AddYears(years) > DateTime.Now)
                years--;
            textBox1.Text =years.ToString();
        }



        private void dateTimePicker1_CloseUp_1(object sender, EventArgs e)
        {
           
                if (Convert.ToInt32(textBox1.Text) < 0)
                {
                    MessageBox.Show("Invalid Date");
                    return;
                }
                y.setvalue(dateTimePicker1.Text, textBox1.Text);
            
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
