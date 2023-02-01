<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="GridViewProduto.aspx.cs" Inherits="GestaoManual.Supervisor.Produtos.GridViewProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Button runat="server" ID="btnCadastrar" Text="CADASTRAR PRODUTO" OnClick="btnCadastrar_Click" />
    <asp:TextBox runat="server" ID="txtPesquisar"></asp:TextBox>
    <asp:Button runat="server" ID="btnPesquisar" Text="PESQUISAR" OnClick="btnPesquisar_Click"/>
    <asp:GridView runat="server" ID="grdProduto" Width="80%" AutoGenerateColumns="false" 
                        CssClass="table table-condensed" OnRowCommand="grdMaquina_RowCommand"
                        AllowPaging="false">
                        <Columns>
                            <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO:" />
                            <asp:ButtonField ButtonType="Link" CommandName="VER" ControlStyle-CssClass="btn btn-primary" Text="VER" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
        </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
