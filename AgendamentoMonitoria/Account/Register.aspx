<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Cadastro</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Crie uma nova conta</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Nome" CssClass="col-md-2 control-label">Nome</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nome" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nome"
                    CssClass="text-danger" ErrorMessage="O campo nome é necessário" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">E-mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="O campo e-mail é necessário" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Senha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="O campo senha é necessário" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirme a Senha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirmar sua senha é necessário" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="A senha e sua confirmação devem ser iguais" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="IsMonitor" CssClass="col-md-2">É um monitor?</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="IsMonitor" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Button1" runat="server" OnClick="CreateUser_Click" Text="Cadastrar-se" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

