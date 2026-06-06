using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Kfc.Controllers;

[ApiController]
[Route("api/v1/manifest")]
public class ApiManifestController : AbpController
{
    /// <summary>
    /// Endpoint para obtener el manifiesto de la API
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ApiManifestDto Get()
    {
        return new ApiManifestDto()
        {
            Name = "KFC API",
            Version = "1.0.0",            
            Description = "Gestión de Productos y Precios por Canal"
            // can be incñude comit hash or version build
        };
    }
}

public class ApiManifestDto
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
}

