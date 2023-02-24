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
            </div>
        </div>
    </div>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
