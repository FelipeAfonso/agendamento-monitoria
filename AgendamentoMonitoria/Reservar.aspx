<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reservar.aspx.cs" Inherits="Reservar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="jumbotron" style="background-color: #d9ffcc">
        <h1 runat="server" id="TitleH1"/>
    </div>

    <div class="row row-centered">

        <div class="col-md-12">
            <div class="form-horizontal" style="background-color: #d9ffcc; padding: 5px;">
                <div>
                    <center><asp:Table ID="TableMonitorias" runat="server" style="padding:5px; text-align:center"/></center>
                </div>
                <p>Reservar, considerando uma hora de sessão</p>
                <p><asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-danger"/></p>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Hora" CssClass="col-md-2 control-label">Hora da Visita</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Hora" TextMode="Time" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Hora"
                            CssClass="text-danger" ErrorMessage="O campo Hora da Visita é necessário" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Duracao" CssClass="col-md-2 control-label">Duração da Visita</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Duracao" TextMode="Time" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Duracao"
                            CssClass="text-danger" ErrorMessage="O campo Duração da Visita é necessário" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Dia" CssClass="col-md-2 control-label">Dia da Visita</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList runat="server" ID="Dia" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-9">
                        <asp:Button ID="Send" runat="server" OnClick="Send_Click" Text="Reservar &raquo;" CssClass="btn btn-default" ValidateRequestMode="Inherit" />
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

