using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adm_Agenda.Models
{
    [Table("tb_Agenda")]
    public class mdAgenda
    {
        [Key]
        [Required]
        public int IdAgenda { get; set; }
        
        [Display(Name = "Contato")]
        public int idContato { get; set; }

        [Display(Name = "Tipo de Compromisso")]
        public int idTipo { get; set; }  

        public DateOnly dtCompromisso { get; set; }

    }
}
