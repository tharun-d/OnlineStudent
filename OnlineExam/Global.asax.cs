using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.SqlClient;
namespace OnlineExam
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["user"] = null;

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
        protected void Session_End(object sender, EventArgs e)
        {
        //    string user = Session["user"].ToString();
        //    int i;
        //    SqlConnection con1 = new SqlConnection("server=172.16.170.183;uid=sa;pwd=Passw0rd@12;DataBase=hi");
        //    con1.Open();
        //    SqlCommand cmd = new SqlCommand("set_user_status_to_zero @name", con1);
        //    SqlParameter p1 = new SqlParameter("@name", user);
        //    cmd.Parameters.Add(p1);

        //    i = cmd.ExecuteNonQuery();

        //    con1.Close();
         }
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}