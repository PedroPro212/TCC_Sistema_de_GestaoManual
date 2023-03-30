<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="ChamadoSuporte.aspx.cs" Inherits="GestaoManual.Supervisor.Dev.ChamadoSuporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        .quadro{
            width:100%;
            margin-top:50px;
            border-radius:5px;
            box-shadow:2px 2px 2px;
            background-color:white;
        }
        
        p{
            font-size:20px;
        }

        .txtPesquisar{
            width:180px;
            height:30px;
            border-radius:5px;
            border: solid 1px;
        }
        .btn{
            width:120px;
            height:30px;
            border-radius:5px;
            font-size:15px;
        }
        .btn1{
            background-color:#00A3FF;
        }

        .ddlSetor{
            width:150px;
            height:28px;
            font-size:15px;
        }

        .ddlProblema{
            width:150px;
            height:28px;
            font-size:15px;
        }

        .table{
            margin-top:30px;
            margin-left:70px;
            margin-bottom:30px
        }

        .btn-table{
            text-decoration:none
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="quadro">
                <h1 class="col-sm-12 text-center" style="margin-top:15px">Chamados de Suporte</h1>
                <div class="col-sm-12 text-center">
                    <p>FILTRAR:</p>
                    <asp:TextBox runat="server" ID="txtPesquisar" CssClass="txtPesquisar"></asp:TextBox>
                    <asp:Button runat="server" ID="btnPesquisar" CssClass="btn btn1" Text="PESQUISAR" OnClick="btnPesquisar_Click"/>
                    <asp:DropDownList runat="server" ID="ddlSetor" CssClass="ddlSetor">
                        <asp:ListItem Text="Setor" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlProblema" CssClass="ddlProblema">
                        <asp:ListItem Text="Problema" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2"></div>

                <div class="col-sm-8">
                    <asp:GridView runat="server" ID="grdProblema" Width="80%" AutoGenerateColumns="false"
                        CssClass="table table-condensed" AllowPaging="false" OnRowCommand="grdProblema_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="IdRegistro" HeaderText="REGISTRO:" />
                            <asp:BoundField DataField="IdSetor" HeaderText="SETOR:" />
                            <asp:BoundField DataField="DataEnvio" HeaderText="DATA:" />
                            <asp:BoundField DataField="NomeProblema" HeaderText="PROBLEMA:" />
                            <asp:BoundField DataField="Descricao" HeaderText="DESCRIÇÃO:" />
                            <asp:ButtonField ButtonType="Link" CommandName="MarcarConcluido" ControlStyle-CssClass="btn-primary form-control btn-table" Text="MARCAR COMO CONCLUÍDO" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="col-sm-2"></div>
            </div>
        </div>
    </div>








</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
