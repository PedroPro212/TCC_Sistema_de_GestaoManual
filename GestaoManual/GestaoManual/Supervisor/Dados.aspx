<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Dados.aspx.cs" Inherits="GestaoManual.Supervisor.Dados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        .quadro{
            background-color:#FFFFFF;
            border-radius:5px;
            box-shadow:black 2px 2px 2px;
            width:776px;
            height:428px;
        }

        .btnSalvar{
            background-color:#00A3FF;
            width:173px;
            height:35px;
            border-radius:5px;
            color:white;
            font-size:15px;
            margin-top:70px;
        }

        .btnEditar{
            background-image:url('/imgs/edit.png');
            width:30px;
        }

        p{
            font-size:15px;
        }

    </style>

    <div class="container">
        <div class="row">
            <div class="col-sm-1"></div>
            <div class="col-sm-10" style="margin-top:80px;margin-left:50px">
                <div class="quadro">
                    <div class="container">
                        <p class="text-center" style="text-transform:uppercase; font-size:25px; margin-top:5px">Seus Dados</p>
                        <div class="col-sm-6">
                            <p>Nome: <asp:Label runat="server" ID="lblNome" Font-Size="11"></asp:Label></p>
                            <p>Data Nascimento: <asp:Label runat="server" ID="lblData" Font-Size="11"></asp:Label></p>
                            <p>Setor: </p><asp:Label runat="server" ID="lblSetor" Font-Size="11"></asp:Label>
                        </div>
                        <div class="col-sm-6">
                            <p>E-mail:</p><asp:TextBox runat="server" ID="txtEmail" Enabled="false" Width="280" Height="30" Font-Size="11"></asp:TextBox><asp:CheckBox runat="server" ID="ckbEditarEmail" OnCheckedChanged="ckbEditarEmail_CheckedChanged" AutoPostBack="true" />
                            <p>Telefone:</p><asp:TextBox runat="server" ID="txtTelefone" Enabled="false" Width="170" Height="30" Font-Size="11"></asp:TextBox><asp:CheckBox runat="server" ID="ckbEditar" OnCheckedChanged="ckbEditar_CheckedChanged" AutoPostBack="true" />
                            
                            <p>Alterar Senha: 
                            <asp:CheckBox runat="server" ID="ckbSenha" OnCheckedChanged="ckbSenha_CheckedChanged" AutoPostBack="true" /></p>
                            <asp:TextBox runat="server" ID="txtSenha1" Width="170" Height="30" Font-Size="11"></asp:TextBox>

                            <p>Confirmar Senha:</p>
                            <asp:TextBox runat="server" ID="txtSenha2" Width="170" Height="30" Font-Size="11"></asp:TextBox>
                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnSalvar" CssClass="btnSalvar" Text="SALVAR" OnClick="btnSalvar_Click" BorderStyle="None" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
