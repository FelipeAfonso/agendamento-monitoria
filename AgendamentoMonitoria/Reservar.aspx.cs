using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reservar : System.Web.UI.Page {

    private Monitoria monitoria;

    protected void Page_Load(object sender, EventArgs e) {
        if (Session["user_email"] != null) {
            try {
                var ctx = new ModelContainer();
                int id = (Request.QueryString["id"] != null) ? Int32.Parse(Request.QueryString["id"]) : Int32.Parse(Session["reserva_id"].ToString());
                monitoria = ctx.MonitoriaSet.Single(o => o.Id == id);

            } catch { Response.Redirect("Default.aspx"); }
            TitleH1.InnerText = "Reservar Horário de " + monitoria.Nome;

            var row = new TableRow() { CssClass = "monitoriarow" };
            var title = new Label() { Text = monitoria.Nome };
            title.Font.Size = 16;
            title.Font.Bold = true;

            var th = new Table();
            foreach (Horario h in monitoria.Horario) {
                var tr = new TableRow();
                var tc = new TableCell();
                tc.Controls.Add(new Label() { Text = h.Dia + " das " + h.Inicio.ToString() + " até as " + h.Fim.ToString() });
                tr.Cells.Add(tc);
                th.Rows.Add(tr);
                DayOfWeek d;
                switch (h.Dia) {
                    case "Segunda": d = DayOfWeek.Monday; break;
                    case "Terça": d = DayOfWeek.Tuesday; break;
                    case "Quarta": d = DayOfWeek.Wednesday; break;
                    case "Quinta": d = DayOfWeek.Thursday; break;
                    case "Sexta": d = DayOfWeek.Friday; break;
                    default: d = DayOfWeek.Monday; break;
                }
                Dia.Items.Add(new ListItem(h.Dia + " (Dia " + GetNextWeekday(DateTime.Today, d).Day + ")", h.Dia));
            }

            var cell1 = new TableCell() { CssClass = "monitoriacell" };
            cell1.Controls.Add(title);
            row.Cells.Add(cell1);

            var cell2 = new TableCell() { CssClass = "monitoriacell" };
            cell2.Controls.Add(th);
            row.Cells.Add(cell2);

            var cell3 = new TableCell() { CssClass = "monitoriacell" };
            cell3.Controls.Add(new Label() { Text = "Docente: " + monitoria.Docente });
            row.Cells.Add(cell3);

            TableMonitorias.Rows.Add(row);
            ErrorMessage.Text = "";

        } else {
            Response.Redirect("Default.aspx");
        }
    }
    protected void Send_Click(object sender, EventArgs e) {
        if ((TimeSpan.Parse(Hora.Text).Add(TimeSpan.Parse(Duracao.Text)) <= monitoria.Horario.Single(o => o.Dia == Dia.Text).Fim
            && TimeSpan.Parse(Hora.Text) >= monitoria.Horario.Single(o => o.Dia == Dia.Text).Inicio) || TimeSpan.Parse(Duracao.Text).TotalMinutes < 15) {

            using (var ctx = new ModelContainer()) {
                    DayOfWeek d;
                    switch (Dia.SelectedValue) {
                        case "Segunda": d = DayOfWeek.Monday; break;
                        case "Terça": d = DayOfWeek.Tuesday; break;
                        case "Quarta": d = DayOfWeek.Wednesday; break;
                        case "Quinta": d = DayOfWeek.Thursday; break;
                        case "Sexta": d = DayOfWeek.Friday; break;
                        default: d = DayOfWeek.Monday; break;
                    }
                    var horario = new DateTime(DateTime.Today.Year, GetNextWeekday(DateTime.Today, d).Month,
                                                    GetNextWeekday(DateTime.Today, d).Day, DateTime.Parse(Hora.Text).Hour,
                                                    DateTime.Parse(Hora.Text).Minute, DateTime.Parse(Hora.Text).Second);
                var val = new List<Reserva>();
                foreach (Reserva r in ctx.ReservaSet.Where(o => o.Horario.Day == horario.Day).ToList()) {
                    if (TimeSpan.Parse(Hora.Text).Add(TimeSpan.Parse(Duracao.Text)) > r.Horario.TimeOfDay &&
                      TimeSpan.Parse(Hora.Text) < r.Horario.TimeOfDay.Add(r.Duracao))
                    val.Add(r);
                }


                if (val.Count == 0) {

                    var email = Session["user_email"].ToString();
                    var usuario = ctx.UsuarioSet.Single(o => o.Email == email);
                    var reserva = new Reserva() { Monitoria = ctx.MonitoriaSet.Single(o => o.Id == monitoria.Id), Usuario = null, Horario = horario, Duracao = TimeSpan.Parse(Duracao.Text) };
                    //ctx.ReservaSet.Add(reserva);
                    //ctx.MonitoriaSet.Attach(reserva.Monitoria);
                    //ctx.UsuarioSet.Attach(reserva.Usuario);

                    usuario.Reserva.Add(reserva);

                    ctx.SaveChanges();
                    ctx.Dispose();
                    Response.Redirect("Reservas");
                } else {
                    ErrorMessage.Text = "Já existe uma consulta neste horário: " + val.First().Horario.ToString() + " que irá durar " + val.First().Duracao.ToString();
                }
            }


        } else { ErrorMessage.Text = "Horário e/ou Duração Inválidos, cheque o horário acima e insira uma duração de pelo menos quinze minutos!"; }

    }
    private static DateTime GetNextWeekday(DateTime start, DayOfWeek day) {
        int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
        return start.AddDays(daysToAdd);
    }
}