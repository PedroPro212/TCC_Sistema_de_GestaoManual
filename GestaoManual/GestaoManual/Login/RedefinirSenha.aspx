<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="RedefinirSenha.aspx.cs" Inherits="GestaoManual.Login.RedefinirSenha1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        body{
            background-color:#F9B463;
        }

        .quadro{
            width:70vh;
            background-color:white;
            border-radius:5px;
            box-shadow:2px 2px 2px;
            margin-top:15vh;
            padding-top:2px;
            padding-bottom:2vh;
        }

        h1{
            text-transform:uppercase;
            font-size:22px;
        }

        p{
            font-size:17px
        }

        .btnRedefinir{
            display:block;
            width:40vh;
            height:5vh;
            background-color:#38B6FF;
            margin-top:4vh;
            border-style:none;
            border-radius:5px;
            font-size:18px
        }
    </style>

    <div class="container" style="display:flex; justify-content:center; align-items:center;">
        <div class="row">
            <div class="quadro">
                <h1 class="text-center">Redefinir Senha</h1>
                <div class="text-center">
                    <p>Nova senha:</p><asp:TextBox runat="server" ID="txtSenha1" TextMode="Password"></asp:TextBox>
                    <p>Conferir senha:</p><asp:TextBox runat="server" ID="txtSenha2" TextMode="Password"></asp:TextBox>
                </div>

                <asp:Button runat="server" ID="btnAlterar" CssClass="btnRedefinir center-block" Text="ALTERAR SENHA" OnClick="btnAlterar_Click" />
            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
