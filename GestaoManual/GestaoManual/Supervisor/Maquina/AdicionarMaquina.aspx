<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="AdicionarMaquina.aspx.cs" Inherits="GestaoManual.Supervisor.Maquina.AdicionarMaquina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        .quadro{
            width:100%;
            margin-top:100px;
            border-radius:5px;
            box-shadow:2px 2px 2px;
            background-color:white;
        }

        h1{
            margin-top:15px;
            margin-bottom:70px;
        }

        p{
            font-size:20px;
            margin-bottom:30px;
        }

        .btnCriar{
            width:262px;
            height:44px;
            background-color:#00A3FF;
            border-radius:5px;
            font-size:23px;
            margin-top:100px;
            margin-bottom:60px;
            border:none;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="quadro center-block">
                <div class="col-sm-4"><h3 class="text-left" runat="server" id="dev" visible="false">DEV</h3></div>
                <div class=" col-sm-4 text-center">
                    <h1 style="font-size:25px; text-transform:uppercase">Criar Máquina</h1>
                    <p>Nome: <asp:TextBox runat="server" ID="txtNome"></asp:TextBox></p>
                    <p runat="server" id="pSetor" visible="false">Setor: <asp:DropDownList runat="server" ID="ddlSetor" Visible="false"></asp:DropDownList></p>
                    <asp:Button runat="server" CssClass="btnCriar" ID="btnCriar" Text="CRIAR" OnClick="btnCriar_Click" />
                </div>
                <div class="col-sm-4">
                    <asp:Label runat="server" ID="lblinvisivel" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="lblinvisivel2" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
