var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

connection.on("ReceiveMessage", addMessageToChat);

connection.start()
    .catch(function (err) {
    return console.error(err.toString());
    });

function sendMessageToHub(message) {
    connection.invoke('SendMessage', message);
}