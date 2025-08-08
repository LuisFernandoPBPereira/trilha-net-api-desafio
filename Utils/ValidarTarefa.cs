using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Utils;

public static class ValidarTarefa
{
    /// <summary>
    /// Este método valida as propriedades da model Tarefa
    /// </summary>
    /// <param name="tarefa"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void Validar(Tarefa tarefa)
    {
        if (tarefa is null) throw new ArgumentNullException(nameof(tarefa), "Não há tarefa para criar");

        if (string.IsNullOrWhiteSpace(tarefa.Titulo)) throw new ArgumentNullException(nameof(tarefa.Titulo), "Não há título");

        if (tarefa.Data.Date < DateTime.Now.Date) throw new ArgumentNullException(nameof(tarefa.Data), "Data está no passado");
    }
}
