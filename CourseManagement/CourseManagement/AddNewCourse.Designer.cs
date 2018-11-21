namespace CourseManagement
{
    partial class AddNewCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewCourse));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CancelEditBtn = new System.Windows.Forms.Button();
            this.EditCourseBtn = new System.Windows.Forms.Button();
            this.SuccessLabel = new System.Windows.Forms.Label();
            this.ClearFormBtn = new System.Windows.Forms.Button();
            this.FindCourseBtn = new System.Windows.Forms.Button();
            this.selectCredit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNameID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.topicName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(13, 15);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(789, 600);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(137)))));
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(453, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 626);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtNameID);
            this.panel2.Controls.Add(this.CancelEditBtn);
            this.panel2.Controls.Add(this.EditCourseBtn);
            this.panel2.Controls.Add(this.SuccessLabel);
            this.panel2.Controls.Add(this.ClearFormBtn);
            this.panel2.Controls.Add(this.FindCourseBtn);
            this.panel2.Controls.Add(this.selectCredit);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtTime);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(24, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 615);
            this.panel2.TabIndex = 2;
            // 
            // CancelEditBtn
            // 
            this.CancelEditBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CancelEditBtn.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelEditBtn.Location = new System.Drawing.Point(280, 518);
            this.CancelEditBtn.Name = "CancelEditBtn";
            this.CancelEditBtn.Size = new System.Drawing.Size(117, 38);
            this.CancelEditBtn.TabIndex = 19;
            this.CancelEditBtn.Text = "ยกเลิก";
            this.CancelEditBtn.UseVisualStyleBackColor = false;
            this.CancelEditBtn.Visible = false;
            this.CancelEditBtn.Click += new System.EventHandler(this.CancelEditBtn_Click);
            // 
            // EditCourseBtn
            // 
            this.EditCourseBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.EditCourseBtn.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCourseBtn.Location = new System.Drawing.Point(157, 518);
            this.EditCourseBtn.Name = "EditCourseBtn";
            this.EditCourseBtn.Size = new System.Drawing.Size(117, 38);
            this.EditCourseBtn.TabIndex = 18;
            this.EditCourseBtn.Text = "แก้ไขรายวิชา";
            this.EditCourseBtn.UseVisualStyleBackColor = false;
            this.EditCourseBtn.Visible = false;
            this.EditCourseBtn.Click += new System.EventHandler(this.EditCourseBtn_Click);
            // 
            // SuccessLabel
            // 
            this.SuccessLabel.AutoSize = true;
            this.SuccessLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SuccessLabel.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccessLabel.ForeColor = System.Drawing.Color.GreenYellow;
            this.SuccessLabel.Location = new System.Drawing.Point(36, 533);
            this.SuccessLabel.Name = "SuccessLabel";
            this.SuccessLabel.Size = new System.Drawing.Size(347, 34);
            this.SuccessLabel.TabIndex = 17;
            this.SuccessLabel.Text = "เพิ่มรายวิชา สำเร็จ  กรุณาตรวจสอบหน้าตารางเรียน";
            this.SuccessLabel.Visible = false;
            // 
            // ClearFormBtn
            // 
            this.ClearFormBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClearFormBtn.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearFormBtn.Location = new System.Drawing.Point(280, 480);
            this.ClearFormBtn.Name = "ClearFormBtn";
            this.ClearFormBtn.Size = new System.Drawing.Size(117, 38);
            this.ClearFormBtn.TabIndex = 16;
            this.ClearFormBtn.Text = "ล้างฟอร์ม";
            this.ClearFormBtn.UseVisualStyleBackColor = false;
            this.ClearFormBtn.Click += new System.EventHandler(this.ClearFormBtn_Click);
            // 
            // FindCourseBtn
            // 
            this.FindCourseBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.FindCourseBtn.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindCourseBtn.Location = new System.Drawing.Point(157, 480);
            this.FindCourseBtn.Name = "FindCourseBtn";
            this.FindCourseBtn.Size = new System.Drawing.Size(117, 38);
            this.FindCourseBtn.TabIndex = 15;
            this.FindCourseBtn.Text = "เพิ่มรายวิชา";
            this.FindCourseBtn.UseVisualStyleBackColor = false;
            this.FindCourseBtn.Click += new System.EventHandler(this.btnFindCourse_Click);
            // 
            // selectCredit
            // 
            this.selectCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCredit.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCredit.FormattingEnabled = true;
            this.selectCredit.Items.AddRange(new object[] {
            "  1",
            "  2",
            "  3",
            "  4",
            "  5",
            "  6",
            "  7",
            "  8"});
            this.selectCredit.Location = new System.Drawing.Point(20, 263);
            this.selectCredit.Name = "selectCredit";
            this.selectCredit.Size = new System.Drawing.Size(58, 42);
            this.selectCredit.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(43, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 34);
            this.label8.TabIndex = 13;
            this.label8.Text = "รหัสวิชา";
            // 
            // txtNameID
            // 
            this.txtNameID.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameID.ForeColor = System.Drawing.Color.Gray;
            this.txtNameID.Location = new System.Drawing.Point(20, 110);
            this.txtNameID.Name = "txtNameID";
            this.txtNameID.Size = new System.Drawing.Size(372, 41);
            this.txtNameID.TabIndex = 12;
            this.txtNameID.Text = "121234";
            this.txtNameID.Enter += new System.EventHandler(this.TxtPlaceHoler_Enter);
            this.txtNameID.Leave += new System.EventHandler(this.TxtPlaceHoler_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(19, 62);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(10);
            this.label6.Size = new System.Drawing.Size(20, 54);
            this.label6.TabIndex = 11;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.ForeColor = System.Drawing.Color.Gray;
            this.txtTime.Location = new System.Drawing.Point(22, 337);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(370, 115);
            this.txtTime.TabIndex = 10;
            this.txtTime.Text = "Mo10:00-12:00 B1111\nWe10:00-12:00 B1111\nFr08:00-10:00 B1111";
            this.txtTime.Enter += new System.EventHandler(this.txtTime_Enter);
            this.txtTime.Leave += new System.EventHandler(this.txtTime_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(20, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 34);
            this.label5.TabIndex = 9;
            this.label5.Text = "เวลา";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(21, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 34);
            this.label4.TabIndex = 7;
            this.label4.Text = "หน่วยกิต";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(23, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "ชื่อวิชา";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Gray;
            this.txtName.Location = new System.Drawing.Point(20, 189);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(372, 41);
            this.txtName.TabIndex = 5;
            this.txtName.Text = "Course Name";
            this.txtName.Enter += new System.EventHandler(this.TxtPlaceHoler_Enter);
            this.txtName.Leave += new System.EventHandler(this.TxtPlaceHoler_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.topicName);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 53);
            this.panel3.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(19, 1);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(10);
            this.label7.Size = new System.Drawing.Size(20, 54);
            this.label7.TabIndex = 12;
            // 
            // topicName
            // 
            this.topicName.AutoSize = true;
            this.topicName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topicName.Font = new System.Drawing.Font("Cordia New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicName.ForeColor = System.Drawing.Color.Gainsboro;
            this.topicName.Location = new System.Drawing.Point(39, 12);
            this.topicName.Name = "topicName";
            this.topicName.Size = new System.Drawing.Size(118, 36);
            this.topicName.TabIndex = 1;
            this.topicName.Text = "เพิ่มรายวิชา";
            // 
            // AddNewCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(57)))), ((int)(((byte)(124)))));
            this.ClientSize = new System.Drawing.Size(1283, 650);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "AddNewCourse";
            this.Text = "AddNewCourse";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label topicName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RichTextBox txtTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNameID;
        private System.Windows.Forms.ComboBox selectCredit;
        private System.Windows.Forms.Button FindCourseBtn;
        private System.Windows.Forms.Button ClearFormBtn;
        private System.Windows.Forms.Label SuccessLabel;
        private System.Windows.Forms.Button CancelEditBtn;
        private System.Windows.Forms.Button EditCourseBtn;
    }
}