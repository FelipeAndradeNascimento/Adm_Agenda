using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adm_Agenda.Models
{
    [Table("tb_Endereco")]
    public class mdEndereco
    {
        [Key]
        [Required]
        public int IdEndereco { get; set; }

        [Display(Name = "Rua/Avenida:")]
        public string? Rua { get; set; }

        [Display(Name = "Bairro:")]
        public string? Bairro { get; set; }

        [Display(Name = "Cidade:")]
        public string? Cidade { get; set; }

        [Display(Name = "Uf:")]
        public string? Uf { get; set; }

        [Display(Name = "Ibge:")]
        public string? Ibge { get; set; }
        
        [Display(Name = "Cep:")]
        public string? Cep { get; set; }
    }
}