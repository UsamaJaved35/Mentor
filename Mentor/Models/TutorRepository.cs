using System.Linq;
namespace Tutor_Finder.Models;
public class TutorRepository
{
    public  void AddTutor(Tutor t)
    {
        //var db = new TutorFinderContext();
        //db.Tutors.Add(t);
        //await db.SaveChangesAsync();
    }
    public  bool Login(Tutor t)
    {
      //  var db = new TutorFinderContext();
      ////  var auth="";
      //  var pass = from m in db.Tutors where m.Email == t.Email where m.Password==t.Password select m.Id;
      //  //foreach(int query in pass)
      //  //{
      //  //    auth= query;

      //  //}
      //  if (pass.Any())
      //  {
      //      return true;
      //  }
      //  else
            return false;
    }
}