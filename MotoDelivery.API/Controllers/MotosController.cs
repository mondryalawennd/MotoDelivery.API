using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.API.Features.Locacao.CreateLocacao;
using MotoDelivery.API.Features.Locacao.GetLocacao;
using MotoDelivery.API.Features.Motos;
using MotoDelivery.API.Features.Motos.CreateMoto;
using MotoDelivery.API.Features.Motos.DeletarMoto;
using MotoDelivery.API.Features.Motos.GetMoto;
using MotoDelivery.API.Features.Motos.GetMotos;
using MotoDelivery.API.Features.Motos.UpdateMotos;
using MotoDelivery.API.Features.Motos.UpdatePlacaMoto;
using MotoDelivery.Application.Moto.CreateMoto;
using MotoDelivery.Application.Moto.DeleteMotos;
using MotoDelivery.Application.Moto.GetMoto;
using MotoDelivery.Application.Moto.GetMotos;
using MotoDelivery.Application.Moto.UpdateMoto;
using MotoDelivery.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using static MassTransit.ValidationResultExtensions;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MotosController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar uma nova moto")]
        [ProducesResponseType(typeof(CreateMotoResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateMoto([FromBody] CreateMotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateMotoRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                
                var command = _mapper.Map<CreateMotoCommand>(request);

                // Envia o Command para o Handler via Mediator
                var result = await _mediator.Send(command, cancellationToken);
                var response = _mapper.Map<CreateMotoResponse>(result);

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao cadastrar a moto.", details = ex.Message });
            }
        }

        [HttpGet()]
        [SwaggerOperation(Summary = "Consultar motos existentes")]
        [ProducesResponseType(typeof(CreateMotoResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMotos(CancellationToken cancellationToken)
        {

            try
            {
                var command = new GetMotosCommand();
                var result = await _mediator.Send(command, cancellationToken);

                var response = _mapper.Map<List<GetMotosResponse>>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao listar motos", details = ex.Message });
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Modificar a placa de uma moto")]
        [ProducesResponseType(typeof(CreateMotoResult), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePlaca([FromBody]  UpdatePlacaMotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UpdatePlacaMotoRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);


                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

                var command = _mapper.Map<UpdatePlacaMotoCommand>(request);
                
                var result = await _mediator.Send(command, cancellationToken);
                var response = _mapper.Map<UpdatePlacaMotoResponse>(result);

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao alterar a placa moto", details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar uma moto por id")]
        [ProducesResponseType(typeof(CreateMotoResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            try
            {

                var command = new GetMotoCommand { Identificador = id };

                // Envia o Command para o Handler via Mediator
                var result = await _mediator.Send(command, cancellationToken);
                var response = _mapper.Map<GetMotoResponse>(result);

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao consultar a moto.", details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover uma moto")]
        [ProducesResponseType(typeof(DeletarMotoResponse), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteMoto(string id, CancellationToken cancellationToken)
        {
            try
            {
                var request = new DeletarMotoRequest { Identificador = id };
                var validator = new DeletarMotoRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

                var command = _mapper.Map<DeleteMotoCommand>(request);

                var result = await _mediator.Send(command, cancellationToken);
                var response = _mapper.Map<DeletarMotoResponse>(result);

                if (!response.Sucesso)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao deletar moto", details = ex.Message });
            }
        }
    }
}
