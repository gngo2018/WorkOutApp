using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkOut.API.DataContract.Exercise;
using WorkOut.Business.DataContract.Exercise;
using WorkOut.Business.DataContract.Exercise.DTOs;

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

        //Create Exercise
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

        //Get All Exercises
        [HttpGet]
        public async Task<IActionResult> GetExercises()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetExercises();
            var response = _mapper.Map<IEnumerable<ExerciseListItemResponse>>(dto);

            return Ok(response);
        }

        //Get Exercise By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetExerciseById(id);
            var response = _mapper.Map<ExerciseListItemResponse>(dto);

            return Ok(response);
        }

        //PUT Update Exercise
        [HttpPut]
        public async Task<IActionResult> UpdateExercise(ExerciseUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<ExerciseUpdateDTO>(request);
            if (await _manager.UpdateExercise(dto))
                return StatusCode(202);

            throw new Exception();
        }

        //DELETE Delete Exercise
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteExercise(id))
                return StatusCode(207);

            throw new Exception();
        }
    }
}