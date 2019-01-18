var service = {
    ws: null,
    pingInterval: null,
    callbacks: [],
    on: function (eventName, callback) {
        eventName = eventName.toLowerCase();
        if (!this.callbacks[eventName]) this.callbacks[eventName] = [];
        this.callbacks[eventName].push(callback);
    },
    invoke: function (method) {
        var args = new Array();
        for (var i = 1; i < arguments.length; i++)
            args.push(arguments[i]);
        this.ws.send(JSON.stringify({
            method,
            arguments: args
        }));
    },
    start: function (url) {
        var that = this;
        return new Promise((resolve, reject) => {
            try {
                that.ws = new WebSocket('wss://' + location.host + url);
                that.ws.onopen = function () {
                    that.pingInterval = setInterval(function () {
                        that.ping();
                    }, 1000 * 10);
                    resolve();
                };
                that.ws.onmessage = function (message) {
                    var json = JSON.parse(message.data);
                    var methodName = json.method.toLowerCase();
                    if (service.callbacks[methodName]) {
                        for (var i = 0; i < service.callbacks[methodName].length; i++) {
                            service.callbacks[methodName][i].apply(this, json.arguments);
                        }
                    } else {
                        console.error("未注册的方法" + methodName);
                    }
                };
                that.ws.onclose = function () {
                    clearInterval(that.pingInterval);
                    alert("重新连接中...");
                    window.location.reload();
                };
            } catch (e) {
                reject(e);
            }
        });
    },
    stop: function () {
        this.ws.close();
    },
    ping: function () {
        this.invoke("ping");
    }
};