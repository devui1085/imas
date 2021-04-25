$(function () {
    zw.page.initialize();
})

zw.page = {
    startIndex: 12,
    offSet: 12,
    isPreviousEventComplete: true,
    isDataAvailable: true,
    initialize: function () {
        $(window).scroll(function () {
            var scrollHeight = $(document).height();
            var scrollPosition = $(window).height() + $(window).scrollTop();

            if ((scrollHeight - scrollPosition) / scrollHeight === 0) {
                if (zw.page.isPreviousEventComplete && zw.page.isDataAvailable) {
                    zw.page.isPreviousEventComplete = false;
                    $(".LoaderImage").css("display", "block");

                    zw.page.loadNewData();
                }
            }
        });
    },
    loadNewData: function () {
        $.ajax({
            type: "GET",
            url: '/Home/GetAdavertisment?startIndex=' + zw.page.startIndex + '&offset=' + zw.page.offSet + '',
            success: function (result) {
                //   $(".divContent").append(result);
                zw.page.AppendNewData(result);

                zw.page.startIndex = zw.page.startIndex + zw.page.offSet;
                zw.page.isPreviousEventComplete = true;

                if (result.advertisments.length == 0) //When data is not available
                    zw.page.isDataAvailable = false;

                $(".LoaderImage").css("display", "none");
            },
            error: function (error) {
                alert(error);
            }
        });
    },
    AppendNewData: function (result) {
        var advertismentsElement = $("#advertisments");
        for (var index in result.advertisments) {
            var newItem = '<div class="item  col-sm-4 ">'
                + '<div class="thumbnail">'
                + '<img class="group list-group-image" src='
                + '"/AdImages/Pic400x250/' + result.advertisments[index].FistImageName +'.png" alt= "" />'
                + '<div class="caption number-fa">'
                + '<h4 class="group inner list-group-item-heading">'
                + result.advertisments[index].Title 
                      +              '</h4>\
                        <h55 class="group inner list-group-item-text">'
                + result.advertisments[index].RegisterDateString 
                                  +  '</h55>\
                        <div class="row">\
                            <div class="col-xs-12 col-md-6">\
                                <p class="lead"></p>\
                            </div>\
                            <div class="col-sm-12">\
                                <a class="btn btn-primary btn-lg btn-block" href="advertisment/'+ result.advertisments[index].Id+'">مشاهده آگهی</a>\
                            </div>\
                        </div>\
                    </div>\
                            </div >\
                        </div >';
            advertismentsElement.append(newItem);
        }
    }
}