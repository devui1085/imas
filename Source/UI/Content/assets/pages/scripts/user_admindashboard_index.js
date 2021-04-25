$(function () {
    zw.page.initialize();
});

zw.page = {
    strings: {

    },

    initialize: function () {
        zw.ui.charts.buildChart({
            dataUrl: "/AdminDashboard/GetSiteVisitChartData",
            chartDiv: "site-visits-chart-div",
            theme: "none",
            valueField: 'Visits',
            categoryField: 'Date'
        });
        zw.ui.charts.buildChart({
            dataUrl: "/AdminDashboard/GetUsersRegistrationStatisticChartData",
            chartDiv: "site-user-registration-chart-div",
            theme: "none",
            valueField: 'Visits',
            categoryField: 'Date'
        });
        zw.ui.charts.buildChart({
            dataUrl: "/AdminDashboard/GetAdvertismentStatisticChartData",
            chartDiv: "site-advertisment-chart-div",
            theme: "none",
            valueField: 'Visits',
            categoryField: 'Date'
        });
    }

};

