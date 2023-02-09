using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FabricFinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Security.Claims;
using FabricFinder.Repositories;
using System;


namespace FabricFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FabricController : ControllerBase
    {
        private readonly IFabricRepository _fabricRepository;
        public FabricController(IFabricRepository fabricRepository)
        {
            _fabricRepository = fabricRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fabricRepository.GetAll());
        }



        [HttpPost]
        public IActionResult Post(Fabric fabric)
        {
           _fabricRepository.Add(fabric);
            return CreatedAtAction("Get", new { id = fabric.Id }, fabric);



        //[HttpGet("{id}")]
       // public IActionResult Get(int id)
       // {
           // var fabric = _fabricRepository.GetById(id);
            //if (fabric == null)
           // {
               // return NotFound();
           // }
            //return Ok(fabric);
       // }

        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, Fabric fabric)
       // {
          //  if (id != fabric.Id)
          //  {
           //     return BadRequest();
           // }

           // _fabricRepository.Update(fabric);
           // return NoContent();
       // }

       // [HttpDelete("{id}")]
      //  public IActionResult Delete(int id)
       // {
       //     _fabricRepository.Delete(id);
       //     return NoContent();
       // }
    }
}
    

       
