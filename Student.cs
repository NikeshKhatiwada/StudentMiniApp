using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMiniApp
{
    public class Student
    {
        [System.ComponentModel.Browsable(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string FatherName { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string MotherName { get; set; }
        public char Gender { get; set; }
        public string PermanentAddress { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string TemporaryAddress { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string MobileNumber { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string EmailAddress { get; set; }
        public AcademicProgram AcademicProgram { get; set; }
        public string AcademicYear { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string RegistrationNumber { get; set; }
        [System.ComponentModel.Browsable(false)]
        public Image Photo { get; set; }
        [System.ComponentModel.Browsable(false)]
        public Image Signature { get; set; }
    }
}
