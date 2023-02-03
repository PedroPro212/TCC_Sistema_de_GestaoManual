<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="ChamadoSuporte.aspx.cs" Inherits="GestaoManual.Supervisor.Dev.ChamadoSuporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <p>
        FILTRAR:<asp:TextBox runat="server" ID="txtPesquisar"></asp:TextBox>
        <asp:Button runat="server" ID="btnPesquisar" Text="PESQUISAR" OnClick="btnPesquisar_Click"/>
    </p>
    <br />

    <p>
        <asp:DropDownList runat="server" ID="ddlSetor">
            <asp:ListItem Text="Setor" Value="0"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlProblema">
            <asp:ListItem Text="Problema" Value=""></asp:ListItem>
        </asp:DropDownList>
    </p>

    <asp:GridView runat="server" ID="grdProblema" Width="80%" AutoGenerateColumns="false"
        CssClass="table table-condensed" AllowPaging="false" OnRowCommand="grdProblema_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdRegistro" HeaderText="REGISTRO:" />
            <asp:BoundField DataField="IdSetor" HeaderText="SETOR:" />
            <asp:BoundField DataField="DataEnvio" HeaderText="DATA:" />
            <asp:BoundField DataField="NomeProblema" HeaderText="PROBLEMA:" />
            <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO:" />
            <asp:ButtonField ButtonType="Link" CommandName="MarcarConcluido" ControlStyle-CssClass="btn btn-primary" Text="MARCAR COMO CONCLUÍDO" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>







</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
