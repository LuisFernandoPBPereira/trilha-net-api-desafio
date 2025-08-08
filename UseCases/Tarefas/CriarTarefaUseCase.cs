using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Utils;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class CriarTarefaUseCase
{
    private readonly OrganizadorContext _dbContext;

    public CriarTarefaUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// </summary>
    /// <param name="tarefa"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task Executar(Tarefa tarefa)
    {
        try
        {
            ValidarTarefa.Validar(tarefa);

            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
        }
        catch (ArgumentNullException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
