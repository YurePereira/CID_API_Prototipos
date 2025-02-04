using CidApi.Application.Services;
using CidApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CidApi.Controllers
{
    [Route("api/cid")]
    [ApiController]
    public class CidController : ControllerBase
    {
        private readonly CidService _service;

        public CidController(CidService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cid>>> GetAll()
        {
            var cids = await _service.GetAllAsync();
            return Ok(cids);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Cid>> GetByCodigo(string codigo)
        {
            var cid = await _service.GetByCodigoAsync(codigo);
            return cid is not null ? Ok(cid) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cid cid)
        {
            await _service.AddAsync(cid);
            return CreatedAtAction(nameof(GetByCodigo), new { codigo = cid.Codigo }, cid);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Update(string codigo, Cid cid)
        {
            if (codigo != cid.Codigo)
                return BadRequest("Código do CID inconsistente.");

            await _service.UpdateAsync(cid);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(string codigo)
        {
            await _service.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
