"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/roomChat").build();

connection.start().then(function () {
    
}).catch(function (err) {
    return console.error(err.toString());
});
