using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using k8s;
using StudyProject.Services;

namespace StudyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamespaceController : ControllerBase
    {
        private readonly KubernetesClientService _kubernetesService;

        public NamespaceController(KubernetesClientService kubernetesService)
        {
            _kubernetesService = kubernetesService;
        }

        [HttpGet("stream")]
        public async Task GetAllNamespacesStream()
        {
            var response = Response;
            response.Headers.Add("Content-Type", "text/event-stream");

            try
            {
                var kubernetesClient = _kubernetesService.GetClient();

                // Перевіряємо, чи ініціалізовано клієнт
                if (kubernetesClient == null)
                {
                    var errorData = new { error = "Kubernetes client is not initialized" };
                    await response.WriteAsync($"data: {System.Text.Json.JsonSerializer.Serialize(errorData)}\n\n");
                    await response.Body.FlushAsync();
                    // Продовжуємо цикл, не перериваючи з'єднання
                }

                while (!HttpContext.RequestAborted.IsCancellationRequested)
                {
                    if (kubernetesClient != null)
                    {
                        var namespaces = await kubernetesClient.CoreV1.ListNamespaceAsync();
                        var names = namespaces.Items.Select(n => n.Metadata.Name).ToList();

                        await response
                            .WriteAsync($"data: {System.Text.Json.JsonSerializer.Serialize(names)}\n\n");
                        await response.Body.FlushAsync();
                    }

                    await Task.Delay(1000); // Час оновлення (може бути налаштований)
                }
            }
            catch (System.Exception ex)
            {
                var errorData = new { error = ex.Message };
                await response.WriteAsync($"data: {System.Text.Json.JsonSerializer.Serialize(errorData)}\n\n");
                await response.Body.FlushAsync();
            }
        }
    }
}


