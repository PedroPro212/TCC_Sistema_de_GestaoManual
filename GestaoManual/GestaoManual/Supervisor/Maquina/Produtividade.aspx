<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Produtividade.aspx.cs" Inherits="GestaoManual.Supervisor.Maquina.Produtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <asp:DropDownList ID="ddlSetor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DUMMY" CssClass="btn-sm"></asp:DropDownList>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
