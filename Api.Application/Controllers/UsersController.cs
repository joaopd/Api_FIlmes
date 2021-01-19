using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserServices _service;
    public UsersController(IUserServices service)
    {
      _service = service;
    }

    [Authorize("Bearer")]
    [HttpGet]
  
    public async Task<ActionResult> GetAll()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        return Ok(await _service.GetAll());
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [Authorize("Bearer")]
    [HttpGet]
    [Route("{id}", Name = "GetWithId")]
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

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserEntity user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        var result = await _service.Post(user);
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
    public async Task<ActionResult> Put([FromBody] UserEntity user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); //400 solicitação invalida
      }
      try
      {
        var result = await _service.Put(user);
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

    [Authorize("Bearer")]
    [HttpDelete("{id}")]
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
