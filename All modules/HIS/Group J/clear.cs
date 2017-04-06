using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    class clear
    {
       public static  void Clear(Form frm)
        {
            foreach (var item in (frm).Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }
    }
}
