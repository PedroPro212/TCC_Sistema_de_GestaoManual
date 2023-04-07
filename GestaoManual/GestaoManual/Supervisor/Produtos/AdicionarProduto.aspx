<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="AdicionarProduto.aspx.cs" Inherits="GestaoManual.Supervisor.Produtos.AdicionarProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        .quadro{
            background-color:white;
            border-radius:5px;
            width:80vh;
            margin-top:15vh;
            padding-top:15px;
            padding-bottom:15px;
            box-shadow:2px 2px 2px;
        }

        h1{
            text-transform:uppercase;
            font-size:25px;
            margin-bottom:3vh
        }

        p{
            font-size:20px
        }

        .txtDescricao{
            width:30vh;
            height:4vh;
            font-size:15px;
        }

        .btnCadastrar{
            width:30vh;
            height:5vh;
            background-color:#00A3FF;
            border-radius:5px;
            font-size:23px;
            margin-top:2vh;
            border:none;
            color:white;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="quadro center-block">
                <div class="col-sm-12 text-center">
                    <h1>Cadastrar Produto</h1>
                    <p>Descrição:</p><asp:TextBox runat="server" ID="txtDescricao" CssClass="txtDescricao"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnCadastrar" CssClass="btnCadastrar" Text="CADASTRAR" OnClick="btnCadastrar_Click" />
                </div>
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
