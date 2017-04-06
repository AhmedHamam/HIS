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
    public partial class GroupA_Patient_Bill_MainForm : Form
    {
        Connection conn;
        UserControl us;
        int USER_ID = 1;

        public GroupA_Patient_Bill_MainForm()
        {
            InitializeComponent();
            conn = new Connection();
        }
        public GroupA_Patient_Bill_MainForm(int user_code)
        {
            InitializeComponent();
            conn=new Connection();
            USER_ID = user_code;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                panel1.VerticalScroll.Value = 0;
                panel1.HorizontalScroll.Value = 0;
                int x = panel1.Width / 2 - us.Size.Width / 2;
                int y = panel1.Height / 2 - us.Size.Height / 2;
                if (x <= 0) { x = 0; }
                if (y <= 0) { y = 0; }
                us.Location = new Point(x, y);
            }
            catch
            { }
        }

       private void billextractionToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new UserControl_bill_extraction(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "استخراج فاتورة مريض";
       }

       private void paycashToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Pay_Cash(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "سداد نقدية";
       }

       private void visitResidenceTempToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Pay_Cash_Back(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "رد نقدية";
       }

       private void toolStripMenuItem2_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_bill_Show_AND_Print();
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "فواتير المرضى";
       }

       private void تعديلالخدماتToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Visit_Service_Temp_Before(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "تعديل الخدمات لمريض قبل استخراج الفاتورة ";
       }

       private void تعديلالاقامةToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Visit_Residence_Temp_Before(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "تعديل الاقامة لمريض قبل استخراج الفاتورة";
       }

       private void تعديلالادويةToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Visit_Medicine_Temp_Before(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "تعديل الادوية لمريض قبل استخراج الفاتورة";
       }

        /// <summary>
        /// ////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void تعديلالخدماتToolStripMenuItem1_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Visit_Service_Temp_After(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "تعديل الخدمات لمريض بعد استخراج الفاتورة ";
       }

       private void تعديلالاقامةToolStripMenuItem1_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Visit_Residence_Temp_After(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "تعديل الاقامة لمريض بعد استخراج الفاتورة";
       }

       private void تعديلالادويةToolStripMenuItem1_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_Visit_Medicine_Temp_After(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "تعديل الادوية لمريض بعد استخراج الفاتورة";
       }

       private void عملخصمعلىفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_bill_discount(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "عمل خصم على فاتورة";
       }

       private void تفاصيلفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_bill_Show_AND_Print();
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "تفاصيل فاتورة";
       }

       private void الغاءفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
       {
           panel1.Controls.Clear();
           us = new GroupA_PatientBill_bill_delete(USER_ID);
           Form1_Resize(null, null);
           panel1.Controls.Add(us);
           this.Text = "الغاء فاتورة";
       }

    }
}
