$(document).ready(function () {

    $("#Upper").html("This is a test");

    $("[data-test]").click(function (a) {
        $("#Upper").load($(a.target).attr("data-test"))
    }); 
});