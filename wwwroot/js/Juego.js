let theWheel = new Winwheel({
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

function startSpin() {
    theWheel.stopAnimation(false);
    theWheel.rotationAngle = theWheel.rotationAngle % 360;
    theWheel.startAnimation();
}

function calculatePrize(segmentNumber) {
    let stopAt = theWheel.getRandomForSegment(segmentNumber);
    theWheel.animation.stopAngle = stopAt;
    theWheel.startAnimation();
}

function girarA(idCategoria) {
    calculatePrize(idCategoria);
}

function desmontarFachada() {
    alert("You have won ");
    document.getElementById("ruleta").style = "display:none;";
    document.getElementById("pregunta").style = "display:block;";
}

document.getElementById("ruleta").style = "display:block;";
document.getElementById("pregunta").style = "display:none;";