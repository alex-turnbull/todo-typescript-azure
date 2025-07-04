using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace todo_solution
{
    internal class GetTodos
    {
        [Function("GetTodos")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var todos = new[]
            {
                new { id = 1, task = "Buy milk", completed = false },
                new { id = 2, task = "Write React app", completed = true },
                new { id = 3, task = "Deploy to Azure", completed = false }
            };

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");

            await response.WriteStringAsync(JsonSerializer.Serialize(todos));
            return response;
        }
    }
}
