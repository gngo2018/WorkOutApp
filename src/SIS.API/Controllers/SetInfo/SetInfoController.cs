﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkOut.API.DataContract.SetInfo;
using WorkOut.Business.DataContract.SetInfo.DTOs;
using WorkOut.Business.DataContract.SetInfo.Interfaces;

namespace WorkOut.API.Controllers.MealPrep
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetInfoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISetInfoManager _manager;

        public SetInfoController(IMapper mapper, ISetInfoManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        //Create Set
        [HttpPost]
        public async Task<IActionResult> PostSetInfo(SetInfoCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<SetInfoCreateDTO>(request);
            dto.OwnerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (await _manager.CreateSetInfo(dto))
                return StatusCode(201);

            throw new Exception();
        }

        //GET All Sets
        [HttpGet]
        public async Task<IActionResult> GetAllSetInfo()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetAllSetInfo();
            var response = _mapper.Map<IEnumerable<SetInfoListItemResponse>>(dto);

            return Ok(response);
        }

        //GET Set By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSetInfoById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetSetInfoById(id);
            var response = _mapper.Map<SetInfoListItemResponse>(dto);

            return Ok(response);
        }

        //PUT Update Set Info
        [HttpPut]
        public async Task<IActionResult> UpdateSetInfo(SetInfoUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<SetInfoUpdateDTO>(request);

            if (await _manager.UpdateSetInfo(dto))
                return StatusCode(202);

            throw new Exception();
        }

        //DELETE Set Info Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetInfo(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteSetInfo(id))
                return StatusCode(207);

            throw new Exception();
        }
    }
}