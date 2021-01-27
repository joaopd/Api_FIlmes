using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AvaliarController : ControllerBase
  {
    private AvaliarService _service;

    public AvaliarController(AvaliarService service)
    {
      _service = service;
    }

    // [HttpPost]
    // [Route("RateMovie", Name = "Avaliar")]
    // public async Task<ActionResult> Avaliar([FromBody] AvaliacaoEntity item)
    // {
    //   if (!ModelState.IsValid)
    //   {
    //     return BadRequest(ModelState); //400 solicitação invalida
    //   }
    //   try
    //   {
    //     var result = await _service.Avaliar(item);
    //     if (result != null)
    //     {
    //       return Ok(result);
    //     }
    //     else
    //     {
    //       return BadRequest();
    //     }
    //   }
    //   catch (ArgumentException e)
    //   {
    //     return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
    //   }
    //}
  }
}
