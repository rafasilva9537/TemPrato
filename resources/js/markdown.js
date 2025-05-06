function executeCommand(command, value){
    document.execCommand(command,false,value);
}



document.getElementById("bold").addEventListener("click", function() {
    executeCommand("bold");
});

