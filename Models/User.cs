using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SysGestFullstack.Data;

namespace SysGestFullstack.Models
{
    public class User : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.", MinimumLength = 6)]
        public string Password { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true; // Propriedade adicionada para indicar se o usuário está ativo

        // Implementação da validação customizada
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

            // Verifica se já existe um usuário com o mesmo email (excluindo o próprio ID em caso de edição)
            if (context.Users.Any(u => u.Email == Email && u.Id != Id))
            {
                yield return new ValidationResult("Este email já está em uso.", new[] { "Email" });
            }
        }

    }
}


