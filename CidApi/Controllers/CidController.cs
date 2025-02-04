using Microsoft.AspNetCore.Mvc;
using CidApi.Application.Services;
using CidApi.Domain.Models;

namespace CidApi.Controllers;

[ApiController]
[Route("api/cid")]
public class CidController : ControllerBase
{
    private readonly CidService _cidService;

    public CidController(CidService cidService)
    {
        _cidService = cidService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var cids = _cidService.GetAll();
        return Ok(cids);
    }

    [HttpGet("{codigo}")]
    public IActionResult GetByCodigo(string codigo)
    {
        var cid = _cidService.GetByCodigo(codigo);
        return cid is not null ? Ok(cid) : NotFound(new { message = "CID não encontrado" });
    }
}
