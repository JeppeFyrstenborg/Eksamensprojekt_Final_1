
$(document).ready(function () {

    var path = window.location.pathname;

    //Function som ændrer på knapperne i toppen, og sørger for at det er den aktuelle sides knap der er aktiv.
    $('.nav-link').each(function () {
        var href = $(this).attr('href');
        var hrefPath = href.split('/')[1];

        var currentPathSegments = path.split('/');
        var currentPathFirstSegment = currentPathSegments[1];

        if (currentPathFirstSegment === hrefPath) {
            $(this).addClass('active');
            return false;
        }
    });


    //Funktion til knapperne ud for hver chat, på brugersiden. 
    //Sender et ajax-kald til serveren, og modtager noget html.
    $(".view-messages-btn").click(function () {
        var chatId = $(this).data("chatid");
        var userId = $(this).data("userid");
        var url = "/message/_messagesListView/" + chatId + "/" + userId;

        $.ajax({
            url: url,
            type: "GET",
            success: function (data) {
                $("#messagesPartialViewContainer").html(data);
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    });



});
