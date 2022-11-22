using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adm_Agenda.Models
{
    [Table("tbContatos")]
    public class mdContatos
    {
        /// <summary>
        /// Identificação única do registro
        /// </summary>
        [Key]
        [Required]
        public int IdContato { get; set; }

        [Required(ErrorMessage = "Favor informar o Nome da Usuário")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o email para contato")]
        public string? Email { get; set; }

        [StringLength(11, ErrorMessage = "Informe o telefone no seguinte formato: 31999999999")]
        public string? Telefone { get; set; }

        [NotMapped]
        [Display(Name = "Endereço")]
        public virtual mdEndereco IdEndereco { get; set; }
    }
}