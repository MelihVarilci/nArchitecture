using Application.Features.OperationClaims.Commands.CreateOrEditOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditOperationClaimCommand createOrEditOperationClaimCommand)
        {
            CreateOrEditOperationClaimDto result = await Mediator.Send(createOrEditOperationClaimCommand);

            if (createOrEditOperationClaimCommand.Id == null || createOrEditOperationClaimCommand.Id == 0)
            {
                return Ok(result);
            }

            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeleteOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListOperationClaimQuery getListOperationClaimQuery)
        {
            OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }
    }
}