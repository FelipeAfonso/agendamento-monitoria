using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : Page {

    protected void Page_Load(object sender, EventArgs e) {

        if (Session["user_email"] == null) Response.Redirect("/Default");
        if (!IsPostBack) {
            using (var ctx = new ModelContainer()) {
                var email = Session["user_email"].ToString();
                var user = ctx.UsuarioSet.Single(o => o.Email == email);
                if (user is Monitor) {
                    MonitorGroup.Visible = true;
                    Disciplina.Text = ((Monitor)user).Monitoria.Nome;
                    Docente.Text = ((Monitor)user).Monitoria.Docente;
                }
                Nome.Text = user.Nome;
                UserName.Text = user.Email;
                Curso.Text = user.Curso;
            }
        }

        for (int i = 0; i < Int32.Parse(Dias.SelectedValue); i++) {
            Horarios.Rows.Add(getRow());
        }
    }

    protected void CreateUser_Click(object sender, EventArgs e) {
        var val = true;
        foreach (TableRow r in Horarios.Rows) {
            if (r.GetType() == typeof(TableRow)) {
                var inicio = ((TextBox)r.Cells[1].Controls[0]).Text;
                var fim = ((TextBox)r.Cells[2].Controls[0]).Text;
                if (new TimeSpan(Int32.Parse(inicio.Substring(0, inicio.IndexOf(":")))) > new TimeSpan(Int32.Parse(fim.Substring(0, fim.IndexOf(":"))))) {
                    val = false;
                }
            }
        }
        if (val) {
            var ctx = new ModelContainer();
            var email = Session["user_email"].ToString();
            var user = ctx.UsuarioSet.Single(o => o.Email == email);
            if (user is Monitor) {
                var horarios = new List<Horario>();
                ((Monitor)user).Monitoria.Horario.ToList().ForEach(o => ctx.HorarioSet.Remove(o));
                foreach (TableRow r in Horarios.Rows) {
                    if (r.GetType() == typeof(TableRow)) {
                        var inicio = ((TextBox)r.Cells[1].Controls[0]).Text;
                        var fim = ((TextBox)r.Cells[2].Controls[0]).Text;

                        ((Monitor)user).Monitoria.Horario.Add(new Horario() {
                            Dia = ((DropDownList)r.Cells[0].Controls[0]).SelectedValue,
                            Inicio = new TimeSpan(Int32.Parse(inicio.Substring(0, inicio.IndexOf(":"))),
                            Int32.Parse(fim.Substring(inicio.IndexOf(":") + 1)), 0),
                            Fim = new TimeSpan(Int32.Parse(fim.Substring(0, fim.IndexOf(":"))),
                            Int32.Parse(fim.Substring(fim.IndexOf(":") + 1)), 0),
                            //Monitoria = ((Monitor)user).Monitoria
                        });
                    }
                }

                ((Monitor)user).Monitoria.Nome = Disciplina.Text;
                ((Monitor)user).Monitoria.Docente = Docente.Text;



                user.Nome = Nome.Text;
                user.Senha = Controller.getMd5(Password.Text);
                user.Email = UserName.Text;
                user.Curso = Curso.Text;

                ctx.SaveChanges();
                Session.Add("user_email", user.Email);
                Response.Redirect("/Default.aspx");

            } else {
                var usuario = new Usuario() {
                    Email = UserName.Text,
                    Senha = Controller.getMd5(Password.Text),
                    Curso = Curso.Text,
                    Nome = Nome.Text,
                    Reserva = user.Reserva
                };

                user.Email = usuario.Email;
                user.Senha = usuario.Senha;
                user.Curso = usuario.Curso;
                user.Nome = usuario.Nome;
                user.Reserva = usuario.Reserva;

                ctx.SaveChanges();
                Session.Add("user_email", usuario.Email);
                Response.Redirect("/Default.aspx");

            }
        } else {
            ErrorMessage.Text = "O Inicio deve começar antes do Fim";
        }
    }

    private TableRow getRow() {

        var row = new TableRow();
        var dia_cell = new TableCell();
        var inicio_cell = new TableCell();
        var fim_cell = new TableCell();

        row.BorderColor = System.Drawing.Color.DarkGreen;

        var dia = new DropDownList() { CssClass = "form-control" };
        dia.Items.Add(new ListItem("Segunda", "Segunda"));
        dia.Items.Add(new ListItem("Terça", "Terça"));
        dia.Items.Add(new ListItem("Quarta", "Quarta"));
        dia.Items.Add(new ListItem("Quinta", "Quinta"));
        dia.Items.Add(new ListItem("Sexta", "Sexta"));
        dia_cell.Controls.Add(dia);

        var inicio = new TextBox() { TextMode = TextBoxMode.Time, CssClass = "form-control", ID = "inicio" };
        var fim = new TextBox() { TextMode = TextBoxMode.Time, CssClass = "form-control", ID = "fim" };

        inicio_cell.Controls.Add(inicio);
        fim_cell.Controls.Add(fim);

        row.Cells.Add(dia_cell);
        row.Cells.Add(inicio_cell);
        row.Cells.Add(fim_cell);

        return row;
    }


}