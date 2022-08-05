using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PeakInvest.API.Models;
using PeakInvest.API.Services.Interfaces;

namespace PeakInvest.API.Controllers;

[Route("api/[controller]"), ApiController]
public class PeakController : ControllerBase
{
    private readonly IService _service;
    private readonly IValidator<RegisterDto> _validator;

    public PeakController(IService service, IValidator<RegisterDto> validator)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    [HttpPost]
    public IActionResult Post([FromBody] RegisterDto registerDto)
    {
        var validationResult = _validator.Validate(registerDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = _service.CalculateValue(registerDto.Value, registerDto.Times);
        return Ok(result.ToString("C"));
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var name = _service.GetName(id);

        if (string.IsNullOrEmpty(name)) return NotFound();

        return Ok(name);
    }
}