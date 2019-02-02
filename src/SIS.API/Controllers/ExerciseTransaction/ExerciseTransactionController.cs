using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkOut.API.DataContract.ExerciseTransaction;
using WorkOut.Business.DataContract.ExerciseTransaction.DTOs;
using WorkOut.Business.DataContract.ExerciseTransaction;

namespace WorkOut.API.Controllers.ExerciseTransaction
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseTransactionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExerciseTransactionManager _manager;

        public ExerciseTransactionController(IMapper mapper, IExerciseTransactionManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        //Create Exercise Transaction
        [HttpPost]
        public async Task<IActionResult> PostExerciseTransaction(ExerciseTransactionCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<ExerciseTransactionCreateDTO>(request);
            dto.OwnerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (await _manager.CreateExerciseTransaction(dto))
                return StatusCode(201);

            throw new Exception();
        }
    }
}