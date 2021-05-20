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
    // The [controller] names the route with whatever the name before the word "Controller" in the Class is:  <-- "api/kingdoms"
    public class KingdomsController : ControllerBase
    {
        private readonly KingdomsService _service;

        public KingdomsController(KingdomsService service)
        // Dependency Injection:  In order to use this Controller, this Service must be injected on Construction
        {
            _service = service;
        }

        [HttpGet]
        // This attribute defines that the method to follow is a "get" request
        public ActionResult<IEnumerable<Kingdom>> getAll()
        // IEnumerable takes the place of any collection type (List, Array, etc...)
        // ActionResult <-- "of type" List <-- "of type" Kingdom
        {
            try
            {
                IEnumerable<Kingdom> kingdoms = _service.GetAll();
                return Ok(kingdoms);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GetById  <-- same as :id
        [HttpGet("{id}")]
        public ActionResult<Kingdom> GetById(int id) // <-- NOTE Convert to Int for afternoon Challenge
        {
            try
            {
                Kingdom kingdom = _service.GetById(id);
                return Ok(kingdom);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST
        [HttpPost]
        public ActionResult<Kingdom> Create([FromBody] Kingdom newKingdom)
        // This says that "From the Body" create a Kingdom called "newKingdom"
        {
            try
            {
                Kingdom kingdom = _service.Create(newKingdom);
                return Ok(kingdom);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult<Kingdom> Update([FromBody] Kingdom edit, int id)
        {
            try
            {
                edit.Id = id;
                Kingdom update = _service.Update(edit);
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
                _service.DeleteKingdom(id);
                return Ok("Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}