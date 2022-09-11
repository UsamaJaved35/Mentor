using Mentor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Mentor.Models;

namespace Mentor.Models.Repositories
{
    public class LoginRepository : ILogin
    {
        public Student StudentLogin(string username, string password)
        {
            var db = new StudentContext();
            Student myUser = db.Students.FirstOrDefault
               (u => u.Email.Equals(username) && u.Password.Equals(password));
            return myUser;
        }
        public Tutor TutorLogin(string username, string password)
        {
            var db = new StudentContext();
            Tutor myUser = db.Tutors.FirstOrDefault
               (u => u.Email.Equals(username) && u.Password.Equals(password)
               && u.Status == true);
            return myUser;
        } 
    }
}
