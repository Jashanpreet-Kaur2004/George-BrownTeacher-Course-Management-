using George_BrownTeacher_Course_Management.Business;
using George_BrownTeacher_Course_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace George_BrownTeacher_Course_Management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //button login
            using (var context = new Entities()) ;
            string enteredUsername = textbox1.Text;
            string enteredPassword = textboxPassword.Text;

            if (enteredUsername, enteredPassword)
            { 
                MessageBox.Show("Login successful!");
                // Open the main form or perform other actions

                Form f2 = new CourseAssignmentForm();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }


        }


       

    }
}
