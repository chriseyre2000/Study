$(document).ready(function () {

    $("#Upper").html("This is a test");

    $("[open]").click(function (a) {
        $("#Upper").load($(a.target).attr("open"))
    }); 
});