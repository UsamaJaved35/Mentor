using Mentor.Models;

namespace Mentor.Models.Interfaces
{
    public interface IStudent
    {
        public bool AddStudent(Student s);
        //public Student GetStudent(Login l);
        public bool UpdateStudent(Student s, List<IFormFile> postedFiles);
        public string imageExists(string email);
        public bool sendRequest(string email, int id);
       // public void DeleteStudent();
       //public IStudent GetStudent();
    }
}
