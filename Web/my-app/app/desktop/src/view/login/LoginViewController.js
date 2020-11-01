Ext.define('MyExtGenApp.view.login.LoginViewController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.loginviewcontroller',

    onLoginClick: function() {
        var form = this.getView();

        // получаем данные формы и фомируем объект для отправки
        const formData = {"id": "0",
            "login": form.items.getByKey("ext-textfield-1").getValue(),
            "password" : form.items.getByKey("ext-passwordfield-1").getValue()
        };

        let _this = this;
        Ext.Ajax.request({
            method: 'post',
            params: formData,
            url: 'https://localhost:44334/account',
            success: function(response, options){
                // запишем токен в заголовки то бы прикреплялся к каждому запросу
                // в реализации Logout нужно его оттуда убирать + к тому что токен при логауте на сервер тоже должен
                // делаться невалидным
                Ext.Ajax.setDefaultHeaders({
                    'Authorization': 'Bearer ' + response.responseText,
                    'Accept': 'application/json'
                });
                localStorage.setItem("LoggedIn", true);
                _this.getView().destroy();
                Ext.Viewport.add([{xtype: 'personnelview'}])
            },
            failure: function(response, options){
                Ext.Msg.alert('Ошибка', 'Не правильное имяользователя или пароль!');
            }
        });
    }
});