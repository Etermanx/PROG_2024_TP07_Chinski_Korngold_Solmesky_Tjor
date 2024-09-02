const SEGUNDOS_FALTANTES_URL = "/Home/SegundosFaltantes";
const Juego_URL = "/Home/Jugar";
const contador = document.getElementById("contador");
let intervalo;
var segundosFaltantes;

fetch(SEGUNDOS_FALTANTES_URL)
    .then((res) => res.text())
    .then((text) => segundosFaltantes = Number(text));

function incluirCero(numeroSinCero) {
    var numeroConCero = numeroSinCero.toString();
    if (numeroConCero.length == 1)
        numeroConCero = "0" + numeroSinCero;
    return numeroConCero;
}

function actualizarContador() {
    let horas = incluirCero(Math.floor(segundosFaltantes / 3600));
    let minutos = incluirCero(Math.floor(segundosFaltantes / 60 - horas * 60));
    let segundos = incluirCero(segundosFaltantes - minutos * 60 - horas * 3600);
    contador.innerText = horas + ":" + minutos + ":" + segundos;
}

intervalo = setInterval(() => {
    segundosFaltantes--;
    
    if (segundosFaltantes < 0) {
        clearInterval(intervalo);
        segundosFaltantes = 0;
    } else if (segundosFaltantes == 0) {
        clearInterval(intervalo);
        location.href = Juego_URL;
    }

    actualizarContador();
}, 1000);