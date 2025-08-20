using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.API.Features.Locacao.CreateLocacao;
using MotoDelivery.API.Features.Locacao.GetDevolucaoLocacao;
using MotoDelivery.API.Features.Locacao.GetLocacao;
using MotoDelivery.Application.Locacao.CreateLocacao;
using MotoDelivery.Application.Locacao.GetDevolucaoLocacao;
using MotoDelivery.Application.Locacao.GetLocacao;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocacaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IValidator<CreateLocacaoCommand> _validator;

        public LocacaoController(IMediator mediator, IMapper mapper, IValidator<CreateLocacaoCommand> validator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _validator = validator;
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Alugar uma moto")]
        [ProducesResponseType(typeof(CreateLocacaoResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateLocacao([FromBody] CreateLocacaoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Convert.ToDateTime(request.DataInicio);
                Convert.ToDateTime(request.DataTermino);
                Convert.ToDateTime(request.DataPrevisaoTermino);
                request.DataCriacao = DateTime.UtcNow;

                var validator = new CreateLocacaoRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }
                                
                var command = _mapper.Map<CreateLocacaoCommand>(request);
                var result = await _mediator.Send(command, cancellationToken);
                var response = _mapper.Map<CreateLocacaoResponse>(result);

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao cadastrar a locação.", details = ex.Message });
            }
        }

        // GET: api/motos/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar locação por ID")]
        [ProducesResponseType(typeof(GetLocacaoResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetLocacaoResponse>> GetById(string id, CancellationToken cancellationToken)
        {
            try
            {
                
                var result = await _mediator.Send(new GetLocacaoCommand { LocacaoId = id }, cancellationToken);

                if (result == null)
                    return NotFound(new { message = "Locação não encontrada" });

                var response = _mapper.Map<GetLocacaoResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar locação", details = ex.Message });
            }
        }


        [HttpPost("valor-devolucao")]
        [SwaggerOperation(Summary = "Informar data de devolução e calcular valor")]
        [ProducesResponseType(typeof(GetLocacaoResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetLocacaoResponse>> GetValorByDevolucao([FromBody]GetDevolucaoRequest request, CancellationToken cancellationToken)
        {
            try
            {
               
                var command = new GetDevolucaoCommand
                {
                    LocacaoId = request.LocacaoId,
                    DataDevolucao = Convert.ToDateTime(request.DataDevolucao)
                };

                var result = await _mediator.Send(command, cancellationToken);

                if (result == null)
                    return NotFound(new { message = "Locação não encontrada" });


                var response = _mapper.Map<GetDevolucaoResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar locação", details = ex.Message });
            }
        }

    }
}
