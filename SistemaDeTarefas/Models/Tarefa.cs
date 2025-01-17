﻿using SistemaDeTarefas.Enuns;

namespace SistemaDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public StatusTarefascs Status { get; set; }

        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }

    }
}
