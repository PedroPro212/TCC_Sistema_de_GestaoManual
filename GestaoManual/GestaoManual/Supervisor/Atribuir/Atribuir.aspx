<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Atribuir.aspx.cs" Inherits="GestaoManual.Supervisor.Atribuir.Atribuir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">


     <style>
            .quadro{
                width:400px;
                height:350px;
                margin-top:100px;
                border-radius:5px;
                box-shadow:2px 2px 2px;
                background-color:white;
            }
    
            p{
                font-size:15px;
            }

            .center-func{
                margin-right:25px;
            }

            .center-mqn{
                margin-left:50px;
            }

            .btnLinkar{
                width:262px;
                height:44px;
                background-color:#00A3FF;
                border-radius:5px;
                font-size:23px;
                margin-top:100px;
                border:none;
                color:white;
            }
            
     </style>

        <div class="container">
            <div class="row">
                <div class="quadro center-block">
                    <p class="text-center col-sm-12" style="font-size:25px; text-transform:uppercase; margin-top:25px;">Tela de Atribuição</p>
                    <div class="col-sm-12"><h3 class="text-left" runat="server" style="margin-top:10px" id="dev" visible="false">DEV</h3></div>
                    <div class=" col-sm-12 text-center">
                        <p class="text-center center-func" >Funcionario: <asp:DropDownList runat="server" CssClass="" ID="ddlOperador" AutoPostBack="true" OnSelectedIndexChanged="ddlOperador_SelectedIndexChanged"></asp:DropDownList></p>
                        <p class="text-center">Máquina: <asp:DropDownList runat="server" CssClass="" ID="ddlMaquina" Enabled="false"></asp:DropDownList></p>
                        <p><asp:Button runat="server" CssClass="" ID="btnAtribuir" Text="ATRIBUIR" OnClick="btnAtribuir_Click"/></p>
                    </div>
                </div>
            </div>
         </div>
        



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
