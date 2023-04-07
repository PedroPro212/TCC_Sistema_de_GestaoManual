<%@ Page Title="" Language="C#" MasterPageFile="~/Logar.Master" AutoEventWireup="true" CodeBehind="ProcessoPintura.aspx.cs" Inherits="GestaoManual.Producao.PinturaImersao.ProcessoPintura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <script src="../quagga.min.js"></script>
   <%-- <script src="ProcessoPintura.js"></script>--%>

    <style>
        body{
            background-color: #F9B463;
        }

        .btnVoltar{
            background-color:yellow;
            border:solid 1px;
            border-radius:4px;
            margin-bottom:15px;
            text-decoration:none;
            padding:3px
        }

        .quadro{
            background-color:#FFFFFF;
            width:100%;
            height:500px;
            margin-top:70px;
            padding-top:15px;
            padding-left:15px;
            border-radius:10px;
            box-shadow:2px 2px 2px;
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

        .modalFinalizar{
            background-color:white;
            width:800px;
            height:200px;
            position:absolute;
            margin-top:150px;
            border-radius:5px;
            box-shadow:2px 2px 2px;
                top:50%;
                left:50%;
                transform:translate(-50%,-50%);
                cursor:pointer;
                display:none;      
                animation:animate;
                animation-duration:400ms;
                z-index:10;
        }
            .modalFinalizar h1{
                font-size:30px;
                color:black;
                margin-bottom:60px;
            }
            .modalFinalizar .btn{
                width:150px;
                margin-left:5px;
            }
            .btnCancelar{
                background-color:#f3214e;
                color:black
            }
            .btnConfirmar{
                background-color:#a0c55f;
                color:white;
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

        #txtLoteTinta{
            width:auto;
            background-color:white
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="quadro">
                <div class="col-sm-12 text-left"><a href="PinturaImersao.aspx" class="btnVoltar" style="text-decoration:none;">Voltar</a></div>
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
                    <%--<label id="txtLoteTinta"></label>--%><asp:TextBox runat="server" ID="txtLoteTinta" AutoPostBack="false"></asp:TextBox><img runat="server" id="imgLoteTinta" src="/imgsproducao/code.png" width="37" onclick="acao()" />
                    
                    <p>Quantidade produzida:</p>
                    <asp:TextBox runat="server" ID="txtQts" TextMode="Number"></asp:TextBox><br />
                    
                    <%--<asp:Button runat="server" ID="btnFinalizar" CssClass="btnFinalizar" Text="Finalizar Processo" OnClick="btnFinalizar_Click" />--%>
                    <input type="button" id="btnFinalizar" class="btnFinalizar" value="Finalizar Processo" onclick="abrirFinalizar()" />

                    <label id="lblLTinta" visible="false"></label>
                    <asp:Label runat="server" ID="lblLoteTinat" Visible="false"></asp:Label>

                    <label id="lblLPecas" visible="false"></label>
                    <asp:Label runat="server" ID="lblLotePecas" Visible="false"></asp:Label>
                    
                    <div class="modal1">

                        <div id="camera"></div>
                        <video id="video" autoplay></video>
                        <textbox id="LoteTinta"></textbox>

                        <input type="button" id="btnFechar" value="Fechar" onclick="fechar()" />
                    </div>

                    <div class="modalFinalizar text-center">
                        <h1 class="text-center">Tem certeza que deseja finalizar esse processo?</h1>
                        <input type="button" id="btnCancelar" class="btn btnCancelar" value="CANCELAR" onclick="cancelarFinalizar()" />
                        <asp:Button runat="server" ID="btnConfirmar" CssClass="btn btnConfirmar" Text="CONFIRMAR" OnClick="btnConfirmar_Click" />
                    </div>

                </div>
                <div class="col-sm-4">
                    <asp:Label runat="server" CssClass="informacoes" ID="lblSetor"></asp:Label>

                    <p>Lote de Peças:</p>
                    <asp:TextBox runat="server" ID="txtLotePecas" AutoPostBack="false"></asp:TextBox><img runat="server" id="imgLotePecas" src="/imgsproducao/code.png" width="37" />
                    <p style="margin-top:45px">Quantidade peças boas:</p>
                    <asp:TextBox runat="server" ID="txtPecasBoas" TextMode="Number"></asp:TextBox>
                    <div id="fader" style="display:none"></div>
                    <div id="fader2" style="display:none"></div>
                </div>
            </div>
        </div>
    </div>
    <%--<p id="parTesteHora">lllllllllllllll</p>--%>
    <asp:Label runat="server" ID="lblMaquina" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblTeste"></asp:Label>
    <asp:HiddenField runat="server" ID="teste" Value="teste1" ClientIDMode="Static" />

<%--    <asp:Label runat="server" ID="LabelLotePecas"></asp:Label>
    <asp:HiddenField runat="server" ID="lblLoteP" Value="teste2" ClientIDMode="Static" />--%>
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
            document.getElementById('teste').value = document.getElementById('txtLoteTinta').textContent;
            //document.getElementById('lblLoteP').value = document.getElementById('txtLotePecas').textContent;
        });

        //Abrir modal camera
        function acao() {
            let modal = document.querySelector('.modal1');
            let divFadel = document.querySelector('#fader');

            modal.style.display = 'block';
            divFadel.style.display = 'block';
        }

        //Fechar modal camera
        function fechar() {
            let modal = document.querySelector('.modal1');
            let divFadel = document.querySelector('#fader');

            modal.style.display = 'none';
            divFadel.style.display = 'none';
        }

        function abrirFinalizar() {
            let modal = document.querySelector('.modalFinalizar');
            let divFadel = document.querySelector('#fader');

            modal.style.display = 'block';
            divFadel.style.display = 'block';
        }

        function cancelarFinalizar() {
            let modal = document.querySelector('.modalFinalizar');
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
            console.log("Inicialização concluída. Pronto para começar");
            Quagga.start();
        });

        Quagga.onDetected(function (data) {
            console.log(data);

            var l = document.querySelector('#LoteTinta').innerHTML = data.codeResult.code;
            document.querySelector('#txtLoteTinta').innerHTML = l;

        });
        lblLTinta.textContent = txtLoteTinta.textContent;
        //lblLPecas.textContent = txtLotePecas.textContent;
        
   
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>