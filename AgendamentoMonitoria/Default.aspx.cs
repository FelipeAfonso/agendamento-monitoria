using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void BtnLogin_Click(object sender, EventArgs e) {
        var ctx = new ModelContainer();
        var query = from u in ctx.UsuarioSet
                    where u.Email == TextBoxLogin.Text
                    select u;
        if (query.Count() > 0) {
            var usuario = query.First();
            if (usuario.Senha == Controller.getMd5(TextBoxSenha.Text)) {
                LabelUserInvalid.Visible = false;
                TextBoxLogin.Text = "Funcionou";
            } else LabelUserInvalid.Visible = true;
        } else LabelUserInvalid.Visible = true;


    }
}