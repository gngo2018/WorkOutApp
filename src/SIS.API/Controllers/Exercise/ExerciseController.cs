using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkOut.API.DataContract.Exercise;
using WorkOut.Business.DataContract.Exercise;

namespace WorkOut.API.Controllers.Exercise
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExerciseManager _manager;

        public ExerciseController(IMapper mapper, IExerciseManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        //Create Set
        [HttpPost]
        public async Task<IActionResult> PostExercise(ExerciseCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<ExerciseCreateDTO>(request);
            dto.OwnerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (await _manager.CreateExercise(dto))
                return StatusCode(201);

            throw new Exception();
        }
    }
}