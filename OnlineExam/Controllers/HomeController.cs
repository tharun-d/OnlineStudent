using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Data.SqlClient;

using BusinessEntities;

namespace OnlineExam.Controllers
{
    public class HomeController : Controller
    {

        BLayer blayer_ob = new BLayer();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string uname, string pwd)
        {

            string result = blayer_ob.Login(uname, pwd);

            if (result == "Success")
            {
                Session["user"] = uname;
                return RedirectToAction("UserPage");
            }
            else
            {
                ViewBag.Message = result;
            }


            return View();

        }
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string firstname, string lastname, string username, string password, string gender, string email, string phno)
        {
            firstname = Request["fname"];
            lastname = Request["lname"];
            username = Request["uname"];
            password = Request["password"];
            gender = Request["radiochoice"];
            email = Request["email"];
            phno = Request["phno"];
            string result = blayer_ob.register(firstname, lastname, username, password, gender, email, phno, 0);
            if (result == "Success")
            {
                return RedirectToAction("login");

            }
            else
            {
                ViewBag.Message = result;
                return View();
            }

        }


        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username, string email, string phno, string pwd)
        {
            string result = blayer_ob.PasswordChange(username, email, phno, pwd);
            if (result == "successfully updated")
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = result;
            }

            return View();

        }



        public ActionResult UserPage()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public ActionResult UserProfile()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index");
            }
            string name = Session["user"].ToString();
            string[] details = blayer_ob.DisplayProfile(name);
            ViewBag.firstname = details[0];
            ViewBag.lastname = details[1];
            ViewBag.password = details[2];
            ViewBag.email = details[3];
            ViewBag.phoneno = details[4];
            return View();
        }
        [HttpPost]
        public ActionResult UserProfile(string fname, string lname, string pwd, string mail, string phone)
        {
            string name = Session["user"].ToString();
            string result = blayer_ob.UpdateProfile(fname, lname, pwd, mail, phone, name);
            if (result == "Success")
            {
                return RedirectToAction("UserPage");
            }
            else
            {
                ViewBag.Message = result;
                return View();
            }
        }

        public ActionResult TakeTest()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Subjects = blayer_ob.GettingSubjects();

            return View();
        }
        [HttpPost]
        public ActionResult TakeTest(string SubjectName)
        {
            string user = Session["user"].ToString();
            string result = blayer_ob.CheckStatus(user);
            if (result == "Success")
            {
                blayer_ob.SetStatus(user);
                TempData["SubjectName"] = SubjectName;
                TempData.Keep();
                return RedirectToAction("Questions");
            }
            else
            {
                ViewBag.Message = result;
            }
            return View();
        }
        public ActionResult History()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index");
            }
            List<History> list = blayer_ob.ExamsHistory(Session["user"].ToString());
            ViewBag.List = list;
            return View();

        }
        public ActionResult Questions()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                string SubjectName = TempData["SubjectName"].ToString();
                ViewBag.SubjectName = SubjectName;
                List<Questions> RandomQuestions = blayer_ob.RandomQuestions(SubjectName);
                ViewBag.RandomQuestions = RandomQuestions;
                
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("TakeTest");
            }


        }
        [HttpPost]
        public ActionResult Questions(string SubjectName)
        {
            string UserName = Session["user"].ToString();
            blayer_ob.SetStatusToZero(UserName);
            int crt = 0;
            int tques = Convert.ToInt32( Request["tques"]);
            string[] a = new string[tques];
            string[] b = new string[tques];
            List<Questions> correctanswer = new List<Questions>();
            List<Questions> questiondispaly = new List<Questions>();
            for (int j = 1; j <= tques-1; j++)
            {
                a[j - 1] = Request["arr" + j];
                b[j - 1] = Request["crt" + j];
                
                Questions q = new Questions()
                {   
                    option1 = a[j - 1],
                    option2 = b[j - 1]
                };
                correctanswer.Add(q);

                Questions quesdis = new Questions()
                {
                    question = Request["que"+j],
                    option1 = Request["que1"+j],
                    option2 = Request["que2"+j],
                    option3 = Request["que3"+j],
                    option4 = Request["que4"+j]
                };
                questiondispaly.Add(quesdis);
                
            }
            ViewBag.correctanswers = correctanswer;
            ViewBag.questiondisplay = questiondispaly;
            for (int k = 1; k <= tques-1; k++)
            {
                if (a[k - 1] == b[k - 1])
                {
                    crt++;
                }
            }
            ViewBag.correct = crt;
            ViewBag.wrong = tques - crt-1;
            ViewBag.percentage = ((100/(tques-1))*crt);
            float Percentage = ViewBag.percentage;
            string Status;
            if (Percentage > 40)
            {
                Status = "Pass";
            }
            else
                Status = "Fail";
            blayer_ob.UpdateReportsTable(UserName,DateTime.Now,SubjectName,crt,Percentage,Status);
            return View();
        }
        public ActionResult Logout()
        {     
            blayer_ob.SetStatusToZero(Session["user"].ToString());
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}

