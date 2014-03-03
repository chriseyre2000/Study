using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyD3
{

    public class Data
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class D3DataModule : NancyModule
    { 
        public D3DataModule()
        {
            Get["data"] = x => 
                {   
                    return new [] {
                        new Data { x = 1, y = 5 },
                        new Data { x = 20, y = 20 },
                        new Data { x = 40, y = 10 },
                        new Data { x = 60, y = 40 },
                        new Data { x = 80, y = 5 },
                        new Data { x = 100, y = 60 }
                    }; 
                };

            Get["/"] = x =>  View["Index"];
        }
    }
}