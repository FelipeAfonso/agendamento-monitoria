using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] != null) Response.Redirect("/Default");
            RegisterHyperLink.NavigateUrl = "Cadastro";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var ctx = new ModelContainer();
                var query = ctx.UsuarioSet.Where(o => o.Email == UserName.Text).ToList();
                if (query.Count() > 0) {
                    var usuario = query.First();
                    if (usuario.Senha == Controller.getMd5(Password.Text)) {

                        Session.Add("user_email", usuario.Email);
                        Response.Redirect("/Default.aspx");

                    } 
                }

            }
        }
}