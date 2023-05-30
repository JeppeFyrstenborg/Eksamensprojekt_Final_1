$(document).ready(function () {
    // Get the current URL path
    var path = window.location.pathname;

    // Add the active class to the corresponding navigation item
    $('.nav-link').each(function () {
        var href = $(this).attr('href');
        var hrefPath = href.split('/')[1]; // Extract the first segment of the href path

        var currentPathSegments = path.split('/'); // Split the current path into segments
        var currentPathFirstSegment = currentPathSegments[1]; // Get the first segment of the current path

        if (currentPathFirstSegment === hrefPath) {
            $(this).addClass('active');
            return false; // Exit the loop early if a match is found
        }
    });

    $(".view-messages-btn").click(function () {
        var chatId = $(this).data("chatid");
        var userId = $(this).data("userid");
        var url = "/message/_messagesListView/" + chatId + "/" + userId;

        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            success: function (data) {
                if (data !== null) {
                    var html = "";
                    for (var i = 0; i < data.length; i++) {
                        html += "<p>" + data[i].MessageText + "</p>";
                    }
                    $("#messagesPartialViewContainer").html(html);
                } else {
                    $("#messagesPartialViewContainer").html("<p>No messages found.</p>");
                }
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    });



});
