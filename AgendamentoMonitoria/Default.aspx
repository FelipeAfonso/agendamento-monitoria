<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="background-color:#d9ffcc">
        <h1>Agendamento de Monitorias</h1>
        <p class="lead">Sistema para alunos regulares do IFSP Piracicaba agendar horários em uma monitoria</p>
    </div>

    <div class="row row-centered">
        <div class="col-md-6 col-centered" style="background-color: #d9ffcc;">
            <h2>Faça o Login ou Cadastre-se</h2>
                <asp:Table runat="server" HorizontalAlign="Center" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right"><h4>E-mail: </h4></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBoxLogin" runat="server" Width="100%"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right"><h4>Senha: </h4></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBoxSenha" runat="server" Width="100%" TextMode="Password" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Button CssClass="btn btn-default" ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click"  /></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right"><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Cadastre-se &raquo;</a></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Label ID="LabelUserInvalid" runat="server" Text="Usuário ou senha inválidos" Visible="false" BackColor="Red"></asp:Label>
            <br />
        </div>
    </div>
</asp:Content>
