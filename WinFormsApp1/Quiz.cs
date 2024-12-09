﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace WinFormsApp1
{
    public partial class Quiz : Form
    {
        List<string> selectedFilePaths = new List<string>();
        private int userID;

        public Quiz()
        {
            InitializeComponent();
            panelLeft.Height = button2.Height;
            panelLeft.Top = button2.Top;
        }

        public Quiz(int userID) : this()
        {
            this.userID = userID;
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            List<string> courseNames = GetCourseNamesFromDatabase(userID);
            Course_comboBox2.DataSource = courseNames;

            List<string> studentIDs = GetStudentIDsFromDatabase();

            Student_comboBox3.DataSource = studentIDs;
        }

        private void Course_comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = Course_comboBox2.SelectedItem.ToString();
            List<string> sectionNames = GetSectionsForCourse(userID, selectedCourse);

            Section_comboBox1.DataSource = sectionNames;
        }


        private List<string> GetCourseNamesFromDatabase(int userID)
        {
            List<string> courseNames = new List<string>();

            var connectionString = Constant.ConnectionString;
            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            string query = "Select DISTINCT c.CourseName from Enrollment e JOIN Courses c on c.CourseID = e.CourseID where e.UserID = '" + userID + "' ";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string courseName = reader["CourseName"].ToString();
                courseNames.Add(courseName);
            }

            reader.Close();

            return courseNames;
        }


        private List<string> GetSectionsForCourse(int userID, string courseName)
        {
            List<string> sectionNames = new List<string>();

            var connectionString = Constant.ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                sqlconn.Open();

                string query = "SELECT Section FROM Enrollment WHERE UserID = '" + userID + "' AND CourseID IN (SELECT CourseID FROM Courses WHERE CourseName = '" + courseName + "')";
                using (SqlCommand cmd = new SqlCommand(query, sqlconn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string sectionName = reader["Section"].ToString();
                            sectionNames.Add(sectionName);
                        }
                    }
                }
            }

            return sectionNames;
        }

        private List<string> GetStudentIDsFromDatabase()
        {
            List<string> studentIDs = new List<string>();

            var connectionString = Constant.ConnectionString;
            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            string query = "SELECT UserID FROM Users WHERE UserType = 'Student' ";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string studentID = reader["UserID"].ToString();
                studentIDs.Add(studentID);
            }

            return studentIDs;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panelLeft.Height = button1.Height;
            panelLeft.Top = button1.Top;

            this.Hide();
            var form3 = new Assignmnet(userID);
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panelLeft.Height = button2.Height;
            panelLeft.Top = button2.Top;
            panelLeft.BringToFront();

            //this.Hide();
            //var form4 = new Quiz();
            //form4.Closed += (s, args) => this.Close();
            //form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelLeft.Height = button3.Height;
            panelLeft.Top = button3.Top;

            this.Hide();
            var form3 = new Notes(userID);
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelLeft.Height = button4.Height;
            panelLeft.Top = button4.Top;
            panelLeft.BringToFront();

            this.Hide();
            var form9 = new Announcement(userID);
            form9.Closed += (s, args) => this.Close();
            form9.Show();
        }

        private void showFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files|*.pdf";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();

                foreach (string file in openFileDialog.FileNames)
                {
                    listBox1.Items.Add(file);
                    selectedFilePaths.Add(file); 
                }
            }
        }

        //upload button
        private void button6_Click(object sender, EventArgs e)
        {
            var connectionString = Constant.ConnectionString;
            SqlConnection sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            //get user input
            var studentIDstr = Student_comboBox3.Text;
            var section = Section_comboBox1.Text;

            if (listBox1.SelectedItem != null)
            {
                string selectedFileName = listBox1.SelectedItem.ToString();


                //MessageBox.Show("Selected file: " + selectedFilePath);

                //get courseID of user entered coursename from courses table
                var coursename = Course_comboBox2.Text;
                string query = "Select TOP 1 CourseID from Courses where CourseName = '" + coursename + "'";
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string CourseIDstr = reader["CourseID"].ToString();
                    reader.Close();

                    //convert CourseIDstr to integer so it can be inserted into assignment table
                    int courseID;
                    if (int.TryParse(CourseIDstr, out courseID))
                    {
                        int studentID;
                        if (int.TryParse(studentIDstr, out studentID))
                        {
                            string selectedFilePathsConcatenated = string.Join(";", selectedFilePaths);
                            //insert courseid, sectiom, deadline
                            /* SqlCommand sqlcomm11 = new SqlCommand("insert into Quiz " +
                                    "values('" + studentID + "' , '" + section + "', '" + courseID + "' , '" + selectedFilePathsConcatenated + "' )", sqlconn);  */
                            SqlCommand sqlcomm11 = new SqlCommand("insert into Quiz values(@studentID, @section, @courseID, @selectedFilePathsConcatenated)", sqlconn);
                            sqlcomm11.Parameters.AddWithValue("@studentID", studentID);
                            sqlcomm11.Parameters.AddWithValue("@section", section);
                            sqlcomm11.Parameters.AddWithValue("@courseID", courseID);
                            sqlcomm11.Parameters.AddWithValue("@selectedFilePathsConcatenated", selectedFilePathsConcatenated);

                            var ifError11 = sqlcomm11.ExecuteNonQuery();
                            if (ifError11 == 0)
                            {
                                MessageBox.Show("Error");
                            }
                            else
                            {
                                MessageBox.Show("Successfully uploaded!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to convert studentID string to integer");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to convert courseID string to integer");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a file from the list.");
                }
            }
        }

        //logout button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form9 = new login();
            form9.Closed += (s, args) => this.Close();
            form9.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}