using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;

namespace HIS
{
    class validation
    {
        public void stringvalidation(TextBox txt, String name)
        {
            var regexItem = new Regex("^[a-zA-Z]*$");
            if (!(regexItem.IsMatch(txt.Text)))
            {
                int VisibleTime = 1000;  //in milliseconds
                ToolTip tt = new ToolTip();

                tt.ForeColor = Color.Red;
                tt.Show(name + " must be letters", txt, 0, 0, VisibleTime);

            }
            
        }
        public void numbervalidation(TextBox txt, String name)
        {
            var regexItem = new Regex("^[0-9]*$");
            if (!(regexItem.IsMatch(txt.Text)))
            {
                int VisibleTime = 1000;  //in milliseconds
                ToolTip tt = new ToolTip();
                
                tt.BackColor = Color.Crimson;
                tt.ForeColor = Color.Red;
                tt.Show(name + " must be numbers", txt, 0, 0, VisibleTime);
              
                
            }
        }
    }
}
