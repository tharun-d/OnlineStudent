using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class Common
    {
        public readonly string user_register = "insertuser @fname,@lname,@uname,@pwd,@gender,@email,@phno,@def";
        public readonly string valid_user = "validuser @uname,@pwd";
        public readonly string get_user = "get_user @one";
        public readonly string get_email = "get_email @two";
        public readonly string get_phno = "get_phno @three";
        public readonly string get_details = "sp_getdetails @one,@two,@three";
        public readonly string sp_changepassword = "Sp_changepassword @four,@five";
        public readonly string getting_details = "gettingdetails @name";
        public readonly string edit_profile = "editprofile @one,@two,@three,@four,@five,@name";
        public readonly string get_coursecount = "getcoursecount";
        public readonly string getting_SubjectNames = "GettingSubjects";
        public readonly string getting_RandomQuestions = "RandomQuestions @SubjectName";
        public readonly string get_courseid = "getcourseid @cname";
        public readonly string UpdateReportsTable = "UpdateReportsTableProcedure @UserName,@DateOfExam,@SubjectName,@CorrectAnswers,@Percentage,@Status";
        public readonly string set_userstatus = "set_userstatus @name";
        public readonly string status_zero = "set_user_status_to_zero @name";
        public readonly string get_userstatus = "get_status @name";
        public readonly string ExamsHistory = "ExamsHistory @UserName";

    }
}
