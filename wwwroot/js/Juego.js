const elementoRuleta = document.getElementById("ruleta");
const elementoPregunta = document.getElementById("pregunta");
const elementoCategoriaElegida = document.getElementById("categoriaElegida");
let canvasRuleta = new Winwheel({
    "canvasId": "ruletaCanvas",
    "drawMode": "segmentImage",
    "numSegments": segments.length,
    "responsive": true,
    "segments": segments,
    "animation":
    {
        "type": "spinToStop",
        "duration": 5,
        "spins": 3,
        "callbackFinished": desmontarFachada
    }
});

function girarA(numeroSegmento) {
    let pararEn = canvasRuleta.getRandomForSegment(numeroSegmento);
    canvasRuleta.animation.stopAngle = pararEn;
    canvasRuleta.startAnimation();
}

function desmontarFachada() {
    document.body.style = "";
    elementoRuleta.style.display = "none";
    abrirSplashCategoria();
    setTimeout(() => {
        elementoPregunta.style.display = "block";
        elementoCategoriaElegida.style.display = "none";
        comenzarContador();
    }, 3000);
}

function abrirSplashCategoria() {
    var audio = new Audio("/audio/Tadaa.mp3");
    elementoCategoriaElegida.style.display = "flex";
    audio.play();
}

document.body.style = "background: #a7d6ff;";
elementoRuleta.style.display = "block";
elementoPregunta.style.display = "none";