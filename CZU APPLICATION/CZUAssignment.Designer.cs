namespace CZU_APPLICATION
{
    partial class CZUAssignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CZUAssignment));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.assignmentMainGB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.solution = new System.Windows.Forms.RichTextBox();
            this.assignment = new System.Windows.Forms.RichTextBox();
            this.submit = new System.Windows.Forms.Button();
            this.exitAssignment = new System.Windows.Forms.Button();
            this.addAssignmentSolution = new System.Windows.Forms.Panel();
            this.addAssignment = new System.Windows.Forms.Panel();
            this.addAssignmentMainGB = new System.Windows.Forms.GroupBox();
            this.assignmentMinGrade = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deadline = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label666 = new System.Windows.Forms.Label();
            this.assignmentDescription = new System.Windows.Forms.RichTextBox();
            this.studentAssignmentSolution = new System.Windows.Forms.Panel();
            this.studentAssignmentSolutionMainGB = new System.Windows.Forms.GroupBox();
            this.gradeOfSolution = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.studentSolution = new System.Windows.Forms.RichTextBox();
            this.assignmentDescription1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.assignmentMainGB.SuspendLayout();
            this.addAssignmentSolution.SuspendLayout();
            this.addAssignment.SuspendLayout();
            this.addAssignmentMainGB.SuspendLayout();
            this.studentAssignmentSolution.SuspendLayout();
            this.studentAssignmentSolutionMainGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CZU_APPLICATION.Properties.Resources.logoczu;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // assignmentMainGB
            // 
            this.assignmentMainGB.Controls.Add(this.label2);
            this.assignmentMainGB.Controls.Add(this.label1);
            this.assignmentMainGB.Controls.Add(this.solution);
            this.assignmentMainGB.Controls.Add(this.assignment);
            this.assignmentMainGB.Location = new System.Drawing.Point(15, 12);
            this.assignmentMainGB.Name = "assignmentMainGB";
            this.assignmentMainGB.Size = new System.Drawing.Size(943, 442);
            this.assignmentMainGB.TabIndex = 1;
            this.assignmentMainGB.TabStop = false;
            this.assignmentMainGB.Text = "Your Assignment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your solution:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Assignment:";
            // 
            // solution
            // 
            this.solution.Location = new System.Drawing.Point(102, 243);
            this.solution.Name = "solution";
            this.solution.Size = new System.Drawing.Size(752, 174);
            this.solution.TabIndex = 1;
            this.solution.Text = "";
            // 
            // assignment
            // 
            this.assignment.Location = new System.Drawing.Point(102, 58);
            this.assignment.Name = "assignment";
            this.assignment.ReadOnly = true;
            this.assignment.Size = new System.Drawing.Size(752, 132);
            this.assignment.TabIndex = 0;
            this.assignment.Text = "";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(394, 549);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(113, 44);
            this.submit.TabIndex = 2;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // exitAssignment
            // 
            this.exitAssignment.Location = new System.Drawing.Point(546, 549);
            this.exitAssignment.Name = "exitAssignment";
            this.exitAssignment.Size = new System.Drawing.Size(113, 44);
            this.exitAssignment.TabIndex = 3;
            this.exitAssignment.Text = "Exit";
            this.exitAssignment.UseVisualStyleBackColor = true;
            this.exitAssignment.Click += new System.EventHandler(this.exitAssignment_Click);
            // 
            // addAssignmentSolution
            // 
            this.addAssignmentSolution.Controls.Add(this.assignmentMainGB);
            this.addAssignmentSolution.Location = new System.Drawing.Point(32, 67);
            this.addAssignmentSolution.Name = "addAssignmentSolution";
            this.addAssignmentSolution.Size = new System.Drawing.Size(974, 476);
            this.addAssignmentSolution.TabIndex = 4;
            // 
            // addAssignment
            // 
            this.addAssignment.Controls.Add(this.addAssignmentMainGB);
            this.addAssignment.Location = new System.Drawing.Point(30, 67);
            this.addAssignment.Name = "addAssignment";
            this.addAssignment.Size = new System.Drawing.Size(976, 454);
            this.addAssignment.TabIndex = 5;
            // 
            // addAssignmentMainGB
            // 
            this.addAssignmentMainGB.Controls.Add(this.assignmentMinGrade);
            this.addAssignmentMainGB.Controls.Add(this.label4);
            this.addAssignmentMainGB.Controls.Add(this.deadline);
            this.addAssignmentMainGB.Controls.Add(this.label3);
            this.addAssignmentMainGB.Controls.Add(this.label666);
            this.addAssignmentMainGB.Controls.Add(this.assignmentDescription);
            this.addAssignmentMainGB.Location = new System.Drawing.Point(0, 3);
            this.addAssignmentMainGB.Name = "addAssignmentMainGB";
            this.addAssignmentMainGB.Size = new System.Drawing.Size(973, 448);
            this.addAssignmentMainGB.TabIndex = 0;
            this.addAssignmentMainGB.TabStop = false;
            this.addAssignmentMainGB.Text = "Add Assignment";
            // 
            // assignmentMinGrade
            // 
            this.assignmentMinGrade.FormattingEnabled = true;
            this.assignmentMinGrade.ItemHeight = 20;
            this.assignmentMinGrade.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.assignmentMinGrade.Location = new System.Drawing.Point(751, 386);
            this.assignmentMinGrade.Name = "assignmentMinGrade";
            this.assignmentMinGrade.Size = new System.Drawing.Size(54, 24);
            this.assignmentMinGrade.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(728, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Minim Grade:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deadline
            // 
            this.deadline.Location = new System.Drawing.Point(154, 386);
            this.deadline.Name = "deadline";
            this.deadline.Size = new System.Drawing.Size(250, 27);
            this.deadline.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Assignment";
            // 
            // label666
            // 
            this.label666.AutoSize = true;
            this.label666.Location = new System.Drawing.Point(246, 349);
            this.label666.Name = "label666";
            this.label666.Size = new System.Drawing.Size(72, 20);
            this.label666.TabIndex = 3;
            this.label666.Text = "Deadline:";
            this.label666.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // assignmentDescription
            // 
            this.assignmentDescription.Location = new System.Drawing.Point(129, 76);
            this.assignmentDescription.Name = "assignmentDescription";
            this.assignmentDescription.Size = new System.Drawing.Size(752, 232);
            this.assignmentDescription.TabIndex = 0;
            this.assignmentDescription.Text = "";
            // 
            // studentAssignmentSolution
            // 
            this.studentAssignmentSolution.Controls.Add(this.studentAssignmentSolutionMainGB);
            this.studentAssignmentSolution.Location = new System.Drawing.Point(22, 64);
            this.studentAssignmentSolution.Name = "studentAssignmentSolution";
            this.studentAssignmentSolution.Size = new System.Drawing.Size(974, 476);
            this.studentAssignmentSolution.TabIndex = 6;
            // 
            // studentAssignmentSolutionMainGB
            // 
            this.studentAssignmentSolutionMainGB.Controls.Add(this.gradeOfSolution);
            this.studentAssignmentSolutionMainGB.Controls.Add(this.label6);
            this.studentAssignmentSolutionMainGB.Controls.Add(this.label7);
            this.studentAssignmentSolutionMainGB.Controls.Add(this.label8);
            this.studentAssignmentSolutionMainGB.Controls.Add(this.studentSolution);
            this.studentAssignmentSolutionMainGB.Controls.Add(this.assignmentDescription1);
            this.studentAssignmentSolutionMainGB.Location = new System.Drawing.Point(15, 12);
            this.studentAssignmentSolutionMainGB.Name = "studentAssignmentSolutionMainGB";
            this.studentAssignmentSolutionMainGB.Size = new System.Drawing.Size(943, 442);
            this.studentAssignmentSolutionMainGB.TabIndex = 1;
            this.studentAssignmentSolutionMainGB.TabStop = false;
            this.studentAssignmentSolutionMainGB.Text = "Your Assignment";
            // 
            // gradeOfSolution
            // 
            this.gradeOfSolution.FormattingEnabled = true;
            this.gradeOfSolution.ItemHeight = 20;
            this.gradeOfSolution.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.gradeOfSolution.Location = new System.Drawing.Point(444, 387);
            this.gradeOfSolution.Name = "gradeOfSolution";
            this.gradeOfSolution.Size = new System.Drawing.Size(58, 24);
            this.gradeOfSolution.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Solution Grade:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Student solution:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(444, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Assignment:";
            // 
            // studentSolution
            // 
            this.studentSolution.Location = new System.Drawing.Point(112, 227);
            this.studentSolution.Name = "studentSolution";
            this.studentSolution.ReadOnly = true;
            this.studentSolution.Size = new System.Drawing.Size(752, 120);
            this.studentSolution.TabIndex = 1;
            this.studentSolution.Text = "";
            // 
            // assignmentDescription1
            // 
            this.assignmentDescription1.Location = new System.Drawing.Point(112, 58);
            this.assignmentDescription1.Name = "assignmentDescription1";
            this.assignmentDescription1.ReadOnly = true;
            this.assignmentDescription1.Size = new System.Drawing.Size(752, 113);
            this.assignmentDescription1.TabIndex = 0;
            this.assignmentDescription1.Text = "";
            // 
            // CZUAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 605);
            this.Controls.Add(this.studentAssignmentSolution);
            this.Controls.Add(this.addAssignmentSolution);
            this.Controls.Add(this.addAssignment);
            this.Controls.Add(this.exitAssignment);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CZUAssignment";
            this.Text = "CZU University of LifeSciences - Assignment";
            this.Load += new System.EventHandler(this.CZUAssignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.assignmentMainGB.ResumeLayout(false);
            this.assignmentMainGB.PerformLayout();
            this.addAssignmentSolution.ResumeLayout(false);
            this.addAssignment.ResumeLayout(false);
            this.addAssignmentMainGB.ResumeLayout(false);
            this.addAssignmentMainGB.PerformLayout();
            this.studentAssignmentSolution.ResumeLayout(false);
            this.studentAssignmentSolutionMainGB.ResumeLayout(false);
            this.studentAssignmentSolutionMainGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox assignmentMainGB;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button exitAssignment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox solution;
        private System.Windows.Forms.RichTextBox assignment;
        private System.Windows.Forms.Panel addAssignmentSolution;
        private System.Windows.Forms.Panel addAssignment;
        private System.Windows.Forms.GroupBox addAssignmentMainGB;
        private System.Windows.Forms.ListBox assignmentMinGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker deadline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label666;
        private System.Windows.Forms.RichTextBox assignmentDescription;
        private System.Windows.Forms.Panel studentAssignmentSolution;
        private System.Windows.Forms.GroupBox studentAssignmentSolutionMainGB;
        private System.Windows.Forms.ListBox gradeOfSolution;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox studentSolution;
        private System.Windows.Forms.RichTextBox assignmentDescription1;
    }
}