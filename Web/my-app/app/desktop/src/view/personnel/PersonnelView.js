Ext.define('MyExtGenApp.view.personnel.PersonnelView',{
    extend: 'Ext.grid.Grid',
    xtype: 'personnelview',
    cls: 'personnelview',
    requires: ['Ext.grid.rowedit.Plugin'],
    controller: {type: 'personnelviewcontroller'},
    viewModel: {type: 'personnelviewmodel'},
    store: {type: 'personnelviewstore'},
    plugins: {
        rowedit: {
            autoConfirm: false
        },
        pagingtoolbar: true
    },
    dockedItems: [
        {
            xtype: 'pagingtoolbar',
            dock: 'bottom',
            store: {type: 'personnelviewstore'},
            displayInfo: true,
            pageSize: 10,
            prependButtons: true,
            beforePageText: 'Страница',
            afterPageText: 'из {0}',
            displayMsg: 'Персоны {0} - {1} из {2}'}
    ],
    columns: [
        {
            text: 'Name',
            dataIndex: 'name',
            editable: true,
            width: 100,
            cell: {userCls: 'bold'}
        },
        {text: 'Email',dataIndex: 'email',editable: true, width: 230},
        {
            text: 'Phone',
            dataIndex: 'phone',
            editable: true,
            width: 150
        }
    ],
    listeners: {
        canceledit: 'onEditCancelled'
    }
});
