using Adm_Agenda.Controllers;
using Adm_Agenda.Models;
using Adm_Agenda.Data;

namespace Adm_Agenda.Regras
{
    public class clsDadosEndereco
    {
        private readonly Context_db? DbContext;

        public List<mdEndereco> mdEnderecos = new List<mdEndereco>();


        //     return View(await _context.DbSetEndereco.ToListAsync());
        public List<mdEndereco> retornaEnderecos()
        {
            List<mdEndereco> listaEndereco = this.DbContext.DbSetEndereco.ToList();
            return listaEndereco;
        }

    }
}
