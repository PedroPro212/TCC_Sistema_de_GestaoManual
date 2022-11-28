<%@ Page Title="Login" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="TelaLogin.aspx.cs" Inherits="GestaoManual.Login.TelaLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>sss</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                <h3 style="text-transform:uppercase">*Logo</h3>
                <h2 style="text-transform:uppercase">Fazer Login</h2>
                <p>Registro:</p>
                <asp:TextBox runat="server"></asp:TextBox>
                <p>Senha:</p>
                <asp:TextBox runat="server"></asp:TextBox><br />
                <asp:Button runat="server" Text="ENTRAR" />
            </div>
            <div class="col-sm-4"></div>
        </div>
    </div>
</asp:Content>
