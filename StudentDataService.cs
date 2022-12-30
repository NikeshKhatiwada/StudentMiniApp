using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentMiniApp
{
    public static class StudentDataService
    {
        static string connectionString = "SERVER=localhost; DATABASE=student_database; UID=root; Password=my_database2";
        static MySqlConnection? connection;
        static MySqlCommand? command;
        static MySqlDataAdapter? dataAdapter;
        static MySqlCommandBuilder? sqlCommandBuilder;
        private static void InitConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public static List<Student> SelectStudents()
        {
            if (connection == null)
            {
                InitConnection();
            }
            string selectStudents = "SELECT * FROM student INNER JOIN academicprogram ON student.AcademicProgramId = academicprogram.Id;";
            command = new MySqlCommand(selectStudents, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            List<Student> students = new List<Student>();
            byte[] bytes;
            while (dataReader.Read())
            {
                Student student = new Student();
                student.Id = dataReader.GetInt32(0);
                student.Name = dataReader.GetString(1);
                student.FatherName = dataReader.GetString(2);
                student.MotherName = dataReader.GetString(3);
                student.Gender = dataReader.GetChar(4);
                student.PermanentAddress = dataReader.GetString(5);
                student.TemporaryAddress = dataReader.GetString(6);
                student.MobileNumber = dataReader.GetString(7);
                student.EmailAddress = dataReader.GetString(8);
                student.AcademicProgram = new AcademicProgram
                {
                    Id = dataReader.GetInt32(9),
                    Name = dataReader.GetString(15)
                };
                student.AcademicYear = dataReader.GetString(10);
                student.RegistrationNumber = dataReader.GetString(11);
                var base64PhotoData = Regex.Match(dataReader.GetString(12), @"data:(?<type>.+?);base64,(?<data>.+)").Groups["data"].Value;
                var base64SignatureData = Regex.Match(dataReader.GetString(13), @"data:(?<type>.+?);base64,(?<data>.+)").Groups["data"].Value;
                student.Photo = new Bitmap(new MemoryStream(Convert.FromBase64String(base64PhotoData)));
                student.Signature = new Bitmap(new MemoryStream(Convert.FromBase64String(base64SignatureData)));
                students.Add(student);
            }
            dataReader.Close();
            return students;
        }

        public static List<AcademicProgram> SelectAcademicPrograms()
        {
            if (connection == null)
            {
                InitConnection();
            }
            string selectStudents = "SELECT * FROM academicprogram;";
            command = new MySqlCommand(selectStudents, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            List<AcademicProgram> academicPrograms = new List<AcademicProgram>();
            while (dataReader.Read())
            {
                AcademicProgram academicProgram = new AcademicProgram();
                academicProgram.Id = dataReader.GetInt32(0);
                academicProgram.Name = dataReader.GetString(1);
                academicPrograms.Add(academicProgram);
            }
            dataReader.Close();
            return academicPrograms;
        }

        public static MySqlDataAdapter GetSelectDataAdapter()
        {
            if (connection == null)
            {
                InitConnection();
            }
            string selectStudents = "SELECT * FROM student;";
            command = new MySqlCommand(selectStudents);
            dataAdapter = new MySqlDataAdapter(selectStudents, connection);
            sqlCommandBuilder = new MySqlCommandBuilder(dataAdapter);
            //dataAdapter.InsertCommand = (MySqlCommand)sqlCommandBuilder.GetInsertCommand(true);
            /*
            string updateStudent = "UPDATE student SET Name='@Name', FatherName='@FatherName', MotherName='@MotherName' WHERE ID='@Id';";
            command = new MySqlCommand(updateStudent);
            dataAdapter.UpdateCommand = new MySqlCommand(updateStudent, connection);
            dataAdapter.UpdateCommand.Parameters.Add("@Name", MySqlDbType.VarString, 60, "Name");
            dataAdapter.UpdateCommand.Parameters.Add("@FatherName", MySqlDbType.VarString, 60, "FatherName");
            dataAdapter.UpdateCommand.Parameters.Add("@MotherName", MySqlDbType.VarString, 60, "MotherName");
            dataAdapter.UpdateCommand.Parameters.Add("@Id", MySqlDbType.Int32, 10, "Id");
            */
            return dataAdapter;
        }

        public static void InsertStudent(Student student)
        {
            if(connection == null)
            {
                InitConnection();
            }
            string insertStudent = "INSERT INTO student(name, father_name, mother_name, gender, permanent_address, temporary_address, mobile_number, email, academic_program_id, academic_year, registration_number, photo, signature)" +
                " VALUES (@Name, @FatherName, @MotherName, @Gender, @PermanentAddress, @TemporaryAddress, @MobileNumber, @Email, @AcademicProgramId, @AcademicYear, @RegistrationNumber, @Photo, @Signature);";
            command = new MySqlCommand(insertStudent);
            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@FatherName", student.FatherName);
            command.Parameters.AddWithValue("@MotherName", student.MotherName);
            command.Parameters.AddWithValue("@Gender", student.Gender);
            command.Parameters.AddWithValue("@PermanentAddress", student.PermanentAddress);
            command.Parameters.AddWithValue("@TemporaryAddress", student.TemporaryAddress);
            command.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);
            command.Parameters.AddWithValue("Email", student.EmailAddress);
            command.Parameters.AddWithValue("@AcademicProgramId", student.AcademicProgram.Id);
            command.Parameters.AddWithValue("AcademicYear", student.AcademicYear);
            command.Parameters.AddWithValue("RegistrationNumber", student.RegistrationNumber);
            command.ExecuteNonQuery();
        }

        public static void UpdateStudent(DataTable studentDataTable)
        {
            if(connection == null)
            {
                InitConnection();
            }
            dataAdapter.Update(studentDataTable);
        }
    }
}
