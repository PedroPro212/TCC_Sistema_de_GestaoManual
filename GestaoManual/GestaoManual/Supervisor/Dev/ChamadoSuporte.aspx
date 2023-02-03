<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="ChamadoSuporte.aspx.cs" Inherits="GestaoManual.Supervisor.Dev.ChamadoSuporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <p>
        FILTRAR:<asp:TextBox runat="server" ID="txtPesquisar"></asp:TextBox>
        <asp:Button runat="server" ID="btnPesquisar" OnClick="btnPesquisar_Click" />
    </p>
    <br />

    <p>
        <asp:DropDownList runat="server" ID="ddlSetor">
            <asp:ListItem Text="Setor" Value="0"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlProblema">
            <asp:ListItem Text="Problema" Value="0"></asp:ListItem>
        </asp:DropDownList>
    </p>

    <asp:GridView runat="server" ID="grdProblema" Width="80%" AutoGenerateColumns="false"
        CssClass="table table-condensed" OnRowCommand="grdProblema_RowCommand" AllowPaging="false">
        <Columns>
            <asp:BoundField DataField="Registro" HeaderText="REGISTRO:" />
            <asp:BoundField DataField="Setor" HeaderText="SETOR:" />
            <asp:BoundField DataField="DataEnvio" HeaderText="DATA:" />
            <asp:BoundField DataField="Problema" HeaderText="PROBLEMA:" />
            <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO:" />
            <asp:ButtonField ButtonType="Link" CommandName="MARCAR COMO CONCLUIDO" ControlStyle-CssClass="btn btn-primary" Text="VER" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>







</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
