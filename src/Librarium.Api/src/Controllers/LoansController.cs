using Error_definitions;
using Librarium.Services.application_interfaces;
using Microsoft.AspNetCore.Mvc;
using models.api_models;

namespace Librarium.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController(ILoansService loansService) : ControllerBase
{
  
    [HttpPost]
    public async Task<IActionResult> CreateLoan([FromBody] CreateLoanRequest request)
    {
        var response = await  loansService.CreateLoan(request);
        if (!response.Created)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }


    [HttpGet("{memberId}")]
    public async Task<IActionResult> GetLoansByMember(Guid memberId)
    {
        try
        {
            var response = await loansService.GetLoansByMember(memberId);
            return Ok(response);
        }
        catch (LoanInvalid ex)
        {
            return  NotFound(new LoanError(LoanError.Codes.LoanNotFound, ex.Message));
        }

    }
}


