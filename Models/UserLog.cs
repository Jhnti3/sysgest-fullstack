using System;

namespace SysGestFullstack.Models
{
    public class UserLog
    {
        public int Id { get; set; }
        public string Action { get; set; } // Criado, Editado, Excluído
        public string UserName { get; set; } // Nome do usuário afetado
        public string UserEmail { get; set; } // E-mail do usuário afetado
        public DateTime Timestamp { get; set; } = DateTime.Now; // Data e hora do log
    }
}

