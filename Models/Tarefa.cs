namespace Argos.Models;

public class Tarefa
{
    // O que precisa ser feito 
    public string Descricao { get; set; } = string.Empty;

    // Se já foi feito ou não
    public bool Concluida { get; set; } = false;
}