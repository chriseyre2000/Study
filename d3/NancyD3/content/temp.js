
d3.json('data', function (data) {
    
    var svg = d3.select("svg");

    svg.append("rect").attr("x", 0)
                      .attr("y", 0)
                      .attr("width", 100)
                      .attr("height", 80)
                      .attr("fill", "yellow")
    
    //The data for our line
    var lineData = data;

    var xscale = d3.scale.linear();
    xscale.domain([0, 100]);
    xscale.range([100, 0]);

    var yscale = d3.scale.linear();
    yscale.domain([5,70 ]);
    yscale.range([0,50])
    
    //This is the accessor function we talked about above
    var lineFunction = d3.svg.line()
                             .x(function (d) { return xscale(d.x); })
                             .y(function (d) { return d.y; })
                             .interpolate("linear");

    //The line SVG Path we draw
    var lineGraph = svg.append("path")
                       .attr("d", lineFunction(lineData))
                       .attr("stroke", "green")
                       .attr("stroke-width", 2)
                       .attr("fill", "none");
});


