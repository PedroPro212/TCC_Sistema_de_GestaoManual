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

        p{
            font-size:15px;
        }

        .btnPesquisar{
            border-radius:5px;
            border:none;
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

                    <p class="text-center">Pesquisar: <asp:TextBox runat="server" ID="txtPesquisar"></asp:TextBox> <asp:Button runat="server" ID="btnPesquisar" CssClass="btnPesquisar" Text="PESQUISAR" OnClick="btnPesquisar_Click" /></p>
                    <asp:DropDownList runat="server" ID="ddlSetor" CssClass="ddlSetor center-block" Width="170" Height="25" Font-Size="11"></asp:DropDownList>

                    <asp:GridView runat="server" ID="grdMaquina" Width="80%" AutoGenerateColumns="false" 
                        CssClass="table table-condensed" OnRowCommand="grdMaquina_RowCommand"
                        AllowPaging="false" OnRowDataBound="grdMaquina_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="nome" HeaderText="NOME:" />
                            <asp:BoundField DataField="tel" HeaderText="SETOR:" />
                            <asp:ButtonField ButtonType="Link" CommandName="VER" ControlStyle-CssClass="btn btn-primary" Text="VER" ItemStyle-HorizontalAlign="Center" />
                        </Columns>

                    </asp:GridView> 
                </div>
                <div class="col-sm-2"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>