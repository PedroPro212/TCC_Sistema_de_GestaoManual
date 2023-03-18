<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Produtividade.aspx.cs" Inherits="GestaoManual.Supervisor.Maquina.Produtividade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <asp:HiddenField runat="server" ID="maq1" Value="10" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="maq2" Value="20" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="maq3" Value="30" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="maq4" Value="40" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="maq5" Value="50" ClientIDMode="Static" />

    <asp:DataList runat="server" ID="dtlTeste">
        <ItemTemplate>  
                <table cellpadding="2" cellspacing="0" border="1" style="width: 300px; height: 100px;   
                border: dashed 2px #04AFEF; background-color: #FFFFFF">  
                    <tr>  
                        <td>  
                            <b>Pecas: </b><span ><%# Eval("PecasBoas") %></span><br />  
                            <b>Maquina: </b><span ><%# Eval("Maquina") %></span><br /> 
                        </td>  
                    </tr>  
                </table>  
            </ItemTemplate>  
    </asp:DataList>

    <asp:DropDownList ID="ddlSetor" runat="server" AutoPostBack="true" CssClass="btn-sm"></asp:DropDownList>

    <canvas id="myChart"></canvas>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <script>

            var alt1 = parseInt(document.getElementById('<%=maq1.ClientID %>').value);
            var alt2 = parseInt(document.getElementById('<%=maq2.ClientID %>').value);
            var alt3 = parseInt(document.getElementById('<%=maq3.ClientID %>').value);
            var alt4 = parseInt(document.getElementById('<%=maq4.ClientID %>').value);
            var alt5 = parseInt(document.getElementById('<%=maq5.ClientID %>').value);
        </script>

        <script>

            var maquinas = [];
            

            var labels = [];
            labels.push('teste 1')
            labels.push('teste 2')
            labels.push('teste 3')

            const data = {
                labels: labels,
                datasets: [{
                    label: 'Peças',
                    backgroundColor: 'rgb(0, 99, 132)',
                    borderColor: 'rgb(0, 99, 139)',
                    data: [alt1, alt2, alt3, alt4, alt5,],
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
