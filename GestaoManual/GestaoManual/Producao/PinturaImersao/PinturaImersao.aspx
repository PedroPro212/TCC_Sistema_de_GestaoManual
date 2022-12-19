<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="PinturaImersao.aspx.cs" Inherits="GestaoManual.Producao.PinturaImersao.PinturaImersao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        body{
            background-color: #F9B463;
        }
        .quadro{
            background-color: #F5F5F5;
            width:361px;
            height:446px;
            border-radius:5px;
        }

    </style>
    
    <div class="col-sm-4"></div>
    <div class="col-sm-4 center-block">
        <div class="quadro">
            <p class="text-center" style="text-transform:uppercase; font-size:20px; margin-top:70px; padding-top:20px">Pintura por Imersão</p>
            <p class="text-center" style="font-size:18px; margin-top:25px">Selecione o produto:</p>
            <div class="text-center"><asp:DropDownList runat="server" ID="ddlProduto" Width="250" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged"></asp:DropDownList></div>
            <div style="margin-top:20px"><asp:Image runat="server" ID="imgProduto" CssClass="text-center" Width="110" /></div>
            <div style="margin-top:100px"><asp:Button runat="server" ID="btnEntrar" CssClass="center-block" Text="ENTRAR" Width="142" /></div>
        </div>
    </div>
    
    <div class="col-sm-4"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>