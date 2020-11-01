Ext.define('MyExtGenApp.Application', {
	extend: 'Ext.app.Application',
	name: 'MyExtGenApp',
	requires: ['MyExtGenApp.*'],
	defaultToken: 'homeview',

	removeSplash: function () {
		Ext.getBody().removeCls('launching')
		var elem = document.getElementById("splash")
		elem.parentNode.removeChild(elem)
	},
    views: [
        'MyExtGenApp.view.login.LoginView',
        'MyExtGenApp.view.main.MainView'
    ],
	launch: function () {
		this.removeSplash()

        // It's important to note that this type of application could use
        // any type of storage, i.e., Cookies, LocalStorage, etc.
        var loggedIn;

        // Check to see the current value of the localStorage key
        loggedIn = localStorage.getItem("LoggedIn");

        // This ternary operator determines the value of the TutorialLoggedIn key.
        // If TutorialLoggedIn isn't true, we display the login window,
        // otherwise, we display the main view
        //Ext.create({
        //    xtype: loggedIn ? 'app-main' : 'login'
        //});

		var whichView = loggedIn ? 'mainview' : 'login';
        // var whichView = 'mainview';
		Ext.Viewport.add([{xtype: whichView}])
	},

	onAppUpdate: function () {
		Ext.Msg.confirm('Application Update', 'This application has an update, reload?',
			function (choice) {
				if (choice === 'yes') {
					window.location.reload();
				}
			}
		);
	}
});
