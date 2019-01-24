using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkOut.API.DataContract.WorkOut;
using WorkOut.Business.DataContract.WorkOut.DTOs;
using WorkOut.Business.DataContract.WorkOut.Interfacees;

namespace WorkOut.API.Controllers.WorkOut
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOutController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkOutManager _manager;

        public WorkOutController(IMapper mapper, IWorkOutManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> PostWorkOut(WorkOutCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<WorkOutCreateDTO>(request);
            dto.OwnerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (await _manager.CreateWorkOut(dto))
                return StatusCode(201);

            throw new Exception();
        }
    }
}