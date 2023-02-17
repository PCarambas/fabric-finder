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
        private IFabricRepository _fabricRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public FabricController(IFabricRepository fabricRepository, IUserProfileRepository userProfileRepository)
        {
            _fabricRepository = fabricRepository;
            _userProfileRepository = userProfileRepository;

        }
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fabricRepository.GetAll());
        }

        [HttpPost("addpatternfabric")]
        public IActionResult AddPatternFabric(PatternFabric patternFabric) 
        {
            var userProfile = GetCurrentUserProfile();
            patternFabric.UserId= userProfile.Id;
            _fabricRepository.AddPatternFabric(patternFabric);
            return NoContent();
        }




        //[Authorize]
        [HttpPost]
        public IActionResult Post(Fabric fabric)
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userProfile = _userProfileRepository.GetByFirebaseUserId(firebaseUserId);


            fabric.UserId = userProfile.Id;
            _fabricRepository.Add(fabric);
            return CreatedAtAction("Get", new { id = fabric.Id }, fabric);



        }
        [Authorize]
        [HttpGet("myFabrics")]
        public IActionResult MyFabrics()
        {
            var currentUserProfile = GetCurrentUserProfile();
            var fabric = _fabricRepository.GetByUserId(currentUserProfile.Id);
            if (fabric == null)
            {
                return NotFound();
            }
            return Ok(fabric);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Fabric fabric)
        {
          if (id != fabric.Id)
          {
             return BadRequest();
         }

         _fabricRepository.Update(fabric);
         return NoContent();
         }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var fabric = _fabricRepository.GetFabricById(id);
            if (fabric == null)
            {
                return NotFound();
            }
            return Ok(fabric);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _fabricRepository.Delete(id);
            return NoContent();
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}



