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
    }
}