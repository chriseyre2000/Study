using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Redis;

namespace MixedTechWebApp.Models
{
    public class RedisDemoModel
    {
        public RedisDemoModel()
        {
            RedisClient redisClient = new RedisClient();
            DemoValue = redisClient.Get<string>("DemoValue");
        }

        public string DemoValue { get; set; }
    }
}