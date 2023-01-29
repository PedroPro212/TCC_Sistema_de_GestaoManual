<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="CriarFuncionario.aspx.cs" Inherits="GestaoManual.Supervisor.Funcionario.CriarFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        body{
            background-color:#F9B463;
        }

        .quadro{
            margin-top:120px;
            background-color:white;
            border-radius:5px;
            box-shadow:2px 2px 2px;
            width:1069px;
            height:500px;
            
        }

        .titulo{
            margin-top:20px;
            margin-bottom:70px;
            font-size:25px;
            text-transform:uppercase;
        }

        p{
            font-size:20px;
        }

        .txt{
            width:80%;
        }

        .DataN{
            margin-left:23px
        }

        .cpf{
            margin-left:21px
        }

        .tel{
            margin-left:37px;
        }

        .setor{
            margin-left:12px
        }

        .btn{
            width:262px;
            height:44px;
            background-color:#00A3FF;
            font-size:23px;
            margin-top:150px;
            color:black;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="quadro">
                <h1 class="titulo text-center">Cadastrar Funcionário</h1>
                <div class="col-sm-5">
                    <p>Nome: <asp:TextBox runat="server" ID="txtNome" CssClass="txt"></asp:TextBox></p>
                    <p>Data Nascimento: <asp:TextBox runat="server" ID="txtNascimento" CssClass="DataN" TextMode="Date"></asp:TextBox></p>
                    <p>CPF: <asp:TextBox runat="server" ID="txtCPF" CssClass="txt cpf"></asp:TextBox></p>
                </div>
                <div class="col-sm-2"></div>
                <div class="col-sm-5">
                    <p>E-mail: <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox></p>
                    <p>Tel: <asp:TextBox runat="server" ID="txtTel" TextMode="Number" CssClass="tel"></asp:TextBox></p>
                    <p>Setor: <asp:DropDownList runat="server" ID="ddlSetor" CssClass="setor"></asp:DropDownList></p>
                </div>
                <asp:Button runat="server" ID="btnCadastrar" CssClass="btn col-sm-12 center-block" Text="CADASTRAR" OnClick="btnCadastrar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
