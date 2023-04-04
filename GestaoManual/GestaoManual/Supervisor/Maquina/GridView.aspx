<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="GestaoManual.Supervisor.Maquina.GridView" EnableEventValidation="false" %>
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
            color:white;
        }
        .btn1{
            background-color:#00A3FF;
            margin-right:10%;
            margin-left:23%;
            margin-bottom:20px;
            
        }
        .btn2{
            background-color:#F9B463;
            margin-bottom:20px;
        }

        p{
            font-size:15px;
        }
        .p2{
            font-size:15px;
            margin-left:260px;
            margin-top:10px;
        }

        .btnPesquisar{
            border-radius:5px;
            border:none;
        }
        
        .btn-excel{
            margin-bottom:15px;
            font-size:12px;
        }

    </style>

    <div class="container">
        <div class="row">
            <div class="quadro center-block">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <p class="text-center col-sm-12" style="font-size:25px; text-transform:uppercase; margin-top:15px;">Seção de Máquinas</p>
                    <asp:Button runat="server" CssClass="btn btn1" ID="btnCriar" Text="CRIAR MÁQUINA" OnClick="btnCriar_Click" />
                   <asp:Button runat="server" CssClass="btn btn2" ID="btnProdutividade" Text="PRODUTIVIDADE" OnClick="btnProdutividade_Click"/>

                    <p class="text-center">Pesquisar: <asp:TextBox runat="server" ID="txtPesquisar" placeholder="Máquina:"></asp:TextBox> <asp:Button runat="server" ID="btnPesquisar" CssClass="btnPesquisar" Text="PESQUISAR" OnClick="btnPesquisar_Click" /></p>
                    <p class="p2"><asp:TextBox runat="server" ID="txtPesquisarOp" CssClass="txtPesquisarOp" placeholder="Operador:"></asp:TextBox></p>
                    <asp:DropDownList runat="server" ID="ddlSetor" CssClass="ddlSetor center-block" Width="170" Height="25" Font-Size="11" AutoPostBack="true" OnSelectedIndexChanged="ddlSetor_SelectedIndexChanged"></asp:DropDownList>

                    <asp:Button runat="server" ID="btnExportarExcel" Text="Excel" CssClass="btn btn-success btn-excel" Width="100" Height="23" Enabled="false" OnClick="btnExportarExcel_Click" />
                    <asp:GridView runat="server" ID="grdMaquina" Width="80%" AutoGenerateColumns="false" 
                        CssClass="table table-condensed" OnRowCommand="grdMaquina_RowCommand"
                        AllowPaging="false" OnRowDataBound="grdMaquina_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="NomeMaquina" HeaderText="MÁQUINA:" />
                            <asp:BoundField DataField="NomeSetor" HeaderText="SETOR:" />
                            <asp:BoundField DataField="NomeOperador" HeaderText="OPERADOR:" />
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