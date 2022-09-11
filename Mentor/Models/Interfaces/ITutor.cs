using Mentor.Models;

namespace Mentor.Models.Interfaces
{
    public interface ITutor
    {
        public bool AddTutor(Tutor t, List<IFormFile> postedFiles);
        public bool UpdateTutor(Tutor t, List<IFormFile> postedFiles);
        public List<Tutor> GetAllTutors();
        public List<Student> SeeRequests(string id);
        public int getIdByEmail(string email);
        public bool requestStatus(bool status,int id);
    }
}
