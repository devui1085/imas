$(function() {
    zw.page.initialize();
});

zw.page = {
    strings: {
        selectedAdvertismentsDiactivated: "مقاله‌های انتخاب شده بلاک شدند",
    },

    initialize: function () {
        this.initialContentsGrid();
        $("#deactive-advertisment").click(this.deactiveAdvertisment);
    },

    initialContentsGrid: function () {
        $('.contents-grid').DataTable({
            language: {
                url: '/content/assets/global/plugins/datatables/localization/persian.js'
            },
            ajax: {
                url: '/User/Advertisment/GetActiveAdvertisment',
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
                    data: 'TypeIdentityLocalized'
                    , title: zw.strings.AdvertismentTypeIdentity
                    , width: '20%'
                },
                {
                    data: 'StatusTitle'
                    , title: zw.strings.advertismentStatus
                    , width: '20%'
                },
                {
                    data: 'RegisterDateString',
                    title: zw.strings.createDate
                },
                {
                    data: 'Id',
                    title: '',
                    render: function (data, type, full, meta) {
                        return ('<div><a  target="_blank" href="{0}" class="btn btn-sm btn-outline grey-salsa">' +
                         '<i class="fa fa-search"></i> {1}' +
                         '</a>').replace('{0}', '/advertisment/' + full.Id).replace('{1}', zw.strings.view) +

                         ('<a href="{0}" class="btn btn-sm blue">' +
                         '<i class="fa fa-pencil"></i> {1}' +
                         '</a>').replace('{0}', '/user/advertisment/edit/' + full.Id).replace('{1}', zw.strings.edit);// +

                    }
                },
            ]
        });
    },

    deactiveAdvertisment: function (e) {
        var grid = $(".contents-grid").DataTable();
        var selectedRows = [], selectedRowsIds = [];
        $("tbody > tr > td:nth-child(1) input[type=\"checkbox\"]:checked").each(function () {
            var row = $(this).parent().parent().parent();
            selectedRows.push(row);
            selectedRowsIds.push(grid.row(row).data().Id);
        });

        $.ajax("/user/admindashboard/blockArticles", {
            type: "POST",
            data: { ids: selectedRowsIds },
            success: function (response) {
                grid.initialContentsGrid();
                zw.ui.showMessage(zw.page.strings.selectedArticlesBlocked, "");
            }
        });
    },
}
