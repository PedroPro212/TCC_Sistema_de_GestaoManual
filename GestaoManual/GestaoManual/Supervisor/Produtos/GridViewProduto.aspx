<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="GridViewProduto.aspx.cs" Inherits="GestaoManual.Supervisor.Produtos.GridViewProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        .quadro{
            background-color:white;
            width:100%;
            box-shadow:2px 2px 2px;
            border-radius:5px;
            margin-top:10%;
        }

        .table{
            font-size:15px;
        }
        .btn{
            width:100px;
            height:30px;
            font-size:15px
        }

    </style>

    <div class="container">
        <div class="row">
            <div class="quadro">
                <div class="col-sm-3"></div>
                <div class="col-sm-6 center-block">
                    <div class="pesqisa text-center">
                        <h1 style="margin-top:15px; margin-bottom:20px;">Pesquisar Produto</h1>
                        <asp:Button runat="server" ID="btnCadastrar" CssClass="btn btn-success" Text="CADASTRAR PRODUTO" OnClick="btnCadastrar_Click" />
                        <asp:TextBox runat="server" ID="txtPesquisar" Width="150" Height="28" Font-Size="10"></asp:TextBox>
                        <asp:Button runat="server" ID="btnPesquisar" CssClass="btn btn-primary" Text="PESQUISAR" OnClick="btnPesquisar_Click"/>
                    </div>
                    <div class="text-center" style="margin-left:76px;margin-top:50px; margin-bottom:50px">
                        <asp:Label runat="server" ID="lblQTS"></asp:Label>
                        <asp:GridView runat="server" ID="grdProduto" Width="80%" AutoGenerateColumns="false" 
                            CssClass="table table-condensed" OnRowCommand="grdProduto_RowCommand"
                            AllowPaging="false">
                            <Columns>
                                <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO:" />
                                <asp:ButtonField ButtonType="Link" CommandName="excluir" ControlStyle-CssClass="btn btn-primary" Text="EXCLUIR" ItemStyle-HorizontalAlign="Center" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-sm-3"></div>
            </div>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
