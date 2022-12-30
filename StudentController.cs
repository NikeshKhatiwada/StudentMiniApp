using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMiniApp
{
    public class StudentController
    {
        public static List<Student> students;
        public static List<AcademicProgram> academicPrograms;
        public static DataSet studentDataSet = new DataSet();
        public static Student? studentInfo;
        public static DataRow? studentDataRow;

        static Form1 form1;

        static StudentController()
        {
            students = StudentDataService.SelectStudents();
            academicPrograms = StudentDataService.SelectAcademicPrograms();
            StudentDataService.GetSelectDataAdapter().Fill(studentDataSet, "student");
            form1 = new Form1();
            form1.Show();
        }

        public void SetNewDataRow()
        {
            studentDataRow = studentDataSet.Tables[0].NewRow();
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student GetStudentInfo()
        {
            return studentInfo;
        }

        public void SetStudentInfo(Student student)
        {
            studentInfo = student;
        }

        public bool SetStudentPhoto(Image photo, int ae)
        {
            int studentIndex = -1;
            if (ae == 2)
            {
                studentIndex = getDataSetStudentIndex();
                if (studentIndex == -1)
                {
                    MessageBox.Show("Error setting image.", "Error");
                    return false;
                }
            }
            try
            {
                studentInfo.Photo = photo;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    photo.Save(memoryStream, photo.RawFormat);
                    byte[] imageBytes = memoryStream.ToArray();
                    //string base64String = Convert.ToBase64String(imageBytes);
                    string base64String = "data:image/" + photo.RawFormat.ToString() + ";base64," + Convert.ToBase64String(imageBytes);
                    if (ae == 2)
                        studentDataSet.Tables[0].Rows[studentIndex][12] = base64String;
                    else if (ae == 1)
                        studentDataRow[12] = base64String;
                    //studentDataSet.Tables[0].Rows[studentIndex][12] = imageBytes;
                }
            }
            catch
            {
                MessageBox.Show("Error setting image.", "Error");
                return false;
            }
            return true;
        }

        public bool SetStudentSignature(Image signature, int ae)
        {
            int studentIndex = -1;
            if (ae == 2)
            {
                studentIndex = getDataSetStudentIndex();
                if (studentIndex == -1)
                {
                    MessageBox.Show("Error setting image.", "Error");
                    return false;
                }
            }
            try
            {
                studentInfo.Signature = signature;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    signature.Save(memoryStream, signature.RawFormat);
                    byte[] imageBytes = memoryStream.ToArray();
                    string base64String = "data:image/" + signature.RawFormat.ToString() + ";base64," + Convert.ToBase64String(imageBytes);
                    if (ae == 2)
                        studentDataSet.Tables[0].Rows[studentIndex][13] = base64String;
                    else if (ae == 1)
                        studentDataRow[13] = base64String;
                }
            }
            catch
            {
                MessageBox.Show("Error setting image.", "Error");
                return false;
            }
            return true;
        }

        public int getDataSetStudentIndex()
        {
            int i = 0;
            foreach (DataRow dataRow in studentDataSet.Tables[0].Rows)
            {
                if (dataRow[0].ToString() == studentInfo.Id.ToString())
                    return i;
                i++;
            }
            return -1;
        }

        public void InsertStudent()
        {
            try
            {
                studentDataRow[1] = studentInfo.Name;
                studentDataRow[2] = studentInfo.FatherName;
                studentDataRow[3] = studentInfo.MotherName;
                studentDataRow[4] = studentInfo.Gender;
                studentDataRow[5] = studentInfo.PermanentAddress;
                studentDataRow[6] = studentInfo.TemporaryAddress;
                studentDataRow[7] = studentInfo.MobileNumber;
                studentDataRow[8] = studentInfo.EmailAddress;
                studentDataRow[9] = studentInfo.AcademicProgram.Id;
                studentDataRow[10] = studentInfo.AcademicYear;
                studentDataRow[11] = studentInfo.RegistrationNumber;
                studentDataSet.Tables[0].Rows.Add(studentDataRow);
                StudentDataService.UpdateStudent(studentDataSet.Tables[0]);
                MessageBox.Show("Inserted");
                UpdateStudentDetails();
            }
            catch
            {
                MessageBox.Show("Error inserting student.");
            }
        }

        public void UpdateStudent()
        {
            int studentIndex = getDataSetStudentIndex();
            try
            {
                studentDataSet.Tables[0].Rows[studentIndex][1] = studentInfo.Name;
                studentDataSet.Tables[0].Rows[studentIndex][2] = studentInfo.FatherName;
                studentDataSet.Tables[0].Rows[studentIndex][3] = studentInfo.MotherName;
                studentDataSet.Tables[0].Rows[studentIndex][4] = studentInfo.Gender;
                studentDataSet.Tables[0].Rows[studentIndex][5] = studentInfo.PermanentAddress;
                studentDataSet.Tables[0].Rows[studentIndex][6] = studentInfo.TemporaryAddress;
                studentDataSet.Tables[0].Rows[studentIndex][7] = studentInfo.MobileNumber;
                studentDataSet.Tables[0].Rows[studentIndex][8] = studentInfo.EmailAddress;
                studentDataSet.Tables[0].Rows[studentIndex][9] = studentInfo.AcademicProgram.Id;
                studentDataSet.Tables[0].Rows[studentIndex][10] = studentInfo.AcademicYear;
                studentDataSet.Tables[0].Rows[studentIndex][11] = studentInfo.RegistrationNumber;
                StudentDataService.UpdateStudent(studentDataSet.Tables[0]);
                MessageBox.Show("Updated");
                UpdateStudentDetails();
            }
            catch
            {
                MessageBox.Show("Error updating student.");
            }
        }

        public void DeleteStudent()
        {
            int studentIndex = getDataSetStudentIndex();
            try
            {
                studentDataSet.Tables[0].Rows[studentIndex].Delete();
                StudentDataService.UpdateStudent(studentDataSet.Tables[0]);
                MessageBox.Show("Deleted");
                UpdateStudentDetails();
            }
            catch
            {
                MessageBox.Show("Error deleting student.");
            }
        }

        public void UpdateStudentDetails()
        {
            students = StudentDataService.SelectStudents();
            academicPrograms = StudentDataService.SelectAcademicPrograms();
            StudentDataService.GetSelectDataAdapter().Fill(studentDataSet, "student");
            form1.UpdateStudentList();
            form1.form0.ShowStudentInfo();
        }
    }
}
