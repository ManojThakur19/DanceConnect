using DanceConnect.Server.Dtos;
using DanceConnect.Server.Entities;
using DanceConnect.Server.Response.Dtos;
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
        //[Authorize]
        public async Task<IActionResult> GetInstructors()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            var instructorResponses = instructors.Select(x => new InstructorResponseDto()
            {
                Name = x.Name,
                Gender = x.Gender,
                Dob = x.Dob,
                Phone = x.Phone,
                Email = x.AppUser?.Email,
                ProfileStatus = x.ProfileStatus.ToString(),
                ProfilePic = x.ProfilePic,
                IdentityDocument = x.IdentityDocument,
                ShortIntroVideo = x.IntroVideo,
                Street = x.Street,
                City = x.City,
                PostalCode = x.PostalCode,
                Province = x.Province,
            }).ToList();
            return Ok(instructorResponses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(int id)
        {
            var user = await _instructorService.GetInstructorByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost(Name = "Save Instructor")]
        //[Authorize]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddInstructor([FromForm] InstructorDto instructorDto)
        {
            try
            {
                //var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);
                var userId = 2;

                if (string.IsNullOrEmpty(userId.ToString()))
                {
                    return Unauthorized("CustomerId claim is missing.");
                }

                string profilePicturePath = null;
                string identityDocumentPath = null;
                string shortIntroVideoPath = null;

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
                
                if (instructorDto.ShortIntroVideo != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, @"uploads/videos");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(instructorDto.ShortIntroVideo.FileName);
                    shortIntroVideoPath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(shortIntroVideoPath, FileMode.Create))
                    {
                        await instructorDto.ShortIntroVideo.CopyToAsync(fileStream);
                    }
                }

                var instructor = new Instructor
                {
                    Name = instructorDto.Name,
                    Gender = instructorDto.Gender,
                    Phone = instructorDto.Phone,
                    Dob = instructorDto.Dob,
                    HourlyRate = instructorDto.HourlyRate,
                    ProfileStatus = Enums.ProfileStatus.ProfileCompleted,
                    ProfilePic = profilePicturePath,
                    IdentityDocument = identityDocumentPath,
                    IntroVideo = shortIntroVideoPath,
                    Street = instructorDto.Street,
                    City = instructorDto.City,
                    Province = instructorDto.Province,
                    PostalCode = instructorDto.PostalCode,
                    AppUserId = userId
                };

                var createdInstructor = await _instructorService.AddInstructorAsync(instructor);
                return CreatedAtAction(nameof(GetInstructorById), new { id = createdInstructor.InstructorId }, createdInstructor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
