namespace CZU_APPLICATION
{
    partial class QuestionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionDetails));
            this.studentQuestion = new System.Windows.Forms.RichTextBox();
            this.submitResponse = new System.Windows.Forms.Button();
            this.teacherAnswer = new System.Windows.Forms.RichTextBox();
            this.questionDetailsMainGB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.questionDetailsMainGB2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.priority = new System.Windows.Forms.CheckedListBox();
            this.questionTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.questionTitleLabel = new System.Windows.Forms.Label();
            this.questionDetailsMainGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.questionDetailsMainGB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentQuestion
            // 
            this.studentQuestion.Location = new System.Drawing.Point(104, 47);
            this.studentQuestion.Name = "studentQuestion";
            this.studentQuestion.ReadOnly = true;
            this.studentQuestion.Size = new System.Drawing.Size(745, 178);
            this.studentQuestion.TabIndex = 1;
            this.studentQuestion.Text = "";
            // 
            // submitResponse
            // 
            this.submitResponse.Location = new System.Drawing.Point(374, 677);
            this.submitResponse.Name = "submitResponse";
            this.submitResponse.Size = new System.Drawing.Size(145, 53);
            this.submitResponse.TabIndex = 3;
            this.submitResponse.Text = "Response";
            this.submitResponse.UseVisualStyleBackColor = true;
            this.submitResponse.Click += new System.EventHandler(this.submitResponse_Click);
            // 
            // teacherAnswer
            // 
            this.teacherAnswer.Location = new System.Drawing.Point(104, 268);
            this.teacherAnswer.Name = "teacherAnswer";
            this.teacherAnswer.Size = new System.Drawing.Size(745, 168);
            this.teacherAnswer.TabIndex = 4;
            this.teacherAnswer.Text = "";
            // 
            // questionDetailsMainGB
            // 
            this.questionDetailsMainGB.Controls.Add(this.label2);
            this.questionDetailsMainGB.Controls.Add(this.label1);
            this.questionDetailsMainGB.Controls.Add(this.teacherAnswer);
            this.questionDetailsMainGB.Controls.Add(this.studentQuestion);
            this.questionDetailsMainGB.Enabled = false;
            this.questionDetailsMainGB.Location = new System.Drawing.Point(53, 157);
            this.questionDetailsMainGB.Name = "questionDetailsMainGB";
            this.questionDetailsMainGB.Size = new System.Drawing.Size(951, 505);
            this.questionDetailsMainGB.TabIndex = 5;
            this.questionDetailsMainGB.TabStop = false;
            this.questionDetailsMainGB.Text = "Question";
            this.questionDetailsMainGB.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Response:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Question:";
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(565, 677);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(145, 53);
            this.exit.TabIndex = 6;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(381, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // questionDetailsMainGB2
            // 
            this.questionDetailsMainGB2.Controls.Add(this.label5);
            this.questionDetailsMainGB2.Controls.Add(this.priority);
            this.questionDetailsMainGB2.Controls.Add(this.questionTitle);
            this.questionDetailsMainGB2.Controls.Add(this.label4);
            this.questionDetailsMainGB2.Controls.Add(this.question);
            this.questionDetailsMainGB2.Controls.Add(this.label3);
            this.questionDetailsMainGB2.Enabled = false;
            this.questionDetailsMainGB2.Location = new System.Drawing.Point(53, 157);
            this.questionDetailsMainGB2.Name = "questionDetailsMainGB2";
            this.questionDetailsMainGB2.Size = new System.Drawing.Size(951, 505);
            this.questionDetailsMainGB2.TabIndex = 8;
            this.questionDetailsMainGB2.TabStop = false;
            this.questionDetailsMainGB2.Text = "Question";
            this.questionDetailsMainGB2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Your Question:";
            // 
            // priority
            // 
            this.priority.BackColor = System.Drawing.SystemColors.Control;
            this.priority.FormattingEnabled = true;
            this.priority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.priority.Location = new System.Drawing.Point(104, 95);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(149, 70);
            this.priority.TabIndex = 4;
            // 
            // questionTitle
            // 
            this.questionTitle.Location = new System.Drawing.Point(99, 45);
            this.questionTitle.Name = "questionTitle";
            this.questionTitle.Size = new System.Drawing.Size(652, 27);
            this.questionTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Title:";
            // 
            // question
            // 
            this.question.Location = new System.Drawing.Point(99, 268);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(691, 169);
            this.question.TabIndex = 1;
            this.question.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Priority:";
            // 
            // questionTitleLabel
            // 
            this.questionTitleLabel.AutoSize = true;
            this.questionTitleLabel.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.questionTitleLabel.Location = new System.Drawing.Point(433, 117);
            this.questionTitleLabel.Name = "questionTitleLabel";
            this.questionTitleLabel.Size = new System.Drawing.Size(200, 28);
            this.questionTitleLabel.TabIndex = 9;
            this.questionTitleLabel.Text = "Title of the question";
            // 
            // QuestionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 742);
            this.Controls.Add(this.questionDetailsMainGB2);
            this.Controls.Add(this.questionTitleLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.submitResponse);
            this.Controls.Add(this.questionDetailsMainGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionDetails";
            this.Text = "Czech University Of LifeSciences";
            this.Load += new System.EventHandler(this.QuestionDetails_Load);
            this.questionDetailsMainGB.ResumeLayout(false);
            this.questionDetailsMainGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.questionDetailsMainGB2.ResumeLayout(false);
            this.questionDetailsMainGB2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox studentQuestion;
        private System.Windows.Forms.Button submitResponse;
        private System.Windows.Forms.RichTextBox teacherAnswer;
        private System.Windows.Forms.GroupBox questionDetailsMainGB;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox questionDetailsMainGB2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox priority;
        private System.Windows.Forms.TextBox questionTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox question;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label questionTitleLabel;
    }
}