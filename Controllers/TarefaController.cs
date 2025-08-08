using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Exceptions;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.UseCases.Tarefas;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private readonly ObterTarefaPorIdUseCase _obterTarefaPorId;
        private readonly ObterTarefasUseCase _obterTarefas;
        private readonly ObterTarefaPorDataUseCase _obterTarefaPorData;
        private readonly ObterTarefaPorStatusUseCase _obterTarefaPorStatus;
        private readonly ObterTarefaPorTituloUseCase _obterTarefaPorTitulo;
        private readonly CriarTarefaUseCase _criarTarefa;
        private readonly AtualizarTarefaUseCase _atualizarTarefa;
        private readonly DeletarTarefaUseCase _deletarTarefa;


        public TarefaController(OrganizadorContext context,
                                ObterTarefaPorIdUseCase obterTarefaPorId,
                                ObterTarefasUseCase obterTarefas,
                                ObterTarefaPorDataUseCase obterTarefaPorData,
                                ObterTarefaPorStatusUseCase obterTarefaPorStatus,
                                ObterTarefaPorTituloUseCase obterTarefaPorTitulo,
                                CriarTarefaUseCase criarTarefa,
                                AtualizarTarefaUseCase atualizarTarefa,
                                DeletarTarefaUseCase deletarTarefa)
        {
            _context = context;
            _obterTarefaPorId = obterTarefaPorId;
            _obterTarefas = obterTarefas;
            _obterTarefaPorData = obterTarefaPorData;
            _obterTarefaPorStatus = obterTarefaPorStatus;
            _obterTarefaPorTitulo = obterTarefaPorTitulo;
            _criarTarefa = criarTarefa;
            _atualizarTarefa = atualizarTarefa;
            _deletarTarefa = deletarTarefa;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var tarefa = await _obterTarefaPorId.Executar(id);
            
                return Ok(tarefa);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var tarefas = await _obterTarefas.Executar();

                return Ok(tarefas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<IActionResult> ObterPorTitulo(string titulo)
        {

            try
            {
                var tarefas = await _obterTarefaPorTitulo.Executar(titulo);

                return Ok(tarefas);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("ObterPorData")]
        public async Task<IActionResult> ObterPorData(DateTime data)
        {
            try
            {
                var tarefas = await _obterTarefaPorData.Executar(data);

                return Ok(tarefas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("ObterPorStatus")]
        public async Task<IActionResult> ObterPorStatus(EnumStatusTarefa status)
        {
            try
            {
                var tarefas = await _obterTarefaPorStatus.Executar(status);

                return Ok(tarefas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Tarefa tarefa)
        {
            try
            {
                await _criarTarefa.Executar(tarefa);

                return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Tarefa tarefa)
        {
            try
            {
                await _atualizarTarefa.Executar(id, tarefa);

                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _deletarTarefa.Executar(id);

                return NoContent();
            }
            catch(NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
