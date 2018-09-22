function testingForm(formname) {
    var form = document.forms[formname];
    document.write(form.name + "sdfsdf");
    var el = form.elements["testInput"]
    el.value = "tsset";
}
testingForm("testForm");
var i = 0;
function send(e) {
    var form = document.forms["testForm"];
    var input =
        form.elements["input1"].value;
    var intValue = parseInt(input, 10);
    form.elements["testInput"].value = i + intValue;
    i += 1;
   // document.testForm.action = "Index";
   //e.preventDefault();

}
//document.testForm.send.addEventListener("click", send);
var b =
    document.getElementById("btn");
b.addEventListener("click", send);