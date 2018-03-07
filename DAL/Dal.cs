using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using CommonLayer;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
     
    public class Dal
    {
        string connection = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        
        Common com = new Common();

        public string RegisterValidation(Register reg)
        {
            SqlConnection con1 = new SqlConnection(connection);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand(com.get_user, con1);
            SqlParameter p0 = new SqlParameter("@one", reg.username);
            cmd1.Parameters.Add(p0);
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.HasRows)
            {
                return "User name already exists";
            }
            con1.Close();


            SqlConnection con2 = new SqlConnection(connection);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand(com.get_email, con2);
            SqlParameter h2 = new SqlParameter("@two", reg.email);
            cmd2.Parameters.Add(h2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.HasRows)
            {
                return "email already exists";
            }
            con2.Close();

            SqlConnection con3 = new SqlConnection(connection);
            con3.Open();
            SqlCommand cmd3 = new SqlCommand(com.get_phno, con3);
            SqlParameter h3 = new SqlParameter("@three", reg.phno);
            cmd3.Parameters.Add(h3);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.HasRows)
            {
                return "Phone Number  already exists";
            }
            con3.Close();

            SqlCommand sda;
            SqlConnection con = new SqlConnection(connection);

            con.Open();
            sda = new SqlCommand(com.user_register, con);

            SqlParameter p1 = new SqlParameter("@fname", reg.firstname);
            SqlParameter p2 = new SqlParameter("@lname", reg.lastname);
            SqlParameter p3 = new SqlParameter("@uname", reg.username);
            SqlParameter p4 = new SqlParameter("@pwd", reg.password);
            SqlParameter p5 = new SqlParameter("@gender", reg.gender);
            SqlParameter p6 = new SqlParameter("@email", reg.email);
            SqlParameter p7 = new SqlParameter("@phno", reg.phno);
            SqlParameter p8 = new SqlParameter("@def", reg.def);
            sda.Parameters.Add(p1);
            sda.Parameters.Add(p2);
            sda.Parameters.Add(p3);
            sda.Parameters.Add(p4);
            sda.Parameters.Add(p5);
            sda.Parameters.Add(p6);
            sda.Parameters.Add(p7);
            sda.Parameters.Add(p8);

            
            sda.ExecuteNonQuery();
            con.Close();
            return "Success";


        }
        public string ValidUser(Register log)
        {
            string username = log.username;
            string password = log.password;
            if (username == "" && password == "")
            {
                return "Please enter credentials";
            }
            else if (username == "" && password != "")
            {
                return "Please enter username";
            }
            else if (username != "" && password == "")
            {
                return "Please enter password";
            }
            else
            {

                SqlCommand sda;
                SqlConnection con = new SqlConnection(connection);

                con.Open();
                sda = new SqlCommand(com.valid_user, con);
                SqlParameter p1 = new SqlParameter("@uname", log.username);
                SqlParameter p2 = new SqlParameter("@pwd", log.password);
                sda.Parameters.Add(p1);
                sda.Parameters.Add(p2);
               
                SqlDataReader dr=sda.ExecuteReader();
                while(dr.HasRows)
                {
                    return "Success";
                }
                con.Close();
                return "Please provide a valid username and password";
            }
            
        }
        public string ForgotPassword(ForgotPassword fp)
        {
            string username = fp.username;
            string password = fp.password;
            string email = fp.email;
            string phno = fp.phno;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.get_details, con);
            SqlParameter p = new SqlParameter("@one", username);
            cmd.Parameters.Add(p);
            SqlParameter p1 = new SqlParameter("@two", email);
            cmd.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@three", phno);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand(com.sp_changepassword, con);
                SqlParameter p3 = new SqlParameter("@four", username);
                cmd1.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@five", password);
                cmd1.Parameters.Add(p4);
                SqlDataReader dr2 = cmd1.ExecuteReader();
                con.Close();
                return "successfully updated";
            }
            else
            {
                return "Please provide valid username phone number and email-id";  
            } 
        }

        public string[] UserProfile(UserProfile profile)
        {
            string name = profile.uname;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.getting_details, con);
            SqlParameter p = new SqlParameter("@name", name);
            cmd.Parameters.Add(p);
            SqlDataReader dr = cmd.ExecuteReader();
            string[] user = new string[5];
            while (dr.Read())
            {
                user[0] = Convert.ToString(dr[0]);
                user[1] = Convert.ToString(dr[1]);
                user[2] = Convert.ToString(dr[2]);
                user[3] = Convert.ToString(dr[3]);
                user[4] = Convert.ToString(dr[4]);
            }
            con.Close();
            return user;
        }
        public string UpdateUserProfile(UserProfile user_profile)
        {
            string uname = user_profile.uname;
            string fname = user_profile.firstname;
            string lname = user_profile.lastname;
            string pwd = user_profile.password;
            string email = user_profile.email;
            string phone = user_profile.phone;



            if (fname == "" && lname == "" && pwd == "" && email == "" && phone == "")
            {
                return "All fields are mandatory";
              
            }
            int i;
            SqlConnection con = new SqlConnection(connection);
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(com.edit_profile, con);
                SqlParameter p1 = new SqlParameter("@one", fname);
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@two", lname);
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@three", pwd);
                cmd.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@four", email);
                cmd.Parameters.Add(p4);
                SqlParameter p5 = new SqlParameter("@five", phone);
                cmd.Parameters.Add(p5);
                SqlParameter p6 = new SqlParameter("@name", uname);
                cmd.Parameters.Add(p6);
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return "Email or Phone number already exists";
            }
            finally
            {
                con.Close();
            }

         
            return "Success";
        }
        public void SetStatus(Register add)
        {
            string f = add.username;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.set_userstatus, con);
            SqlParameter p1 = new SqlParameter("@name", f);
            cmd.Parameters.Add(p1);
            int i = cmd.ExecuteNonQuery();


        }
        public void SetStatusToZero(Register add)
        {
            string f = add.username;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.status_zero, con);
            SqlParameter p1 = new SqlParameter("@name", f);
            cmd.Parameters.Add(p1);
            int i = cmd.ExecuteNonQuery();


        }
        public string CheckuserStatus(Register add)
        {
            string f = add.username;
            SqlConnection con = new SqlConnection(connection);
            int j = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand(com.get_userstatus, con);
            SqlParameter p1 = new SqlParameter("@name", f);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
                j = Convert.ToInt16(dr[0]);
            if (j == 0)
                return "Success";
            else
               return "You are already taking exam in different system";
        }
        public List<string> GettingSubjects()
        {
            List<string> Subjects = new List<string>();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.getting_SubjectNames, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                Subjects.Add(Convert.ToString(dr[0]));
            con.Close();
            return Subjects;
        }
        public List<Questions> RandomQuestions(string SubjectName)
        {
            List<Questions> ListOfQuestions = new List<Questions>();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.getting_RandomQuestions, con);
            SqlParameter p = new SqlParameter("@SubjectName", SubjectName);
            cmd.Parameters.Add(p);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Questions Q = new Questions()
                {
                    question = Convert.ToString(dr[0]),
                    option1 = Convert.ToString(dr[1]),
                    option2 = Convert.ToString(dr[2]),
                    option3 = Convert.ToString(dr[3]),
                    option4 = Convert.ToString(dr[4]),
                    crt = Convert.ToInt16(dr[5])
                };
                ListOfQuestions.Add(Q);
            }
            return ListOfQuestions;
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
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.UpdateReportsTable, con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@DateOfExam", DateOfExam);
            cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
            cmd.Parameters.AddWithValue("@CorrectAnswers", CorrectAnswers);
            cmd.Parameters.AddWithValue("@Percentage", Percentage);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<History> ExamsHistory(string UserName)
        {
            List<History> List = new List<History>();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(com.ExamsHistory, con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                History H = new History()
                {
                    SubjectName = Convert.ToString(dr[0]),
                    Examdate=Convert.ToDateTime(dr[1]),
                    Percantage=Convert.ToDouble(dr[2]),
                    StatusOfExam =Convert.ToString(dr[3])
                };
                List.Add(H);
            }
            return List;
        }
    }
}
