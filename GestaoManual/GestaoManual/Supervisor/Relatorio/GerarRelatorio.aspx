<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="GerarRelatorio.aspx.cs" Inherits="GestaoManual.Supervisor.Relatorio.GerarRelatorio" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        .quadro{
            width:100%;
            margin-top:100px;
            border-radius:5px;
            box-shadow:2px 2px 2px;
            background-color:white;
        }

        h1{
            text-transform:uppercase;
            font-size:25px;
            margin-top:15px
        }

        p{
            font-size:12px;
        }

        .table{
            margin-left:80px;
        }

        .btnExcel{
            background-color:#00c16c;
            font-size:12px;
            color:white;
            width:100px;
            height:23px;
            border-radius:3px;
            border-style:none;
            margin-bottom:15px
        }
        .btnPesquisar{
            width:200px;
            height:25px;
            font-size:15px;
            background-color:#00A3FF;
            color:white;
            margin-top:40px;
            margin-bottom:15px;
            border-style:none;
            border-radius:3px;
            box-shadow:1px 1px 1px;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="quadro">
                <div class="col-sm-4"><h3 runat="server" class="text-left" id="dev" style="margin-top:10px" id="dev" visible="false">Dev</h3></div>

                <div class="col-sm-4 text-center"><h1>Gerar Relatório</h1></div>
                <div class="col-sm-4"></div>
                <div class="col-sm-6" style="padding-left:260px">
                    <p>Data Início:</p>
                    <asp:Calendar runat="server" CssClass="calendario right" ID="cldInicio" Width="200" Height="150" Font-Size="8"></asp:Calendar>
                </div>

                <div class="col-sm-6" style="padding-left:100px">
                    <p>Data Final</p>
                    <asp:Calendar runat="server" ID="cldFinal" CssClass="calendario" Width="200" Height="150" Font-Size="8"></asp:Calendar>
                </div>
                <div class="col-sm-12 text-center">
                    <asp:Button runat="server" ID="btnPesquisar" CssClass="btnPesquisar" Text="PESQUISAR" OnClick="btnPesquisar_Click" />
                </div>

                <div class="col-sm-12 text-center">
                    
                    <asp:GridView runat="server" ID="grdRelatorio" Width="80%" AutoGenerateColumns="false" 
                        CssClass="table table-condensed" OnRowCommand="grdRelatorio_RowCommand"
                        AllowPaging="false" OnRowDataBound="grdRelatorio_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="DataInicio" HeaderText="DATA HORA INICIO:" />
                            <asp:BoundField DataField="Produto" HeaderText="PRODUTO:" />
                            <asp:BoundField DataField="QtsPecas" HeaderText="QTS PEÇAS:" />
                            <asp:BoundField DataField="LotePecas" HeaderText="LOTE PEÇAS:" />
                            <asp:BoundField DataField="Setor" HeaderText="SETOR:" />
                            <asp:BoundField DataField="Maquina" HeaderText="MÁQUINA:" />
                            <asp:BoundField DataField="LoteTinta" HeaderText="LOTE TINTA:" />
                            <asp:BoundField DataField="DataFinal" HeaderText="DATA HORA FINAL:" />
                            <%--<asp:ButtonField ButtonType="Link" CommandName="VER" ControlStyle-CssClass="btn btn-primary" Text="VER" ItemStyle-HorizontalAlign="Center" />--%>
                        </Columns>

                    </asp:GridView>
                </div>
                <div class="col-sm-12 text-left">
                    <asp:Button runat="server" ID="btnGerar" CssClass="btnExcel" Text="Excel" OnClick="btnGerar_Click" />
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>