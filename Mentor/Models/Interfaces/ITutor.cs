using Tutor_Finder.Models;

namespace Mentor.Models.Interfaces
{
    public interface ITutor
    {
        public bool AddTutor(Tutor t, List<IFormFile> postedFiles);
    }
}
