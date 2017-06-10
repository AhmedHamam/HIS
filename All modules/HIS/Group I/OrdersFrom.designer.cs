namespace HIS
{
    partial class OrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_visited = new System.Windows.Forms.Label();
            this.lbl_cancelled_orders = new System.Windows.Forms.Label();
            this.lbl_orders_added = new System.Windows.Forms.Label();
            this.lbl_Executed = new System.Windows.Forms.Label();
            this.lbl_notExecuted = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.linkLblShortcutOrders = new System.Windows.Forms.LinkLabel();
            this.linkLblPendingOrders = new System.Windows.Forms.LinkLabel();
            this.linkLblpermissionExch = new System.Windows.Forms.LinkLabel();
            this.linkLblBloodReq = new System.Windows.Forms.LinkLabel();
            this.linkLblMealRequest = new System.Windows.Forms.LinkLabel();
            this.linkLblRayRequest = new System.Windows.Forms.LinkLabel();
            this.linlblLabRequest = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_visited);
            this.tabPage2.Controls.Add(this.lbl_cancelled_orders);
            this.tabPage2.Controls.Add(this.lbl_orders_added);
            this.tabPage2.Controls.Add(this.lbl_Executed);
            this.tabPage2.Controls.Add(this.lbl_notExecuted);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1093, 522);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تقارير";
            // 
            // lbl_visited
            // 
            this.lbl_visited.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_visited.AutoSize = true;
            this.lbl_visited.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_visited.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_visited.Location = new System.Drawing.Point(706, 247);
            this.lbl_visited.Name = "lbl_visited";
            this.lbl_visited.Size = new System.Drawing.Size(267, 19);
            this.lbl_visited.TabIndex = 0;
            this.lbl_visited.Text = "تقرير الحالات والخدمات لمريض الزيارات ";
            this.lbl_visited.Click += new System.EventHandler(this.label10_Click);
            // 
            // lbl_cancelled_orders
            // 
            this.lbl_cancelled_orders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cancelled_orders.AutoSize = true;
            this.lbl_cancelled_orders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_cancelled_orders.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_cancelled_orders.Location = new System.Drawing.Point(784, 197);
            this.lbl_cancelled_orders.Name = "lbl_cancelled_orders";
            this.lbl_cancelled_orders.Size = new System.Drawing.Size(189, 19);
            this.lbl_cancelled_orders.TabIndex = 0;
            this.lbl_cancelled_orders.Text = "تقرير أوامر المرضي الملغاة ";
            this.lbl_cancelled_orders.Click += new System.EventHandler(this.label9_Click);
            // 
            // lbl_orders_added
            // 
            this.lbl_orders_added.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_orders_added.AutoSize = true;
            this.lbl_orders_added.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_orders_added.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_orders_added.Location = new System.Drawing.Point(768, 147);
            this.lbl_orders_added.Name = "lbl_orders_added";
            this.lbl_orders_added.Size = new System.Drawing.Size(205, 19);
            this.lbl_orders_added.TabIndex = 0;
            this.lbl_orders_added.Text = "الأوامر المضافة لحساب مريض";
            this.lbl_orders_added.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbl_Executed
            // 
            this.lbl_Executed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Executed.AutoSize = true;
            this.lbl_Executed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Executed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_Executed.Location = new System.Drawing.Point(765, 87);
            this.lbl_Executed.Name = "lbl_Executed";
            this.lbl_Executed.Size = new System.Drawing.Size(208, 19);
            this.lbl_Executed.TabIndex = 0;
            this.lbl_Executed.Text = "أوامر المريض التي تم تنفيذها ";
            this.lbl_Executed.Click += new System.EventHandler(this.label7_Click);
            // 
            // lbl_notExecuted
            // 
            this.lbl_notExecuted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_notExecuted.AutoSize = true;
            this.lbl_notExecuted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_notExecuted.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_notExecuted.Location = new System.Drawing.Point(791, 30);
            this.lbl_notExecuted.Name = "lbl_notExecuted";
            this.lbl_notExecuted.Size = new System.Drawing.Size(182, 19);
            this.lbl_notExecuted.TabIndex = 0;
            this.lbl_notExecuted.Text = "أوامر المريض التي لم تنفذ";
            this.lbl_notExecuted.Click += new System.EventHandler(this.label6_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.linkLblShortcutOrders);
            this.tabPage1.Controls.Add(this.linkLblPendingOrders);
            this.tabPage1.Controls.Add(this.linkLblpermissionExch);
            this.tabPage1.Controls.Add(this.linkLblBloodReq);
            this.tabPage1.Controls.Add(this.linkLblMealRequest);
            this.tabPage1.Controls.Add(this.linkLblRayRequest);
            this.tabPage1.Controls.Add(this.linlblLabRequest);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1093, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "برامج";
            // 
            // linkLblShortcutOrders
            // 
            this.linkLblShortcutOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLblShortcutOrders.AutoSize = true;
            this.linkLblShortcutOrders.Font = new System.Drawing.Font("Tahoma", 14F);
            this.linkLblShortcutOrders.Location = new System.Drawing.Point(877, 344);
            this.linkLblShortcutOrders.Name = "linkLblShortcutOrders";
            this.linkLblShortcutOrders.Size = new System.Drawing.Size(192, 23);
            this.linkLblShortcutOrders.TabIndex = 13;
            this.linkLblShortcutOrders.TabStop = true;
            this.linkLblShortcutOrders.Text = "قائمة الأوامر المختصرة ";
            this.linkLblShortcutOrders.Visible = false;
            this.linkLblShortcutOrders.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblShortcutOrders_LinkClicked);
            // 
            // linkLblPendingOrders
            // 
            this.linkLblPendingOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLblPendingOrders.AutoSize = true;
            this.linkLblPendingOrders.Font = new System.Drawing.Font("Tahoma", 14F);
            this.linkLblPendingOrders.Location = new System.Drawing.Point(877, 286);
            this.linkLblPendingOrders.Name = "linkLblPendingOrders";
            this.linkLblPendingOrders.Size = new System.Drawing.Size(187, 23);
            this.linkLblPendingOrders.TabIndex = 12;
            this.linkLblPendingOrders.TabStop = true;
            this.linkLblPendingOrders.Text = "الأوامر المعلقة لمريض ";
            this.linkLblPendingOrders.Visible = false;
            this.linkLblPendingOrders.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblPendingOrders_LinkClicked);
            // 
            // linkLblpermissionExch
            // 
            this.linkLblpermissionExch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLblpermissionExch.AutoSize = true;
            this.linkLblpermissionExch.Font = new System.Drawing.Font("Tahoma", 14F);
            this.linkLblpermissionExch.Location = new System.Drawing.Point(877, 228);
            this.linkLblpermissionExch.Name = "linkLblpermissionExch";
            this.linkLblpermissionExch.Size = new System.Drawing.Size(182, 23);
            this.linkLblpermissionExch.TabIndex = 10;
            this.linkLblpermissionExch.TabStop = true;
            this.linkLblpermissionExch.Text = "بحث إذن صرف لمريض";
            this.linkLblpermissionExch.Visible = false;
            this.linkLblpermissionExch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblpermissionExch_LinkClicked);
            // 
            // linkLblBloodReq
            // 
            this.linkLblBloodReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLblBloodReq.AutoSize = true;
            this.linkLblBloodReq.Font = new System.Drawing.Font("Tahoma", 14F);
            this.linkLblBloodReq.Location = new System.Drawing.Point(943, 182);
            this.linkLblBloodReq.Name = "linkLblBloodReq";
            this.linkLblBloodReq.Size = new System.Drawing.Size(115, 23);
            this.linkLblBloodReq.TabIndex = 9;
            this.linkLblBloodReq.TabStop = true;
            this.linkLblBloodReq.Text = "طلب نقل دم ";
            this.linkLblBloodReq.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblBloodReq_LinkClicked);
            // 
            // linkLblMealRequest
            // 
            this.linkLblMealRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLblMealRequest.AutoSize = true;
            this.linkLblMealRequest.Font = new System.Drawing.Font("Tahoma", 14F);
            this.linkLblMealRequest.Location = new System.Drawing.Point(966, 131);
            this.linkLblMealRequest.Name = "linkLblMealRequest";
            this.linkLblMealRequest.Size = new System.Drawing.Size(93, 23);
            this.linkLblMealRequest.TabIndex = 8;
            this.linkLblMealRequest.TabStop = true;
            this.linkLblMealRequest.Text = "طلب وجبة";
            this.linkLblMealRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblMealRequest_LinkClicked);
            // 
            // linkLblRayRequest
            // 
            this.linkLblRayRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLblRayRequest.AutoSize = true;
            this.linkLblRayRequest.Font = new System.Drawing.Font("Tahoma", 14F);
            this.linkLblRayRequest.Location = new System.Drawing.Point(910, 84);
            this.linkLblRayRequest.Name = "linkLblRayRequest";
            this.linkLblRayRequest.Size = new System.Drawing.Size(148, 23);
            this.linkLblRayRequest.TabIndex = 7;
            this.linkLblRayRequest.TabStop = true;
            this.linkLblRayRequest.Text = "طلب خدمة أشعة";
            this.linkLblRayRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblRayRequest_LinkClicked);
            // 
            // linlblLabRequest
            // 
            this.linlblLabRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linlblLabRequest.AutoSize = true;
            this.linlblLabRequest.Font = new System.Drawing.Font("Tahoma", 14F);
            this.linlblLabRequest.Location = new System.Drawing.Point(910, 31);
            this.linlblLabRequest.Name = "linlblLabRequest";
            this.linlblLabRequest.Size = new System.Drawing.Size(149, 23);
            this.linlblLabRequest.TabIndex = 6;
            this.linlblLabRequest.TabStop = true;
            this.linlblLabRequest.Text = "طلب خدمة معمل";
            this.linlblLabRequest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linlblLabRequest_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 548);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Deselected);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 572);
            this.Controls.Add(this.tabControl1);
            this.Name = "OrdersForm";
            this.Text = "الأوامر -الرئيسية";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbl_visited;
        private System.Windows.Forms.Label lbl_cancelled_orders;
        private System.Windows.Forms.Label lbl_orders_added;
        private System.Windows.Forms.Label lbl_Executed;
        private System.Windows.Forms.Label lbl_notExecuted;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.LinkLabel linkLblShortcutOrders;
        private System.Windows.Forms.LinkLabel linkLblPendingOrders;
        private System.Windows.Forms.LinkLabel linkLblpermissionExch;
        private System.Windows.Forms.LinkLabel linkLblBloodReq;
        private System.Windows.Forms.LinkLabel linkLblMealRequest;
        private System.Windows.Forms.LinkLabel linkLblRayRequest;
        private System.Windows.Forms.LinkLabel linlblLabRequest;
        private System.Windows.Forms.TabControl tabControl1;



    }
}

