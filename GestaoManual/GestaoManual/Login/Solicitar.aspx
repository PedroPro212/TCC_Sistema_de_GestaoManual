<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="Solicitar.aspx.cs" Inherits="GestaoManual.Login.RedefinirSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        body{
            background-color:#F9B463;
        }
    </style>

    <p>Registro:</p>
    <asp:TextBox runat="server" ID="txtRegistro"></asp:TextBox>
    <asp:Button runat="server" ID="btnGerar_Numero" Text="Gerar" OnClick="btnGerar_Numero_Click" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
