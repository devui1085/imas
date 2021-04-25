$(function () {
    zw.page.initialize();
});

zw.page = {
    strings: {

    },

    initialize: function () {
        zw.ui.charts.buildChart({
            dataUrl: "/advertisment/GetAdvertismentVisitChartData",
            chartDiv: "advertismentVisitChart",
            theme: "none",
            valueField: 'Value',
            categoryField: 'Key',
            parameter: { advertismentId: $('#AdvertismentId').val() } ,
        });
    }
};

