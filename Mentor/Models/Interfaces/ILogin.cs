using Tutor_Finder.Models;

namespace Mentor.Models.Interfaces
{
    public interface ILogin
    {
        public Student StudentLogin(string username, string password);
       // public bool TutorLogin(string username, string password);
    }
}
