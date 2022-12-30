using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentMiniApp
{
    public partial class Form0 : Form
    {
        Student student;
        public Form0()
        {
            InitializeComponent();
        }

        private void mobileNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailAddressInfo_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm();
            //var dataRow = StudentController.studentDataSet.Tables[0].Rows[0];
            addEditForm.SetData();
            addEditForm.ShowUpdateFeatures();
            addEditForm.ShowDialog();
        }

        public void ShowStudentInfo()
        {
            student = (new StudentController()).GetStudentInfo();
            studentPhotoBox.Image = student.Photo;
            nameInfo.Text = student.Name;
            signatureBox.Image = student.Signature;
            if (student.Gender == 'M')
                genderInfo.Text = "Male";
            else
                genderInfo.Text = "Female";
            fatherNameInfo.Text = student.FatherName;
            mobileNumberInfo.Text = student.MotherName;
            permanentAddressInfo.Text = student.PermanentAddress;
            temporaryAddressInfo.Text = student.TemporaryAddress;
            mobileNumberInfo.Text = student.MobileNumber;
            emailAddressInfo.Text = student.EmailAddress;
            academicProgramInfo.Text = student.AcademicProgram.Name;
            academicYearInfo.Text = student.AcademicYear;
            registrationNumberInfo.Text = student.RegistrationNumber;
        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }
    }
}
