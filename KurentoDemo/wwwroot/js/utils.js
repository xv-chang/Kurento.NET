var uuidv4 = function () {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
};
var cookie = {
    set: function (key, val, time) {//设置cookie方法
        var date = new Date(); //获取当前时间
        var expiresDays = time;  //将date设置为n天以后的时间
        date.setTime(date.getTime() + expiresDays * 24 * 3600 * 1000); //格式化为cookie识别的时间
        document.cookie = key + "=" + val + ";expires=" + date.toGMTString();  //设置cookie
    },
    get: function (key) {//获取cookie方法
        var getCookie = document.cookie.replace(/[ ]/g, "");
        var arrCookie = getCookie.split(";");
        var tips;
        for (var i = 0; i < arrCookie.length; i++) {
            var arr = arrCookie[i].split("=");
            if (key == arr[0]) {
                tips = arr[1];
                break;
            }
        }
        return tips;
    },
    delete: function (key) { //删除cookie方法
        var date = new Date(); //获取当前时间
        date.setTime(date.getTime() - 10000); //将date设置为过去的时间
        document.cookie = key + "=v; expires =" + date.toGMTString();//设置cookie
    }
};