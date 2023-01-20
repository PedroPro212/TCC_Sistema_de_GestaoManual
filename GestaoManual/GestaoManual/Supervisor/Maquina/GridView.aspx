<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="GestaoManual.Supervisor.Maquina.GridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
        <style>
        .quadro{
            width:100%;
            background-color:white;
            border-radius:5px;
            margin-top:50px;
        }

        .btn{
            width:140px;
            height:32px;
            border-radius:5px;
            font-size:15px;
        }
        .btn1{
            background-color:#00A3FF;
            
        }
        .btn2{
            background-color:#F9B463;
            margin-left:60%
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="quadro center-block">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <p class="text-center col-sm-12" style="font-size:25px; text-transform:uppercase">Máquinas</p>
                    <asp:Button runat="server" CssClass="btn btn1" ID="btnCriar" Text="CRIAR MÁQUINA" OnClick="btnCriar_Click" />
                    <asp:Button runat="server" CssClass="btn btn2" ID="btnProdutividade" Text="PRODUTIVIDADE" OnClick="btnProdutividade_Click" />
                </div>
                <div class="col-sm-2"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
