using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS
{
    public partial class  printing_devices : Form
    {
       
        public printing_devices( )
        {
            

            InitializeComponent();
        }

        private void printing_devices_Load(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        { 
            //parent.Show();
            this.Close();

        }
    }
}
