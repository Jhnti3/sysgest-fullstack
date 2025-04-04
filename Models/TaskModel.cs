using System;
using System.ComponentModel.DataAnnotations;

namespace SysGestFullstack.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        public string Status { get; set; } // Exemplo: "Pendente", "Em andamento", "Concluída"

        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}