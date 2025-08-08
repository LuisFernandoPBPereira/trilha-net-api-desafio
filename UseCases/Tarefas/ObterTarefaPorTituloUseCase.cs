using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class ObterTarefaPorTituloUseCase
{
    private readonly OrganizadorContext _dbContext;

    public ObterTarefaPorTituloUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// </summary>
    /// <param name="titulo"></param>
    /// <returns>Retorna uma lista de Tarefa</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<List<Tarefa>> Executar(string titulo)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentNullException(nameof(titulo), "Título da tarefa é inválido");

            var tarefas = await _dbContext.Tarefas.Where(x => x.Titulo.ToUpper().Contains(titulo.ToUpper())).ToListAsync();

            return tarefas;
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
