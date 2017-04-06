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
    public partial class buy : Form
    {
        
        string c,d;
        public buy()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            طلبشراء f5 = new طلبشراء();
            f5.Show();
        }

       


     

     

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            تعديلبياناتمورد f11 = new تعديلبياناتمورد();
            f11.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            مسحبياناتمورد f12 = new مسحبياناتمورد();
            f12.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            اضافةعروضاسعار f13 = new اضافةعروضاسعار();
            f13.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            تعديلعروضاسعار f14 = new تعديلعروضاسعار(c);
            f14.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            مسحعروضاسعار f15 = new مسحعروضاسعار();
            f15.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            استخراجمزكرةشراء f16 = new استخراجمزكرةشراء();
            f16.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافةامرتوريداصناف f25 = new اضافةامرتوريداصناف();
            f25.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافةامرتوريدادوية f26 = new اضافةامرتوريدادوية();
            f26.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            اضافةامرتوريداصول f18 = new اضافةامرتوريداصول();
            f18.Show();
        
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافةامرتوريدخدمات f28 = new اضافةامرتوريدخدمات();
            f28.Show();
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            الغاءامرتوريد f19 = new الغاءامرتوريد();
            f19.Show();
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تعديلامرتوريد f20 = new تعديلامرتوريد();
            f20.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            عروضالاثمان f7 = new عروضالاثمان();
            f7.Show();
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            حصراوامرالتوريد f29 = new حصراوامرالتوريد();
            f29.Show();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();

        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel12_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
