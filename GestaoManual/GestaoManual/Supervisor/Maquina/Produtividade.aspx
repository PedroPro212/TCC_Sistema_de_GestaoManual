<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Produtividade.aspx.cs" Inherits="GestaoManual.Supervisor.Maquina.Produtividade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="visibility: hidden">
        <asp:HiddenField runat="server" ID="noMaquinas" ClientIDMode="Static" />
        <asp:DropDownList runat="server" ID="ddlPecas"></asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlMaquina"></asp:DropDownList>
    </div>

    <asp:DropDownList ID="ddlSetor" runat="server" AutoPostBack="true" CssClass="btn-sm"></asp:DropDownList>

    <canvas id="myChart"></canvas>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <script>
        var x = document.getElementById('<%=noMaquinas.ClientID %>').value;

        var maquinas = [];
        var noPecas = [];

        for (var i = 0; i < x; i++) {
            document.getElementById('<%=ddlMaquina.ClientID %>').selectedIndex = i;
            document.getElementById('<%=ddlPecas.ClientID %>').selectedIndex = i;
            maquinas.push(document.getElementById('<%=ddlMaquina.ClientID %>').value);
            noPecas.push(document.getElementById('<%=ddlPecas.ClientID %>').value);
        }
    </script>

    <script>
        const data = {
            labels: maquinas,
            datasets: [{
                label: 'Peças',
                backgroundColor: 'rgb(0, 99, 132)',
                borderColor: 'rgb(0, 99, 139)',
                data: noPecas,
            }]
        };

        const config = {
            type: 'bar',
            data: data,
            options: {}
        };
    </script>

    <script>
        const myChart = new Chart(
            document.getElementById('myChart'),
            config
        );

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
