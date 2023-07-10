using Application.Features.UserOperationClaims.Commands.CreateOrEditUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditUserOperationClaimCommand createOrEditUserOperationClaimCommand)
        {
            CreateOrEditUserOperationClaimDto result = await Mediator.Send(createOrEditUserOperationClaimCommand);

            if (createOrEditUserOperationClaimCommand.Id == null || createOrEditUserOperationClaimCommand.Id == 0)
            {
                return Ok(result);
            }

            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeleteUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(result);
        }
    }
}