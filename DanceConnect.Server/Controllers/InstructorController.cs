using DanceConnect.Server.Dtos;
using DanceConnect.Server.Entities;
using DanceConnect.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceConnect.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IWebHostEnvironment _environment;

        public InstructorController(IInstructorService instructorService, IWebHostEnvironment environment)
        {
            _instructorService = instructorService;
            _environment = environment;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _instructorService.GetAllInstructorsAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _instructorService.GetInstructorByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost(Name = "Save Instructor")]
        [Authorize]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddInstructor([FromForm] InstructorDto instructorDto)
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
                if (instructorDto.ProfilePic != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(instructorDto.ProfilePic.FileName);
                    profilePicturePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(profilePicturePath, FileMode.Create))
                    {
                        await instructorDto.ProfilePic.CopyToAsync(fileStream);
                    }
                }

                if (instructorDto.IdentityDocument != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(instructorDto.IdentityDocument.FileName);
                    identityDocumentPath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(identityDocumentPath, FileMode.Create))
                    {
                        await instructorDto.IdentityDocument.CopyToAsync(fileStream);
                    }
                }

                var instructor = new Instructor
                {
                    Name = instructorDto.Name,
                    Gender = instructorDto.Gender,
                    Phone = instructorDto.Phone,
                    Dob = instructorDto.Dob,
                    ProfilePic = profilePicturePath,
                    IdentityDocument = identityDocumentPath,
                    Street = instructorDto.Street,
                    City = instructorDto.City,
                    Province = instructorDto.Province,
                    PostalCode = instructorDto.PostalCode,
                    AppUserId = userId
                };

                var createdUser = await _instructorService.AddInstructorAsync(instructor);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.InstructorId }, createdUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
