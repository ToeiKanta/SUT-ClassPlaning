namespace CourseManagement
{
    partial class FindCourse
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
            this.txtRequestURI = new System.Windows.Forms.RichTextBox();
            this.cmdGO = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.SelectGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CourseMonitor = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtRequestURI
            // 
            this.txtRequestURI.Location = new System.Drawing.Point(43, 27);
            this.txtRequestURI.Name = "txtRequestURI";
            this.txtRequestURI.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRequestURI.Size = new System.Drawing.Size(538, 35);
            this.txtRequestURI.TabIndex = 0;
            this.txtRequestURI.Text = "";
            // 
            // cmdGO
            // 
            this.cmdGO.Location = new System.Drawing.Point(606, 27);
            this.cmdGO.Name = "cmdGO";
            this.cmdGO.Size = new System.Drawing.Size(95, 35);
            this.cmdGO.TabIndex = 1;
            this.cmdGO.Text = "button1";
            this.cmdGO.UseVisualStyleBackColor = true;
            this.cmdGO.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Font = new System.Drawing.Font("Angsana New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponse.Location = new System.Drawing.Point(43, 81);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(461, 346);
            this.txtResponse.TabIndex = 2;
            this.txtResponse.Text = "";
            this.txtResponse.TextChanged += new System.EventHandler(this.txtResponse_TextChanged);
            // 
            // SelectGroup
            // 
            this.SelectGroup.FormattingEnabled = true;
            this.SelectGroup.Location = new System.Drawing.Point(551, 102);
            this.SelectGroup.Name = "SelectGroup";
            this.SelectGroup.Size = new System.Drawing.Size(57, 21);
            this.SelectGroup.TabIndex = 3;
            this.SelectGroup.Text = "Groups";
            this.SelectGroup.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // CourseMonitor
            // 
            this.CourseMonitor.Location = new System.Drawing.Point(634, 81);
            this.CourseMonitor.Name = "CourseMonitor";
            this.CourseMonitor.Size = new System.Drawing.Size(406, 346);
            this.CourseMonitor.TabIndex = 5;
            this.CourseMonitor.Text = "";
            // 
            // FindCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 451);
            this.Controls.Add(this.CourseMonitor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectGroup);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.cmdGO);
            this.Controls.Add(this.txtRequestURI);
            this.Name = "FindCourse";
            this.Text = "FindCourse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtRequestURI;
        private System.Windows.Forms.Button cmdGO;
        private System.Windows.Forms.RichTextBox txtResponse;
        private System.Windows.Forms.ComboBox SelectGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox CourseMonitor;
    }
}