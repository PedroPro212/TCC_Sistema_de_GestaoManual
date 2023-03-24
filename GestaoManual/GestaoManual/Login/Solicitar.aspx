<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="Solicitar.aspx.cs" Inherits="GestaoManual.Login.RedefinirSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        body{
            background-color:#F9B463;
        }

        .box{
            width:5vh
        }
    </style>

    <div runat="server">
        <p>Registro:</p>
        <asp:TextBox runat="server" ID="txtRegistro"></asp:TextBox>
        <asp:Button runat="server" ID="btnGerar_Numero" Text="Gerar" OnClick="btnGerar_Numero_Click" />
    </div>


    <div runat="server" class="text-center" id="divConferir">
        <asp:TextBox runat="server" ID="txtN1" CssClass="box text-center"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtN2" CssClass="box text-center"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtN3" CssClass="box text-center"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtN4" CssClass="box text-center"></asp:TextBox>

        <asp:Button runat="server" ID="btnConferir" Text="CONFERIR" OnClick="btnConferir_Click" />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
