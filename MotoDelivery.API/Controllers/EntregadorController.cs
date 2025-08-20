using AutoMapper;
using FluentValidation;
using MassTransit.Transports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.API.Features.Entregador.CreateEntregador;
using MotoDelivery.API.Features.Entregador.UploadCNH;
using MotoDelivery.Application.Entregador.CreateEntregador;
using MotoDelivery.Application.Entregador.UploadCNH;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;

namespace MotoDelivery.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class EntregadorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EntregadorController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar entregador")]
        [ProducesResponseType(typeof(CreateEntregadorResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateEntregador([FromBody] CreateEntregadorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Convert.ToDateTime(request.DataNascimento);
                var validator = new CreateEntregadorRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }


                var command = _mapper.Map<CreateEntregadorCommand>(request);
                var result = await _mediator.Send(command, cancellationToken);
                var response = _mapper.Map<CreateEntregadorResponse>(result);

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao cadastrar o entregador.", details = ex.Message });
            }
        }

        [HttpPost("upload/cnh")]
        [SwaggerOperation(Summary = "Enviar foto da CNH do entregador")]
        [ProducesResponseType(typeof(UploadCNHResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UploadCNH([FromForm] UploadCNHRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var validator = new UploadCNHResquestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

                var command = _mapper.Map<UploadCNHCommand>(request);
                var result = await _mediator.Send(command, cancellationToken);

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao enviar foto da CNH entregador.", details = ex.Message });
            }
            
        }

    }
}
