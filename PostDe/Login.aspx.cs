using System;
using System.Web.UI.WebControls;

namespace PostDe
{
    public partial class Login : System.Web.UI.Page
    {
        //Login Event
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;
            Uri uri = new Uri("http://daydayup.ink/api/User/Login");
            string token = Helper.GetToken(uri, username, password);
            if (token!="")
            {
                Session["token"] = token;
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }
     
    }
}