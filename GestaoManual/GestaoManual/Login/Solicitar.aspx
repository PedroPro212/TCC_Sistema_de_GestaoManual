<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="Solicitar.aspx.cs" Inherits="GestaoManual.Login.RedefinirSenha" %>
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

        .box{
            width:5vh
        }

        .txtRegistro{
            margin-bottom:5vh
        }

        .btnGerar{
            display:block;
            width:40vh;
            height:5vh;
            background-color:#38B6FF;
            border-style:none;
            border-radius:5px;
            font-size:18px
        }
    </style>

    <div class="container" style="display:flex; justify-content:center; align-items:center;">
        <div class="row">
            <div class="quadro text-center">
                <div runat="server" id="divSolicitar">
                    <h1 class="text-center">Recuperar Senha</h1>
                    <p style="margin-top:5vh; margin-bottom:7vh">Coloque seu registro para recuperar redefinir sua senha</p>
                    <p style="display:inline; margin-top:15vh">Registro:</p>
                    <asp:TextBox runat="server" ID="txtRegistro" CssClass="txtRegistro"></asp:TextBox>
                    <asp:Button runat="server" ID="btnGerar_Numero" CssClass="btnGerar center-block" Text="GERAR" OnClick="btnGerar_Numero_Click" />
                </div>


                <div runat="server" class="text-center" id="divConferir">
                    <asp:TextBox runat="server" ID="txtN1" CssClass="box text-center"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtN2" CssClass="box text-center"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtN3" CssClass="box text-center"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtN4" CssClass="box text-center"></asp:TextBox>

                    <asp:Button runat="server" ID="btnConferir" Text="CONFERIR" OnClick="btnConferir_Click" />
                </div>
            </div>
            
        </div>

    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
