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

        //Create Work Out
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

        //GET All Work Outs
        [HttpGet]
        public async Task<IActionResult> GetWorkOuts()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetWorkOuts();
            var response = _mapper.Map<IEnumerable<WorkOutListItemResponse>>(dto);

            return Ok(response);
        }

        //GET Work Out By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkOutById (int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetWorkOutById(id);
            var response = _mapper.Map<WorkOutListItemResponse>(dto);

            return Ok(response);
        }

        //PUT Update Work Out

        //DELETE Work Out Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOut(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteWorkOut(id))
                return StatusCode(207);

            throw new Exception();
        }

    }
}