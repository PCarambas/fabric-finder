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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FabricFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatternController : ControllerBase
    {
        private IPatternRepository _patternRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public PatternController(IPatternRepository patternRepository, IUserProfileRepository userProfileRepository)
        {
            _patternRepository = patternRepository;
            _userProfileRepository = userProfileRepository;

        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_patternRepository.GetAll());
        }




        [HttpPut("{id}")]
        public IActionResult Put(int id, Pattern pattern)
        {
            if (id != pattern.Id)
            {
                return BadRequest();
            }

            _patternRepository.Update(pattern);
            return NoContent();
        }



        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var pattern = _patternRepository.GetPatternById(id);
            if (pattern == null)
            {
                return NotFound();
            }
            return Ok(pattern);
        }




        //[Authorize]
        [HttpPost]
        public IActionResult Post(Pattern pattern)
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userProfile = _userProfileRepository.GetByFirebaseUserId(firebaseUserId);


            pattern.UserId = userProfile.Id;
            _patternRepository.Add(pattern);
            return CreatedAtAction("Get", new { id = pattern.Id }, pattern);

        }
        [Authorize]
        [HttpGet("myPatterns")]
        public IActionResult MyPatterns()
        {
            var currentUserProfile = GetCurrentUserProfile();
            var pattern = _patternRepository.GetByUserId(currentUserProfile.Id);
            if (pattern == null)
            {
                return NotFound();
            }
            return Ok(pattern);

        }

        
       

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _patternRepository.Delete(id);
            return NoContent();

        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
