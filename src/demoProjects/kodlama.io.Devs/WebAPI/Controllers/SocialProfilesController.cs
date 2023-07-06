using Application.Features.SocialProfiles.Commands.CreateOrEditSocialProfile;
using Application.Features.SocialProfiles.Commands.DeleteSocialProfile;
using Application.Features.SocialProfiles.Dtos;
using Application.Features.SocialProfiles.Models;
using Application.Features.SocialProfiles.Queries.GetByIdSocialProfile;
using Application.Features.SocialProfiles.Queries.GetListSocialProfile;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialProfilesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditSocialProfileCommand createOrEditSocialProfileCommand)
        {
            CreateOrEditSocialProfileDto result = await Mediator.Send(createOrEditSocialProfileCommand);

            if (createOrEditSocialProfileCommand.Id == null || createOrEditSocialProfileCommand.Id == 0)
            {
                return Ok(result);
            }

            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialProfileCommand deleteSocialProfileCommand)
        {
            DeleteSocialProfileDto result = await Mediator.Send(deleteSocialProfileCommand);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialProfileQuery getListSocialProfileQuery = new() { PageRequest = pageRequest };
            SocialProfileListModel result = await Mediator.Send(getListSocialProfileQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialProfileQuery getByIdSocialProfileQuery)
        {
            SocialProfileGetByIdDto socialProfileGetByIdDto = await Mediator.Send(getByIdSocialProfileQuery);
            return Ok(socialProfileGetByIdDto);
        }
    }
}