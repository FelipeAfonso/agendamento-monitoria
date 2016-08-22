<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Cadastro.aspx.cs" Inherits="Account_Register" %>

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
            <asp:Label runat="server" AssociatedControlID="Curso" CssClass="col-md-2 control-label">Curso</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Curso" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Curso"
                    CssClass="text-danger" ErrorMessage="O campo curso é necessário" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="IsMonitor" CssClass="col-md-2 control-label">É um monitor?</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="IsMonitor" runat="server" OnCheckedChanged="IsMonitor_CheckedChanged" AutoPostBack="true" />
            </div>
        </div>
        <asp:Panel ID="MonitorGroup" runat="server" Visible="false">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Chave" CssClass="col-md-2 control-label">Chave de Acesso</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Chave" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Chave" ID="ChaveValidator" Enabled="false"
                        CssClass="text-danger" ErrorMessage="O campo chave de acesso é necessário se você for um monitor" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Disciplina" CssClass="col-md-2 control-label">Nome da Monitoria</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Disciplina" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Disciplina" ID="DisciplinaValidator" Enabled="false"
                        CssClass="text-danger" ErrorMessage="O campo disciplina é necessário se você for um monitor" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Horarios" CssClass="col-md-2 control-label">Horários da Monitoria</asp:Label>
                <div class="col-md-10">
                    <asp:Table ID="Horarios" runat="server" BorderStyle="Solid" BorderColor="DarkGreen" CellSpacing="5" BorderWidth="5px" CellPadding="5" GridLines="Horizontal">
                        <asp:TableHeaderRow BackColor="DarkGreen">
                            <asp:TableHeaderCell ForeColor="White">
                                <asp:Label runat="server"  CssClass="control-label">Quantidade de Dias</asp:Label></asp:TableHeaderCell>
                            <asp:TableHeaderCell />
                            <asp:TableHeaderCell HorizontalAlign="Right">
                                <asp:DropDownList ID="Dias" runat="server" CssClass="form-control" AutoPostBack="True">
                                    <asp:ListItem Text="1" Value="1" Selected="True"/>
                                    <asp:ListItem Text="2" Value="2"/>
                                    <asp:ListItem Text="3" Value="3"/>
                                    <asp:ListItem Text="4" Value="4"/>
                                    <asp:ListItem Text="5" Value="5"/>
                                </asp:DropDownList>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableFooterRow>
                            <asp:TableCell BackColor="DarkGreen" ForeColor="White" HorizontalAlign="Center" Text="Dia da Semana" />
                            <asp:TableCell BackColor="DarkGreen" ForeColor="White" HorizontalAlign="Center" Text="Inicio" />
                            <asp:TableCell BackColor="DarkGreen" ForeColor="White" HorizontalAlign="Center" Text="Fim" />
                        </asp:TableFooterRow>

                    </asp:Table>
                </div>
            </div>
        </asp:Panel>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Button1" runat="server" OnClick="CreateUser_Click" Text="Cadastrar-se" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

