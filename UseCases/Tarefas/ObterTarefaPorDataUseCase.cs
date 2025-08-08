using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class ObterTarefaPorDataUseCase
{
    private readonly OrganizadorContext _dbContext;

    public ObterTarefaPorDataUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// </summary>
    /// <param name="data"></param>
    /// <returns>Retorna uma lista de Tarefa</returns>
    public async Task<List<Tarefa>> Executar(DateTime data)
    {
        try
        {
            var tarefas = await _dbContext.Tarefas.Where(x => x.Data.Date == data.Date).ToListAsync();

            return tarefas;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
