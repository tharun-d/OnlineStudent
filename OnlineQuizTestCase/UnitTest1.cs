//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Data;
//using System.Web.Http;
//using System.Configuration;
//using System.Web.Mvc;
//using OnlineExam.Controllers;
//using CommonLayer;
//using BusinessEntities;
//using System.Net.Configuration;
//using System.Data;
//using BusinessLayer;
//using DataAccessLayer;
//using System.Data.SqlClient;

//namespace OnlineQuizTestCase
//{
//    [TestClass]
//    public class UnitTest1
//    {

//        Register register_ob = new Register();
//        Dal dal_object = new Dal();
//        SqlConnection con = new SqlConnection("server=172.16.170.183;uid=sa;pwd=Passw0rd@12;database=OnlineQuiz");

//        [TestMethod]

//        public void RegisterUser()
//        {
//            con.Open();
//            register_ob.firstname = "smruti";
//            register_ob.lastname = "satapathy";
//            register_ob.username = "smrutjusa";
//            register_ob.password = "smru@12";
//            register_ob.gender = "female";
//            register_ob.email = "sony@gmail.com";
//            register_ob.phno = "7897867890";

          
//            string expected = "User name already exists";
//            string actual = (dal_object.RegisterValidation(register_ob));


//            Assert.AreEqual(expected, actual);

//        }
//        [TestMethod]
//        public void UserProfile()
//        {
//            con.Open();
//            UserProfile userprofile_ob = new UserProfile();
            

//            userprofile_ob.uname = "bhavya22";

//            userprofile_ob.firstname = "Bhavya";

//            userprofile_ob.lastname = "sghhgjj";

//            userprofile_ob.password = "you1234";

//            userprofile_ob.email = "bhava@123";

//            userprofile_ob.phone = "8589965223";



           
//            string expected = "Success";
//            string actual = (dal_object.UpdateUserProfile(userprofile_ob));


//            Assert.AreEqual(expected, actual);

//        }
//        [TestMethod]
//        public void ForgotPasswordTestCase()
//        {
//            con.Open();
//            ForgotPassword forgotpwd_ob = new ForgotPassword();
//            forgotpwd_ob.username = "bhavya22";
//            forgotpwd_ob.password = "Bhavya123@";
//            forgotpwd_ob.email = "bhava@123";
//            forgotpwd_ob.phno = "8989420849";
//            var expected = "Please provide valid username phone number and email-id";
//            var actual = (dal_object.ForgotPassword(forgotpwd_ob));
//            Assert.AreEqual(expected, actual);
//        }

      
//    }
//}