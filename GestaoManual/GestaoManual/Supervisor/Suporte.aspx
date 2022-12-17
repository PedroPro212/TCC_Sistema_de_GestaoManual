<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Suporte.aspx.cs" Inherits="GestaoManual.Supervisor.Suporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        .quadro{
            background-color:#FFFFFF;
            border-radius:5px;
            box-shadow:1px 1px 1px;
            padding-bottom:15px;
            margin-top:50%;
            padding-top:15px;
        }

        p{
            font-size:13px;
        }

        .ddlSuporte{
            margin-bottom:30px;
            font-size:13px;
            width:88%;
        }

        .UpperBox{
            width:300px;
            height:80px;
        }

        .btnEnviar{
            margin-top:15px;
            background-color:#00A3FF;
            border-style:none;
            border-radius:2px;
            font-size:13px;
        }


    </style>
    <div class="container">
        <div class="row">
            <div class="col-sm-4"></div>
            <div class="col-sm-4 center-block">
                <div class="quadro">
                    <h1 class="text-center" style="margin-bottom:25px">Suporte</h1>
                    <p class="text-center">Selecione a opção que melhor descreve seu problema:</p>
                    <asp:DropDownList runat="server" ID="ddlSuporte" CssClass="text-center center-block ddlSuporte">
                        <asp:ListItem Value="optNCarrega">Página não carrega</asp:ListItem>
                        <asp:ListItem Value="optPermissao">Perdi minha permissão</asp:ListItem>
                    </asp:DropDownList>
                    <p class="text-center">Descreva em poucas palavras o problema encontrado</p>
                    <div class="text-center"><asp:TextBox runat="server" ID="txtPergunta" TextMode="MultiLine" CssClass="UpperBox"></asp:TextBox></div>
                    <asp:Button runat="server" CssClass="btnEnviar center-block" ID="btnEnviar" Text="ENVIAR" Width="88%" Height="30" />
                </div> 
            </div>
            <div class="col-sm-4"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
