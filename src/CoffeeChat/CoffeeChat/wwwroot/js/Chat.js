"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

connection.on("ReceiveMessage", (req) => {
    var message = req.message;

    var currentdate = new Date();
    var messageDate = + currentdate.getDate() + "."
        + (currentdate.getMonth() + 1) + "."
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('pl-PL', { hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: false });

    if (req.sender) {
        message = req.sender + "[" + messageDate + "]: " + message;
    }
    var li = document.createElement("li");
    li.innerHTML = message;
    li.classList = "text-left";
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessageToAll", message)
        .catch(function (err) {
            return console.error(err.toString());
        });
    event.preventDefault();
});
