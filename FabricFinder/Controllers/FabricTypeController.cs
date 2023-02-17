using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;
using FabricFinder.Models;
using FabricFinder.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FabricFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricTypeController : ControllerBase
    {
        private readonly IFabricTypeRepository _fabricTypeRepository;
        public FabricTypeController(IFabricTypeRepository fabricTypeRepository)
        {
            _fabricTypeRepository = fabricTypeRepository;

        }
        // GET: api/<FabricTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fabricTypeRepository.GetAll());
        }

        // GET api/<FabricTypeController>/5
        //[HttpGet("{id}")]
       // public string Get(int id)
       // {
          //  return "value";
       // }

        
    }
}
