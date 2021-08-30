﻿using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Districts.Commands.Create;
using CleanArchitecture.Application.Districts.Queries;
using CleanArchitecture.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Authorize]
    public class DistrictsController: BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportDistrictsQuery { CityId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<DistrictDto>>> Create(CreateDistrictCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
