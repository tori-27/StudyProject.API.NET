using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StudyProject.Data;
using StudyProject.Data.Models;
using k8s;
using AutoMapper;
using System.IO;
using StudyProject.Services;

namespace StudyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KubernetesClusterController : ControllerBase
    {
        private readonly KubernetesListingDbContext _context;
        private readonly IMapper _mapper;
        private readonly KubernetesClientService _kubernetesService;

        public KubernetesClusterController(KubernetesClientService kubernetesService, KubernetesListingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _kubernetesService = kubernetesService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadKubeConfig(IFormFile kubeConfigFile)
        {
            if (kubeConfigFile == null || kubeConfigFile.Length == 0)
                return BadRequest("Файл не надіслано");

            byte[] kubeConfigContent;
            using (var memoryStream = new MemoryStream())
            {
                await kubeConfigFile.CopyToAsync(memoryStream);
                kubeConfigContent = memoryStream.ToArray();
            }

            _kubernetesService.Initialize(kubeConfigContent);
            return Ok("Клієнт Kubernetes ініціалізовано");
        }
    }
}
