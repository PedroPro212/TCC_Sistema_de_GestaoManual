<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="Logar.aspx.cs" Inherits="GestaoManual.Login.Logar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <link rel="stylesheet" href="Logar.css"/> <%--Conexão ao arquivo de estilo css--%>

    <style>

        @import url('https://fonts.googleapis.com/css2?family=Anton&display=swap');

        body{
            width:100%;
            min-height:100vh;
            align-items:center;
            justify-content:center;
        }
        .txt{
            border:0;
            border-bottom:1px solid black;
            outline:none;
        }

        p{
            margin-bottom:0;
            font-size:18px
        }

        .bg {
            background-color: #00C643;
            color: white;
            border-radius: 5px;
            margin-top:25px;
            margin-bottom:150px;
            width:85%;
            height:33px
        }
            .bg:hover{
                background-color:darkgreen
            }


        @keyframes barra1{
            0% {height: 20px;}
            100% {height: 60px;}
        }
        @keyframes barra2{
            0% {height: 35px;}
            100% {height: 60px;}
            0% {height: 0px;}
        }
        @keyframes barra3{
            0% {height: 35px;}
            100% {height: 60px;}
            0% {height: 0px;}
        }
        @keyframes barra4{
            0% {height: 35px;}
            100% {height: 60px;}
            0% {height: 0px;}
        }

        .container2{
            display: flex;
        }

        .col-1{
            width: 20px;
            height: 20px;
            background-color:#FDD04C;
            margin-left: -20px;
            border-radius: 2px;
            animation-name: barra1;
            animation-duration: 1.5s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
            animation-direction: alternate;
            position: absolute;
            bottom: 75%;
            box-shadow:1px 1px 1px;
        }
        .col-2{
            width: 20px;
            height: 35px;
            background-color:#38B6FF;
            margin-left: 5px;
            border-radius: 2px;
            animation-name: barra2;
            animation-duration: 1s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
            animation-direction: alternate;
            position: absolute;
            bottom: 75%;
            box-shadow:1px 1px 1px;
        }
        .col-3{
            width: 20px;
            height: 30px;
            background-color:#3C6A98;
            margin-left: 33px;
            border-radius: 2px;
            animation-name: barra3;
            animation-duration: 1.8s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
            animation-direction: alternate;
            position: absolute;
            bottom: 75%;
            box-shadow:1px 1px 1px;
        }
        .col-4{
            width: 20px;
            height: 45px;
            background-color:#ffbd59;
            margin-left: 60px;
            border-radius: 2px;
            animation-name: barra4;
            animation-duration: 0.9s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
            animation-direction: alternate;
            position: absolute;
            bottom:75%;
            box-shadow:1px 1px 1px;
        }

        .seg p{
            display:flex;
            left: 44%;
            position: absolute;
            bottom: 68%;
            font-size: 20px;
            font-family: 'Anton', sans-serif;
        }
    </style>

    <div class="container">
        <div class="col-sm-4"></div>

        <div class="col-sm-4 quadro text-center">
            <div id="quadro" style="background-color: white; margin-top: 50px; border-radius: 5px; height: 500px; box-shadow: black 1px 1px 1px">
<%--                <img class="logo center-block" src="/imgs/SEGLogar.png" width="80" style="display:flex; padding-top:15px; padding-bottom:15px" /> <%--Espaço reservado para logo do sistema--%>
                <div class="conatiner2" style="margin-left:140px;">
                    <div class="col-1"></div>
                    <div class="col-2"></div>
                    <div class="col-3"></div>
                    <div class="col-4"></div>
                </div>
                <div class="seg"><p style="color:#FDD04C">S</p><p style="color:#3C6A98; margin-left: 13px;">E</p><p style="color:#38B6FF; margin-left: 23px;">G</p></div>
                <b>
                    <p style="text-transform: uppercase; font-size: 25px;padding-top:130px; margin-bottom:15px">Fazer Login</p>
                </b>
                <div style="padding-top: 20px; padding-left: 50px;">
                    <div class="text-left">
                        <p>Registro:</p>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtRegistro" Width="250" Font-Size="15"></asp:TextBox> <%--Campo para inserir o registro--%>
                    </div>
                    <div class="text-left" style="margin-top: 25px">
                        <p>Senha:</p>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtSenha" Width="250" Font-Size="15"></asp:TextBox> <%--Campo para inserir senha--%>
                        <br />
                    </div>
                </div>
                <div class="form-check text-left" style="padding-top: 8px; padding-left: 50px;">
                    <asp:CheckBox runat="server" AutoPostBack="true" ID="chkMostrarSenha" CssClass="form-check-input" Text=" Mostrar senha" OnCheckedChanged="chkMostrarSenha_CheckedChanged"/> <%--Revela os caracteres da textbox txtSenha--%>
                </div>
                <div class="text-right" style="padding-top: 5px; padding-right: 48px;">
                    <asp:Button runat="server" ID="btnLogin" Text="ENTRAR" CssClass="bg" BorderStyle="None" OnClick="btnLogin_Click"/> <%--Botão para checar login e acessar a página principal--%>
                </div>
            </div>
        </div>

        <div class="col-sm-4"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
