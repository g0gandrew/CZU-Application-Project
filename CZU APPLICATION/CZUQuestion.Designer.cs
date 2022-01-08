namespace CZU_APPLICATION
{
    partial class CZUQuestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CZUQuestion));
            this.studentQuestion = new System.Windows.Forms.RichTextBox();
            this.submit = new System.Windows.Forms.Button();
            this.teacherAnswer = new System.Windows.Forms.RichTextBox();
            this.exit = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.questionPriority = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.questionTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.answerToQuestion = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.displayAddQuestion = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showQuestion = new System.Windows.Forms.Panel();
            this.studentQuestion1 = new System.Windows.Forms.RichTextBox();
            this.teacherAnswer1 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.answerToQuestion.SuspendLayout();
            this.displayAddQuestion.SuspendLayout();
            this.showQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentQuestion
            // 
            this.studentQuestion.Location = new System.Drawing.Point(141, 93);
            this.studentQuestion.Name = "studentQuestion";
            this.studentQuestion.ReadOnly = true;
            this.studentQuestion.Size = new System.Drawing.Size(745, 178);
            this.studentQuestion.TabIndex = 1;
            this.studentQuestion.Text = "";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(374, 677);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(145, 53);
            this.submit.TabIndex = 3;
            this.submit.Text = "Response";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submitResponse_Click);
            // 
            // teacherAnswer
            // 
            this.teacherAnswer.Location = new System.Drawing.Point(137, 328);
            this.teacherAnswer.Name = "teacherAnswer";
            this.teacherAnswer.Size = new System.Drawing.Size(745, 188);
            this.teacherAnswer.TabIndex = 4;
            this.teacherAnswer.Text = "";
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
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(-1, -1);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(381, 90);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 7;
            this.logo.TabStop = false;
            // 
            // questionPriority
            // 
            this.questionPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.questionPriority.FormattingEnabled = true;
            this.questionPriority.Items.AddRange(new object[] {
            "Urgent",
            "Minor"});
            this.questionPriority.Location = new System.Drawing.Point(134, 106);
            this.questionPriority.Name = "questionPriority";
            this.questionPriority.Size = new System.Drawing.Size(100, 28);
            this.questionPriority.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Your Question:";
            // 
            // questionTitle
            // 
            this.questionTitle.Location = new System.Drawing.Point(134, 57);
            this.questionTitle.Name = "questionTitle";
            this.questionTitle.Size = new System.Drawing.Size(652, 27);
            this.questionTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Title:";
            // 
            // question
            // 
            this.question.Location = new System.Drawing.Point(134, 237);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(768, 256);
            this.question.TabIndex = 1;
            this.question.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Priority:";
            // 
            // answerToQuestion
            // 
            this.answerToQuestion.Controls.Add(this.studentQuestion);
            this.answerToQuestion.Controls.Add(this.teacherAnswer);
            this.answerToQuestion.Controls.Add(this.label2);
            this.answerToQuestion.Controls.Add(this.label1);
            this.answerToQuestion.Controls.Add(this.groupBox3);
            this.answerToQuestion.Enabled = false;
            this.answerToQuestion.Location = new System.Drawing.Point(33, 95);
            this.answerToQuestion.Name = "answerToQuestion";
            this.answerToQuestion.Size = new System.Drawing.Size(1028, 573);
            this.answerToQuestion.TabIndex = 10;
            this.answerToQuestion.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Your Answer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Student Question:";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(6, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1016, 544);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Student Question:";
            // 
            // displayAddQuestion
            // 
            this.displayAddQuestion.Controls.Add(this.questionPriority);
            this.displayAddQuestion.Controls.Add(this.questionTitle);
            this.displayAddQuestion.Controls.Add(this.question);
            this.displayAddQuestion.Controls.Add(this.label5);
            this.displayAddQuestion.Controls.Add(this.label3);
            this.displayAddQuestion.Controls.Add(this.label4);
            this.displayAddQuestion.Controls.Add(this.groupBox1);
            this.displayAddQuestion.Enabled = false;
            this.displayAddQuestion.Location = new System.Drawing.Point(33, 95);
            this.displayAddQuestion.Name = "displayAddQuestion";
            this.displayAddQuestion.Size = new System.Drawing.Size(1040, 576);
            this.displayAddQuestion.TabIndex = 11;
            this.displayAddQuestion.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 544);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ask a Question ";
            // 
            // showQuestion
            // 
            this.showQuestion.Controls.Add(this.studentQuestion1);
            this.showQuestion.Controls.Add(this.teacherAnswer1);
            this.showQuestion.Controls.Add(this.label6);
            this.showQuestion.Controls.Add(this.label7);
            this.showQuestion.Controls.Add(this.groupBox2);
            this.showQuestion.Enabled = false;
            this.showQuestion.Location = new System.Drawing.Point(33, 95);
            this.showQuestion.Name = "showQuestion";
            this.showQuestion.Size = new System.Drawing.Size(1028, 573);
            this.showQuestion.TabIndex = 11;
            this.showQuestion.Visible = false;
            // 
            // studentQuestion1
            // 
            this.studentQuestion1.Location = new System.Drawing.Point(141, 93);
            this.studentQuestion1.Name = "studentQuestion1";
            this.studentQuestion1.ReadOnly = true;
            this.studentQuestion1.Size = new System.Drawing.Size(745, 178);
            this.studentQuestion1.TabIndex = 1;
            this.studentQuestion1.Text = "";
            // 
            // teacherAnswer1
            // 
            this.teacherAnswer1.Location = new System.Drawing.Point(137, 328);
            this.teacherAnswer1.Name = "teacherAnswer1";
            this.teacherAnswer1.ReadOnly = true;
            this.teacherAnswer1.Size = new System.Drawing.Size(745, 188);
            this.teacherAnswer1.TabIndex = 4;
            this.teacherAnswer1.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Teacher Answer:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Your Question:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1016, 544);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Question Details:";
            // 
            // CZUQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 742);
            this.Controls.Add(this.showQuestion);
            this.Controls.Add(this.displayAddQuestion);
            this.Controls.Add(this.answerToQuestion);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CZUQuestion";
            this.Text = "CZU University of LifeScience - Question";
            this.Load += new System.EventHandler(this.QuestionDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.answerToQuestion.ResumeLayout(false);
            this.answerToQuestion.PerformLayout();
            this.displayAddQuestion.ResumeLayout(false);
            this.displayAddQuestion.PerformLayout();
            this.showQuestion.ResumeLayout(false);
            this.showQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox studentQuestion;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.RichTextBox teacherAnswer;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox questionTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox question;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox questionPriority;
        private System.Windows.Forms.Panel answerToQuestion;
        private System.Windows.Forms.Panel displayAddQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel showQuestion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox studentQuestion1;
        private System.Windows.Forms.RichTextBox teacherAnswer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}