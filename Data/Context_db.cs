using Adm_Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Adm_Agenda.Data
{
    public class Context_db : DbContext
    {
        public Context_db(DbContextOptions<Context_db> options) : base(options) { }

        public DbSet<mdEndereco> DbSetEndereco { get; set; }
        public DbSet<mdContatos> DbSetContatos { get; set; }
        public DbSet<mdTipoCompromisso> DbSetTipoCompromisso { get; set; }
        public DbSet<mdAgenda> DbSetAgenda { get; set; }
        public DbSet<Adm_Agenda.Models.mdContatos> Contato { get; set; }
        public DbSet<Adm_Agenda.Models.mdTipoCompromisso> TipoCompromisso { get; set; }
        public DbSet<Adm_Agenda.Models.mdAgenda> Agenda { get; set; }
    }
}
