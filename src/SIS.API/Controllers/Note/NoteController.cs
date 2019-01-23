using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Note;
using RedStarter.Business.DataContract.Note;

namespace RedStarter.API.Controllers.Note
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INoteManager _manager;

        public NoteController(IMapper mapper, INoteManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")] //<--- Explained in Video 11.
        public async Task<IActionResult> PostNote(NoteCreateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);


            var dto = _mapper.Map<NoteCreateDTO>(request);
            dto.DateCreated = DateTime.Now;
            dto.OwnerId = identityClaimNum;

            if (await _manager.CreateNote(dto))
                return StatusCode(201);

            throw new Exception();
        }

           //TODO 1: Start out just stubbing this out like below. Create the NoteImageRequest class.
        [HttpPost("UploadNoteImage")]
        public async Task<IActionResult> UploadNoteImage([FromForm]NoteImageRequest image)
        {
            //TODO 2: Test in Postman and set a breakpoint at this spot when you write it.

            //TODO 3: You'll need to create the NoteImageDTO 
            var dto = _mapper.Map<NoteImageDTO>(image);

            //TODO 5: Add an UploadFooImage method to the manager. Add the method to the interface for the manager. 
            var success = await _manager.UploadeNoteImage(dto);

            return Ok(); //TODO: Make StatusCode 201?
        }
    }
}