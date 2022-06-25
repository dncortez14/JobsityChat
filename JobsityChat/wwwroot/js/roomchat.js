"use strict";

var roomName = document.getElementById("RoomName").value;
var roomId = document.getElementById("RoomId").value;
var connection = new signalR.HubConnectionBuilder().withUrl(`/roomChat?roomName=${roomName}&roomId=${roomId}`).build();

connection.on("ReceiveMessage", function (message, user, time) {
    createMessage(user, "messageContainer", message, time);
});

connection.on("Notifications", function (user, message, time) {
    createMessage(user, "notificationContainer", message, time);
});

connection.start().then(function () {
    var button = document.getElementById("sendButton");
    button.disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

function sendMessage() {
    var element = document.getElementById("newMessage");

    if (element.value) {
        connection.invoke("SendMessage", element.value).then(function (time) {
            createMessage("Me", "messageContainerDarker", element.value, time);
            element.value = "";
        }).catch(function (err) {
            return console.error(err.toString());
        });
    }
}

function createMessage(sender, color, text, time) {
    var htmlCode = `<div class=${color}>
                        <strong>${sender}</strong><br>
                        ${text}
                        <span class="time-right">${time}</span>
                    </div>`

    var newMessageInput = document.getElementById("newMessage");
    newMessageInput.insertAdjacentHTML('beforebegin', htmlCode);
}
