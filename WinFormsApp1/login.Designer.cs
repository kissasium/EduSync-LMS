﻿namespace WinFormsApp1
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            panel1 = new Panel();
            loginButton = new Button();
            label1 = new Label();
            label2 = new Label();
            emailtextBox = new TextBox();
            PasswordtextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(242, 247, 253);
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Location = new Point(-5, -14);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(374, 352);
            panel1.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.Black;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(438, 212);
            loginButton.Margin = new Padding(3, 2, 3, 2);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(116, 25);
            loginButton.TabIndex = 25;
            loginButton.Text = "LOGIN";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(323, 125);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 26;
            label1.Text = "Email ✉";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(290, 148);
            label2.Name = "label2";
            label2.Size = new Size(102, 18);
            label2.TabIndex = 27;
            label2.Text = "password 🔒";
            // 
            // emailtextBox
            // 
            emailtextBox.Location = new Point(423, 122);
            emailtextBox.Margin = new Padding(3, 2, 3, 2);
            emailtextBox.Name = "emailtextBox";
            emailtextBox.Size = new Size(148, 23);
            emailtextBox.TabIndex = 28;
            emailtextBox.TextChanged += emailtextBox_TextChanged;
            // 
            // PasswordtextBox
            // 
            PasswordtextBox.Location = new Point(423, 148);
            PasswordtextBox.Margin = new Padding(3, 2, 3, 2);
            PasswordtextBox.Name = "PasswordtextBox";
            PasswordtextBox.PasswordChar = '*';
            PasswordtextBox.Size = new Size(148, 23);
            PasswordtextBox.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(328, 14);
            label3.Name = "label3";
            label3.Size = new Size(160, 31);
            label3.TabIndex = 30;
            label3.Text = "WELCOME";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(423, 178);
            label4.Name = "label4";
            label4.Size = new Size(104, 13);
            label4.TabIndex = 31;
            label4.Text = "forgot password?";
            label4.Click += label4_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 247, 253);
            ClientSize = new Size(676, 335);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(PasswordtextBox);
            Controls.Add(emailtextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(loginButton);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button loginButton;
        private Label label1;
        private Label label2;
        private TextBox emailtextBox;
        private TextBox PasswordtextBox;
        private Label label3;
        private Label label4;
    }
}