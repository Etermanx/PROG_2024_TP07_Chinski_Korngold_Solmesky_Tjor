const SEGUNDOS_FALTANTES_URL = "/Home/ComenzarContador";
const Juego_URL = "/Home/Jugar";
const contador = document.getElementById("contador");
let intervalo;
var segundosFaltantes;

function comenzarContador()
{
    fetch(SEGUNDOS_FALTANTES_URL)
        .then((res) => res.text())
        .then((text) => segundosFaltantes = Number(text));

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