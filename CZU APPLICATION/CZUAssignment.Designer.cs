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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.assignmentMainGB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.solution = new System.Windows.Forms.RichTextBox();
            this.assignment = new System.Windows.Forms.RichTextBox();
            this.submitAssignment = new System.Windows.Forms.Button();
            this.exitAssignment = new System.Windows.Forms.Button();
            this.assignmentSolution = new System.Windows.Forms.Panel();
            this.addAssignment = new System.Windows.Forms.Panel();
            this.addAssignmentMainGB = new System.Windows.Forms.GroupBox();
            this.assignmentGrade = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deadline = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label666 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.assignmentMainGB.SuspendLayout();
            this.assignmentSolution.SuspendLayout();
            this.addAssignment.SuspendLayout();
            this.addAssignmentMainGB.SuspendLayout();
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
            this.assignmentMainGB.Size = new System.Drawing.Size(943, 427);
            this.assignmentMainGB.TabIndex = 1;
            this.assignmentMainGB.TabStop = false;
            this.assignmentMainGB.Text = "Your Assignment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your solution:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Assignment:";
            // 
            // solution
            // 
            this.solution.Location = new System.Drawing.Point(112, 243);
            this.solution.Name = "solution";
            this.solution.Size = new System.Drawing.Size(752, 144);
            this.solution.TabIndex = 1;
            this.solution.Text = "";
            // 
            // assignment
            // 
            this.assignment.Location = new System.Drawing.Point(112, 67);
            this.assignment.Name = "assignment";
            this.assignment.ReadOnly = true;
            this.assignment.Size = new System.Drawing.Size(752, 113);
            this.assignment.TabIndex = 0;
            this.assignment.Text = "";
            // 
            // submitAssignment
            // 
            this.submitAssignment.Location = new System.Drawing.Point(394, 549);
            this.submitAssignment.Name = "submitAssignment";
            this.submitAssignment.Size = new System.Drawing.Size(113, 44);
            this.submitAssignment.TabIndex = 2;
            this.submitAssignment.Text = "Submit";
            this.submitAssignment.UseVisualStyleBackColor = true;
            // 
            // exitAssignment
            // 
            this.exitAssignment.Location = new System.Drawing.Point(546, 549);
            this.exitAssignment.Name = "exitAssignment";
            this.exitAssignment.Size = new System.Drawing.Size(113, 44);
            this.exitAssignment.TabIndex = 3;
            this.exitAssignment.Text = "Exit";
            this.exitAssignment.UseVisualStyleBackColor = true;
            // 
            // assignmentSolution
            // 
            this.assignmentSolution.Controls.Add(this.assignmentMainGB);
            this.assignmentSolution.Location = new System.Drawing.Point(32, 67);
            this.assignmentSolution.Name = "assignmentSolution";
            this.assignmentSolution.Size = new System.Drawing.Size(961, 454);
            this.assignmentSolution.TabIndex = 4;
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
            this.addAssignmentMainGB.Controls.Add(this.assignmentGrade);
            this.addAssignmentMainGB.Controls.Add(this.label4);
            this.addAssignmentMainGB.Controls.Add(this.deadline);
            this.addAssignmentMainGB.Controls.Add(this.label3);
            this.addAssignmentMainGB.Controls.Add(this.label666);
            this.addAssignmentMainGB.Controls.Add(this.richTextBox1);
            this.addAssignmentMainGB.Location = new System.Drawing.Point(0, 3);
            this.addAssignmentMainGB.Name = "addAssignmentMainGB";
            this.addAssignmentMainGB.Size = new System.Drawing.Size(973, 448);
            this.addAssignmentMainGB.TabIndex = 0;
            this.addAssignmentMainGB.TabStop = false;
            this.addAssignmentMainGB.Text = "Add Assignment";
            // 
            // assignmentGrade
            // 
            this.assignmentGrade.FormattingEnabled = true;
            this.assignmentGrade.ItemHeight = 20;
            this.assignmentGrade.Items.AddRange(new object[] {
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
            this.assignmentGrade.Location = new System.Drawing.Point(751, 386);
            this.assignmentGrade.Name = "assignmentGrade";
            this.assignmentGrade.Size = new System.Drawing.Size(54, 24);
            this.assignmentGrade.TabIndex = 6;
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(129, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(752, 232);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // CZUAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 605);
            this.Controls.Add(this.addAssignment);
            this.Controls.Add(this.assignmentSolution);
            this.Controls.Add(this.exitAssignment);
            this.Controls.Add(this.submitAssignment);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CZUAssignment";
            this.Text = "CZU University of LifeSciences - Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.assignmentMainGB.ResumeLayout(false);
            this.assignmentMainGB.PerformLayout();
            this.assignmentSolution.ResumeLayout(false);
            this.addAssignment.ResumeLayout(false);
            this.addAssignmentMainGB.ResumeLayout(false);
            this.addAssignmentMainGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox assignmentMainGB;
        private System.Windows.Forms.Button submitAssignment;
        private System.Windows.Forms.Button exitAssignment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox solution;
        private System.Windows.Forms.RichTextBox assignment;
        private System.Windows.Forms.Panel assignmentSolution;
        private System.Windows.Forms.Panel addAssignment;
        private System.Windows.Forms.GroupBox addAssignmentMainGB;
        private System.Windows.Forms.ListBox assignmentGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker deadline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label666;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}