<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="RedefinirSenha.aspx.cs" Inherits="GestaoManual.Login.RedefinirSenha1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        body{
            background-color:#F9B463;
        }
    </style>

    <asp:TextBox runat="server" ID="txtSenha1"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtSenha2"></asp:TextBox>
    <asp:Button runat="server" ID="btnAlterar" Text="ALTERAR SENHA" OnClick="btnAlterar_Click" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
