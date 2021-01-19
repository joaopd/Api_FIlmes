using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Filmes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FilmesController : ControllerBase
  {
    private IFilmeServices _service;
    public FilmesController(IFilmeServices service)
    {
      _service = service;
    }

    [Authorize("Bearer")]
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult> GetList()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {

        return Ok(await _service.GetList());
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

 
    [Authorize("Bearer")]
    [HttpGet]
    [Route("GetId", Name = "GetListId")]
    public async Task<ActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        return Ok(await _service.Get(id));
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [Authorize("Bearer")]
    [HttpGet]
    [Route("GetGenero", Name = "GetListGenero")]
    public async Task<ActionResult> GetGenero(string Gernero)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        return Ok(await _service.GetGenero(Gernero));
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [Authorize("Bearer")]
    [HttpGet]
    [Route("GetDiretor", Name = "GetListDiretor")]
    public async Task<ActionResult> GetDiretor(string Diretor)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        return Ok(await _service.GetDiretor(Diretor));
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [Authorize("Bearer")]
    [HttpGet]
    [Route("GetName", Name = "GetName")]
    public async Task<ActionResult> GetName(string Name)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        return Ok(await _service.GetName(Name));
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [Authorize("Bearer")]
    [HttpPost]
    [Route("Incluir")]
    public async Task<ActionResult> Post([FromBody] FilmeEntity filme)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {

        var result = await _service.Post(filme);
        if (result != null)
        {
          return Created(new Uri(Url.Link("GetwithId", new { id = result.Id })), result);
        }
        else
        {
          return BadRequest();
        }
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [Authorize("Bearer")]
    [HttpPut]
    [Route("Alterar")]
    public async Task<ActionResult> Put([FromBody] FilmeEntity filme)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        var result = await _service.Put(filme);
        if (result != null)
        {
          return Ok(result);
        }
        else
        {
          return BadRequest();
        }
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize("Bearer")]
    public async Task<ActionResult> Delete(int id)
    {

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        return Ok(await _service.Delete(id));
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }

    }
  }
}
