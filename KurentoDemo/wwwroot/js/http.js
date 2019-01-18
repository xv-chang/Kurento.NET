var http = {
    get:function (url, data) {
        return new Promise((resolve, reject) => {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    if ((xhr.status >= 200 && xhr.status < 300) || xhr.status == 304) {
                        var res = JSON.parse(xhr.responseText);
                        resolve(res);
                    } else {
                        reject(xhr.responseText);
                    }
                }
            };
            var dataArray = new Array();
            for (var key in data) {
                dataArray.push(key + "=" + data[key]);
            }
            var urlParams = dataArray.join("&");
            var connectChar = url.indexOf("?") > -1 ? "&" : "?";
            var requestUrl = url + connectChar + urlParams;
            xhr.open("get", requestUrl, true);
            xhr.setRequestHeader("token", localStorage.getItem("token"));
            xhr.send(null);
        });
    },
    post: function (url, data) {
        return new Promise((resolve, reject) => {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    if ((xhr.status >= 200 && xhr.status < 300) || xhr.status == 304) {
                        var res = JSON.parse(xhr.responseText);
                        resolve(res);
                    } else {
                        reject(xhr.responseText);
                    }
                }
            };
            var dataArray = new Array();
            for (var key in data) {
                dataArray.push(key + "=" + data[key]);
            }
            var urlParams = dataArray.join("&");
            xhr.open("post", url, true);
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;charset-UTF-8");
            xhr.setRequestHeader("token", localStorage.getItem("token"));
            xhr.send(urlParams);
        });
    },
    load: function (url) {
        return new Promise((resolve, reject) => {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    if ((xhr.status >= 200 && xhr.status < 300) || xhr.status == 304) {
                        resolve(xhr.response);
                    } else {
                        reject(xhr.response);
                    }
                }
            };
            xhr.open("get", url, true);
            xhr.send(null);
        });
    }
}
