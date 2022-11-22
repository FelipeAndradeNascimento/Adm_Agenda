using Adm_Agenda.Controllers;
using Adm_Agenda.Models;
using Adm_Agenda.Data;

namespace Adm_Agenda.Regras
{
    public class clsDadosEndereco
    {
        private readonly Context_db? DbContext;

        public List<mdEndereco> mdEnderecos = new List<mdEndereco>();

        public List<mdEndereco> retornaEnderecos()
        {
            List<mdEndereco> listaEndereco = DbContext.DbSetEndereco.ToList();
            return listaEndereco;
        }

    }
}
