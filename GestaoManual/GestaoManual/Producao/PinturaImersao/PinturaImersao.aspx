<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="PinturaImersao.aspx.cs" Inherits="GestaoManual.Producao.PinturaImersao.PinturaImersao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style>
        body{
            background-color: #F9B463;
        }
        .quadro{
            background-color: #F5F5F5;
            width:361px;
            height:446px;
            border-radius:5px;
        }

        .relogio{
            display:flex;
        }
        .relogio div{
            margin-left:2px;
        }
    </style>
    
    <div class="col-sm-4"></div>
    <div class="col-sm-4 center-block">
        <div class="quadro">
            <p class="text-center" style="text-transform:uppercase; font-size:20px; margin-top:70px; padding-top:20px">Pintura por Imersão</p>
            <p class="text-center" style="font-size:18px; margin-top:25px">Selecione o produto:</p>
            <div class="text-center"><asp:DropDownList runat="server" ID="ddlProduto" Width="250" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged"></asp:DropDownList></div>
            <div style="margin-top:20px"><asp:Image runat="server" ID="imgProduto" CssClass="text-center" Width="110" /></div>
            <div style="margin-top:100px"><asp:Button runat="server" ID="btnEntrar" CssClass="center-block" Text="ENTRAR" Width="142" OnClick="btnEntrar_Click" /></div>
        </div>
    </div>

    <div class="col-sm-4">
        <div class="horaInicio text-center" style="display:none">
            <p>Início do processo:</p>
            <div class="relogio center-block">
                <div>
                    <span id="horasIn">00</span>
                </div>

                <div>
                    <span id="minutosIn">00</span>
                </div>

                <div>
                    <span id="segundosIn">00</span>
                </div>

                <div>
                    <span id="diaIn">00</span>
                </div>

                <div>
                    <span id="mesIn">00</span>
                </div>

                <div>
                    <span id="anoIn">00</span>
                </div>
            </div>            
        </div>
    </div>

    <script>
        const horasIn = document.getElementById('horasIn');
        const minutosIn = document.getElementById('minutosIn');
        const segundosIn = document.getElementById('segundosIn');
        const diaIn = document.getElementById('diaIn');
        const mesIn = document.getElementById('mesIn');
        const anoIn = document.getElementById('anoIn');

        const relogioIn = setTimeout(function timeIn() {
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

            hh = horasIn.textContent = hr + ':';
            mm = minutosIn.textContent = min + ':';
            ss = segundosIn.textContent = s + ' ';


            dd = diaIn.textContent = d + '/';
            me = mesIn.textContent = m + '/';
            aa = anoIn.textContent = a;

            sessionStorage.setItem('horaIn', hh + mm + ss + dd + me + aa);
        })
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>