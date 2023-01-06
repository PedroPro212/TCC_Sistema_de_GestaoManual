<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="ProcessoPintura.aspx.cs" Inherits="GestaoManual.Producao.PinturaImersao.ProcessoPintura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        body{
            background-color: #F9B463;
        }

        .quadro{
            background-color:#FFFFFF;
        }

        .Nome{
            font-size:18px;
        }
        .produto{
            font-size:30px;
        }

        .relogio{
            display:flex;
            justify-content:center
        }
        .relogio div{
            margin-left:2px;
        }

        .horaIn{
            margin-left:150px
        }

        .horas{
            background-color:#D9D9D9;
            width:265px;
            height:190px;
            padding-top:15px;
            border-style:solid;
            border:solid 1px black;
            font-size:18px;
            margin-top:40px
        }

        .horaInicio{
            background-color:#F9B463;
            width:239px;
            height:64px;
            margin-bottom:15px;
            border:solid 1px black;
        }
        .horasAndamento{
            background-color:#F9B463;
            width:239px;
            height:64px;
            border:solid 1px black;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="quadro">
                <div class="col-sm-4">
                    <asp:Label runat="server" CssClass="Nome" ID="lblNome"></asp:Label>

                    <div class="horas text-center">
                        <div class="horaInicio center-block">
                            <p>Início do processo:</p>
                            <span id="horaIn"></span>      
                        </div>

                        <div class="horasAndamento center-block">
                            <p>Hora em andamento:</p> 
                            <div class="relogio">
                                <div>
                                    <span id="horas">00</span>
                                </div>

                                <div>
                                    <span id="minutos">00</span>
                                </div>

                                <div>
                                    <span id="segundos">00</span>
                                </div>

                                <div>
                                    <span id="dia">00</span>
                                </div>

                                <div>
                                    <span id="mes">00</span>
                                </div>

                                <div>
                                    <span id="ano">00</span>
                                </div>
                            </div>
                        </div>
                    </div>
    
                </div>
                <div class="col-sm-4">
                    <asp:Label runat="server" CssClass="produto" ID="lblProduto"></asp:Label>   
                </div>
                <div class="col-sm-4">
                    <asp:Label runat="server" ID="lblSetor"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <script>
        const horas = document.getElementById('horas');
        const minutos = document.getElementById('minutos');
        const segundos = document.getElementById('segundos');
        const dia = document.getElementById('dia');
        const mes = document.getElementById('mes');
        const ano = document.getElementById('ano');

        var horaIn = sessionStorage.getItem('horaIn');
        const horaInc = document.getElementById('horaIn');

        horaInc.textContent = horaIn;

        const relogio = setInterval(function time() {
            let dateToday = new Date();
            let hr = dateToday.getHours();
            let min = dateToday.getMinutes();
            let s = dateToday.getSeconds();
            let d = dateToday.getDate();
            let m = dateToday.getMonth();
            let a = dateToday.getFullYear();


            if (hr < 10) hr = '0' + hr;

            if (min < 10) min = '0' + min;

            if (s < 10) s = '0' + s;

            if (d < 10) d = '0' + d;

            if (m < 10) {
                m = '0' + m;
                if (m == 0)
                    m = 1;
            }

            horas.textContent = hr + ':';
            minutos.textContent = min + ':';
            segundos.textContent = s;


            dia.textContent = d + '/';
            mes.textContent = m + '/';
            ano.textContent = a;
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
