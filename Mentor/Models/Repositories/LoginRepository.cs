using Mentor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Tutor_Finder.Models;

namespace Mentor.Models.Repositories
{
    public class LoginRepository:ILogin
    {
        public Student StudentLogin(string username, string password)
        {
            var db=new StudentContext();
            Student myUser = db.Students.FirstOrDefault
               (u => u.Email.Equals(username) && u.Password.Equals(password));
            //var userId = (int)Session["userId"]; // I have made a breakpoint and confirm that the user get it's unique Id.
            //var user = db.Students(userId);
            //Student user = dataContext.RegisterUsers.Where
            //  (query => query.Email.Equals(model.Email) 
            // && query.Password.Equals(model.Password)).SingleOrDefault();
            
    
                //User was found
                //Proceed with your login process...
                return myUser;
   //         }  
        }
        //public bool TutorLogin(string username, string password)
        //{
        //    return false;
        //}

    }
}
