using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Student
    {
        public int Id { get; set; }
        private string name_student, familia_student, login_student, password_student, dataofbith_student, email_student;
        public string Name_student{ get { return name_student; } set { name_student = value; } }
        public string Familia_student { get { return familia_student; } set { familia_student = value; } }
        public string Login_student { get { return login_student; } set { login_student = value; } }
        public string Password_student { get { return password_student; } set { password_student = value; } }
        public string Dataofbith_student { get { return dataofbith_student; } set { dataofbith_student = value; } }
        public string Email_student { get { return email_student; } set { email_student = value; } }
        public List<Result> Results { get; set; }

        public Student()
        {

        }
        public Student(string name_student, string familia_student, string login_student, string password_student, string dataofbith_student, string email_student)
        {
            this.name_student = name_student;
            this.familia_student = familia_student;
            this.login_student = login_student;
            this.password_student = password_student;
            this.dataofbith_student = dataofbith_student;
            this.email_student = email_student;
        }
        public override string ToString()
        {
            return "Здравствуйте, "+ Name_student+"  !";
        }
    }
}
