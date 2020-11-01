Ext.define('MyExtGenApp.view.login.LoginView', {
    extend: 'Ext.form.Panel',
    xtype: 'login',
    controller: {type: 'loginviewcontroller'},
    title: 'Login',

    bodyPadding: 20,
    width: 320,
    autoSize: true,

    items: [{
        xtype: 'textfield',
        allowBlank: false,
        required: true,
        label: 'Логин',
        name: 'user',
        placeholder: 'user id'
    }, {
        xtype: 'passwordfield',
        allowBlank: false,
        required: true,
        label: 'Пароль',
        name: 'pass',
        placeholder: 'password'
    }],

    buttons: [{
        text: 'Login',
        handler: 'onLoginClick'
    }]
});