<%@ Page Title="Reservas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reservas.aspx.cs" Inherits="Reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron" style="background-color: #d9ffcc">
        <h1>Minhas Reservas</h1>
    </div>

    <div class="row row-centered">

        <div class="col-md-12">
            <div style="background-color: #d9ffcc; padding: 5px;">
                <center>
                <h2>Horários Reservados</h2>
                <br />
                <asp:Table ID="TableReservas" runat="server" style="padding:5px; text-align:center"/>
                </center>
            </div>
        </div>

    </div>
</asp:Content>

