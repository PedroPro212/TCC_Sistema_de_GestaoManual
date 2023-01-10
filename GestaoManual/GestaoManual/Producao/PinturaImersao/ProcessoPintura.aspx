<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="ProcessoPintura.aspx.cs" Inherits="GestaoManual.Producao.PinturaImersao.ProcessoPintura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <script src="../quagga.min.js"></script>

    <style>
        body{
            background-color: #F9B463;
        }

        .quadro{
            background-color:#FFFFFF;
        }

        .informacoes {
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

        .btnFinalizar{
            background-color:#F9B463;
            color:black;
            font-size:24px;
            width:258px;
            height:51px;
            border:solid black 1px;
            border-radius:5px;
            box-shadow:1px 1px;
            margin-top:150px;
        }

        .modal1{
            background-color:gray;
            width:800px;
            height:500px;
            position:absolute;
            margin-top:150px;
            border-radius:5px;
                top:50%;
                left:50%;
                transform:translate(-50%,-50%);
                cursor:pointer;
                display:none;            
                animation:animate;
                animation-duration:400ms;
                z-index:10;
        }

        #camera{
            display:flex;
            margin-top:2%;
            margin-left:5%;
            border-radius:5px;
            border:1px solid black;
        }

        @keyframes animate{
            from{opacity:1;}
            from{opacity:0;}
        }

        #fader{
            position:fixed;
            top:0;
            left:0;
            width:100%;
            height:100%;
            background-color:rgba(0,0,0,0.6);
        }

        #imgLoteTinta:hover{
            cursor:pointer;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="quadro">
                <div class="col-sm-4">
                    <asp:Label runat="server" CssClass="informacoes" ID="lblNome"></asp:Label>

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
                    
                    <p>N°Lote Tinta:</p>
                    <asp:TextBox runat="server" ID="txtLoteTinta" TextMode="Number"></asp:TextBox><img runat="server" id="imgLoteTinta" src="/imgsproducao/code.png" width="37" onclick="acao()" />
                    <p>Quantidade produzida:</p>
                    <asp:TextBox runat="server" ID="txtQts" TextMode="Number"></asp:TextBox><br />

                    <asp:Button runat="server" ID="btnFinalizar" CssClass="btnFinalizar" Text="Finalizar Processo" OnClick="btnFinalizar_Click" />

                    
                    <div class="modal1">

                        <div id="camera"></div>
                        <video id="video" autoplay></video>
                        <input type="text" id="txtLote" />

                        <input type="button" id="btnFechar" value="Fechar" onclick="fechar()" />
                    </div>
                </div>
                <div class="col-sm-4">
                    <asp:Label runat="server" CssClass="informacoes" ID="lblSetor"></asp:Label>

                    <p>Lote de Peças:</p>
                    <asp:TextBox runat="server" ID="txtLotePeca" TextMode="Number"></asp:TextBox><img runat="server" id="imgLotePecas" src="/imgsproducao/code.png" width="37" />
                    <p>Quantidade peças boas:</p>
                    <asp:TextBox runat="server" ID="txtPecasBoas" TextMode="Number"></asp:TextBox>
                    <div id="fader" style="display:none"></div>
                </div>
            </div>
        </div>
    </div>

    <script>

        //Relógio
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

        //Abrir modal
        function acao() {
            let modal = document.querySelector('.modal1');
            let divFadel = document.querySelector('#fader');

            modal.style.display = 'block';
            divFadel.style.display = 'block';
        }

        //Fechar modal
        function fechar() {
            let modal = document.querySelector('.modal1');
            let divFadel = document.querySelector('#fader');

            modal.style.display = 'none';
            divFadel.style.display = 'none';
        }

        // Abrir WebCam e ler código de barra
        Quagga.init({
            inputStream: {
                name: "Live",
                type: "LiveStream",
                target: document.querySelector('#camera')    // Or '#yourElement' (optional)
            },
            decoder: {
                readers: ["code_128_reader"]
            }
        }, function (err) {
            if (err) {
                console.log(err);
                return
            }
            console.log("Initialization finished. Ready to start");
            Quagga.start();
        });

        Quagga.onDetected(function (data) {
            console.log(data);

            document.querySelector('#txtLote').innerHTML = data.codeResult.code;
        });

        //function startVideoFromCamera() {

        //    const specs = { video: { width: 720 } };

        //    navigator.mediaDevices.getUserMedia(specs).then(stream => {

        //        const videoElement = document.querySelector('#video');
        //        videoElement.srcObject = stream;

        //    }).catch(Error => {console.log(Error) })

        //}

        //window.addEventListener("DOMContentLoaded", startVideoFromCamera);
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
