using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS;

namespace HIS
{
    public partial class الصيدليه : Form
    {
        public الصيدليه()
        {
            InitializeComponent();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            استقبال_الصيدليه f2 = new استقبال_الصيدليه();
            f2.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تعديل_تاريخ_الصلاحيه_لصنف f2 = new تعديل_تاريخ_الصلاحيه_لصنف();
            f2.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main_Pharma_Details m = new Main_Pharma_Details();
            m.Show();
        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            asnaf a = new asnaf();
            a.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            medicineComany mc = new medicineComany();
            mc.Show();
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main_Pharma_Details m = new Main_Pharma_Details();
            m.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            expired_med_befor ex = new expired_med_befor();
            ex.Show();
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            effective_subject es = new effective_subject();
            es.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            medicine_order m = new medicine_order();
            m.Show();
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            retun_from_patient rfp = new retun_from_patient();
            rfp.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ph_credit pc = new ph_credit();
            pc.Show();
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ph_credit_prices ph = new ph_credit_prices();
            ph.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            توريد__ادويه_الي__الصيدليه f2 = new توريد__ادويه_الي__الصيدليه();
            f2.Show();
        }

        private void الصيدليه_Load(object sender, EventArgs e)
        {

        }
    }
}
