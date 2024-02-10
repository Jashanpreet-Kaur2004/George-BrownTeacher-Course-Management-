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
using System.Xml.Linq;

namespace George_BrownTeacher_Course_Management.Business
{
    public partial class CourseAssignmentForm : Form
    {
        public CourseAssignmentForm()
        {
            InitializeComponent();
        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
        private void addTeachersToDataList()
        {
            // select Teachers from database 
            try
            {
                using (var context = new Entities())
                {
                    var selectTeacher = from Teacher in context.Teachers  select Teacher ;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("TeacherID");
                    dt.Columns.Add("FirstName");
                    dt.Columns.Add("LastName");
                    dt.Columns.Add("Email");

                    foreach (var emp in selectTeacher)
                    {
                        dt.Rows.Add(emp.TeacherId , emp.FirstName, emp.LastName
                                    , emp.Email);
                    }

                    dataGridView1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void addCoursesToDataList()
        {
            // select Courses from database 
            try
            {
                using (var context = new Entities())
                {
                    var selectCourse = from Cours in context.Courses select Cours;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CourseNumber");
                    dt.Columns.Add("CourseTitle");
                    dt.Columns.Add("Duration");

                    foreach (var s in selectCourse)
                    {
                        dt.Rows.Add(s.CourseNumber, s.CourseTitle , s.Duration_hours_);
                                   
                    }

                    dataGridView2.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        


        private void addTeachersCourseToDataList()
        { 
            // select TeacherCourses from database 
            try
            {
                using (var context = new Entities())
                {
                    var selectTeacherCourse = from TeachersCours in context.TeachersCourses select TeachersCours;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CourseNumber");
                    dt.Columns.Add("CourseTitle");
                    dt.Columns.Add("TeacherId");
                    dt.Columns.Add("FirstName");

                    foreach (var s in selectTeacherCourse)
                    {
                        dt.Rows.Add(s.CourseNumber, s.CourseTitle, s.TeacherId , s.FirstName);

                    }

                    dataGridView3.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    // add Teacher to database 
                    var teacherToAdd = new Teacher();
                    teacherToAdd.TeacherId  = Int32.Parse(textboxTeacherid.Text);
                    teacherToAdd.FirstName = textBoxFirstName.Text;
                    teacherToAdd.LastName = textboxLastName.Text;
                    teacherToAdd.Email = textboxemail.Text;

                    context.Teachers.Add(teacherToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Teacher Added Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersToDataList();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new Entities())
                {
                    var TeacherToEdit = from Teacher 
                                        in context.Teachers 
                                    where Teacher.TeacherId.ToString() == textboxTeacherid.Text
                                    select Teacher ;

                    foreach (var s in TeacherToEdit)
                    {
                        s.FirstName = textBoxFirstName.Text;
                        s.LastName = textboxLastName.Text;
                        s.Email = (textboxemail.Text);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Teacher Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersToDataList();                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var teacherTodelete = from Teacher
                                          in context.Teachers
                                          where Teacher.TeacherId.ToString() == textboxTeacherid.Text
                                          select Teacher;

                    foreach (var s in teacherTodelete)
                    {
                        context.Teachers.Remove(s);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Teacher Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersToDataList();
                }
            }

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var TeacherToserach = from Teacher
                                          in context.Teachers
                                      where Teacher.TeacherId.ToString() == textBoxsearchid.Text
                                      select Teacher;

                    foreach (var S in TeacherToserach)
                    {
                        label19.Text = S.FirstName + " " + S.LastName + " ";
                        label4.Text =  S.Email;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new Entities())
                {
                    // add Coueses to database 
                    var courseToAdd = new Cours();
                    courseToAdd.CourseNumber =textBoxCoursenumber.Text;
                    courseToAdd.CourseTitle  = textBoxCoursetitle.Text;
                    courseToAdd.Duration_hours_  = Int32.Parse(textBoxdurationhours.Text);

                    context.Courses.Add(courseToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Course Added Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCoursesToDataList();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEditCourse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var CourseToEdit = from Cours
                                        in context.Courses
                                        where Cours.CourseNumber.ToString() == textBoxCoursenumber.Text
                                        select Cours;

                    foreach (var s in CourseToEdit)
                    {
                        s.CourseNumber = textBoxCoursenumber .Text;
                        s.CourseTitle = textBoxCoursetitle .Text;
                        s.Duration_hours_ = Int32.Parse(textBoxdurationhours.Text);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCoursesToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeleteCourse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var courseTodelete = from Cours
                                          in context.Courses
                                          where Cours.CourseNumber.ToString() == textboxTeacherid.Text
                                          select Cours;

                    foreach (var s in courseTodelete)
                    {
                        context.Courses.Remove(s);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCoursesToDataList();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSearchCourse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var CourseToserach = from Cours
                                          in context.Courses
                                          where Cours.CourseNumber.ToString() == textBoxsearchid.Text
                                          select Cours;

                    foreach (var S in CourseToserach)
                    {
                        label10.Text = S.CourseTitle  ;
                        label8.Text = S.CourseNumber ;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd3_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new Entities())
                {
                    // add TeacherCourse to database 
                    var teacherCourseToAdd = new TeachersCours();
                    teacherCourseToAdd.CourseNumber  = textBoxcourseNumber3.Text;
                    teacherCourseToAdd.CourseTitle = textBoxCoursetitle3.Text;
                    teacherCourseToAdd.TeacherId  = Int32.Parse(textBoxTeacherid3.Text);
                    teacherCourseToAdd.FirstName  = textBoxfirstname3.Text;

                    context.TeachersCourses.Add(teacherCourseToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"TeacherCourse Added Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersCourseToDataList();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var TeachercourseToEdit = from TeachersCours
                                        in context.TeachersCourses
                                        where TeachersCours.TeacherId.ToString() == textBoxcourseNumber3.Text
                                        select TeachersCours;

                    foreach (var s in TeachercourseToEdit)
                    {
                        s.CourseTitle = textBoxCoursetitle3.Text;
                        s.TeacherId = Int32.Parse(textBoxTeacherid3.Text);
                        s.FirstName = (textBoxfirstname3.Text);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"TeacherCourse Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersCourseToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonDelete3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var TeachercourseTodelete = from TeachersCours
                                          in context.TeachersCourses
                                         where TeachersCours.CourseNumber.ToString() == textBoxcourseNumber3.Text
                                         select TeachersCours;

                    foreach (var s in TeachercourseTodelete)
                    {
                        //context.Courses.Remove(s);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"TeacherCourse Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCoursesToDataList();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
