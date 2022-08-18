using Microsoft.AspNetCore.Mvc;

namespace Miameal.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}