function executeCommand(command, value){
    document.execCommand(command,false,value);
}

document.getElementById("undo").addEventListener("click", function(){
    executeCommand("undo");
});

document.getElementById("redo").addEventListener("click", function(){
    executeCommand("redo");
});

document.getElementById("bold").addEventListener("click", function() {
    executeCommand("bold");
});

