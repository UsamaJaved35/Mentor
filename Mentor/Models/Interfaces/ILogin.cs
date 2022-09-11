using Mentor.Models;

namespace Mentor.Models.Interfaces
{
    public interface ILogin
    {
        public Student StudentLogin(string username, string password);
        public Tutor TutorLogin(string username, string password);
    }
}
