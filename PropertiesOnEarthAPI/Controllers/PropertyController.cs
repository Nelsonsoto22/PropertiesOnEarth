using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertiesOnEarthAPI.DataAccess;
using PropertiesOnEarthAPI.Models;

namespace PropertiesOnEarthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private PropertiesOnEarthDBContext _dbContext;

        public PropertyController(PropertiesOnEarthDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("List")]
        [Authorize]
        public IActionResult GetProperties(int categoryId)
        {
            var propertiesResult = _dbContext.Properties.Where(c => c.CategoryId==categoryId);
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

        [HttpGet("Detail")]
        [Authorize]
        public IActionResult GetDetail(int propertyId)
        {
            var propertyResult = _dbContext.Properties.Find(propertyId);
            if (propertyResult == null)
            {
                return NotFound();
            }
            return Ok(propertyResult);
        }

        [HttpGet("Trending")]
        [Authorize]
        public IActionResult GetTrending()
        {
            var propertiesResult = _dbContext.Properties.Where(c => c.IsTrending==true);
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }
        
        [HttpGet("SearchAddress")]
        [Authorize]
        public IActionResult GetSearch(string address)
        {
            var propertiesResult = _dbContext.Properties.Where(c => c.Address.Contains(address));
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(Property property)
        {
            if (property == null)
            {
                return NoContent();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
                if (user==null) 
                {
                    return NotFound("Invalid User");
                }
                property.IsTrending = false;
                property.UserId = user.Id;
                _dbContext.Properties.Add(property);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        [HttpPut("{propertyId}")]
        [Authorize]
        public IActionResult Put(int propertyId, [FromBody] Property property)
        {
            if (property == null)
            {
                return NoContent();
            }
            
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user==null) 
            {
                return NotFound("Invalid User");
            }

            var propertyResult = _dbContext.Properties.FirstOrDefault(p=> p.Id==propertyId & p.UserId== user.Id);
            if(propertyResult==null)
            {
                return NotFound("Invalid Property");
            }

            propertyResult.Name = property.Name;
            propertyResult.Detail = property.Detail;
            propertyResult.Price = property.Price;
            propertyResult.Address = property.Address;
            property.IsTrending = false;
            property.UserId = user.Id;

            _dbContext.SaveChanges();
            return Ok("Property updated");
        
        }
        
        [HttpDelete("{propertyId}")]
        [Authorize]
        public IActionResult Delete(int propertyId)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user==null) 
            {
                return NotFound("Invalid User");
            }

            var propertyResult = _dbContext.Properties.FirstOrDefault(p=> p.Id==propertyId & p.UserId== user.Id);
            if(propertyResult==null)
            {
                return NotFound("Invalid Property");
            }

            _dbContext.Properties.Remove(propertyResult);
            _dbContext.SaveChanges();

            return Ok("Property deleted");
        }
    }
}