<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="GerarRelatorio.aspx.cs" Inherits="GestaoManual.Supervisor.Relatorio.GerarRelatorio" %>
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
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="quadro">
                <div class="col-sm-12 text-center"><h1>Gerar Relatório</h1></div>
                <div class="col-sm-6">
                    <p>Data Início:</p>
                    <asp:Calendar runat="server" ID="cldInicio"></asp:Calendar>
                </div>

                <div class="col-sm-6">
                    <p>Data Final</p>
                    <asp:Calendar runat="server" ID="cldFinal"></asp:Calendar>
                </div>
                <div class="col-sm-12 text-center">
                    <asp:Button runat="server" ID="btnGerar" Text="GERAR RELATÓRIO" OnClick="btnGerar_Click" />
                </div>
                <div class="col-sm-12">
                    <asp:Button runat="server" ID="btnPesquisar" Text="PESQUISAR" OnClick="btnPesquisar_Click" />
                    <asp:GridView runat="server" ID="grdRelatorio" Width="80%" AutoGenerateColumns="false" 
                        CssClass="table table-condensed" OnRowCommand="grdRelatorio_RowCommand"
                        AllowPaging="false" OnRowDataBound="grdRelatorio_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="Produto" HeaderText="PRODUTO:" />
                            <asp:BoundField DataField="DataInicio" HeaderText="DATA HORA INICIO:" />
                            <asp:BoundField DataField="DataFim" HeaderText="DATA HORA FINAL:" />
                            <asp:BoundField DataField="NPecas" HeaderText="QTS PEÇAS:" />
                            <asp:BoundField DataField="LotePecas" HeaderText="LOTE PEÇAS:" />
                            <asp:BoundField DataField="Setor" HeaderText="SETOR:" />
                            <asp:BoundField DataField="Maquina" HeaderText="MÁQUINA:" />
                            <asp:BoundField DataField="LoteTinta" HeaderText="LOTE TINTA:" />
                            <%--<asp:ButtonField ButtonType="Link" CommandName="VER" ControlStyle-CssClass="btn btn-primary" Text="VER" ItemStyle-HorizontalAlign="Center" />--%>
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>