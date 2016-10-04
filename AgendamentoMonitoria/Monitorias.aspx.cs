using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Monitorias : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        using (var ctx = new ModelContainer()) {
            foreach (Monitoria m in ctx.MonitoriaSet.ToList()) {
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
                cell3.Controls.Add(new Label() { Text = "Docente: "+ m.Docente });
                row.Cells.Add(cell3);

                if (Session["user_email"] != null) {
                    var cell4 = new TableCell() { CssClass = "monitoriacell" };
                    var btn = new Button() { CssClass = "btn btn-default", Text = "Reservar" };
                    btn.Click += (sa, ea) => { Session.Add("reserva_id", m.Id); Response.Redirect("Reservar?id=" + m.Id); };
                    cell4.Controls.Add(btn);
                    row.Cells.Add(cell4);
                }

                TableMonitorias.Rows.Add(row);
            }
        }
    }
}