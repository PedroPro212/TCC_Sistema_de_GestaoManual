<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="GestaoManual.Supervisor.Funcionario.Funcionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <!-- The sidebar element -->
    <div id="mySidenav" class="sidenav">...</div>
    <!-- Right after the browser renders the sidebar -->
    <script type="text/javascript">
        // If localStorage is supported by the browser
        if (typeof(Storage) !== "undefined") {
            // If we need to open the bar
            if(localStorage.getItem("sidebar") == "opened"){
                // Open the bar
                document.getElementById("mySidenav").style.width = "250px";
                document.getElementById("main").style.marginLeft = "250px";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
