using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using AgendamentoMonitoria;

public partial class Account_Register : Page {
    protected void CreateUser_Click(object sender, EventArgs e) {
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded) {
            var ctx = new ModelContainer();
            var usuario = new Usuario();
            usuario.Email = UserName.Text;
            usuario.Senha = Controller.getMd5(Password.Text);
            //usuario.Curso;
            //usuario.Nome;
            ctx.UsuarioSet.Add(usuario);
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        } else {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}