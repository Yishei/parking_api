using Microsoft.AspNetCore.Mvc;
using parking_api.Models;
using parking_api.Services;

namespace parking_api.Controllers;

[Route("api/webhook")]
[ApiController]
public class WebhookController : ControllerBase
{
    private readonly IWebHookService webHookService;

    public WebhookController(IWebHookService service)
    {
        webHookService = service;
    }

    [HttpPost]
    public async Task<IActionResult> HandelPost([FromBody] RootALpr data, CancellationToken cancellationToken = default)
    {
        await webHookService.HandleCameraLog(data, cancellationToken);

        return Ok();
    }
}
