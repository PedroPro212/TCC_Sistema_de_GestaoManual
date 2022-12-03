<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="Logar.aspx.cs" Inherits="GestaoManual.Login.Logar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <link rel="stylesheet" href="Logar.css" /> <%--Conexão ao arquivo de estilo css--%>
   
    <div class="container">
        <div class="col-sm-4"></div>

        <div class="col-sm-4 quadro text-center">
            <div id="quadro" style="background-color: white; margin-top: 50px; border-radius: 5px; height: 330px; box-shadow: black 1px 1px 1px">
                <p class="text-left" style="padding-top: 10px; padding-left: 18px">*LOGO</p> <%--Espaço reservado para logo do sistema--%>
                <b>
                    <p style="text-transform: uppercase; font-size: 18px;">Fazer Login</p>
                </b>
                <div style="padding-top: 20px; padding-left: 50px;">
                    <div class="text-left">
                        <p>Registro:</p>
                        <asp:TextBox runat="server" ID="txtRegistro" Width="250"></asp:TextBox> <%--Campo para inserir o registro--%>
                    </div>
                    <div class="text-left" style="margin-top: 10px">
                        <p>Senha:</p>
                        <asp:TextBox runat="server" ID="txtSenha" Width="250" MaxLength="6"></asp:TextBox> <%--Campo para inserir senha--%>
                        <br />
                    </div>
                </div>
                <div class="form-check text-left" style="padding-top: 8px; padding-left: 50px;">
                    <asp:CheckBox runat="server" AutoPostBack="true" ID="chkMostrarSenha" CssClass="form-check-input" Text=" Mostrar senha" OnCheckedChanged="chkMostrarSenha_CheckedChanged"/> <%--Revela os caracteres da textbox txtSenha--%>
                </div>
                <div class="text-right" style="padding-top: 30px; padding-right: 48px;"> 
                    <asp:Button runat="server" ID="btnLogin" Text="ENTRAR" CssClass="bg" BorderStyle="None" OnClick="btnLogin_Click"/> <%--Botão para checar login e acessar a página principal--%>
                </div>
            </div>
        </div>

        <div class="col-sm-4"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
