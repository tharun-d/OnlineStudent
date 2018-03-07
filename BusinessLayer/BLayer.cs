using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLayer
    {
        Register Register_ob = new Register();
        ForgotPassword forgotpassword_ob = new ForgotPassword();
        UserProfile userprofile_object = new UserProfile();
        
        Dal data_object = new Dal();
        public string register(string firstname, string lastname, string username, string password, string gender, string email, string phno,int def)
        {
            

                Register_ob.firstname = firstname;
                Register_ob.lastname = lastname;
                Register_ob.username = username;
                Register_ob.password = password;
                Register_ob.gender = gender;
                Register_ob.email = email;
                Register_ob.phno = phno;
                Register_ob.def = def;

                 return data_object.RegisterValidation(Register_ob);

               

        }

        public string Login(string username, string password)
        {
            Register_ob.username = username;
            Register_ob.password = password;
            string result =  data_object.ValidUser(Register_ob);
            
            return result;
        }

        public string PasswordChange(string username, string email, string phno, string pwd)
        {
            forgotpassword_ob.username = username;
            forgotpassword_ob.password = pwd;
            forgotpassword_ob.email = email;
            forgotpassword_ob.phno = phno;
            return data_object.ForgotPassword(forgotpassword_ob);
        }

        public string[] DisplayProfile(string username)
        {
            userprofile_object.uname = username;
            return data_object.UserProfile(userprofile_object);
        }

        public string UpdateProfile(string fname, string lname, string pwd, string mail, string phone, string uname)
        {

            userprofile_object.firstname = fname;
            userprofile_object.lastname = lname;
            userprofile_object.password = pwd;
            userprofile_object.email = mail;
            userprofile_object.phone = phone;
            userprofile_object.uname = uname;
            return data_object.UpdateUserProfile(userprofile_object);
        }
        public void SetStatus(string name)
        {
            Register_ob.username = name;
            data_object.SetStatus(Register_ob);
        }
        public void SetStatusToZero(string name)
        {
            Register_ob.username = name;
            data_object.SetStatusToZero(Register_ob);
        }
        public string CheckStatus(string name)
        {
            Register_ob.username = name;
            return  data_object.CheckuserStatus(Register_ob);
        }
        public List<string> GettingSubjects()
        {
            return data_object.GettingSubjects();
        }
        public List<Questions> RandomQuestions(string SubjectName)
        {
            return data_object.RandomQuestions(SubjectName);
        }
        public void UpdateReportsTable(
                                           string UserName,
                                           DateTime DateOfExam,
                                           string SubjectName,
                                           int CorrectAnswers,
                                           float Percentage,
                                           string Status
                                      )
        {
            data_object.UpdateReportsTable(UserName,DateOfExam,SubjectName,CorrectAnswers,Percentage,Status);
        }
        public List<History> ExamsHistory(string UserName)
        {
            return data_object.ExamsHistory(UserName);
        }
    }
}
