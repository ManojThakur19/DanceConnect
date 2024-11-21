using DanceConnect.Server.Dtos;
using DanceConnect.Server.Entities;
using DanceConnect.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DanceConnect.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;

        public UserController(IUserService userService, IWebHostEnvironment environment)
        {
            _userService = userService;
            _environment = environment;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);

            if (string.IsNullOrEmpty(userId.ToString()))
            {
                return Unauthorized("CustomerId claim is missing.");
            }
            var allHeaders = HttpContext.Request.Headers;
            var authHeader = HttpContext.Request.Headers.Authorization;
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost(Name = "Save User")]
        //[Authorize]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddUser([FromForm] UserDto userDto)
        {
            try
            {
                //var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);
                var userId = 1;

                if (string.IsNullOrEmpty(userId.ToString()))
                {
                    return Unauthorized("CustomerId claim is missing.");
                }

                string profilePicturePath = null;
                string identityDocumentPath = null;
                if (userDto.ProfilePic != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(userDto.ProfilePic.FileName);
                    profilePicturePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(profilePicturePath, FileMode.Create))
                    {
                        await userDto.ProfilePic.CopyToAsync(fileStream);
                    }
                }

                if (userDto.IdentityDocument != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(userDto.IdentityDocument.FileName);
                    identityDocumentPath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(identityDocumentPath, FileMode.Create))
                    {
                        await userDto.IdentityDocument.CopyToAsync(fileStream);
                    }
                }

                var user = new User
                {
                    Name = userDto.Name,
                    Gender = userDto.Gender,
                    Phone = userDto.Phone,
                    Dob = userDto.Dob,
                    ProfilePic = profilePicturePath,
                    IdentityDocument = identityDocumentPath,
                    Street = userDto.Street,
                    City = userDto.City,
                    Province = userDto.Province,
                    PostalCode = userDto.PostalCode,
                    Id = userId
                };

                var createdUser = await _userService.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
