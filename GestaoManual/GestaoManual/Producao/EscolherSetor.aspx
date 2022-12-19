<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscolherSetor.aspx.cs" Inherits="GestaoManual.Producao.EscolherSetor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<!-- Latest compiled and minified CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet"/>

<!-- Latest compiled JavaScript -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <title>Escolher Setor</title>

    <style>
        body{
            background-color: #F9B463;
        }
        .quadro{
            background-color:#FFFFFF;
            margin-top:20%; 
            width:390px; 
            height:389px;
            border-radius:5px;
            
        }
        a{
            text-decoration:none;
            color:black;
        }
        a:hover{
            color:gray;
        }

        .btnEntrar{
            background-color:#FF4A4A;
            width:109px;
            height:30px;
            border-radius:5px;
            border-style:none;
        }
        .btnEntrar:hover{
            background-color:red;
        }

        .nome{
            font-weight:bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <div class="quadro">
                        <div class="container">
                            <div class="row">
                                <div class="text-left"><a href="../Login/Logar.aspx"><img runat="server" src="/imgs/user_sair.png" width="30" /><p style="text-transform:uppercase; font-size:15px;">Sair</a></p></div>
                                <div class="text-center"><p style="text-transform:uppercase; font-size:20px;">Preencha</p></div>
                                <div class="text-left"><p>Selecione o setor:</p></div>
                                <div class="text-center"><asp:DropDownList runat="server" ID="ddlSetor"></asp:DropDownList></div>
                                <div class="text-center" style="margin-top:100px;"><asp:Button runat="server" ID="btnEntrar" CssClass="btnEntrar" Text="Entrar" OnClick="btnEntrar_Click" /></div>
                                <div class="text-center"><p style="margin-top:30px;">Seja bem-vindo <asp:Label runat="server" ID="lblNome" CssClass="nome"></asp:Label></p></div>
                                
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4"></div>
            </div>
        </div>
    </form>
</body>
</html>
