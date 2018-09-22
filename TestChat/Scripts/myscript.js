function scrollToBottom() {
        var objDiv = document.getElementById("scrollView");
    if (objDiv)
        objDiv.scrollTo(0,100000000);
}
scrollToBottom();
//function updateTime() {
//    try {
//        document.getElementById("timer").innerHTML = new Date().toTimeString();
//    } catch{ }
//}
//updateTime();
//setInterval(updateTime, 1000);

var item = document.getElementById("animated");
var angle = 0;
function rotate() {
    angle = (angle + 2) % 360;
    item.style.transform = "rotate(" + angle + "deg)";
    window.requestAnimationFrame(rotate);
}
var fontSize = 1;
//window.requestAnimationFrame(rotate);
function fill() {
    var elementToFill = document.getElementById("autofiller");
    var divToAdd = document.createElement("div");
    divToAdd.style.fontSize += fontSize + "px";
    fontSize += 1;
    divToAdd.className = "testClass";
    var addedText = document.createTextNode(new Date().toTimeString());
    divToAdd.appendChild(addedText);
    elementToFill.appendChild(divToAdd);
}
//fill();
//setInterval(fill, 1000);