<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Monitorias.aspx.cs" Inherits="Monitorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron" style="background-color: #d9ffcc">
        <h1>Monitorias Disponíveis</h1>
    </div>

    <div class="row row-centered">

        <div class="col-md-12">
            <div style="background-color: #d9ffcc; padding: 5px;">
                <center>
                <h2>Monitorias Disponíveis</h2>
                <br />
                <asp:Table ID="TableMonitorias" runat="server" style="padding:5px; text-align:center"/>
                </center>
            </div>
        </div>

    </div>

</asp:Content>

