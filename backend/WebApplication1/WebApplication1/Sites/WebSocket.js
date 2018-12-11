$(function () {
    "use strict";

    if (Modernizr.websockets) {
        $("#Status").append("WebSockets is supported. Click the Connect button.");
    }

    if (!window.WebSocket && window.MozWebSocket) {
        window.WebSocket = window.MozWebSocket;
    }


    $('#connect').click(function () {

        var count;
        var connection;

        var host =
            "ws://localhost/WebEventHandler/WebEventHandler.ashx";
        //var host =
        "ws://localhost/WebEventHandler/WebEventHandler.svc";

        connection = new WebSocket(host);

        connection.onopen = function () {
            $(".btn").css("color", "green");
        }

        connection.onmessage = function (message) {
            var data = window.JSON.parse(message.data);
            $("<li/>").html(data).appendTo($('#messages'));
        };

    });

});