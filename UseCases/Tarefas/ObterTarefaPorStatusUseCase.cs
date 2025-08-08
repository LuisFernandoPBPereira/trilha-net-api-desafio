using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class ObterTarefaPorStatusUseCase
{
    private readonly OrganizadorContext _dbContext;

    public ObterTarefaPorStatusUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// </summary>
    /// <param name="statusTarefa"></param>
    /// <returns>Retorna uma lista de Tarefa</returns>
    public async Task<List<Tarefa>> Executar(EnumStatusTarefa statusTarefa)
    {
        try
        {
            return await _dbContext.Tarefas.Where(x => x.Status == statusTarefa).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
