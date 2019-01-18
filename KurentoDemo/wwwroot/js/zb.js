var zb = {
    addComponent: function (componentName, url) {
        var componentURL = url || "/components/" + componentName + ".html?v=" + new Date().getTime();
        Vue.component(componentName, function (resolve) {
            http.load(componentURL).then(str => {
                var template = /<template>([\s\S]*?)<\/template>/i.exec(str)[1];
                var script = /export\s*default\s*({[\s\S]*})/i.exec(str)[1];
                var obj = eval('(' + script + ')');
                obj.template = template;
                resolve(obj);
            });
        });
    }
};