<%@ Page Title="" Language="C#" MasterPageFile="~/Responsavel.Master" AutoEventWireup="true" CodeBehind="Responsavel.aspx.cs" Inherits="GestaoManual.Supervisor.Responsavel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <style>
        body{
            color:black;
        }

        .quadro{
            background-color:white;
            width:207px;
            height:191px;
            margin-top:50px;
            border-radius:5px;
            box-shadow:1px 1px 1px black;
        }
            .quadro img{
                filter:drop-shadow(2px 2px 2px black);
            }
            .quadro p{
                font-size:20px;
                text-transform:uppercase;
                color:black;
                filter:drop-shadow(1px 1px 1px);
            }
                .quadro:hover{
                    margin-top:40px;
                    transition:0.2s;
                }
        .quadroCenter{
            position: relative;
            top: 50%;
            transform: translateY(-50%);
        }
    </style>    
    

    <div class="container text-center">
        <div class="row">
            <div class="col-sm-12 text-center" style="text-transform:uppercase;margin-top:20px  ;margin-left:20px;"><h1>Opções</h1></div>
            <div class="col-sm-2"></div>
            <div class="col-sm-2">
                <div class="quadro">
                    <div class="quadroCenter">
                        <a href="Atribuir/Atribuir.aspx"><img runat="server" src="/imgs/chave.png" width="70" />
                        <p>Atribuir</p></a>
                    </div>
                </div>
                <div class="quadro">
                    <div class="quadroCenter">
                        <a href="Funcionario/Funcionario.aspx" style="text-decoration:none"><img runat="server" src="/imgs/user.png" width="70" />
                        <p>Funcionários</p></a>
                    </div>
                </div>
            </div>

            <div class="col-sm-1"></div>
            <div class="col-sm-2">
                <div class="quadro">
                    <div class="quadroCenter">
                        <a href="Maquina/GridView.aspx" style="text-decoration:none"><img runat="server" src="/imgs/ferramenta.png" width="70" />
                        <p>Máquina</p></a>
                    </div>
                </div>

                <div class="quadro">
                    <div class="quadroCenter">
                        <img runat="server" src="/imgs/qualidade.png" width="70" />
                        <p>Técnico de Qualidade</p>
                    </div>
                </div>
            </div>

            <div class="col-sm-1"></div>
            <div class="col-sm-2">
                <div class="quadro">
                    <div class="quadroCenter">
                        <a href="Relatorio/GerarRelatorio.aspx"><img runat="server" src="/imgs/check.png" width="70" />
                        <p>Gerar Relatório</p></a>
                    </div>

                </div>
                <div class="quadro">
                    <div class="quadroCenter">
                        <a href="Suporte.aspx" style="text-decoration:none"><img runat="server" src="/imgs/suporte.png" width="70" />
                        <p>Suporte</p></a>
                    </div>
                </div>
            </div>

            <div class="col-sm-1"></div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
