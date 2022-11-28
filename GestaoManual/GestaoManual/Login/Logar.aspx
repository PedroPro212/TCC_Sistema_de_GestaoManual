<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="Logar.aspx.cs" Inherits="GestaoManual.Login.Logar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        body{
            background-color:#F9B463;
        }

        .bg{
            background-color:#00C643;
            color:white;
            border-radius:5px;
            
        }
    </style>

    <div class="container">
        <div class="col-sm-4"></div>

        <div class="col-sm-4 quadro text-center">
            <div style="background-color:white;margin-top:50px;border-radius:5px; height:330px; box-shadow:black 1px 1px 1px">
                <p class="text-left" style="padding-top:10px; padding-left:18px">*LOGO</p>
                <b><p style="text-transform:uppercase; font-size:18px;">Fazer Login</p></b>
                <div style="padding-top:20px;padding-left:50px;">
                    <div class="text-left">
                        <p>Registro:</p>
                        <asp:TextBox runat="server" Width="250"></asp:TextBox>
                    </div>
                    <div class="text-left">
                        <p>Senha:</p>
                        <asp:TextBox runat="server" Width="250"></asp:TextBox><br />
                    </div>
                </div>

                <div class="text-right" style="padding-top:30px;padding-right:48px;"><asp:Button runat="server" Text="ENTRAR" CssClass="bg" BorderStyle="None" /></div>
            </div>
        </div>

        <div class="col-sm-4"></div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
