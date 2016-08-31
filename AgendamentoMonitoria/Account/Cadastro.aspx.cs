using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : Page {

    protected void Page_Load(object sender, EventArgs e) {

        for (int i = 0; i < Int32.Parse(Dias.SelectedValue); i++) {
            Horarios.Rows.Add(getRow());
        }

    }

    protected void CreateUser_Click(object sender, EventArgs e) {
        var ctx = new ModelContainer();
        if (IsMonitor.Checked) {
            var horarios = new List<Horario>();
            var monitoria = new Monitoria() {
                Nome = Disciplina.Text,
                Docente = Docente.Text
            };
            foreach (TableRow r in Horarios.Rows) {
                if (r.GetType() == typeof(TableRow)) {
                    var inicio = ((TextBox)r.Cells[1].Controls[0]).Text;
                    var fim = ((TextBox)r.Cells[2].Controls[0]).Text;

                    horarios.Add(new Horario() {
                        Dia = ((DropDownList)r.Cells[0].Controls[0]).SelectedValue,
                        Inicio = new TimeSpan(Int32.Parse(inicio.Substring(0, inicio.IndexOf(":"))),
                        Int32.Parse(fim.Substring(inicio.IndexOf(":") + 1)), 0),
                        Fim = new TimeSpan(Int32.Parse(fim.Substring(0, fim.IndexOf(":"))),
                        Int32.Parse(fim.Substring(fim.IndexOf(":") + 1)), 0),
                        Monitoria = monitoria
                    });
                }
            }
            var monitor = new Monitor() {
                Email = UserName.Text,
                Senha = Controller.getMd5(Password.Text),
                Curso = Curso.Text,
                Nome = Nome.Text
            };
            monitoria.Horario = horarios;
            monitor.Monitoria = monitoria;
            monitoria.Monitor = monitor;
            if (ctx.UsuarioSet.Where(u => u.Email == monitor.Email).ToList().Count == 0) {
                ctx.UsuarioSet.Add(monitor);
                ctx.SaveChanges();
                Response.Redirect("/Default.aspx");
            } else {
                ErrorMessage.Text = "Usuario já existe";
                ErrorMessage.Visible = true;
            }
        } else {
            var usuario = new Usuario() {
                Email = UserName.Text,
                Senha = Controller.getMd5(Password.Text),
                Curso = Curso.Text,
                Nome = Nome.Text
            };
            if (ctx.UsuarioSet.Where(u => u.Email == usuario.Email).ToList().Count == 0) {
                ctx.UsuarioSet.Add(usuario);
                ctx.SaveChanges();
            } else {
                ErrorMessage.Text = "Usuario já existe";
                ErrorMessage.Visible = true;
            }

        }
    }
    protected void IsMonitor_CheckedChanged(object sender, EventArgs e) {
        if (IsMonitor.Checked) {
            MonitorGroup.Visible = true;
            DisciplinaValidator.Enabled = true;
            ChaveValidator.Enabled = true;
        } else {
            MonitorGroup.Visible = false;
            DisciplinaValidator.Enabled = false;
            ChaveValidator.Enabled = false;
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

        var inicio = new TextBox() { TextMode = TextBoxMode.Time, CssClass = "form-control" };
        var fim = new TextBox() { TextMode = TextBoxMode.Time, CssClass = "form-control" };
        inicio_cell.Controls.Add(inicio);
        fim_cell.Controls.Add(fim);

        row.Cells.Add(dia_cell);
        row.Cells.Add(inicio_cell);
        row.Cells.Add(fim_cell);

        return row;
    }


}