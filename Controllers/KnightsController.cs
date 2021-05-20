using System;
using System.Collections.Generic;
using cs_knights_tale.Models;
using cs_knights_tale.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_knights_tale.Controllers
{
    [ApiController]
    // This attribute tells dotnet that this class should be registered with the controllers
    [Route("api/[controller]")]
    // The [controller] names the route with whatever the name before the word "Controller" in the Class is:  <-- "api/knights"
    public class KnightsController : ControllerBase
    {
        private readonly KnightsService _service;

        public KnightsController(KnightsService service)
        // Dependency Injection:  In order to use this Controller, this Service must be injected on Construction
        {
            _service = service;
        }

        [HttpGet]
        // This attribute defines that the method to follow is a "get" request
        public ActionResult<IEnumerable<Knight>> getAll()
        // IEnumerable takes the place of any collection type (List, Array, etc...)
        // ActionResult <-- "of type" List <-- "of type" Knight
        {
            try
            {
                IEnumerable<Knight> knights = _service.GetAll();
                return Ok(knights);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GetById  <-- same as :id
        [HttpGet("{id}")]
        public ActionResult<Knight> GetById(int id) // <-- NOTE Convert to Int for afternoon Challenge
        {
            try
            {
                Knight knight = _service.GetById(id);
                return Ok(knight);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST
        [HttpPost]
        public ActionResult<Knight> Create([FromBody] Knight newKnight)
        // This says that "From the Body" create a Knight called "newKnight"
        {
            try
            {
                Knight knight = _service.Create(newKnight);
                return Ok(knight);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult<Knight> Update([FromBody] Knight edit, int id)
        {
            try
            {
                edit.Id = id;
                Knight update = _service.Update(edit);
                return Ok(update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _service.DeleteKnight(id);
                return Ok("Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}