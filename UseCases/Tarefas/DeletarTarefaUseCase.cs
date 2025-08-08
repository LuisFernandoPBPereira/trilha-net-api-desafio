using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Exceptions;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class DeletarTarefaUseCase
{
    private readonly OrganizadorContext _dbContext;

    public DeletarTarefaUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tarefaId"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="NotFoundException"></exception>
    public async Task Executar(int tarefaId)
    {
        try
        {
            if (tarefaId < 1) throw new ArgumentException("ID da tarefa é inválido", nameof(tarefaId));

            var tarefa = await _dbContext.Tarefas.Where(x => x.Id == tarefaId).FirstOrDefaultAsync();

            if (tarefa is null) throw new NotFoundException("Tarefa não encontrada");

            _dbContext.Tarefas.Remove(tarefa);
            await _dbContext.SaveChangesAsync();
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
