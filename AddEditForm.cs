using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentMiniApp
{
    public partial class AddEditForm : Form
    {
        public DataRow dataRow;
        public AddEditForm()
        {
            InitializeComponent();
            foreach (AcademicProgram academicProgram in StudentController.academicPrograms)
            {
                this.academicProgramComboBox.Items.Add(academicProgram.Name);
            }
            for (int i = 2030; i <= 2090; ++i)
            {
                this.academicYearComboBox.Items.Add(i.ToString());
            }
            new StudentController().SetNewDataRow();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {

        }

        public void SetData()
        {
            foreach (DataRow dataRow in StudentController.studentDataSet.Tables[0].Rows)
            {
                if (dataRow[0].ToString() == StudentController.studentInfo.Id.ToString())
                {
                    //var base64PhotoByte = (byte[])dataRow[12];
                    //var text = Convert.ToBase64String(base64PhotoByte);
                    /*
                    using(var ms = new MemoryStream((byte[])dataRow[12]))
                    {
                        this.studentPhotoBox.Image = Image.FromStream(ms);
                    }
                    */
                    //var base64PhotoData = Regex.Match(text, @"data:(?<type>.+?);base64,(?<data>.+)").Groups["data"].Value;
                    //var base64SignatureData = Regex.Match(Convert.ToBase64String((byte[])dataRow[12]), @"data:(?<type>.+?);base64,(?<data>.+)").Groups["data"].Value;
                    //this.studentPhotoBox.Image = new Bitmap(new MemoryStream(Convert.FromBase64String(text)));
                    this.studentPhotoBox.Image = StudentController.studentInfo.Photo;
                    this.signatureBox.Image = StudentController.studentInfo.Signature;
                    this.nameInputBox.Text = dataRow[1].ToString();
                    this.fatherNameInputBox.Text = dataRow[2].ToString();
                    this.motherNameInputBox.Text = dataRow[3].ToString();
                    if (dataRow[4].ToString() == "M")
                        this.genderMaleRadioButton.Checked = true;
                    else
                        this.genderFemaleRadioButton.Checked = true;
                    this.permanentAddressInputBox.Text = dataRow[5].ToString();
                    this.temporaryAddressInputBox.Text = dataRow[6].ToString();
                    this.mobileNumberInputBox.Text = dataRow[7].ToString();
                    this.emailAddressInputBox.Text = dataRow[8].ToString();
                    foreach (string item in academicProgramComboBox.Items)
                    {
                        foreach (AcademicProgram academicProgram in StudentController.academicPrograms)
                        {
                            if (item == academicProgram.Name && academicProgram.Id.ToString() == dataRow[9].ToString())
                                academicProgramComboBox.SelectedIndex = academicProgramComboBox.Items.IndexOf(item);
                        }
                    }
                    foreach (string item in academicYearComboBox.Items)
                    {
                        if (item == dataRow[10].ToString())
                            academicYearComboBox.SelectedIndex = academicYearComboBox.Items.IndexOf(item);
                    }
                    this.registrationNumberInputBox.Text = dataRow[11].ToString();
                }
            }
        }

        public void ShowInsertFeatures()
        {
            this.addEditTitle.Text = "Add New Student";
        }

        public void ShowUpdateFeatures()
        {
            this.addEditTitle.Text = "Edit Existing Student";
            this.insertButton.Visible = false;
            this.updateButton.Visible = true;
            this.deleteButton.Visible = true;
        }

        private void selectImageButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Image";
            dialog.Filter = "Jpeg Files|*.jpg;*.jpeg;*.jpe;*.jif;*.jfif;*.jfi;*.jp2;*.j2k;*.jpf;*.jpx;*.jpm;*.mj2";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileSize = new FileInfo(dialog.FileName).Length;
                if (fileSize > 61440)
                {
                    MessageBox.Show("File size should not be greater than 60 KB.", "Large file");
                    return;
                }
                Bitmap imageBitmap = new Bitmap(dialog.FileName);
                int i = 0;
                if (addEditTitle.Text == "Add New Student")
                {
                    i = 1;
                }
                else if (addEditTitle.Text == "Edit Existing Student")
                    i = 2;
                if (new StudentController().SetStudentPhoto(imageBitmap, i) == true)
                {
                    studentPhotoBox.Image = StudentController.studentInfo.Photo;
                }
                else
                {
                    return;
                }
            }
        }

        private void selectImageButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Image";
            dialog.Filter = "Jpeg Files|*.jpg;*.jpeg;*.jpe;*.jif;*.jfif;*.jfi;*.jp2;*.j2k;*.jpf;*.jpx;*.jpm;*.mj2";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileSize = new FileInfo(dialog.FileName).Length;
                if (fileSize > 61440)
                {
                    MessageBox.Show("File size should not be greater than 60 KB.", "Large file");
                    return;
                }
                Bitmap imageBitmap = new Bitmap(dialog.FileName);
                int i = 0;
                if (addEditTitle.Text == "Add New Student")
                {
                    i = 1;
                }
                else if (addEditTitle.Text == "Edit Existing Student")
                    i = 2;
                if (new StudentController().SetStudentSignature(imageBitmap, i) == true)
                {
                    signatureBox.Image = StudentController.studentInfo.Signature;
                }
                else
                {
                    return;
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Student studentInfo = (new StudentController()).GetStudentInfo();
            if (((Button)sender).Name == "insertButton")
            {
                studentInfo.AcademicProgram = new AcademicProgram();
            }
            studentInfo.Name = this.nameInputBox.Text;
            studentInfo.FatherName = this.fatherNameInputBox.Text;
            studentInfo.MotherName = this.motherNameInputBox.Text;
            if (this.genderMaleRadioButton.Checked == true)
            {
                studentInfo.Gender = 'M';
            }
            else
            {
                studentInfo.Gender = 'F';
            }
            studentInfo.PermanentAddress = this.permanentAddressInputBox.Text;
            studentInfo.TemporaryAddress = this.temporaryAddressInputBox.Text;
            studentInfo.MobileNumber = this.mobileNumberInputBox.Text;
            studentInfo.EmailAddress = this.emailAddressInputBox.Text;
            foreach (AcademicProgram academicProgram in StudentController.academicPrograms)
            {
                if (academicProgram.Name == this.academicProgramComboBox.Text)
                {
                    studentInfo.AcademicProgram.Id = academicProgram.Id;
                    studentInfo.AcademicProgram.Name = academicProgram.Name;
                }
            }
            studentInfo.AcademicYear = this.academicYearComboBox.SelectedItem.ToString();
            studentInfo.RegistrationNumber = this.registrationNumberInputBox.Text;
            (new StudentController()).SetStudentInfo(studentInfo);
            if (((Button)sender).Name == "insertButton")
            {
                (new StudentController()).InsertStudent();
            }
            else if (((Button)sender).Name == "updateButton")
            {
                (new StudentController()).UpdateStudent();
            }
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            (new StudentController()).DeleteStudent();
            this.Close();
        }
    }
}
