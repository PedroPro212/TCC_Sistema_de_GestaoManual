<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Atribuir.aspx.cs" Inherits="GestaoManual.Supervisor.Atribuir.Atribuir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:DropDownList runat="server" ID="ddlOperador"></asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddlMaquina"></asp:DropDownList>
    <asp:Button runat="server" ID="btnAtribuir" Text="ATRIBUIR" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
