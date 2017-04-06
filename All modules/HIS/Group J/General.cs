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
    public partial class General : Form
    {

        public General()
        {
            InitializeComponent();
        }

        private void برامجToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {


        }

        private void برامجToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Red;
        }

        private void برامجToolStripMenuItem_MouseHover_1(object sender, EventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Red;
        }

        private void تسويهبنكيهلشيكامحصلهToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }
        استقبال_فحوصات_القلب استفبال;

        private void استقبالفحوصاتالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (استفبال == null)
            {
                استفبال = new استقبال_فحوصات_القلب();
                استفبال.MdiParent = this;
                استفبال.FormClosed += new FormClosedEventHandler(استفبال_FormClosed);
                استفبال.Show();
            }
            else
            {

                استفبال.Activate();
            }
        }

        void استفبال_FormClosed(object sender, FormClosedEventArgs e)
        {
            // throw new NotImplementedException();
            استفبال = null;
        }
        استقبال_طلبات_عمليات_قسطرة_القلب frm;
        private void استقبالطلباتعملياتقسطرةالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frm == null)
            {
                frm = new استقبال_طلبات_عمليات_قسطرة_القلب();
                frm.MdiParent = this;
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();
            }
            else
            {

                frm.Activate();
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //	throw new NotImplementedException();
            frm = null;


        }
        طلب_فحوصات_القلب طلب;

        private void طلبفحوصاتالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (طلب == null)
            {
                طلب = new طلب_فحوصات_القلب();
                طلب.MdiParent = this;
                طلب.FormClosed += new FormClosedEventHandler(طلب_FormClosed);
                طلب.Show();
            }
            else
            {

                طلب.Activate();
            }
        }

        void طلب_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            طلب = null;
        }
        مواعيد_فحوصات_القلب مواعيد;
        private void جدولمواعيدفحوصاتالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (مواعيد == null)
            {
                مواعيد = new مواعيد_فحوصات_القلب();
                مواعيد.MdiParent = this;
                مواعيد.FormClosed += new FormClosedEventHandler(مواعيد_FormClosed);
                مواعيد.Show();
            }
            else
            {

                مواعيد.Activate();
            }
        }

        void مواعيد_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            مواعيد = null;
        }
        اجهزة_فحوصات_القلب اجهزة;
        private void اجهزةفحوصاتالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (اجهزة == null)
            {
                اجهزة = new اجهزة_فحوصات_القلب();
                اجهزة.MdiParent = this;
                اجهزة.FormClosed += new FormClosedEventHandler(اجهزة_FormClosed);
                اجهزة.Show();
            }
            else
            {

                اجهزة.Activate();
            }
        }

        void اجهزة_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            اجهزة = null;
        }
        مجموعة_افلام_القلب افلام;
        private void مجموعهافلامالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (افلام == null)
            {
                افلام = new مجموعة_افلام_القلب();
                افلام.MdiParent = this;
                افلام.FormClosed += new FormClosedEventHandler(افلام_FormClosed);
                افلام.Show();
            }
            else
            {

                افلام.Activate();
            }
        }

        void افلام_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            افلام = null;
        }
        اعداد_جدول_عمل_اجهزة_فحوصات_القلب اعداد;

        private void اعداداتجدولعملاجهزةفحوصاتالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (اعداد == null)
            {
                اعداد = new اعداد_جدول_عمل_اجهزة_فحوصات_القلب();
                اعداد.MdiParent = this;
                اعداد.FormClosed += new FormClosedEventHandler(اعداد_FormClosed);
                اعداد.Show();
            }
            else
            {

                اعداد.Activate();
            }
        }

        void اعداد_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            اعداد = null;
        }

        private void قسمالقلبToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void طلبصيانةغرفةToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void General_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// //////////////////////////////////المخازن////////////////////////////////
        /// </summary>
        add_bill addBill;

        private void رقمالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addBill == null)
            {
                addBill = new add_bill();
                addBill.MdiParent = this;
                addBill.FormClosed += new FormClosedEventHandler(addBill_FormClosed);
                addBill.Show();
            }
            else
            {

                addBill.Activate();
            }

        }

        void addBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            addBill = null;
            //throw new NotImplementedException();
        }
        add_inventory addInventory;
        private void المخازندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addInventory == null)
            {
                addInventory = new add_inventory();
                addInventory.MdiParent = this;
                addInventory.FormClosed += new FormClosedEventHandler(addInventory_FormClosed);
                addInventory.Show();
            }
            else
            {

                addInventory.Activate();
            }
        }

        void addInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            addInventory = null;
        }
        category category;
        private void الاضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (category == null)
            {
                category = new category();
                category.MdiParent = this;
                category.FormClosed += new FormClosedEventHandler(category_FormClosed);
                category.Show();
            }
            else
            {

                category.Activate();
            }
        }

        void category_FormClosed(object sender, FormClosedEventArgs e)
        {
            category = null;
            //throw new NotImplementedException();
        }

        private void إرتجاعحركةإستعاضةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        supplier supplier;
        private void الموردToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (supplier == null)
            {
                supplier = new supplier();
                supplier.MdiParent = this;
                supplier.FormClosed += new FormClosedEventHandler(supplier_FormClosed);
                supplier.Show();
            }
            else
            {

                category.Activate();
            }
        }

        void supplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            supplier = null;
        }
        category_to_employee category_to_employee;

        private void صرفاصنافلموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (category_to_employee == null)
            {
                category_to_employee = new category_to_employee();
                category_to_employee.MdiParent = this;
                category_to_employee.FormClosed += new FormClosedEventHandler(category_to_employee_FormClosed);
                category_to_employee.Show();
            }
            else
            {

                category.Activate();
            }
        }

        void category_to_employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            category_to_employee = null;
        }
        categoryToDepartment categoryToDepartment;

        private void صرفاصنافلقسمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoryToDepartment == null)
            {
                categoryToDepartment = new categoryToDepartment();
                categoryToDepartment.MdiParent = this;
                categoryToDepartment.FormClosed += new FormClosedEventHandler(categoryToDepartment_FormClosed);
                categoryToDepartment.Show();
            }
            else
            {

                categoryToDepartment.Activate();
            }

        }

        void categoryToDepartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            categoryToDepartment = null;
        }
        returnFromEmployee returnFromEmployee;
        private void ارتجاعاصنافمنموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (returnFromEmployee == null)
            {
                returnFromEmployee = new returnFromEmployee();
                returnFromEmployee.MdiParent = this;
                returnFromEmployee.FormClosed += new FormClosedEventHandler(returnFromEmployee_FormClosed);
                returnFromEmployee.Show();
            }
            else
            {

                returnFromEmployee.Activate();
            }
        }

        void returnFromEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            returnFromEmployee = null;
        }
        return_category_from_inventory return_category_from_inventory;
        private void ارتجاعرصيدمنمخزنفرعىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (return_category_from_inventory == null)
            {
                return_category_from_inventory = new return_category_from_inventory();
                return_category_from_inventory.MdiParent = this;
                return_category_from_inventory.FormClosed += new FormClosedEventHandler(return_category_from_inventory_FormClosed);
                return_category_from_inventory.Show();
            }
            else
            {

                return_category_from_inventory.Activate();
            }
        }

        void return_category_from_inventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            return_category_from_inventory = null;
        }
        WM_device dvc;
        private void أجهزةالمغسلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dvc == null)
            {
                dvc = new WM_device();
                dvc.MdiParent = this;
                dvc.FormClosed += new FormClosedEventHandler(dvc_FormClosed);
                dvc.Show();
            }
            else
            {

                dvc.Activate();
            }
        }

        void dvc_FormClosed(object sender, FormClosedEventArgs e)
        {
            dvc = null;
            //throw new NotImplementedException();
        }
        wm_operating_order order;

        private void اصدارأمرشغلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (order == null)
            {
                order = new wm_operating_order();
                order.MdiParent = this;
                order.FormClosed += new FormClosedEventHandler(order_FormClosed);
                order.Show();
            }
            else
            {

                order.Activate();
            }
        }

        void order_FormClosed(object sender, FormClosedEventArgs e)
        {
            order = null;
            //throw new NotImplementedException();
        }
        covers_clothes cls;
        private void اغطيةوملابسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cls == null)
            {
                cls = new covers_clothes();
                cls.MdiParent = this;
                cls.FormClosed += new FormClosedEventHandler(cls_FormClosed);
                cls.Show();
            }
            else
            {

                cls.Activate();
            }
        }

        void cls_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            cls = null;
        }

        inventory_movement inventory_movement;
        private void الحركاتالمخزنيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inventory_movement == null)
            {
                inventory_movement = new inventory_movement();
                inventory_movement.MdiParent = this;
                inventory_movement.FormClosed += new FormClosedEventHandler(inventory_movement_FormClosed);
                inventory_movement.Show();
            }
            else
            {

                inventory_movement.Activate();
            }
        }

        void inventory_movement_FormClosed(object sender, FormClosedEventArgs e)
        {
            inventory_movement = null;
            //throw new NotImplementedException();
        }

        private void برامجToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        takhen takhen;
        private void التكهينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (takhen == null)
            {
                takhen = new takhen();
                takhen.MdiParent = this;
                takhen.FormClosed += new FormClosedEventHandler(takhen_FormClosed);
                takhen.Show();
            }
            else
            {

                takhen.Activate();
            }
        }

        void takhen_FormClosed(object sender, FormClosedEventArgs e)
        {
            takhen = null;
            //throw new NotImplementedException();
        }
        detergentForm det;
        private void المساحيقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (det == null)
            {
                det = new detergentForm();
                det.MdiParent = this;
                det.FormClosed += new FormClosedEventHandler(det_FormClosed);
                det.Show();
            }
            else
            {

                det.Activate();
            }
        }

        void det_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            det = null;
        }
        WM_Worker wm;
        private void عمالالمغسلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wm == null)
            {
                wm = new WM_Worker();
                wm.MdiParent = this;
                wm.FormClosed += new FormClosedEventHandler(wm_FormClosed);
                wm.Show();
            }
            else
            {

                wm.Activate();
            }
        }

        void wm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            wm = null;
        }
        coverPreperations cpp;
        private void تعقيمالاغطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cpp == null)
            {
                cpp = new coverPreperations();
                cpp.MdiParent = this;
                cpp.FormClosed += new FormClosedEventHandler(cpp_FormClosed);
                cpp.Show();
            }
            else
            {

                cpp.Activate();
            }
        }

        void cpp_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            cpp = null;
        }

        private void تقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void أرصدهالمخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void بياناتالاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      
        private void أسماءالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       
        private void تقريربأسماءالغسالاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        
        private void الجردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_stocking a = new add_stocking();
            a.Show();
        }
    }
}