using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertiesOnEarthAPI.DataAccess;

namespace PropertiesOnEarthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        PropertiesOnEarthDBContext _dbContext;
        public CategoryController(PropertiesOnEarthDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_dbContext.Categories);
        }
    }
}