$(function () {
    zw.page.initialize();
});

zw.page = {
    strings: {
        selectedAdvertismentsRemoved: "آگهی های انتخاب شده حذف شدند",
    },

    initialize: function () {
        this.initialAdvertismentsGrid();
        $("#remove-advertisments").click(this.removeAdvertisments);
        $("#unconfirm-advertisments").click(this.unconfirmAdvertisments);
    },

    initialAdvertismentsGrid: function () {
        $('.advertisments-grid').DataTable({
            language: {
                url: '/content/assets/global/plugins/datatables/localization/persian.js'
            },
            ajax: {
                url: '/User/AdminDashboard/GetAllAdvertisments',
                type: 'GET'
            },
            columns: [
                {
                    data: 'Id',
                    render: function (data, type, full, meta) {
                        return '<label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes"><span></span></label>';
                    }
                },
                {
                    data: 'Title'
                    , title: zw.strings.title
                    , width: '50%'
                },
                {
                    data: 'StatusTitle'
                    , title: zw.strings.statusTitle
                },
                {
                    data: 'RegisterDateString',
                    title: zw.strings.publishDate
                },
                {
                    data: 'Id',
                    title: '',
                    render: function (data, type, full, meta) {
                        return ('<div><a  target="_blank" href="{0}" class="btn btn-sm btn-outline grey-salsa">' +
                            '<i class="fa fa-search"></i> {1}' +
                            '</a>').replace('{0}', '/advertisment/' + full.Id).replace('{1}', zw.strings.view);// +

                    }
                },
            ]
        });
    },

    removeAdvertisments: function (e) {
        var grid = $(".advertisments-grid").DataTable();
        var selectedRows = [], selectedRowsIds = [];
        $("tbody > tr > td:nth-child(1) input[type=\"checkbox\"]:checked").each(function () {
            var row = $(this).parent().parent().parent();
            selectedRows.push(row);
            selectedRowsIds.push(grid.row(row).data().Id);
        });

        $.ajax("/user/admindashboard/removeAdvertisments", {
            type: "POST",
            data: { ids: selectedRowsIds },
            success: function (response) {
                $('.advertisments-grid').DataTable().ajax.reload();
                zw.ui.showMessage(zw.page.strings.selectedAdvertismentsRemoved, "");
            }
        });
    },
    unconfirmAdvertisments: function (e) {
        var grid = $(".advertisments-grid").DataTable();
        var selectedRows = [], selectedRowsIds = [];
        $("tbody > tr > td:nth-child(1) input[type=\"checkbox\"]:checked").each(function () {
            var row = $(this).parent().parent().parent();
            selectedRows.push(row);
            selectedRowsIds.push(grid.row(row).data().Id);
        });

        $.ajax("/user/admindashboard/unconfirmAdvertisments", {
            type: "POST",
            data: { ids: selectedRowsIds },
            success: function (response) {
                $('.advertisments-grid').DataTable().ajax.reload();
                zw.ui.showMessage(zw.page.strings.selectedAdvertismentsUnconfirmed, "");
            }
        });
    },


}
