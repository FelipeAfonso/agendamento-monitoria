﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Horario
{
    public int Id { get; set; }
    public System.TimeSpan Inicio { get; set; }
    public System.TimeSpan Fim { get; set; }
    public string Dia { get; set; }

    public virtual Monitoria Monitoria { get; set; }
}

public partial class Monitor : Usuario
{

    public virtual Monitoria Monitoria { get; set; }
}

public partial class Monitoria
{
    public Monitoria()
    {
        this.Horario = new HashSet<Horario>();
        this.Reserva = new HashSet<Reserva>();
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Docente { get; set; }

    public virtual ICollection<Horario> Horario { get; set; }
    public virtual Monitor Monitor { get; set; }
    public virtual ICollection<Reserva> Reserva { get; set; }
}

public partial class Reserva
{
    public int Id { get; set; }
    public System.DateTime Horario { get; set; }
    public System.TimeSpan Duracao { get; set; }

    public virtual Monitoria Monitoria { get; set; }
    public virtual Usuario Usuario { get; set; }
}

public partial class Usuario
{
    public Usuario()
    {
        this.Reserva = new HashSet<Reserva>();
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Curso { get; set; }

    public virtual ICollection<Reserva> Reserva { get; set; }
}
