using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StudentMaintenance.DataAccess;
using StudentMaintenance.Business;
using System.Windows.Forms;

namespace StudentMaintenance.DataAccess
{
    class StudentDB
    {
        public static void SaveRecord(Student stu)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO student(StudentNumber,LastName,FirstName,Email)" +
                                " VALUES (@StudentNumber,@LastName,@FirstName,@Email)";
            cmd.Parameters.AddWithValue("@StudentNumber", stu.StudentNumber1);
            cmd.Parameters.AddWithValue("@LastName", stu.LastName1);
            cmd.Parameters.AddWithValue("@FirstName", stu.FirstName1);
            cmd.Parameters.AddWithValue("@Email", stu.Email1);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }
        public static List<Student> GetRecordList()
        {
            List<Student> listStu = new List<Student>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM student", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Student stu;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    stu = new Student();//create the object here, not outside
                    stu.StudentNumber1 = Convert.ToInt32(reader["StudentNumber"]);
                    stu.LastName1 = reader["LastName"].ToString();
                    stu.FirstName1 = reader["FirstName"].ToString();
                   
                    stu.Email1 = reader["Email"].ToString();
                    listStu.Add(stu);

                }
            }
            else
            {
                listStu = null;
            }

            return listStu;
        }
        public static Student SearchRecord(int searchId)
        {
            Student stu = new Student();
            SqlConnection sqlConn = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandText = "SELECT * from student " +
                                "WHERE StudentNumber = @StudentNumber ";
            cmd.Parameters.AddWithValue("@StudentNumber", searchId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                stu.StudentNumber1 = Convert.ToInt32(reader["EmployeeId"]);
                stu.LastName1 = reader["LastName"].ToString();
                stu.FirstName1 = reader["FirstName"].ToString();
               
                stu.Email1 = reader["Email"].ToString();

            }
            else
            {
                stu = null;
            }

            return stu;
        }
        public static List<Student> SearchRecord(string input)
        {
            List<Student> listStu = new List<Student>();
            List<Student> listStu1 = new List<Student>();
            Student stu = new Student();
            listStu = stu.GetStudentList();
            Student stu2;
            if (listStu != null)
            {
                foreach (Student anStu in listStu)
                {
                    if ((input.ToUpper() == anStu.LastName1.ToUpper()))
                    {
                        stu2 = new Student();
                        stu2.StudentNumber1 = Convert.ToInt32(anStu.StudentNumber1);
                        stu2.LastName1 = anStu.LastName1;
                        stu2.FirstName1 = anStu.FirstName1;
                       
                        stu2.Email1 = anStu.Email1;
                        listStu1.Add(stu2);
                    }
                }

            }

            return listStu1;


        }
    }
}
