using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class ObterTarefasUseCase
{
    private readonly OrganizadorContext _dbContext;

    public ObterTarefasUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// </summary>
    /// <returns>Retorna uma lista de Tarefa</returns>
    public async Task<List<Tarefa>> Executar()
    {
        try
        {
            return await _dbContext.Tarefas.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
