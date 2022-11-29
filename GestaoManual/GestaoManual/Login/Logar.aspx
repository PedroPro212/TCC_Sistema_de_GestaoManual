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
            <div id="quadro" style="background-color:white;margin-top:50px;border-radius:5px; height:330px; box-shadow:black 1px 1px 1px">
                <p class="text-left" style="padding-top:10px; padding-left:18px">*LOGO</p>
                <b><p style="text-transform:uppercase; font-size:18px;">Fazer Login</p></b>
                <div style="padding-top:20px;padding-left:50px;">
                    <div class="text-left">
                        <p>Registro:</p>
                        <asp:TextBox runat="server" ID="txtRegistro" Width="250"></asp:TextBox>
                    </div>
                    <div class="text-left" style="margin-top:10px">
                        <p>Senha:</p>
                        <asp:TextBox runat="server" CssClass="txtSenha" ID="txtSenha" Width="250" type="password"></asp:TextBox><br />
                    </div>
                </div>
<%--                <asp:CheckBox runat="server" ID="chkSenha" Text="Mostrar senha" OnCheckedChanged="chkSenha_CheckedChanged" />--%>
                <div class="form-check text-left" style="padding-top:8px;padding-left:50px;">
                    <input type="checkbox" class="form-check-input" id="check1" name="option1" value="Msenha">
                    <label class="form-check-label" for="check1">Mostrar senha</label>
                </div>
                <div class="text-right" style="padding-top:30px;padding-right:48px;"><asp:Button runat="server" ID="btnLogin" Text="ENTRAR" CssClass="bg" BorderStyle="None" /></div>
            </div>
        </div>
        
        <div class="col-sm-4"></div>
    </div>
    
    <script>

        const senha = document.querySelector('#txtSenha').value;
        const check = document.querySelector('#check1');

        check.onclick = () => {
            if (senha.type === 'password')
            {
                senha.type = 'text'
                console.log('Type')
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
