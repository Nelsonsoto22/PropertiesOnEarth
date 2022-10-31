using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertiesOnEarthAPI.DataAccess;
using PropertiesOnEarthAPI.Models;
using PropertiesOnEarthAPI.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace PropertiesOnEarthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private PropertiesOnEarthDBContext _dbContext;
        private EncryptionHelper encryptionHelper;
        public UserController(IConfiguration config, PropertiesOnEarthDBContext dbContext)
        {
            _config= config;
            _dbContext = dbContext;
            encryptionHelper = new EncryptionHelper();
        }
        
        [HttpPost("[action]")]
        public IActionResult Register([FromBody]User user)
        {
            var userExists = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if(userExists != null)
            {
                return BadRequest("There is a User with this email");
            }
            else 
            {
                string pepper = _config.GetSection("PasswordPepper").ToString();
                user.PasswordSalt = encryptionHelper.CreateSalt();
                user.Password = encryptionHelper.HashPassword(user.Password, user.PasswordSalt, pepper);
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }

        }

        [HttpPost("[action]")]
        public IActionResult Login(UserCredentials user)
        {
            //Validating User
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if(currentUser == null)
            {
                return NotFound("User not found");
            }
            else 
            {
                string pepper = _config.GetSection("PasswordPepper").ToString();
                var validPassword = encryptionHelper.VerifyHash(user.Password, currentUser.Password, currentUser.PasswordSalt, pepper);
                if(!validPassword)
                {
                    return BadRequest("The password is not valid");
                }
                else
                {
                    //Generating JWT
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Email , user.Email)
                    };

                    var token = new JwtSecurityToken(
                        issuer: _config["JWT:Issuer"],
                        audience: _config["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: credentials);
                    var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(jwt);
                }
            }
        }

        public IActionResult Get()
        {
            
            return Ok(_dbContext.Users);
        }

    }
}