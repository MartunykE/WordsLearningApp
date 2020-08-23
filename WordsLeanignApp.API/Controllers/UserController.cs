using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WordsLeanignApp.API.Heplers;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;

namespace WordsLeanignApp.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        IWordsService wordsService;
        //AppSettings appSettings;
        public UserController(IUserService userService, IWordsService wordsService/*, AppSettings appSettings*/)
        {
            this.wordsService = wordsService;
            //this.appSettings = appSettings;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult RegisterUser(UserDTO userDTO)
        {
            try
            {
                userService.CreateUser(userDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")] //TODO: think about model
        public IActionResult AuthenticateUser(UserLogin userLogin)
        {
            var userDTO = userService.Authenticate(userLogin.Username, userLogin.Password);
            if (userDTO == null)
            {
                return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Words Secret SecretSecretSecretSecretSecretSecretSecretSecret");
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userDTO.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = userDTO.Id,
                ChatId = userDTO.ChatId,
                Name = userDTO.Username,
                Token = tokenString
            });
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok();
        }
    }
}