using System.ComponentModel;

namespace SistemaDeTarefas.Enuns
{
    public enum StatusTarefascs
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
