function testClisk(e) {
    console.log("rect click")
    e.target.style.backgroundColor = "green";
}
function ttt(e) {
    i += 1;
    if (i < 10) {
        e.preventDefault();
        alert("test");
    }
}
function setColor(e) {
    if (e.type === "mouseover")
        e.target.style.backgroundColor = "red";
    else if (e.type === "mouseout")
        e.target.style.backgroundColor = "blue";
}
function test(e) {

    console.log("screenX: " + e.screenX);
    console.log("screenY: " + e.screenY);
    console.log("clientX: " + e.clientX);
    console.log("clientY: " + e.clientY);
     document.getElementsByClassName("rect")[0].style.left = e.screenX / 2 + "px";
     document.getElementsByClassName("rect")[0].style.top = e.screenY / 2 + "px";
}
var left = 0;
var top = 0;
function testkeyDown(e) {
    switch(e.keyCode) {

        case 37:  // если нажата клавиша влево
            if (left >= 0)
                left += 10;
            document.getElementsByClassName("rectBig")[0].style.left = left  + "px";
            break;
        case 38:   // если нажата клавиша вверх
            if (top >= 0)
                top += 10;
            document.getElementsByClassName("rectBig")[0].style.top = top  + "px";
            break;
    }
}
document.getElementsByClassName("rect")[0].addEventListener("mouseover", setColor);
document.getElementsByClassName("rect")[0].addEventListener("mouseout", setColor);
document.body.addEventListener("mouseover", test);
document.body.addEventListener("keydown", testkeyDown);
