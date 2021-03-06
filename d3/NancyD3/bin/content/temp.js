﻿
d3.json('data', function (d) {

    var svg = d3.select("svg");


    //The data for our line
    var lineData = d; /* [{ "x": 1, "y": 5 },
                    { "x": 20, "y": 20 },
                    { "x": 40, "y": 10 },
                    { "x": 60, "y": 40 },
                    { "x": 80, "y": 5 },
                    { "x": 100, "y": 60 }];*/

    //This is the accessor function we talked about above
    var lineFunction = d3.svg.line()
                             .x(function (d) { return d.x; })
                             .y(function (d) { return d.y; })
                             .interpolate("linear");


    //The line SVG Path we draw
    var lineGraph = svg.append("path")
                       .attr("d", lineFunction(lineData))
                       .attr("stroke", "red")
                       .attr("stroke-width", 2)
                       .attr("fill", "none");
});


