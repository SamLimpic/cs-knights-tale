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
    // The [controller] names the route with whatever the name before the word "Controller" in the Class is:  <-- "api/lords"
    public class LordsController : ControllerBase
    {
        private readonly LordsService _service;

        public LordsController(LordsService service)
        // Dependency Injection:  In order to use this Controller, this Service must be injected on Construction
        {
            _service = service;
        }

        [HttpGet]
        // This attribute defines that the method to follow is a "get" request
        public ActionResult<IEnumerable<Lord>> getAll()
        // IEnumerable takes the place of any collection type (List, Array, etc...)
        // ActionResult <-- "of type" List <-- "of type" Lord
        {
            try
            {
                IEnumerable<Lord> lords = _service.GetAll();
                return Ok(lords);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GetById  <-- same as :id
        [HttpGet("{id}")]
        public ActionResult<Lord> GetById(int id) // <-- NOTE Convert to Int for afternoon Challenge
        {
            try
            {
                Lord lord = _service.GetById(id);
                return Ok(lord);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST
        [HttpPost]
        public ActionResult<Lord> Create([FromBody] Lord newLord)
        // This says that "From the Body" create a Lord called "newLord"
        {
            try
            {
                Lord lord = _service.Create(newLord);
                return Ok(lord);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult<Lord> Update([FromBody] Lord edit, int id)
        {
            try
            {
                edit.Id = id;
                Lord update = _service.Update(edit);
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
                _service.DeleteLord(id);
                return Ok("Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}