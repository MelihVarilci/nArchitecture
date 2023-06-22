using Application.Features.Technologies.Commands.CreateOrEditTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditTechnologyCommand createOrEditTechnologyCommand)
        {
            CreateOrEditTechnologyDto result = await Mediator.Send(createOrEditTechnologyCommand);

            if (createOrEditTechnologyCommand.Id == null || createOrEditTechnologyCommand.Id == 0)
            {
                return Ok(result);
            }

            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeleteTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            TechnologyGetByIdDto technologyGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(technologyGetByIdDto);
        }
    }
}