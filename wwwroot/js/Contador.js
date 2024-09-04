const SEGUNDOS_MAX = 15;
const CAMBIAR_ESTADO_PERDIDO_URL = "/Home/CambiarEstadoPerdido";
const FIN_URL = "/Home/Fin";
const contador = document.getElementById("contador");
let intervalo;
var segundosFaltantes;

function comenzarContador()
{
    segundosFaltantes = SEGUNDOS_MAX;

    intervalo = setInterval(() => {
        actualizarContador();
        segundosFaltantes--;
        
        if (segundosFaltantes < 0) {
            clearInterval(intervalo);
            segundosFaltantes = 0;
        } else if (segundosFaltantes == 0) {
            clearInterval(intervalo);
            fetch(CAMBIAR_ESTADO_PERDIDO_URL)
                .then(() => {
                    location.href = FIN_URL;
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