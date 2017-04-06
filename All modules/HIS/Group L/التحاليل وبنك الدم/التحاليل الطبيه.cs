using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; using System.Configuration;

namespace HIS
{
    public partial class التحاليل_الطبية : Form
    {
       
        public التحاليل_الطبية()
        {
            InitializeComponent();
        }

        private void المريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            طلب_تحليل_لمريض form = new طلب_تحليل_لمريض();
            form.Show();
        }

        private void جمعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_sample_print form = new txt_sample_print();
            form.Show();
        }

        private void استلامالعيناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            استلام_العينات form = new استلام_العينات();
            form.Show();
        }

        private void كتابةالنتايجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            كتابة_النتايج form = new كتابة_النتايج();
            form.Show();
        }

        private void تاكيدالنتايجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تاكيد_النتايج form = new تاكيد_النتايج();
            form.Show();
        }

        private void تسليمالنتايجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تسليم_النتايج form = new تسليم_النتايج();
            form.Show();
        }

        private void البحثعنمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            البحث_عن_مريض form = new البحث_عن_مريض();
            form.Show();
        }

        private void البحثعنتحليلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            البحث_عن_تحليل form = new البحث_عن_تحليل();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            البحث_عن_تحليل form = new البحث_عن_تحليل();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            البحث_عن_مريض form = new البحث_عن_مريض();
            form.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            طلب_تحليل_لمريض form = new طلب_تحليل_لمريض();
            form.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txt_sample_print form = new txt_sample_print();
            form.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            استلام_العينات form = new استلام_العينات();
            form.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            كتابة_النتايج form = new كتابة_النتايج();
            form.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تاكيد_النتايج form = new تاكيد_النتايج();
            form.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تسليم_النتايج form = new تسليم_النتايج();
            form.Show();
        }

        private void اضافهاوتعديلفيتحليلToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void التحاليل_الطبية_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            البحث_عن_مريض nw = new البحث_عن_مريض();
            nw.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تقرير_بأختبارات__المعمل nw = new تقرير_بأختبارات__المعمل();
            nw.Show();
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            البحث_عن_تحليل nw = new البحث_عن_تحليل();
            nw.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            تقرير_بنتائج__المعمل nw = new تقرير_بنتائج__المعمل();
            nw.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            البحث_عن_نتيجه_لمريض nw = new البحث_عن_نتيجه_لمريض();
            nw.Show();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافه_تحليل_فرعى nw = new اضافه_تحليل_فرعى();
            nw.Show();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اعدادات_وسائل_استلام_نتيجه_المعمل nw = new اعدادات_وسائل_استلام_نتيجه_المعمل();
            nw.Show();
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            قائمه_الوحدات_المستخدمه_بالمعمل nw = new قائمه_الوحدات_المستخدمه_بالمعمل();
            nw.Show();
        }

        private void تقريرباختبارتالمعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقرير_بأختبارات__المعمل nw = new تقرير_بأختبارات__المعمل();
            nw.Show();
        }

        private void البحثعنتحليلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            البحث_عن_تحليل nw = new البحث_عن_تحليل();
            nw.Show();
        }

        private void تقريربنتائجالمعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            تقرير_بنتائج__المعمل nw = new تقرير_بنتائج__المعمل();
            nw.Show();
        }

        private void البحثعننتيجةلمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            البحث_عن_نتيجه_لمريض nw = new البحث_عن_نتيجه_لمريض();
            nw.Show();
        }

        private void اضافهاوتعديلفيتحليلToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            اضافه_تحليل_فرعى nw = new اضافه_تحليل_فرعى();
            nw.Show();
        }

        private void اعداداتوسائلاستلامنتيجةالمعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اعدادات_وسائل_استلام_نتيجه_المعمل nw = new اعدادات_وسائل_استلام_نتيجه_المعمل();
            nw.Show();
        }

        private void قائمةالوحداتالمستخدمةبالمعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            قائمه_الوحدات_المستخدمه_بالمعمل nw = new قائمه_الوحدات_المستخدمه_بالمعمل();
            nw.Show();
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافة_تحليل_رئيسى nw = new اضافة_تحليل_رئيسى();
            nw.Show();
        }

        
       
    }
}
