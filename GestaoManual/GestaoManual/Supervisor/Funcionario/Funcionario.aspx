<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="GestaoManual.Supervisor.Funcionario.Funcionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        .quadro {
            width: 100%;
            background-color: white;
            border-radius: 5px;
            margin-top: 50px;
        }

        .btn {
            width: 140px;
            height: 32px;
            border-radius: 5px;
            font-size: 15px;
        }

        .btn1 {
            background-color: #00A3FF;
        }

        .btn2 {
            background-color: #F9B463;
            margin-left: 60%
        }

        p {
            font-size: 15px;
        }

        .btnPesquisar {
            border-radius: 5px;
            border: none;
        }
    </style>
    <asp:Button runat="server" ID="btnCriarFuncionario" Text="CADASTRAR FUNCIONÁRIO" OnClick="btnCriarFuncionario_Click" /><br />  

    <p class="text-center">Pesquisar: <asp:TextBox runat="server" ID="txtPesquisar"></asp:TextBox> <asp:Button runat="server" ID="btnPesquisar" CssClass="btnPesquisar" Text="PESQUISAR" OnClick="btnPesquisar_Click"/></p>

    <asp:GridView runat="server" ID="grdFuncionario" Width="80%" AutoGenerateColumns="false"
        CssClass="table table-condensed" OnRowCommand="grdFuncionario_RowCommand"
        AllowPaging="false" OnDataBound="grdFuncionario_DataBound">

        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="NOME:" />
            <asp:BoundField DataField="DataN" HeaderText="SATANAS:" />
            <asp:BoundField DataField="Cpf" HeaderText="CPF:" />
            <asp:BoundField DataField="Email" HeaderText="EMAIL:" />
            <asp:BoundField DataField="Tel" HeaderText="TELEFONE:" />
            <asp:BoundField DataField="NomeSetor" HeaderText="SETOR:" />
            <asp:ButtonField ButtonType="Link" CommandName="VER" ControlStyle-CssClass="btn btn-primary" Text="VER" ItemStyle-HorizontalAlign="Center" />
        </Columns>

    </asp:GridView>


    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
