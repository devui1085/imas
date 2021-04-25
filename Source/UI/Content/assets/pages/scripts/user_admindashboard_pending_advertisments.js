$(function () {
    zw.page.initialize();
});

zw.page = {
    strings: {
        selectedAdvertismentsConfirmed: "آگهی های انتخاب شده تایید شدند",
        selectedAdvertismentsUnconfirmed: "آگهی های انتخاب شده عدم تایید شدند",
        selectedAdvertismentsRemoved: "آگهی های انتخاب شده حذف شدند",
    },

    initialize: function () {
        this.initialAdvertismentsGrid();
        $("#confirm-advertisments").click(this.confirmAdvertisments);
        $("#remove-advertisments").click(this.removeAdvertisments);

    },

    initialAdvertismentsGrid: function () {
        $('.advertisments-grid').DataTable({
            language: {
                url: '/content/assets/global/plugins/datatables/localization/persian.js'
            },
            ajax: {
                url: '/User/AdminDashboard/GetPendingAdvertisments',
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
                    data: 'StatusTitle',
                    title: zw.strings.statusTitle,
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

    confirmAdvertisments: function (e) {
        var selectedRowsIds = zw.page.getSelectedRowsIds();     

        $.ajax("/user/admindashboard/confirmAdvertisments", {
            type: "POST",
            data: { ids: selectedRowsIds },
            success: function (response) {
                $('.advertisments-grid').DataTable().ajax.reload();
                zw.ui.showMessage(zw.page.strings.selectedAdvertismentsConfirmed, "");
            }
        });
    },

    removeAdvertisments: function (e) {
        var selectedRowsIds = zw.page.getSelectedRowsIds();      

        $.ajax("/user/admindashboard/removeAdvertisments", {
            type: "POST",
            data: { ids: selectedRowsIds },
            success: function (response) {
                $('.advertisments-grid').DataTable().ajax.reload();
                zw.ui.showMessage(zw.page.strings.selectedAdvertismentsRemoved, "");
            }
        });
    },
    getSelectedRowsIds: function () {
        var grid = $(".advertisments-grid").DataTable();
        var selectedRows = [], selectedRowsIds = [];
        $("tbody > tr > td:nth-child(1) input[type=\"checkbox\"]:checked").each(function () {
            var row = $(this).parent().parent().parent();
            selectedRows.push(row);
            selectedRowsIds.push(grid.row(row).data().Id);
        });

        return selectedRowsIds;
    }

}
