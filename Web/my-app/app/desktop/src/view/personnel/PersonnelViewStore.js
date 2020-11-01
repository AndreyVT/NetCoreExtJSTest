Ext.define('MyExtGenApp.view.personnel.PersonnelViewStore', {
    extend: 'Ext.data.Store',
    alias: 'store.personnelviewstore',
    fields: [
        'name', 'email', 'phone', 'dept'
    ],
    pageSize: 12,
    proxy: {
        type: 'ajax',
        url: 'https://localhost:44334/data',
        reader: {
            type: 'json',
            rootProperty: 'results',
            totalProperty: 'rowCount'
        }
    },
    autoLoad: true
});
