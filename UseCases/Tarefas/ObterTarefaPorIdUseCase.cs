using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Exceptions;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class ObterTarefaPorIdUseCase
{
    private readonly OrganizadorContext _dbContext;

    public ObterTarefaPorIdUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// </summary>
    /// <param name="tarefaId"></param>
    /// <returns>Retorna uma Model de Tarefa</returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<Tarefa> Executar(int tarefaId)
    {
        try
        {
            if (tarefaId < 1) throw new ArgumentException("ID inválido", "tarefaId");

            var tarefa = await _dbContext.Tarefas.Where(x => x.Id == tarefaId).FirstOrDefaultAsync();

            if (tarefa is null) throw new NotFoundException("Tarefa não encontrada");

            return tarefa;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
