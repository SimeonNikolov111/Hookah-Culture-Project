var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

// The Receive Message Client event. This will trigger, when the Back-End calls the ReceiveMessage method
connection.on("NewMessage", function (message) { ... });

//An error handler for connection errors
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// The Send Message DOM event. This will trigger the Back-End SendMessage method
document.getElementById("sendButton").addEventListener("click", function (event) { ... });

connection.on("NewMessage", function (message) {
    var msg = message.text.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    var encodedMsg = "[" + message.user + "]: " + msg;

    var messageElement = document.createElement("h3");
    messageElement.textContent = encodedMsg;
    document.getElementById("messagesList")
        .appendChild(messageElement);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("Send", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


