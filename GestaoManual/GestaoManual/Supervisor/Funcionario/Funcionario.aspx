<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="GestaoManual.Supervisor.Funcionario.Funcionario" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        .quadro {
            width: 100%;
            background-color: white;
            border-radius: 5px;
            margin-top: 25px;
            box-shadow:2px 2px 2px;
        }

        h1{
            margin-top:15px;
            text-transform:uppercase;
            font-size:25px;
        }

        .btnCadastrar {
            width: 220px;
            height: 32px;
            margin-top:80px;
            margin-bottom:30px;
            border-radius: 5px;
            font-size: 15px;
            background-color:#00A3FF;
            border:none;
            box-shadow:2px 2px 2px;
            color:white
        }   
            .btnCadastrar:hover{
                background-color:cornflowerblue;
            }

        p {
            font-size: 15px;
        }

        .btnPesquisar {
            border-radius: 5px;
            border: none;
            background-color:#00A3FF;
            color:white;
            font-size:15px;
            margin-bottom:15px;
        }

        .table{
            margin-bottom:30px;
            font-size:13px
        }
            .btn{
                width:150px;
                height:30px;
                font-size:15px
            }

        .btn-excel{
            margin-left:110px;
            margin-bottom:15px;
            font-size:12px;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="quadro">
                <%--<div class="col-sm-1"></div>--%>
                <div class="col-sm-12">
                    <h1 class="col-sm-12 text-center">Funcionários</h1>
                    <asp:Button runat="server" ID="btnCriarFuncionario" CssClass="btnCadastrar center-block" Text="CADASTRAR FUNCIONÁRIO" OnClick="btnCriarFuncionario_Click" /><br />  

                    <p class="text-center">Pesquisar: <asp:TextBox runat="server" ID="txtPesquisar"></asp:TextBox></p> 
                    <asp:Button runat="server" ID="btnPesquisar" CssClass="btnPesquisar center-block" Width="150" Height="23" Text="PESQUISAR" OnClick="btnPesquisar_Click"/>
                    
                    <asp:Button runat="server" ID="btnExportarExcel" Text="Excel" CssClass="btn btn-success btn-excel" Width="100" Height="23" Enabled="false" OnClick="btnExportarExcel_Click" />
                    <asp:GridView runat="server" ID="grdFuncionario" Width="80%" AutoGenerateColumns="false"
                        CssClass="table table-condensed center-block" OnRowCommand="grdFuncionario_RowCommand"
                        AllowPaging="false" OnDataBound="grdFuncionario_DataBound">

                        <Columns>
                            <asp:BoundField DataField="Nome" HeaderText="NOME:" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="DataN" HeaderText="DATA NASCIMENTO:" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="Cpf" HeaderText="CPF:" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="Email" HeaderText="EMAIL:" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="Tel" HeaderText="TELEFONE:" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="NomeSetor" HeaderText="SETOR:" HeaderStyle-CssClass="text-center" />
                            <asp:ButtonField ButtonType="Link" CommandName="VER" ControlStyle-CssClass="btn btn-primary" Text="VER" ItemStyle-HorizontalAlign="Center" />
                        </Columns>

                    </asp:GridView>
                </div>
                <%--<div class="col-sm-1"></div>--%>
            </div>
        </div>
    </div>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
