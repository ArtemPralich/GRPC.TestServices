using Grpc.Net.Client;
using GRPC.MainService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRPC.MainClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            // создаем клиента
            var client = new Greeter.GreeterClient(channel);
            string name = "TEST1";
            // обмениваемся сообщениями с сервером
            var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
            Console.WriteLine("Ответ сервера: " + reply.Message);
            Console.ReadKey();
            return Ok();
        }
    }
}
