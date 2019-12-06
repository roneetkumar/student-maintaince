using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMaintenance.DataAccess;

namespace StudentMaintenance.Business
{
    class Student
    {
        private int StudentNumber;
        private string LastName;
        private string FirstName;
        private string Email;

        public int StudentNumber1 { get => StudentNumber; set => StudentNumber = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string Email1 { get => Email; set => Email = value; }
        public void SaveStudent(Student stu)
        {
            StudentDB.SaveRecord(stu);
        }
        public List<Student> GetStudentList()
        {
            return (StudentDB.GetRecordList());
        }
        public Student SearchStudent(int id)
        {
            return (StudentDB.SearchRecord(id));
        }
        public List<Student> SearchStudent(string input)
        {
            return (StudentDB.SearchRecord(input));
        }
    }
}
