using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Exceptions;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Utils;

namespace TrilhaApiDesafio.UseCases.Tarefas;

public class AtualizarTarefaUseCase
{
    private readonly OrganizadorContext _dbContext;

    public AtualizarTarefaUseCase(OrganizadorContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// </summary>
    /// <param name="tarefaId"></param>
    /// <param name="tarefa"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="NotFoundException"></exception>
    public async Task Executar(int tarefaId, Tarefa tarefa)
    {
        try
        {
            if (tarefaId < 1) throw new ArgumentException("ID da tarefa inválido", nameof(tarefaId));

            ValidarTarefa.Validar(tarefa);

            var tarefaParaAtualizar = await _dbContext.Tarefas.Where(x => x.Id == tarefaId).FirstOrDefaultAsync();

            if (tarefaParaAtualizar is null) throw new NotFoundException("Tarefa não encontrada");

            tarefaParaAtualizar.Titulo = tarefa.Titulo;
            tarefaParaAtualizar.Descricao = tarefa.Descricao;
            tarefaParaAtualizar.Data = tarefa.Data;
            tarefaParaAtualizar.Status = tarefa.Status;

            _dbContext.Tarefas.Update(tarefaParaAtualizar);

            await _dbContext.SaveChangesAsync();
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
