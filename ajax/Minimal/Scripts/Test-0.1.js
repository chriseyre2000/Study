$(document).ready(function () {

    $("#Upper").html("This is a test");

    $("[data-open]").click(function (a) {
        $("#Upper").load($(a.target).attr("data-open"))
    }); 
});