namespace Mentor.Models
{
    public class Student_Tutor
    {
        public int Id { get; set; }
        public int SId { get; set; }
        public Student ?Student { get; set; }

        public int TId { get; set; }
        public Tutor ?Tutor{ get; set; }
        public bool requestStatus { get; set; } = false;
    }
}