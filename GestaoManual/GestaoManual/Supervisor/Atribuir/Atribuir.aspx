﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Atribuir.aspx.cs" Inherits="GestaoManual.Supervisor.Atribuir.Atribuir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:DropDownList runat="server" ID="ddlOperador" AutoPostBack="true" OnSelectedIndexChanged="ddlOperador_SelectedIndexChanged"></asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddlMaquina" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlMaquina_SelectedIndexChanged"></asp:DropDownList>
    <asp:Button runat="server" ID="btnAtribuir" Text="ATRIBUIR" OnClick="btnAtribuir_Click" Enabled="false"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
