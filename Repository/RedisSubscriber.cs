using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    //public class RedisSubscriber : BackgroundService
    //{

    //    private readonly IConnectionMultiplexer _connectionMultiplexer;

    //    public RedisSubscriber(IConnectionMultiplexer connectionMultiplexer)
    //    {
    //        _connectionMultiplexer = connectionMultiplexer;
    //    }

    //    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        var subscriber = _connectionMultiplexer.GetSubscriber();
    //        return subscriber.SubscribeAsync("messages", ((channel, value) => {
    //            Console.WriteLine($"the message content was : {value}");

    //        }));
    //    }
    //}
}
