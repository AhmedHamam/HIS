using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace HIS
{
    public partial class showtotalsalary : Form
    {
        Connection con = new Connection();
        public showtotalsalary()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            con.OpenConection();
     
        }

        TextBox value1 = new TextBox();
        DateTimePicker date6 = new DateTimePicker();


    
        public string s;
      
        private void button1_Click(object sender, EventArgs e)
        {
            

            Label type = new Label();
            type.Location = new Point(265, 85);
            type.Size = new Size(100, 20);
            type.Name = "type";
            type.Text = "الاساسي";
            groupBox1.Controls.Add(type);



            value1.Location = new Point(140, 85);
            value1.Size = new Size(100, 20);
            value1.Name = "value1";
            value1.ReadOnly = true;
            groupBox1.Controls.Add(value1);


            con.OpenConection();
            
try
            {
                value1.Text = "";
                SqlCommand cmd = new SqlCommand();
                con.OpenConection();
                cmd.CommandText = ("SELECT top 1 base_salary FROM salary ,employee where name = '" + textBox1.Text + "' and salary.emp_id = employee.emp_id order by _date asc");
                cmd.Connection = con.con;
                value1.Text = cmd.ExecuteScalar().ToString(); ;
                MessageBox.Show("تم البحث بنجاح");
            }

            catch (Exception)
{
             
                MessageBox.Show(" خطأ في اللادخال ");
                value1.Text = "";
            }
            con.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Label type = new Label();
            type.Location = new Point(278, 120);
            type.Size = new Size(90, 20);
            type.Name = "type";
            type.Text = "الاجمالي";
            groupBox2.Controls.Add(type);

            TextBox value2 = new TextBox();
            value2.Location = new Point(145, 120);
            value2.Size = new Size(100, 20);
            value2.Name = "value1";
            value2.ReadOnly = true;
            groupBox2.Controls.Add(value2);

            con.OpenConection();

            try
            {
            SqlCommand cmd = new SqlCommand();
            con.OpenConection();
            cmd.CommandText = ("SELECT top 1 salary.total_salary FROM salary ,employee where name = '" + textBox2.Text + "' and salary.emp_id = employee.emp_id order by _date asc");
            cmd.Connection = con.con;
            value2.Text = cmd.ExecuteScalar().ToString(); ;
            }
            catch (Exception)
            {
                MessageBox.Show(" خطأ في اللادخال ");
            }
            con.CloseConnection();

        }

       
           
        
        

        private void search_Click(object sender, EventArgs e)
        {

        
                con.OpenConection();

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    con.OpenConection();
                    cmd.CommandText = ("SELECT salary._date as date, salary.total_salary,salary.base_salary,ss.deduction,ss.incentive FROM salary , employee ,incentives,deductions cross join ( select Sum(deductions._value) as deduction ,Sum(incentives._value) as incentive from employee,deductions,incentives,salary where salary.emp_id = employee.emp_id and name = '"+name1.Text+"' and employee.emp_id=incentives.emp_id and  employee.emp_id=deductions.emp_id and Month(salary._date)=Month(incentives._date) and Month(salary._date)=Month(deductions._date)  ) as ss where salary.emp_id = employee.emp_id and name = '"+name1.Text+"' and employee.emp_id=incentives.emp_id and  employee.emp_id=deductions.emp_id and Month(salary._date)=Month(incentives._date) and Month(salary._date)=Month(deductions._date)");
                    cmd.Connection = con.con;
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                    
                }
                catch (Exception )
                {
                    MessageBox.Show("خطاء في ادخال الاسم");
                }
                con.CloseConnection();

           

            }

        
        }

     

       

    }

