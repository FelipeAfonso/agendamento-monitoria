using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MinhaMonitoria : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Session["user_email"] != null) {
            TableReservas.Rows.Clear();
            using (var ctx = new ModelContainer()) {
                var email = Session["user_email"];
                if (ctx.UsuarioSet.Single(o => o.Email == email) is Monitor) {
                    var usuario = ctx.UsuarioSet.Single(o => o.Email == email);
                    foreach (Reserva r in ctx.ReservaSet.Where(o => o.Usuario.Id == usuario.Id).ToList()) {
                        var row = new TableRow() { CssClass = "monitoriarow" };
                        var title = new Label() { Text = r.Usuario.Nome };
                        title.Font.Size = 16;
                        title.Font.Bold = true;

                        var th = new Table();
                        var tr = new TableRow();
                        var tc = new TableCell();
                        tc.Controls.Add(new Label() {
                            Text = r.Horario.ToLongDateString()
                                + " das " + r.Horario.ToLongTimeString()
                                + " até as " + r.Horario.Add(r.Duracao).ToLongTimeString(),
                        });
                        tr.Cells.Add(tc);
                        th.Rows.Add(tr);

                        var cell1 = new TableCell() { CssClass = "monitoriacell" };
                        cell1.Controls.Add(title);
                        row.Cells.Add(cell1);

                        var cell2 = new TableCell() { CssClass = "monitoriacell" };
                        cell2.Controls.Add(th);
                        row.Cells.Add(cell2);

                        var cell3 = new TableCell() { CssClass = "monitoriacell" };
                        cell3.Controls.Add(new Label() { Text = "Email: " + r.Usuario.Email });
                        row.Cells.Add(cell3);

                        var cell4 = new TableCell() { CssClass = "monitoriacell" };
                        var btn = new Button() { CssClass = "btn btn-default", Text = "Cancelar" };
                        btn.Click += (sa, ea) => {
                            var ctx2 = new ModelContainer();
                            ctx2.ReservaSet.Remove(ctx2.ReservaSet.Single(o => o.Id == r.Id));
                            ctx2.SaveChanges();
                            ctx2.Dispose();
                            Page_Load(sender, e);
                        };
                        cell4.Controls.Add(btn);
                        row.Cells.Add(cell4);


                        TableReservas.Rows.Add(row);
                    }
                    foreach (Monitoria m in ctx.MonitoriaSet.Where(o=>o.Monitor.Id==usuario.Id).ToList()) {
                        var row = new TableRow() { CssClass = "monitoriarow" };
                        var title = new Label() { Text = m.Nome };
                        title.Font.Size = 16;
                        title.Font.Bold = true;

                        var th = new Table();
                        foreach (Horario h in m.Horario) {
                            var tr = new TableRow();
                            var tc = new TableCell();
                            tc.Controls.Add(new Label() { Text = h.Dia + " das " + h.Inicio.ToString() + " até as " + h.Fim.ToString() });
                            tr.Cells.Add(tc);
                            th.Rows.Add(tr);
                        }


                        var cell1 = new TableCell() { CssClass = "monitoriacell" };
                        cell1.Controls.Add(title);
                        row.Cells.Add(cell1);

                        var cell2 = new TableCell() { CssClass = "monitoriacell" };
                        cell2.Controls.Add(th);
                        row.Cells.Add(cell2);

                        var cell3 = new TableCell() { CssClass = "monitoriacell" };
                        cell3.Controls.Add(new Label() { Text = "Docente: " + m.Docente });
                        row.Cells.Add(cell3);

                        TableMonitorias.Rows.Add(row);
                    }

                }
            }
        } else {
            Response.Redirect("Default");
        }

    }
}