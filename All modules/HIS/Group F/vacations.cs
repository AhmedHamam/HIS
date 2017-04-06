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
    public partial class vacations : Form
    {
       

        public vacations()
        {
            InitializeComponent();
        }

       

        private void رصيدالاجازاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            رصيد_الاجازات رصيد_الاجازات = new رصيد_الاجازات();
            رصيد_الاجازات.MdiParent = this;
            رصيد_الاجازات.Show();
        }

        private void طلباجازةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            طلب_اجازة طلب_اجازة = new طلب_اجازة();
            طلب_اجازة.MdiParent = this;
            طلب_اجازة.Show();
        }

        private void انواعالاجازاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            انواع_الاجازات انواع_الاجازات = new انواع_الاجازات();
            انواع_الاجازات.MdiParent = this;
            انواع_الاجازات.Show();
        }

        private void الاجازاتالرسميهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            الاجازات_الرسمية الاجازات_الرسمية = new الاجازات_الرسمية();
            الاجازات_الرسمية.MdiParent = this;
            الاجازات_الرسمية.Show();
        }

        private void حصرالاجازاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حصر_الاجازات حصر_الاجازات = new حصر_الاجازات();
            حصر_الاجازات.MdiParent = this;
            حصر_الاجازات.Show();
        }

        private void حصررصيدالاجازهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            حصر_رصيد_الاجازات حصر_رصيد_الاجازات = new حصر_رصيد_الاجازات();
            حصر_رصيد_الاجازات.MdiParent = this;
            حصر_رصيد_الاجازات.Show();
        }

        private void المتابعةالشهريهللاجازاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            المتابعة_الشهرية_للاجازات المتابعة_الشهرية_للاجازات = new المتابعة_الشهرية_للاجازات();
            المتابعة_الشهرية_للاجازات.MdiParent = this;
            المتابعة_الشهرية_للاجازات.Show();
        }

        private void رصيدالاجازاتخلالفترخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            حصر_رصيد_الاجازات_خلال_فترة حصر_رصيد_الاجازات_خلال_فترة = new حصر_رصيد_الاجازات_خلال_فترة();
            حصر_رصيد_الاجازات_خلال_فترة.MdiParent = this;
            حصر_رصيد_الاجازات_خلال_فترة.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
