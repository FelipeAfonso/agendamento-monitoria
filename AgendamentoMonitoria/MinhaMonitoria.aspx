<%@ Page Title="Minha Monitoria" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MinhaMonitoria.aspx.cs" Inherits="MinhaMonitoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron" style="background-color: #d9ffcc">
        <h1>Minha Monitoria</h1>
    </div>

    <div class="row row-centered">

        <div class="col-md-12">
            <div style="background-color: #d9ffcc; padding: 5px;">
                <center>
                <h2>Minha Monitoria</h2>
                <br />
                <asp:Table ID="TableMonitorias" runat="server" style="padding:5px; text-align:center"/>
                <h2>Horarios Reservados</h2>
                <br />
                <asp:Table ID="TableReservas" runat="server" Style="padding: 5px; text-align: center" />
                </center>
            </div>
        </div>

    </div>
</asp:Content>

