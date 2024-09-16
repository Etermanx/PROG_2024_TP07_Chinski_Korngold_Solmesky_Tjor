const SEGUNDOS_MAX = 15;
const CAMBIAR_BAJAR_ACTUAL_VIDAS_URL = "/Home/BajarActualVidas";
const JUGAR_URL = "/Home/Jugar";
const contador = document.getElementById("contador");
let intervalo;
var segundosFaltantes;

function comenzarContador()
{
    segundosFaltantes = SEGUNDOS_MAX;

    intervalo = setInterval(() => {
        actualizarContador();
        segundosFaltantes--;
        
        if (segundosFaltantes <= 0) {
            actualizarContadorSinTiempo();
        } else if (segundosFaltantes < -3) {
            actualizarContadorSinTiempo();
            clearInterval(intervalo);
            fetch(CAMBIAR_BAJAR_ACTUAL_VIDAS_URL)
                .then(() => {
                    location.href = JUGAR_URL;
                });
        }
    }, 1000);
}

function incluirCero(numeroSinCero) {
    var numeroConCero = numeroSinCero.toString();
    if (numeroConCero.length == 1)
        numeroConCero = "0" + numeroSinCero;
    return numeroConCero;
}

function actualizarContador() {
    contador.innerText = segundosFaltantes + "s";
}
function actualizarContadorSinTiempo() {
    contador.innerText = "Se acabó el tiempo";
}