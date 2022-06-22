"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/roomChat").build();

connection.on("ReceiveMessage", function (message) {
    alert(message);
});

connection.start().then(function () {
    AddToGroup();
}).catch(function (err) {
    return console.error(err.toString());
});

function AddToGroup() {
    var groupName = document.getElementById("Name").value;
    connection.invoke("AddToGroup", groupName).catch(function (err) {
        return console.error(err.toString());
    });
}