class Message {
    constructor(username, text, createdate) {
        this.userName = username;
        this.text = text;
        this.createDate = createdate;
    }
}

const username = userName;
const textInput = document.getElementById('messageInput');
const createDate = document.getElementById('createdate');
const chat = document.getElementById('chat');
const messagesQueue = [];

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    let messageDate = new Date();
    messageDate.getDate();
    let message = new Message(username, text, messageDate);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    let container = document.createElement('div');
    container.className = "text-left";

    var messageHeader = document.createElement('span');
    var currentdate = new Date();
    messageHeader.innerHTML = message.userName + ", " 
        + currentdate.getDate() + "."
        + (currentdate.getMonth() + 1) + "."
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('pl-PL', { hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: false });
    messageHeader.className = "text-left";

    var br = document.createElement('br');

    let text = document.createElement('span');
    text.innerHTML = message.text;
    text.className = "text-left";

    container.appendChild(messageHeader);
    container.appendChild(br);
    container.appendChild(text);
    chat.appendChild(container);
}