<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row row-centered">
        <div class="jumbotron" style="background-color: #d9ffcc">
            <h1>Agendamento de Monitorias</h1>
            <p class="lead">Sistema para alunos regulares do IFSP Piracicaba agendar horários em uma monitoria</p>
        </div>
    </div>
    <div class="row row-centered">
        <div class="col-md-6">
            <div style="background-color: #d9ffcc; padding: 5px;">
                <h2>Bem-vindo</h2>
                <br />
                <center>
                <h4>
                    <p>Bem-vindo ao Sistema de Agendamento de Monitorias do IFSP - Piracicaba</p>
                    <p>Utilize a barra superior para navegar em nosso site!</p>
                </h4>
            </center>
            </div>
        </div>
        <div class="col-md-6" runat="server" id="LoginForm">
            <div style="background-color: #d9ffcc; padding: 5px">
                <h2>Faça o Login ou Cadastre-se</h2>
                <br />
                <center>
                <h4>
                    <p>Para utilizar o sistema de agendamento de monitorias voce deverá se conectar ou fazer um cadastro, é rápido e fácil!  </p>
                </h4>
                    <div class="row">
                <div class="col-md-6"><a class="btn btn-default" style="margin-bottom:20px" href="Account/Cadastro" >Cadastre-se &raquo;</a></div>
                <div class="col-md-6"><a class="btn btn-default" style="margin-bottom:20px"href="Account/Login" >Login &raquo;</a></div>
                        </div>
            </center>
            </div>
        </div>
    </div>
</asp:Content>
