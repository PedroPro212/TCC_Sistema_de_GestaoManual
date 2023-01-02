<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="ProcessoPintura.aspx.cs" Inherits="GestaoManual.Producao.PinturaImersao.ProcessoPintura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        body{
            background-color: #F9B463;
        }

        .quadro{
            background-color:#FFFFFF;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="quadro">
                <div class="col-sm-4">
                    <asp:Label runat="server" ID="lblNome"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <asp:Label runat="server" ID="lblProduto"></asp:Label>
                    <p>Início do processo:</p>
                    <asp:Label runat="server" ID="lblHoraInicio" Enabled="true"></asp:Label>
                    <asp:Timer runat="server" ID="tmrInicio" OnTick="tmrInicio_Tick"></asp:Timer>
                </div>
                <div class="col-sm-4">
                    <asp:Label runat="server" ID="lblSetor"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
